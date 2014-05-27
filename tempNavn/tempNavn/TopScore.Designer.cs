namespace CSharpProsjekt
{
    partial class TopScore
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
            this.dgvScore = new System.Windows.Forms.DataGridView();
            this.clmPlassering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvScore
            // 
            this.dgvScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmPlassering});
            this.dgvScore.Location = new System.Drawing.Point(12, 12);
            this.dgvScore.Name = "dgvScore";
            this.dgvScore.ReadOnly = true;
            this.dgvScore.RowTemplate.Height = 24;
            this.dgvScore.Size = new System.Drawing.Size(591, 324);
            this.dgvScore.TabIndex = 0;
            this.dgvScore.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvScore_RowPostPaint);
            // 
            // clmPlassering
            // 
            this.clmPlassering.FillWeight = 10F;
            this.clmPlassering.HeaderText = "Plassering";
            this.clmPlassering.MaxInputLength = 10;
            this.clmPlassering.Name = "clmPlassering";
            this.clmPlassering.ReadOnly = true;
            // 
            // TopScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 346);
            this.Controls.Add(this.dgvScore);
            this.MaximizeBox = false;
            this.Name = "TopScore";
            this.Text = "TopScore";
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPlassering;
    }
}