namespace CSharpProsjekt
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
            this.btn_pause = new System.Windows.Forms.Button();
            this.label_level = new System.Windows.Forms.Label();
            this.label_poeng = new System.Windows.Forms.Label();
            this.label_tid = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.valgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hjekoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nyttSpillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggUtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reglerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelDraw = new CSharpProsjekt.MyPanel();
            this.btn_finish = new System.Windows.Forms.Button();
            this.tb_finish = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelDraw.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDraw, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.99134F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.008658F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 451);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelButton
            // 
            this.panelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelButton.Controls.Add(this.btn_pause);
            this.panelButton.Controls.Add(this.label_level);
            this.panelButton.Controls.Add(this.label_poeng);
            this.panelButton.Controls.Add(this.label_tid);
            this.panelButton.Controls.Add(this.buttonStart);
            this.panelButton.Location = new System.Drawing.Point(3, 417);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(728, 31);
            this.panelButton.TabIndex = 1;
            // 
            // btn_pause
            // 
            this.btn_pause.Location = new System.Drawing.Point(85, 4);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(75, 23);
            this.btn_pause.TabIndex = 4;
            this.btn_pause.Text = "Pause";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // label_level
            // 
            this.label_level.AutoSize = true;
            this.label_level.Location = new System.Drawing.Point(539, 9);
            this.label_level.Name = "label_level";
            this.label_level.Size = new System.Drawing.Size(45, 13);
            this.label_level.TabIndex = 3;
            this.label_level.Text = "Level: 1";
            // 
            // label_poeng
            // 
            this.label_poeng.AutoSize = true;
            this.label_poeng.Location = new System.Drawing.Point(419, 9);
            this.label_poeng.Name = "label_poeng";
            this.label_poeng.Size = new System.Drawing.Size(50, 13);
            this.label_poeng.TabIndex = 2;
            this.label_poeng.Text = "Poeng: 0";
            // 
            // label_tid
            // 
            this.label_tid.AutoSize = true;
            this.label_tid.Location = new System.Drawing.Point(226, 9);
            this.label_tid.Name = "label_tid";
            this.label_tid.Size = new System.Drawing.Size(87, 13);
            this.label_tid.TabIndex = 1;
            this.label_tid.Text = "Gjenstående tid: ";
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.valgToolStripMenuItem,
            this.hjekoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // valgToolStripMenuItem
            // 
            this.valgToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nyttSpillToolStripMenuItem,
            this.loggUtToolStripMenuItem});
            this.valgToolStripMenuItem.Name = "valgToolStripMenuItem";
            this.valgToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.valgToolStripMenuItem.Text = "Valg";
            // 
            // hjekoToolStripMenuItem
            // 
            this.hjekoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reglerToolStripMenuItem});
            this.hjekoToolStripMenuItem.Name = "hjekoToolStripMenuItem";
            this.hjekoToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hjekoToolStripMenuItem.Text = "Hjelp";
            // 
            // nyttSpillToolStripMenuItem
            // 
            this.nyttSpillToolStripMenuItem.Name = "nyttSpillToolStripMenuItem";
            this.nyttSpillToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.nyttSpillToolStripMenuItem.Text = "Nytt spill";
            // 
            // loggUtToolStripMenuItem
            // 
            this.loggUtToolStripMenuItem.Name = "loggUtToolStripMenuItem";
            this.loggUtToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.loggUtToolStripMenuItem.Text = "Logg ut";
            // 
            // reglerToolStripMenuItem
            // 
            this.reglerToolStripMenuItem.Name = "reglerToolStripMenuItem";
            this.reglerToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.reglerToolStripMenuItem.Text = "Regler";
            this.reglerToolStripMenuItem.Click += new System.EventHandler(this.reglerToolStripMenuItem_Click);
            // 
            // panelDraw
            // 
            this.panelDraw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDraw.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelDraw.Controls.Add(this.btn_finish);
            this.panelDraw.Controls.Add(this.tb_finish);
            this.panelDraw.Location = new System.Drawing.Point(3, 5);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(728, 404);
            this.panelDraw.TabIndex = 2;
            // 
            // btn_finish
            // 
            this.btn_finish.Location = new System.Drawing.Point(297, 233);
            this.btn_finish.Name = "btn_finish";
            this.btn_finish.Size = new System.Drawing.Size(75, 23);
            this.btn_finish.TabIndex = 1;
            this.btn_finish.Text = "Neste level";
            this.btn_finish.UseVisualStyleBackColor = true;
            this.btn_finish.Visible = false;
            this.btn_finish.Click += new System.EventHandler(this.btn_finish_Click);
            // 
            // tb_finish
            // 
            this.tb_finish.Location = new System.Drawing.Point(229, 146);
            this.tb_finish.Multiline = true;
            this.tb_finish.Name = "tb_finish";
            this.tb_finish.ReadOnly = true;
            this.tb_finish.Size = new System.Drawing.Size(216, 81);
            this.tb_finish.TabIndex = 0;
            this.tb_finish.Visible = false;
            // 
            // BallSpill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 475);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "BallSpill";
            this.Text = "Figurer . . .";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelDraw.ResumeLayout(false);
            this.panelDraw.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btn_finish;
        private System.Windows.Forms.TextBox tb_finish;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem valgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hjekoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nyttSpillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggUtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reglerToolStripMenuItem;
    }
}
