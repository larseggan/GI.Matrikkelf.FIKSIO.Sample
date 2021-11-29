
namespace RecieveSampleWinForms
{
    partial class frmNyBygning
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBygningsnummer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBygningsloepenummer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(323, 124);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 0;
            this.cmdClose.Text = "Lukk";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Simulerer føring av vagt sak i matrikkelen og sender respons tilbake";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bygningsnummer";
            // 
            // txtBygningsnummer
            // 
            this.txtBygningsnummer.Location = new System.Drawing.Point(156, 48);
            this.txtBygningsnummer.Name = "txtBygningsnummer";
            this.txtBygningsnummer.Size = new System.Drawing.Size(242, 23);
            this.txtBygningsnummer.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bgningsloepenummer";
            // 
            // txtBygningsloepenummer
            // 
            this.txtBygningsloepenummer.Location = new System.Drawing.Point(156, 81);
            this.txtBygningsloepenummer.Name = "txtBygningsloepenummer";
            this.txtBygningsloepenummer.Size = new System.Drawing.Size(242, 23);
            this.txtBygningsloepenummer.TabIndex = 5;
            // 
            // frmNyBygning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 175);
            this.Controls.Add(this.txtBygningsloepenummer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBygningsnummer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdClose);
            this.Name = "frmNyBygning";
            this.Text = "Ny bygning";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBygningsnummer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBygningsloepenummer;
    }
}