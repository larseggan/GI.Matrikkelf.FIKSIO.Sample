
namespace RecieveSampleWinForms
{
    partial class frmShowMessage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.dataGridViewFiler = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdAck = new System.Windows.Forms.Button();
            this.cmdVis = new System.Windows.Forms.Button();
            this.cmdForSak = new System.Windows.Forms.Button();
            this.txtSaksaar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSakssekvensnummer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiler)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(654, 391);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.Text = "Lukk";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(62, 47);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(340, 23);
            this.txtType.TabIndex = 1;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(62, 90);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(340, 23);
            this.txtId.TabIndex = 2;
            // 
            // dataGridViewFiler
            // 
            this.dataGridViewFiler.AllowUserToAddRows = false;
            this.dataGridViewFiler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewFiler.Location = new System.Drawing.Point(62, 203);
            this.dataGridViewFiler.Name = "dataGridViewFiler";
            this.dataGridViewFiler.RowTemplate.Height = 25;
            this.dataGridViewFiler.Size = new System.Drawing.Size(339, 130);
            this.dataGridViewFiler.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Filnavn";
            this.Column1.Name = "Column1";
            // 
            // cmdAck
            // 
            this.cmdAck.Location = new System.Drawing.Point(654, 22);
            this.cmdAck.Name = "cmdAck";
            this.cmdAck.Size = new System.Drawing.Size(75, 23);
            this.cmdAck.TabIndex = 4;
            this.cmdAck.Text = "Ack";
            this.cmdAck.UseVisualStyleBackColor = true;
            this.cmdAck.Click += new System.EventHandler(this.cmdAck_Click);
            // 
            // cmdVis
            // 
            this.cmdVis.Location = new System.Drawing.Point(416, 203);
            this.cmdVis.Name = "cmdVis";
            this.cmdVis.Size = new System.Drawing.Size(72, 28);
            this.cmdVis.TabIndex = 5;
            this.cmdVis.Text = "Vis";
            this.cmdVis.UseVisualStyleBackColor = true;
            this.cmdVis.Click += new System.EventHandler(this.cmdVis_Click);
            // 
            // cmdForSak
            // 
            this.cmdForSak.Location = new System.Drawing.Point(654, 61);
            this.cmdForSak.Name = "cmdForSak";
            this.cmdForSak.Size = new System.Drawing.Size(75, 23);
            this.cmdForSak.TabIndex = 6;
            this.cmdForSak.Text = "Før sak";
            this.cmdForSak.UseVisualStyleBackColor = true;
            this.cmdForSak.Click += new System.EventHandler(this.cmdForSak_Click);
            // 
            // txtSaksaar
            // 
            this.txtSaksaar.Location = new System.Drawing.Point(63, 13);
            this.txtSaksaar.Name = "txtSaksaar";
            this.txtSaksaar.Size = new System.Drawing.Size(76, 23);
            this.txtSaksaar.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Saksår";
            // 
            // txtSakssekvensnummer
            // 
            this.txtSakssekvensnummer.Location = new System.Drawing.Point(268, 13);
            this.txtSakssekvensnummer.Name = "txtSakssekvensnummer";
            this.txtSakssekvensnummer.Size = new System.Drawing.Size(133, 23);
            this.txtSakssekvensnummer.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Sakssekvensnummer";
            // 
            // frmShowMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSakssekvensnummer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSaksaar);
            this.Controls.Add(this.cmdForSak);
            this.Controls.Add(this.cmdVis);
            this.Controls.Add(this.cmdAck);
            this.Controls.Add(this.dataGridViewFiler);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.cmdClose);
            this.Name = "frmShowMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Melding";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.DataGridView dataGridViewFiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button cmdAck;
        private System.Windows.Forms.Button cmdVis;
        private System.Windows.Forms.Button cmdForSak;
        private System.Windows.Forms.TextBox txtSaksaar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSakssekvensnummer;
        private System.Windows.Forms.Label label2;
    }
}