using System;
using System.IO;
using System.Configuration;
using KS.Fiks.IO.Client.Models;
using KS.Fiks.IO.Client;
using ClassLibFIKSIO;
using KS.Fiks.ASiC_E;
using System.Xml.Serialization;
using System.Collections.Generic;


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
                    string saksaar = null;
                    string sakssekvensnummer = null;

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
                                    saksaar = sak.saksnummer.saksaar;
                                    sakssekvensnummer = sak.saksnummer.sakssekvensnummer;


                                    if (sak.saksnummer != null)
                                    {
                                        Console.WriteLine("Mottatt byggesak med saksnummer " + sak.saksnummer.saksaar.ToString() + "/" + sak.saksnummer.sakssekvensnummer.ToString());
                                    }
                                  //  string xmlString = new StreamReader(entryStream).ReadToEnd();
                                }
                                else
                                    Console.WriteLine("Mottatt vedlegg: " + asiceReadEntry.FileName);
                            }
                        }
                    }

                    var svarmsg2 = mottatt.SvarSender.Svar("no.ks.fiks.matrikkelfoering.mottatt.v1").Result;
                    Console.WriteLine("Svarmelding " + svarmsg2.MeldingId + " " + svarmsg2.MeldingType + " sendt...");
                    mottatt.SvarSender.Ack();

                    Console.WriteLine("Venter 20 sekund...");

                    // wait some time to add add buildign to matrikkel
                    System.Threading.Thread.Sleep(20000);

                    KvitteringMatrikkelType kvitteringMatrikkelType = new KvitteringMatrikkelType();
                    kvitteringMatrikkelType.saksnummer = new SaksnummerType1();
                    kvitteringMatrikkelType.saksnummer.saksaar = saksaar;
                    kvitteringMatrikkelType.saksnummer.sakssekvensnummer = sakssekvensnummer;

                    kvitteringMatrikkelType.byggIdent = new ByggIdentType[1];
                    ByggIdentType newIdent = new ByggIdentType();
                    newIdent.bygningsnummer = "123";
                    //                    newIdent.bygningsloepenummer = nyBygning.Bygningsloepenummer;
                    kvitteringMatrikkelType.byggIdent[0] = newIdent;

                    kvitteringMatrikkelType.tiltak = new TiltakType[1];
                    TiltakType  newTiltaktype = new TiltakType();
                    TiltaktypeType newType = new TiltaktypeType();
                    newType.kode = "nyttbyggboligformal";
                    newType.beskrivelse = "Nytt bygg - boligformål";
                    newTiltaktype.tiltakstype = newType;
                    
                    newTiltaktype.tiltakid = "1";
                    kvitteringMatrikkelType.tiltak[0] = newTiltaktype;


                    // Lars: New StatusTypeType in kvitteringMatrikkelType
                    kvitteringMatrikkelType.status = StatusTypeType.velykket;


                    string xmlString = "";
                    using (var stringwriter = new ExtentedStringWriter(System.Text.Encoding.UTF8))
                    {


                        var serializer = new XmlSerializer(kvitteringMatrikkelType.GetType());
                        serializer.Serialize(stringwriter, kvitteringMatrikkelType);
                        xmlString = stringwriter.ToString();
                        Console.WriteLine("kvitteringMatrikkelType:");
                        Console.WriteLine(xmlString);
                        Console.WriteLine();

                    }


                    List<IPayload> payloads = new List<IPayload>();
                    string index = @"""dokumenttype"": ""Byggesak""," + "\n" +
                       @"""tittel"": ""Kvittering for matrikkelføring""," + "\n" +
                       @"""dokumentnummer"": ""1""," + "\n" +
                       @"""filnavn"": ""kvittering.xml""";


                    payloads.Add(new StringPayload(index, "index.json"));
                    payloads.Add(new StringPayload(xmlString, "kvittering.xml"));

                    var kvittering = mottatt.SvarSender.Svar("no.ks.fiks.matrikkelfoering.kvittering.v2", payloads).Result;

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
