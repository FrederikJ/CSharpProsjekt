namespace tempNavn
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNavn = new System.Windows.Forms.TextBox();
            this.tbPassord = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnOpprett = new System.Windows.Forms.Button();
            this.lblFeil = new System.Windows.Forms.Label();
            this.btnMistet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Navn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Passord:";
            // 
            // tbNavn
            // 
            this.tbNavn.Location = new System.Drawing.Point(84, 13);
            this.tbNavn.Name = "tbNavn";
            this.tbNavn.Size = new System.Drawing.Size(100, 22);
            this.tbNavn.TabIndex = 2;
            // 
            // tbPassord
            // 
            this.tbPassord.Location = new System.Drawing.Point(84, 44);
            this.tbPassord.Name = "tbPassord";
            this.tbPassord.Size = new System.Drawing.Size(100, 22);
            this.tbPassord.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(16, 81);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(168, 31);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnOpprett
            // 
            this.btnOpprett.Location = new System.Drawing.Point(16, 118);
            this.btnOpprett.Name = "btnOpprett";
            this.btnOpprett.Size = new System.Drawing.Size(168, 31);
            this.btnOpprett.TabIndex = 5;
            this.btnOpprett.Text = "Opprett bruker";
            this.btnOpprett.UseVisualStyleBackColor = true;
            this.btnOpprett.Click += new System.EventHandler(this.btnOpprett_Click);
            // 
            // lblFeil
            // 
            this.lblFeil.AutoSize = true;
            this.lblFeil.ForeColor = System.Drawing.Color.Crimson;
            this.lblFeil.Location = new System.Drawing.Point(13, 187);
            this.lblFeil.Name = "lblFeil";
            this.lblFeil.Size = new System.Drawing.Size(161, 17);
            this.lblFeil.TabIndex = 6;
            this.lblFeil.Text = "Feil brukernavn/passord";
            this.lblFeil.Visible = false;
            // 
            // btnMistet
            // 
            this.btnMistet.Location = new System.Drawing.Point(16, 156);
            this.btnMistet.Name = "btnMistet";
            this.btnMistet.Size = new System.Drawing.Size(168, 28);
            this.btnMistet.TabIndex = 7;
            this.btnMistet.Text = "Mistet passord?";
            this.btnMistet.UseVisualStyleBackColor = true;
            this.btnMistet.Click += new System.EventHandler(this.btnMistet_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 213);
            this.Controls.Add(this.btnMistet);
            this.Controls.Add(this.lblFeil);
            this.Controls.Add(this.btnOpprett);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPassord);
            this.Controls.Add(this.tbNavn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNavn;
        private System.Windows.Forms.TextBox tbPassord;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnOpprett;
        private System.Windows.Forms.Label lblFeil;
        private System.Windows.Forms.Button btnMistet;
    }
}