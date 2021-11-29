using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibFIKSIO;

using System.IO;
using System.Configuration;
using KS.Fiks.IO.Client.Models;
using KS.Fiks.IO.Client;

using KS.Fiks.ASiC_E;
using System.Xml.Serialization;


namespace RecieveSampleWinForms
{
    public partial class frmMain : Form
    {

        private Dictionary<string, MottattMeldingArgs> _messages = new Dictionary<string, MottattMeldingArgs>();
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           

            FiksIOClient client = FiksIOCommunication.Config();

            client.NewSubscription(OnReceivedMelding);
        }

        // Handle cross threading https://stackoverflow.com/questions/10775367/cross-thread-operation-not-valid-control-textbox1-accessed-from-a-thread-othe
        delegate void SetTextCallback(MottattMeldingArgs text);
        private void SetText(MottattMeldingArgs mottatt)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.dataGridView1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { mottatt });
            }
            else
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, dataGridView1.Rows.Count - 1].Value = mottatt.Melding.MeldingType;
                dataGridView1[1, dataGridView1.Rows.Count - 1].Value = mottatt.Melding.MeldingId.ToString();

                dataGridView1[2, dataGridView1.Rows.Count - 1].Value = mottatt.Melding.Ttl.ToString(); //      TotalHours.ToString();//   .Days.ToString() + "d" +   mottatt.Melding.Ttl.Hours.ToString()+ "h";

                _messages.Add(mottatt.Melding.MeldingId.ToString(), mottatt);
            }
        }

        void OnReceivedMelding(object sender, MottattMeldingArgs mottatt)
        {
         
            // Process the message
            //dataGridView1.Rows.Add();
            //dataGridView1[0, dataGridView1.Rows.Count - 1].Value = mottatt.Melding.MeldingType;
            //dataGridView1[1, dataGridView1.Rows.Count - 1].Value = mottatt.Melding.MeldingId.ToString();

            SetText(mottatt);


            //if (mottatt.Melding.MeldingType == "no.ks.fiks.matrikkelfoering.grunnlag.v2")
            //{
            //    Console.WriteLine("Melding " + mottatt.Melding.MeldingId + " " + mottatt.Melding.MeldingType + " mottas...");
            //    if (mottatt.Melding.HasPayload)
            //    {
            //        IAsicReader reader = new AsiceReader();
            //        using (var inputStream = mottatt.Melding.DecryptedStream.Result)
            //        using (var asice = reader.Read(inputStream))
            //        {
            //            foreach (var asiceReadEntry in asice.Entries)
            //            {
            //                using (var entryStream = asiceReadEntry.OpenStream())
            //                {
            //                    if (asiceReadEntry.FileName.Contains(".xml"))
            //                    {
            //                        XmlSerializer serializer = new XmlSerializer(typeof(ByggesakType));

            //                        ByggesakType sak = (ByggesakType)serializer.Deserialize(entryStream);
            //                        if (sak.saksnummer != null)
            //                        {
            //                            Console.WriteLine("Mottatt byggesak med saksnummer " + sak.saksnummer.saksaar.ToString() + "/" + sak.saksnummer.sakssekvensnummer.ToString());
            //                        }
            //                        string xmlString = new StreamReader(entryStream).ReadToEnd();
            //                    }
            //                    else
            //                        Console.WriteLine("Mottatt vedlegg: " + asiceReadEntry.FileName);
            //                }
            //            }
            //        }

            //        var svarmsg2 = mottatt.SvarSender.Svar("no.ks.fiks.matrikkelfoering.grunnlag.v2").Result;
            //        Console.WriteLine("Svarmelding " + svarmsg2.MeldingId + " " + svarmsg2.MeldingType + " sendt...");
            //        mottatt.SvarSender.Ack();
            //    }
            //    else
            //    {
            //        var svarmsg = mottatt.SvarSender.Svar("no.ks.fiks.kvittering.ugyldigforespørsel.v1", "Meldingen mangler innhold", "feil.txt").Result;
            //        Console.WriteLine("Svarmelding " + svarmsg.MeldingId + " " + svarmsg.MeldingType + " Meldingen mangler innhold");
            //        mottatt.SvarSender.Ack(); // Ack message to remove it from the queue
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Ubehandlet melding i køen " + mottatt.Melding.MeldingId + " " + mottatt.Melding.MeldingType);
            //}

        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if  (dataGridView1.Rows.Count> 0 )
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    string key = (string)dataGridView1[1, row.Index].Value;
                    if (key != null)
                    {


                        MottattMeldingArgs foundMessage;

                        if (_messages.TryGetValue(key, out foundMessage)) {
                            cmdVis.Enabled = true;
                        }
                        else
                        {
                            cmdVis.Enabled = false;
                        }
                    }
                    else { cmdVis.Enabled = false; }

                }
                else
                {
                    cmdVis.Enabled = false;
                }
                
            }
            else
            {
                cmdVis.Enabled = false;
            }
        }

        private void cmdVis_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    string key = (string)dataGridView1[1, row.Index].Value;
                    MottattMeldingArgs foundMessage;

                    if (_messages.TryGetValue(key, out foundMessage))
                    {
                        frmShowMessage f = new frmShowMessage();
                        f.Filldata(foundMessage);
                        f.ShowDialog();
                        cmdVis.Enabled = true;
                    }
            
                }
            

            }
            
        }
    }

}
