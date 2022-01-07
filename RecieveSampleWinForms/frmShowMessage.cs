using System;
using System.Windows.Forms;
using KS.Fiks.IO.Client.Models;
using KS.Fiks.IO.Client;

using KS.Fiks.ASiC_E;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ClassLibFIKSIO;

namespace RecieveSampleWinForms
{
    public partial class frmShowMessage : Form
    {
        private MottattMeldingArgs _mottatt;
        public frmShowMessage()
        {
            InitializeComponent();
        }

        internal void Filldata(MottattMeldingArgs mottatt)
        {
            _mottatt = mottatt;
            txtType.Text = mottatt.Melding.MeldingType;
            txtId.Text = mottatt.Melding.MeldingId.ToString();

            if (mottatt.Melding.HasPayload)
            {
                IAsicReader reader = new AsiceReader();
                using (var inputStream = mottatt.Melding.DecryptedStream.Result)
                using (var asice = reader.Read(inputStream))
                {
                    foreach (var asiceReadEntry in asice.Entries)
                    {
                        dataGridViewFiler.Rows.Add();
                        dataGridViewFiler[0, dataGridViewFiler.Rows.Count - 1].Value = asiceReadEntry.FileName;


                        using (var entryStream = asiceReadEntry.OpenStream())
                        {
                            if (asiceReadEntry.FileName.Contains(".xml"))
                            {

                                try
                                {
                                    if (mottatt.Melding.MeldingType == "no.ks.fiks.matrikkelfoering.grunnlag.v2")
                                    {
                                        XmlSerializer serializer = new XmlSerializer(typeof(ByggesakType));
                                        ByggesakType sak = (ByggesakType)serializer.Deserialize(entryStream);
                                        if (sak.saksnummer != null)
                                        {
                                            txtSaksaar.Text = sak.saksnummer.saksaar.ToString();
                                            txtSakssekvensnummer.Text = sak.saksnummer.sakssekvensnummer.ToString();

                                        }
                                    }
                                    else if (mottatt.Melding.MeldingType == "no.ks.fiks.matrikkelfoering.kvittering.v2")
                                    {
                                        XmlSerializer serializer = new XmlSerializer(typeof(KvitteringMatrikkelType));
                                        KvitteringMatrikkelType ident = (KvitteringMatrikkelType)serializer.Deserialize(entryStream);

                                    }
                                }
                                catch (Exception ex)
                                {

                                    MessageBox.Show(ex.Message);
                                }

                            }
                        }

                    }
                }

                //var svarmsg2 = mottatt.SvarSender.Svar("no.ks.fiks.matrikkelfoering.grunnlag.v2").Result;
                //Console.WriteLine("Svarmelding " + svarmsg2.MeldingId + " " + svarmsg2.MeldingType + " sendt...");
                //mottatt.SvarSender.Ack();
            }
        }

        private void cmdClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void cmdAck_Click(object sender, System.EventArgs e)
        {
            _mottatt.SvarSender.Ack();
            Close();
        }

        private void cmdVis_Click(object sender, System.EventArgs e)
        {
            if (dataGridViewFiler.SelectedRows.Count == 1)
            {
                DataGridViewRow selRow = dataGridViewFiler.SelectedRows[0];
                string selFilename = (string)selRow.Cells[0].Value;


                string fileName = Path.GetTempPath() + Guid.NewGuid().ToString() + Path.GetExtension(selFilename);


                IAsicReader reader = new AsiceReader();
                using (var inputStream = _mottatt.Melding.DecryptedStream.Result)
                using (var asice = reader.Read(inputStream))
                {
                    foreach (var asiceReadEntry in asice.Entries)
                    {

                        using (var entryStream = asiceReadEntry.OpenStream())
                        {
                            if (asiceReadEntry.FileName == selFilename)
                            {
                                var fileStream = File.Create(fileName);

                                entryStream.CopyTo(fileStream);
                                fileStream.Close();
                                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = fileName, UseShellExecute = true });
                            }
                        }
                    }
                }
            }
        }

        private void cmdForSak_Click(object sender, EventArgs e)
        {

            frmNyBygning nyBygning = new frmNyBygning();
            nyBygning.ShowDialog();

            KvitteringMatrikkelType kvitteringMatrikkelType = new KvitteringMatrikkelType();
            kvitteringMatrikkelType.saksnummer = new SaksnummerType1();
            kvitteringMatrikkelType.saksnummer.saksaar = txtSaksaar.Text;
            kvitteringMatrikkelType.saksnummer.sakssekvensnummer = txtSakssekvensnummer.Text;

            kvitteringMatrikkelType.byggIdent = new ByggIdentType1[1];
            ByggIdentType1 newIdent = new ByggIdentType1();
            newIdent.bygningsnummer = nyBygning.Bygningsnummer;
            newIdent.bygningsloepenummer = nyBygning.Bygningsloepenummer;
            kvitteringMatrikkelType.byggIdent[0] = newIdent;


            string xmlString = "";
            using (var stringwriter = new ExtentedStringWriter(Encoding.UTF8))
            {

                var serializer = new XmlSerializer(kvitteringMatrikkelType.GetType());
                serializer.Serialize(stringwriter, kvitteringMatrikkelType);
                xmlString = stringwriter.ToString();
            }

            List<IPayload> payloads = new List<IPayload>();
            string index = @"""dokumenttype"": ""Byggesak""," + "\n" +
               @"""tittel"": ""Kvittering for matrikkelføring""," + "\n" +
               @"""dokumentnummer"": ""1""," + "\n" +
               @"""filnavn"": ""kvittering.xml""";


            payloads.Add(new StringPayload(index, "index.json"));
            payloads.Add(new StringPayload(xmlString, "kvittering.xml"));

            var svarmsg2 = _mottatt.SvarSender.Svar("no.ks.fiks.matrikkelfoering.kvittering.v2", payloads).Result;

            _mottatt.SvarSender.Ack();
            Close();
        }


    }
}
