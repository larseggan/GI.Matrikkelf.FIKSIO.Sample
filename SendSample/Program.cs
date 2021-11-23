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
                     
            client = FiksIOCommunication.Config( );

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

            string payload = System.IO.File.ReadAllText("SampleNivaa0.xml");

            List<IPayload> payloads = new List<IPayload>();
            payloads.Add(new StringPayload(payload, "byggesak.xml"));
         
            var msg = client.Send(messageRequest, payloads).Result;
            Console.WriteLine("Melding " + msg.MeldingId.ToString() + " sendt..." + msg.MeldingType + " til konto " + msg.MottakerKontoId.ToString());
            Console.WriteLine(payload);

        }
    }
}
