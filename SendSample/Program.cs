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

            int nivaa = -1;
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

            client = FiksIOCommunication.Config();

            // Lag datasett
            if (nivaa <= 0)
            {
                SendNivaa0();
            }
            if (nivaa == 1 || nivaa == -1)
            {
                SendNivaa1();
            }

            if (nivaa == 2 || nivaa == -1)
            {
                SendNivaa2();
            }

            if (nivaa == 3 || nivaa == -1)
            {
                SendNivaa3();
            }
        }
        /// <summary>
        /// Saksnummer url til vedtak
        /// </summary>
        private static void SendNivaa0()
        {
            Guid receiverId = Guid.Parse(ConfigurationManager.AppSettings["sendToAccountId"]); // Receiver id as Guid
            Guid senderId = Guid.Parse(ConfigurationManager.AppSettings["accountId"]); // Sender id as Guid

            var messageRequest = new MeldingRequest(
                                      mottakerKontoId: receiverId,
                                      avsenderKontoId: senderId,
                                      meldingType: "no.ks.fiks.matrikkelfoering.grunnlag.v2"); // Message type as string https://fiks.ks.no/plan.oppretteplanidentinput.v1.schema.json
                                                                                               //Se oversikt over meldingstyper på https://github.com/ks-no/fiks-io-meldingstype-katalog/tree/test/schema

            string index = @"""dokumenttype"": ""Byggesak""," + "\n" +
                @"""tittel"": ""Underlag for matrikkelføring""," + "\n" +
                @"""dokumentnummer"": ""1""," + "\n" +
                @"""filnavn"": ""byggesak.xml""";





            List<IPayload> payloads = new List<IPayload>();
            payloads.Add(new StringPayload(index, "index.json"));

            string payload = System.IO.File.ReadAllText("SampleNivaa0.xml");
            payloads.Add(new StringPayload(payload, "byggesak.xml"));

            var msg = client.Send(messageRequest, payloads).Result;
            Console.WriteLine("Melding " + msg.MeldingId.ToString() + " sendt..." + msg.MeldingType + " til konto " + msg.MottakerKontoId.ToString());
            Console.WriteLine(payload);

        }

        /// <summary>
        /// Gjeldente tegning grunnlag
        /// </summary>
        private static void SendNivaa1()
        {
            Guid receiverId = Guid.Parse(ConfigurationManager.AppSettings["sendToAccountId"]); // Receiver id as Guid
            Guid senderId = Guid.Parse(ConfigurationManager.AppSettings["accountId"]); // Sender id as Guid

            var messageRequest = new MeldingRequest(
                                      mottakerKontoId: receiverId,
                                      avsenderKontoId: senderId,
                                      meldingType: "no.ks.fiks.matrikkelfoering.grunnlag.v2"); // Message type as string https://fiks.ks.no/plan.oppretteplanidentinput.v1.schema.json
                                                                                               //Se oversikt over meldingstyper på https://github.com/ks-no/fiks-io-meldingstype-katalog/tree/test/schema

            string index = @"""dokumenttype"": ""Byggesak""," + "\n" +
                 @"""tittel"": ""Underlag for matrikkelføring""," + "\n" +
                 @"""dokumentnummer"": ""1""," + "\n" +
                 @"""filnavn"": ""byggesak.xml""," + "\n" +
                 @"""dokumenttype"": ""Kart""," + "\n" +
                 @"""tittel"": ""Situasjonsplan""," + "\n" +
                 @"""dokumentnummer"": ""2""," + "\n" +
                 @"""filnavn"": ""DokSitplan.xml""," + "\n" +
                 @"""dokumenttype"": ""Kart""," + "\n" +
                 @"""tittel"": ""TegningNyPlan""," + "\n" +
                 @"""dokumentnummer"": ""2""," + "\n" +
                 @"""filnavn"": ""DokTegning.xml""" + "\n";


            string payload = System.IO.File.ReadAllText("SampleNivaa1.xml");

            List<IPayload> payloads = new List<IPayload>();
            payloads.Add(new StringPayload(index, "index.json"));
            payloads.Add(new StringPayload(payload, "byggesak.xml"));

            payloads.Add(new FilePayload("DokSitplan.pdf"));
            payloads.Add(new FilePayload("DokTegning.pdf"));


            var msg = client.Send(messageRequest, payloads).Result;
            Console.WriteLine("Melding " + msg.MeldingId.ToString() + " sendt..." + msg.MeldingType + " til konto " + msg.MottakerKontoId.ToString());
            Console.WriteLine(payload);

        }

        /// <summary>
        /// Matrikkelopplysninger
        /// </summary>
        private static void SendNivaa2()
        {
            Guid receiverId = Guid.Parse(ConfigurationManager.AppSettings["sendToAccountId"]); // Receiver id as Guid
            Guid senderId = Guid.Parse(ConfigurationManager.AppSettings["accountId"]); // Sender id as Guid

            var messageRequest = new MeldingRequest(
                                      mottakerKontoId: receiverId,
                                      avsenderKontoId: senderId,
                                      meldingType: "no.ks.fiks.matrikkelfoering.grunnlag.v2"); // Message type as string https://fiks.ks.no/plan.oppretteplanidentinput.v1.schema.json
                                                                                               //Se oversikt over meldingstyper på https://github.com/ks-no/fiks-io-meldingstype-katalog/tree/test/schema



            string index = @"""dokumenttype"": ""Byggesak""," + "\n" +
                @"""tittel"": ""Underlag for matrikkelføring""," + "\n" +
                @"""dokumentnummer"": ""1""," + "\n" +
                @"""filnavn"": ""byggesak.xml""";


            string payload = System.IO.File.ReadAllText("SampleNivaa2.xml");

            List<IPayload> payloads = new List<IPayload>();
            payloads.Add(new StringPayload(index, "index.json"));
            payloads.Add(new StringPayload(payload, "byggesak.xml"));

            var msg = client.Send(messageRequest, payloads).Result;
            Console.WriteLine("Melding " + msg.MeldingId.ToString() + " sendt..." + msg.MeldingType + " til konto " + msg.MottakerKontoId.ToString());
            Console.WriteLine(payload);

        }

        /// <summary>
        /// Byggesaksbim
        /// </summary>
        private static void SendNivaa3()
        {
            Guid receiverId = Guid.Parse(ConfigurationManager.AppSettings["sendToAccountId"]); // Receiver id as Guid
            Guid senderId = Guid.Parse(ConfigurationManager.AppSettings["accountId"]); // Sender id as Guid

            var messageRequest = new MeldingRequest(
                                      mottakerKontoId: receiverId,
                                      avsenderKontoId: senderId,
                                      meldingType: "no.ks.fiks.matrikkelfoering.grunnlag.v2"); // Message type as string https://fiks.ks.no/plan.oppretteplanidentinput.v1.schema.json
                                                                                               //Se oversikt over meldingstyper på https://github.com/ks-no/fiks-io-meldingstype-katalog/tree/test/schema
            string index = @"""dokumenttype"": ""Byggesak""," + "\n" +
                            @"""tittel"": ""Underlag for matrikkelføring""," + "\n" +
                            @"""dokumentnummer"": ""1""," + "\n" +
                            @"""filnavn"": ""byggesak.xml""," + "\n" +
                            @"""dokumenttype"": ""ByggesaksBIM""," + "\n" +
                            @"""tittel"": ""ByggesaksBIM""," + "\n" +
                            @"""dokumentnummer"": ""2""," + "\n" +
                            @"""filnavn"": ""bim.ifc""" + "\n";


            string payload = System.IO.File.ReadAllText("SampleNivaa3.xml");

            List<IPayload> payloads = new List<IPayload>();
            payloads.Add(new StringPayload(index, "index.json"));
            payloads.Add(new StringPayload(payload, "byggesak.xml"));
            payloads.Add(new FilePayload("bim.ifc"));

            var msg = client.Send(messageRequest, payloads).Result;
            Console.WriteLine("Melding " + msg.MeldingId.ToString() + " sendt..." + msg.MeldingType + " til konto " + msg.MottakerKontoId.ToString());
            Console.WriteLine(payload);

        }
    }
}
