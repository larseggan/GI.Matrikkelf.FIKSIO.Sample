using System;
using System.IO;
using System.Configuration;
using KS.Fiks.IO.Client.Models;
using KS.Fiks.IO.Client;
using System.Collections.Generic;
using ClassLibFIKSIO;

namespace SendSample
{
    class Program
    {
        private static FiksIOClient client;
        static void Main(string[] args)
        {

          

            int nivaa = 0;
            if (args.Length == 0)
            {
                // default, kjør alt
            }
            else if (args.Length == 1)
            {
                if (!Int32.TryParse(args[0], out nivaa))
                {
                    nivaa = 0;
                }
            }
          
            //Send til FIKS
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

            client =  fiksIO.Config(accountId, accountPrivateKeyFilename, integrasjonId, integrationPassword,
               virksomhetsSertifikat, issuer);

            // Lag datasett
            SendNivaa0();

        }
        private static void SendNivaa0()
        {
            Guid receiverId = Guid.Parse(ConfigurationManager.AppSettings["sendToAccountId"]); // Receiver id as Guid
            Guid senderId = Guid.Parse(ConfigurationManager.AppSettings["accountId"]); // Sender id as Guid

           


            var messageRequest = new MeldingRequest(
                                      mottakerKontoId: receiverId,
                                      avsenderKontoId: senderId,
                                      meldingType: "no.ks.fiks.matrikkelfoering.grunnlag.v2"); // Message type as string https://fiks.ks.no/plan.oppretteplanidentinput.v1.schema.json
                                                                                                               //Se oversikt over meldingstyper på https://github.com/ks-no/fiks-io-meldingstype-katalog/tree/test/schema

            // client.Lookup(new LookupRequest("", "", 3));

            string payload = System.IO.File.ReadAllText("SampleNivaa0.xml");

            List<IPayload> payloads = new List<IPayload>();
            payloads.Add(new StringPayload(payload, "byggesak.xml"));
            //payloads.Add(new KS.Fiks.IO.Client.Models.FilePayload(@"C:\dev\ks\gi-politiskbehandling\Eksempelklienter\ks.fiks.io.eplansak.utvalg.sample\ks.fiks.io.eplansak.sample\files\saksframlegg.docx"));
            //payloads.Add(new KS.Fiks.IO.Client.Models.FilePayload(@"C:\dev\ks\gi-politiskbehandling\Eksempelklienter\ks.fiks.io.eplansak.utvalg.sample\ks.fiks.io.eplansak.sample\files\planbestemmelser.pdf"));
            //payloads.Add(new KS.Fiks.IO.Client.Models.FilePayload(@"C:\dev\ks\gi-politiskbehandling\Eksempelklienter\ks.fiks.io.eplansak.utvalg.sample\ks.fiks.io.eplansak.sample\files\plankart.pdf"));
            //payloads.Add(new KS.Fiks.IO.Client.Models.FilePayload(@"C:\dev\ks\gi-politiskbehandling\Eksempelklienter\ks.fiks.io.eplansak.utvalg.sample\ks.fiks.io.eplansak.sample\files\analyse.pdf"));

            var msg = client.Send(messageRequest, payloads).Result;
            Console.WriteLine("Melding " + msg.MeldingId.ToString() + " sendt..." + msg.MeldingType + " til konto " + msg.MottakerKontoId.ToString());
            Console.WriteLine(payload);

        }
    }
}
