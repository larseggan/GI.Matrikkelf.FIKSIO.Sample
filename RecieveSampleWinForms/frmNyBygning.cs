using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecieveSampleWinForms
{
    public partial class frmNyBygning : Form
    {
        public frmNyBygning()
        {
            InitializeComponent();
        }

        public string Bygningsnummer
        {
            get
            {
                return txtBygningsnummer.Text;
            }
            set
            {
                txtBygningsnummer.Text = value;
            }
        }

        public string Bygningsloepenummer
        {
            get
            {
                return txtBygningsloepenummer.Text;
            }
            set
            {
                txtBygningsloepenummer.Text = value;
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
