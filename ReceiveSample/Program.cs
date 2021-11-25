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
        static void Main()
        {
         
            string accountId = ConfigurationManager.AppSettings["accountId"];

            FiksIOClient client = FiksIOCommunication.Config();

            client.NewSubscription(OnReceivedMelding);

            Console.WriteLine("Abonnerer på meldinger på konto " + accountId.ToString() + " ...");
            //Pause til neste
            Console.WriteLine("Trykk en tast for å avslutte");
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
                                    XmlSerializer serializer = new XmlSerializer(typeof(ByggesakType));

                                    ByggesakType sak = (ByggesakType)serializer.Deserialize(entryStream);
                                    if (sak.saksnummer != null)
                                    {
                                        Console.WriteLine("Mottatt byggesak med saksnummer " + sak.saksnummer.saksaar.ToString() + "/" + sak.saksnummer.sakssekvensnummer.ToString());
                                    }
                                    string xmlString = new StreamReader(entryStream).ReadToEnd();
                                }
                                else
                                    Console.WriteLine("Mottatt vedlegg: " + asiceReadEntry.FileName);
                            }
                        }
                    }

                    var svarmsg2 = mottatt.SvarSender.Svar("no.ks.fiks.matrikkelfoering.grunnlag.v2").Result;
                    Console.WriteLine("Svarmelding " + svarmsg2.MeldingId + " " + svarmsg2.MeldingType + " sendt...");
                    mottatt.SvarSender.Ack();
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
