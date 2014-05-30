namespace CSharpProsjekt
{
    partial class OpprettKonto
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
            this.lblNavn = new System.Windows.Forms.Label();
            this.tbNavn = new System.Windows.Forms.TextBox();
            this.lblPassord = new System.Windows.Forms.Label();
            this.tbPassord = new System.Windows.Forms.TextBox();
            this.lblBekreftPassord = new System.Windows.Forms.Label();
            this.tbBekreftPassord = new System.Windows.Forms.TextBox();
            this.btnOpprett = new System.Windows.Forms.Button();
            this.lblFeil = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNavn
            // 
            this.lblNavn.AutoSize = true;
            this.lblNavn.Location = new System.Drawing.Point(13, 14);
            this.lblNavn.Name = "lblNavn";
            this.lblNavn.Size = new System.Drawing.Size(45, 17);
            this.lblNavn.TabIndex = 0;
            this.lblNavn.Text = "Navn:";
            // 
            // tbNavn
            // 
            this.tbNavn.Location = new System.Drawing.Point(145, 7);
            this.tbNavn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbNavn.Name = "tbNavn";
            this.tbNavn.Size = new System.Drawing.Size(100, 22);
            this.tbNavn.TabIndex = 1;
            // 
            // lblPassord
            // 
            this.lblPassord.AutoSize = true;
            this.lblPassord.Location = new System.Drawing.Point(13, 48);
            this.lblPassord.Name = "lblPassord";
            this.lblPassord.Size = new System.Drawing.Size(64, 17);
            this.lblPassord.TabIndex = 2;
            this.lblPassord.Text = "Passord:";
            // 
            // tbPassord
            // 
            this.tbPassord.Location = new System.Drawing.Point(145, 43);
            this.tbPassord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPassord.Name = "tbPassord";
            this.tbPassord.PasswordChar = '*';
            this.tbPassord.Size = new System.Drawing.Size(100, 22);
            this.tbPassord.TabIndex = 3;
            // 
            // lblBekreftPassord
            // 
            this.lblBekreftPassord.AutoSize = true;
            this.lblBekreftPassord.Location = new System.Drawing.Point(13, 82);
            this.lblBekreftPassord.Name = "lblBekreftPassord";
            this.lblBekreftPassord.Size = new System.Drawing.Size(112, 17);
            this.lblBekreftPassord.TabIndex = 4;
            this.lblBekreftPassord.Text = "Bekreft passord:";
            // 
            // tbBekreftPassord
            // 
            this.tbBekreftPassord.Location = new System.Drawing.Point(145, 78);
            this.tbBekreftPassord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbBekreftPassord.Name = "tbBekreftPassord";
            this.tbBekreftPassord.PasswordChar = '*';
            this.tbBekreftPassord.Size = new System.Drawing.Size(100, 22);
            this.tbBekreftPassord.TabIndex = 5;
            // 
            // btnOpprett
            // 
            this.btnOpprett.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnOpprett.ForeColor = System.Drawing.Color.Black;
            this.btnOpprett.Location = new System.Drawing.Point(16, 104);
            this.btnOpprett.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpprett.Name = "btnOpprett";
            this.btnOpprett.Size = new System.Drawing.Size(229, 48);
            this.btnOpprett.TabIndex = 8;
            this.btnOpprett.Text = "Opprett konto";
            this.btnOpprett.UseVisualStyleBackColor = false;
            this.btnOpprett.Click += new System.EventHandler(this.btnOpprett_Click);
            // 
            // lblFeil
            // 
            this.lblFeil.AutoSize = true;
            this.lblFeil.ForeColor = System.Drawing.Color.Crimson;
            this.lblFeil.Location = new System.Drawing.Point(13, 168);
            this.lblFeil.Name = "lblFeil";
            this.lblFeil.Size = new System.Drawing.Size(0, 17);
            this.lblFeil.TabIndex = 9;
            this.lblFeil.Visible = false;
            // 
            // OpprettKonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 197);
            this.Controls.Add(this.lblFeil);
            this.Controls.Add(this.btnOpprett);
            this.Controls.Add(this.tbBekreftPassord);
            this.Controls.Add(this.lblBekreftPassord);
            this.Controls.Add(this.tbPassord);
            this.Controls.Add(this.lblPassord);
            this.Controls.Add(this.tbNavn);
            this.Controls.Add(this.lblNavn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OpprettKonto";
            this.Text = "OpprettKonto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNavn;
        private System.Windows.Forms.TextBox tbNavn;
        private System.Windows.Forms.Label lblPassord;
        private System.Windows.Forms.TextBox tbPassord;
        private System.Windows.Forms.Label lblBekreftPassord;
        private System.Windows.Forms.TextBox tbBekreftPassord;
        private System.Windows.Forms.Button btnOpprett;
        private System.Windows.Forms.Label lblFeil;
    }
}