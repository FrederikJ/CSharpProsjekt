namespace CSharpProsjekt
{
    partial class MistetPassord
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.btnEmail = new System.Windows.Forms.Button();
            this.lblFeil = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassord = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Få tilsendt nytt passord";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 66);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 17);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(18, 86);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(207, 22);
            this.tbEmail.TabIndex = 2;
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(18, 114);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(207, 39);
            this.btnEmail.TabIndex = 3;
            this.btnEmail.Text = "Send";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // lblFeil
            // 
            this.lblFeil.AutoSize = true;
            this.lblFeil.ForeColor = System.Drawing.Color.Crimson;
            this.lblFeil.Location = new System.Drawing.Point(15, 202);
            this.lblFeil.Name = "lblFeil";
            this.lblFeil.Size = new System.Drawing.Size(136, 17);
            this.lblFeil.TabIndex = 4;
            this.lblFeil.Text = "E-posten finnes ikke";
            this.lblFeil.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Passordet ditt er:";
            // 
            // tbPassord
            // 
            this.tbPassord.Location = new System.Drawing.Point(18, 177);
            this.tbPassord.Name = "tbPassord";
            this.tbPassord.Size = new System.Drawing.Size(207, 22);
            this.tbPassord.TabIndex = 6;
            // 
            // MistetPassord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 226);
            this.Controls.Add(this.tbPassord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFeil);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.label1);
            this.Name = "MistetPassord";
            this.Text = "MistetPassord";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label lblFeil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassord;
    }
}