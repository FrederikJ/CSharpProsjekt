namespace CSharpProsjekt
{
    partial class PlayBall
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
            this.PanelHolder = new System.Windows.Forms.TableLayoutPanel();
            this.panelDraw = new CSharpProsjekt.MyPanel();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.lblFeil = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_LevelFinished = new System.Windows.Forms.TextBox();
            this.btn_NextLevel = new System.Windows.Forms.Button();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btn_pause = new System.Windows.Forms.Button();
            this.label_level = new System.Windows.Forms.Label();
            this.label_poeng = new System.Windows.Forms.Label();
            this.label_tid = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.valgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nyttSpillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.opprettBrukerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.loggUtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reglerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelHolder.SuspendLayout();
            this.panelDraw.SuspendLayout();
            this.LoginPanel.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelHolder
            // 
            this.PanelHolder.ColumnCount = 1;
            this.PanelHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelHolder.Controls.Add(this.panelDraw, 0, 0);
            this.PanelHolder.Controls.Add(this.panelButton, 0, 1);
            this.PanelHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelHolder.Location = new System.Drawing.Point(0, 28);
            this.PanelHolder.Margin = new System.Windows.Forms.Padding(4);
            this.PanelHolder.Name = "PanelHolder";
            this.PanelHolder.RowCount = 2;
            this.PanelHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.99134F));
            this.PanelHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.008658F));
            this.PanelHolder.Size = new System.Drawing.Size(979, 557);
            this.PanelHolder.TabIndex = 0;
            // 
            // panelDraw
            // 
            this.panelDraw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDraw.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelDraw.BackgroundImage = global::CSharpProsjekt.Resource.WallBackground;
            this.panelDraw.Controls.Add(this.LoginPanel);
            this.panelDraw.Controls.Add(this.tb_LevelFinished);
            this.panelDraw.Controls.Add(this.btn_NextLevel);
            this.panelDraw.Location = new System.Drawing.Point(4, 7);
            this.panelDraw.Margin = new System.Windows.Forms.Padding(4);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(971, 497);
            this.panelDraw.TabIndex = 2;
            this.panelDraw.Click += new System.EventHandler(this.panelDraw_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.LoginPanel.BackgroundImage = global::CSharpProsjekt.Resource.DotWars;
            this.LoginPanel.Controls.Add(this.lblFeil);
            this.LoginPanel.Controls.Add(this.btnLogin);
            this.LoginPanel.Controls.Add(this.tbPassword);
            this.LoginPanel.Controls.Add(this.tbName);
            this.LoginPanel.Controls.Add(this.label2);
            this.LoginPanel.Controls.Add(this.label1);
            this.LoginPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPanel.Margin = new System.Windows.Forms.Padding(4);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(971, 497);
            this.LoginPanel.TabIndex = 4;
            // 
            // lblFeil
            // 
            this.lblFeil.AutoSize = true;
            this.lblFeil.BackColor = System.Drawing.Color.Transparent;
            this.lblFeil.ForeColor = System.Drawing.Color.Crimson;
            this.lblFeil.Location = new System.Drawing.Point(412, 121);
            this.lblFeil.Name = "lblFeil";
            this.lblFeil.Size = new System.Drawing.Size(161, 17);
            this.lblFeil.TabIndex = 16;
            this.lblFeil.Text = "Feil brukernavn/passord";
            this.lblFeil.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(407, 87);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(168, 31);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(473, 58);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 22);
            this.tbPassword.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(473, 27);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 22);
            this.tbName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(403, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Passord:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(403, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Navn:";
            // 
            // tb_LevelFinished
            // 
            this.tb_LevelFinished.Location = new System.Drawing.Point(368, 203);
            this.tb_LevelFinished.Margin = new System.Windows.Forms.Padding(4);
            this.tb_LevelFinished.Multiline = true;
            this.tb_LevelFinished.Name = "tb_LevelFinished";
            this.tb_LevelFinished.ReadOnly = true;
            this.tb_LevelFinished.Size = new System.Drawing.Size(236, 29);
            this.tb_LevelFinished.TabIndex = 5;
            this.tb_LevelFinished.Text = "Gratulerer, du har klart dette nivået! ";
            this.tb_LevelFinished.Visible = false;
            // 
            // btn_NextLevel
            // 
            this.btn_NextLevel.Location = new System.Drawing.Point(440, 240);
            this.btn_NextLevel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_NextLevel.Name = "btn_NextLevel";
            this.btn_NextLevel.Size = new System.Drawing.Size(100, 28);
            this.btn_NextLevel.TabIndex = 6;
            this.btn_NextLevel.Text = "Neste level";
            this.btn_NextLevel.UseVisualStyleBackColor = true;
            this.btn_NextLevel.Visible = false;
            this.btn_NextLevel.Click += new System.EventHandler(this.btn_NextLevel_Click);
            // 
            // panelButton
            // 
            this.panelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelButton.Controls.Add(this.btn_pause);
            this.panelButton.Controls.Add(this.label_level);
            this.panelButton.Controls.Add(this.label_poeng);
            this.panelButton.Controls.Add(this.label_tid);
            this.panelButton.Location = new System.Drawing.Point(4, 516);
            this.panelButton.Margin = new System.Windows.Forms.Padding(4);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(971, 37);
            this.panelButton.TabIndex = 1;
            // 
            // btn_pause
            // 
            this.btn_pause.Location = new System.Drawing.Point(12, 5);
            this.btn_pause.Margin = new System.Windows.Forms.Padding(4);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(100, 28);
            this.btn_pause.TabIndex = 4;
            this.btn_pause.Text = "Pause";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // label_level
            // 
            this.label_level.AutoSize = true;
            this.label_level.Location = new System.Drawing.Point(863, 11);
            this.label_level.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_level.Name = "label_level";
            this.label_level.Size = new System.Drawing.Size(50, 17);
            this.label_level.TabIndex = 3;
            this.label_level.Text = "Level: ";
            // 
            // label_poeng
            // 
            this.label_poeng.AutoSize = true;
            this.label_poeng.Location = new System.Drawing.Point(493, 11);
            this.label_poeng.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_poeng.Name = "label_poeng";
            this.label_poeng.Size = new System.Drawing.Size(57, 17);
            this.label_poeng.TabIndex = 2;
            this.label_poeng.Text = "Poeng: ";
            // 
            // label_tid
            // 
            this.label_tid.AutoSize = true;
            this.label_tid.Location = new System.Drawing.Point(168, 11);
            this.label_tid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_tid.Name = "label_tid";
            this.label_tid.Size = new System.Drawing.Size(116, 17);
            this.label_tid.TabIndex = 1;
            this.label_tid.Text = "Gjenstående tid: ";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.valgToolStripMenuItem,
            this.topScoreToolStripMenuItem,
            this.reglerToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(979, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // valgToolStripMenuItem
            // 
            this.valgToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nyttSpillToolStripMenuItem,
            this.toolStripSeparator1,
            this.opprettBrukerToolStripMenuItem,
            this.toolStripSeparator2,
            this.loggUtToolStripMenuItem});
            this.valgToolStripMenuItem.Name = "valgToolStripMenuItem";
            this.valgToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.valgToolStripMenuItem.Text = "Valg";
            // 
            // nyttSpillToolStripMenuItem
            // 
            this.nyttSpillToolStripMenuItem.Name = "nyttSpillToolStripMenuItem";
            this.nyttSpillToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.nyttSpillToolStripMenuItem.Text = "Nytt spill";
            this.nyttSpillToolStripMenuItem.Click += new System.EventHandler(this.nyttSpillToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // opprettBrukerToolStripMenuItem
            // 
            this.opprettBrukerToolStripMenuItem.Name = "opprettBrukerToolStripMenuItem";
            this.opprettBrukerToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.opprettBrukerToolStripMenuItem.Text = "Opprett bruker";
            this.opprettBrukerToolStripMenuItem.Click += new System.EventHandler(this.opprettBrukerToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // loggUtToolStripMenuItem
            // 
            this.loggUtToolStripMenuItem.Name = "loggUtToolStripMenuItem";
            this.loggUtToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.loggUtToolStripMenuItem.Text = "Logg ut";
            this.loggUtToolStripMenuItem.Click += new System.EventHandler(this.loggUtToolStripMenuItem_Click);
            // 
            // topScoreToolStripMenuItem
            // 
            this.topScoreToolStripMenuItem.Name = "topScoreToolStripMenuItem";
            this.topScoreToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.topScoreToolStripMenuItem.Text = "Top score";
            this.topScoreToolStripMenuItem.Click += new System.EventHandler(this.topScoreToolStripMenuItem_Click);
            // 
            // reglerToolStripMenuItem
            // 
            this.reglerToolStripMenuItem.Name = "reglerToolStripMenuItem";
            this.reglerToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.reglerToolStripMenuItem.Text = "Regler";
            this.reglerToolStripMenuItem.Click += new System.EventHandler(this.reglerToolStripMenuItem_Click);
            // 
            // PlayBall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 585);
            this.Controls.Add(this.PanelHolder);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "PlayBall";
            this.Text = "DotWars";
            this.PanelHolder.ResumeLayout(false);
            this.panelDraw.ResumeLayout(false);
            this.panelDraw.PerformLayout();
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PanelHolder;
        private System.Windows.Forms.Panel panelButton;
        private MyPanel panelDraw;
        private System.Windows.Forms.Label label_level;
        private System.Windows.Forms.Label label_poeng;
        private System.Windows.Forms.Label label_tid;
        private System.Windows.Forms.Label lblFeil;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem valgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nyttSpillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggUtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reglerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opprettBrukerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_NextLevel;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tb_LevelFinished;
    }
}