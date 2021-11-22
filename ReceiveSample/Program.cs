using System;
using System.IO;
using System.Configuration;
using KS.Fiks.IO.Client.Models;
using KS.Fiks.IO.Client;
using ClassLibFIKSIO;
using KS.Fiks.ASiC_E;
using System.Xml.Serialization;

namespace ReceiveSample
{
    class Program
    {
        static void Main(string[] args)
        {

            var fiksIO = new FiksIOCommunication();
            string accountId = ConfigurationManager.AppSettings["accountId"];
            string accountPrivKeyFilename = ConfigurationManager.AppSettings["accountPrivateKeyFilename"];
            string integrasjonId = ConfigurationManager.AppSettings["integrationId"];
            string integrationPassword = ConfigurationManager.AppSettings["integrationPassword"];

            string virksomhetsSertifikat = ConfigurationManager.AppSettings["virksomhetsSertifikat"];
            string issuer = ConfigurationManager.AppSettings["issuer"]; //Issuer is the issuer i.e. the client_id  from DIFI, client_name: nois_test Integrasjon on https://selvbetjening-samarbeid.difi.no/#/ver2/integrations/


            var currFolder = System.IO.Directory.GetCurrentDirectory(); // executing assembly path
            var accountPrivateKeyFilename = Path.Combine(currFolder, accountPrivKeyFilename);

            if (!File.Exists(accountPrivateKeyFilename))
            {
                accountPrivateKeyFilename = Path.Combine(ConfigurationManager.AppSettings["CertificatesFolder"], accountPrivKeyFilename);
            }

              FiksIOClient client = fiksIO.Config(accountId, accountPrivateKeyFilename, integrasjonId, integrationPassword,
               virksomhetsSertifikat, issuer);

            client.NewSubscription(OnReceivedMelding);

            Console.WriteLine("Abonnerer på meldinger på konto " + accountId.ToString() + " ...");
            //Pause til neste
            Console.WriteLine("Trykk en tast for første melding");
            Console.ReadKey();

        }

        static void OnReceivedMelding(object sender, MottattMeldingArgs mottatt)
        {
                        // Process the message
                                    if (mottatt.Melding.MeldingType == "no.ks.fiks.matrikkelfoering.grunnlag.v2")
            {
                Console.WriteLine("Melding " + mottatt.Melding.MeldingId + " " + mottatt.Melding.MeldingType + " mottas...");
                if (mottatt.Melding.HasPayload)
                {

                  //  List<List<string>> errorMessages = new List<List<string>>() { new List<string>(), new List<string>() };
                    IAsicReader reader = new AsiceReader();
                    using (var inputStream = mottatt.Melding.DecryptedStream.Result)
                    using (var asice = reader.Read(inputStream))
                    {
                        foreach (var asiceReadEntry in asice.Entries)
                        {
                            using (var entryStream = asiceReadEntry.OpenStream())
                            {
                                if (asiceReadEntry.FileName.Contains(".xml"))
                                {
                                    XmlSerializer serializer = new XmlSerializer(typeof(Byggesak));

                                    Byggesak sak = (Byggesak)serializer.Deserialize(entryStream);
                                    if (sak.saksnummer != null)
                                    {
                                        Console.WriteLine("Mottatt byggesak med saksnummer " + sak.saksnummer.saksaar.ToString() + "/" + sak.saksnummer.sakssekvensnummer.ToString());
                                    }

                                    string xmlString = new StreamReader(entryStream).ReadToEnd();

                                   // errorMessages = ValidateJsonFile(new StreamReader(entryStream).ReadToEnd(), Path.Combine("schema", "rep.geointegrasjon.no/Matrikkel/foering/v2"));// "no.ks.fiks.politisk.behandling.sendvedtakfrautvalg.v1.schema.json"));
                                }
                                else
                                    Console.WriteLine("Mottatt vedlegg: " + asiceReadEntry.FileName);
                            }
                        }
                    }

                    //if (errorMessages[0].Count == 0)
                    //{
                        var svarmsg2 = mottatt.SvarSender.Svar("no.ks.fiks.matrikkelfoering.grunnlag.v2").Result;
                        Console.WriteLine("Svarmelding " + svarmsg2.MeldingId + " " + svarmsg2.MeldingType + " sendt...");
                        mottatt.SvarSender.Ack(); // Ack message to remove it from the queue
                 //   }
                    //else
                    //{
                    //    Console.WriteLine("Feil i validering av sendvedtakfrautvalg");
                    //    var errorMessage = mottatt.SvarSender.Svar("no.ks.fiks.kvittering.ugyldigforespørsel.v1", String.Join("\n ", errorMessages[0]), "feil.txt").Result;

                    //    Console.WriteLine(String.Join("\n ", errorMessages[0]));

                    //    mottatt.SvarSender.Ack(); // Ack message to remove it from the queue
                    //}

                }
                else
                {
                    var svarmsg = mottatt.SvarSender.Svar("no.ks.fiks.kvittering.ugyldigforespørsel.v1", "Meldingen mangler innhold", "feil.txt").Result;
                    Console.WriteLine("Svarmelding " + svarmsg.MeldingId + " " + svarmsg.MeldingType + " Meldingen mangler innhold");

                    mottatt.SvarSender.Ack(); // Ack message to remove it from the queue

                }
              

            }
            else
            {
                Console.WriteLine("Ubehandlet melding i køen " + mottatt.Melding.MeldingId + " " + mottatt.Melding.MeldingType);

            }

            
        }

    }
}
