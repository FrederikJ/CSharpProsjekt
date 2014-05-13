namespace tempNavn
{
    partial class BallSpill
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label_tid = new System.Windows.Forms.Label();
            this.label_poeng = new System.Windows.Forms.Label();
            this.label_level = new System.Windows.Forms.Label();
            this.btn_pause = new System.Windows.Forms.Button();
            this.panelDraw = new tempNavn.MyPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelDraw, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.95349F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.04651F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(599, 344);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btn_pause);
            this.panelButton.Controls.Add(this.label_level);
            this.panelButton.Controls.Add(this.label_poeng);
            this.panelButton.Controls.Add(this.label_tid);
            this.panelButton.Controls.Add(this.buttonStart);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButton.Location = new System.Drawing.Point(3, 309);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(593, 32);
            this.panelButton.TabIndex = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(4, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label_tid
            // 
            this.label_tid.AutoSize = true;
            this.label_tid.Location = new System.Drawing.Point(226, 9);
            this.label_tid.Name = "label_tid";
            this.label_tid.Size = new System.Drawing.Size(129, 13);
            this.label_tid.TabIndex = 1;
            this.label_tid.Text = "Gjenstående tid: 00:01:45";
            // 
            // label_poeng
            // 
            this.label_poeng.AutoSize = true;
            this.label_poeng.Location = new System.Drawing.Point(419, 9);
            this.label_poeng.Name = "label_poeng";
            this.label_poeng.Size = new System.Drawing.Size(62, 13);
            this.label_poeng.TabIndex = 2;
            this.label_poeng.Text = "Poeng: 734";
            // 
            // label_level
            // 
            this.label_level.AutoSize = true;
            this.label_level.Location = new System.Drawing.Point(539, 9);
            this.label_level.Name = "label_level";
            this.label_level.Size = new System.Drawing.Size(45, 13);
            this.label_level.TabIndex = 3;
            this.label_level.Text = "Level: 3";
            // 
            // btn_pause
            // 
            this.btn_pause.Location = new System.Drawing.Point(85, 4);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(75, 23);
            this.btn_pause.TabIndex = 4;
            this.btn_pause.Text = "Pause";
            this.btn_pause.UseVisualStyleBackColor = true;
            // 
            // panelDraw
            // 
            this.panelDraw.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDraw.Location = new System.Drawing.Point(3, 3);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(593, 300);
            this.panelDraw.TabIndex = 2;
            // 
            // BouncingBall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 344);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BouncingBall";
            this.Text = "Figurer . . .";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button buttonStart;
        private MyPanel panelDraw;
        private System.Windows.Forms.Label label_level;
        private System.Windows.Forms.Label label_poeng;
        private System.Windows.Forms.Label label_tid;
        private System.Windows.Forms.Button btn_pause;
    }
}

