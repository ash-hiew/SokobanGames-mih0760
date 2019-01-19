namespace SokobanExampleSolution
{
    partial class GameBoardF
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
            this.gameLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // gameLayoutPanel1
            // 
            this.gameLayoutPanel1.AutoSize = true;
            this.gameLayoutPanel1.BackColor = System.Drawing.Color.Turquoise;
            this.gameLayoutPanel1.ColumnCount = 2;
            this.gameLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gameLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gameLayoutPanel1.Location = new System.Drawing.Point(2, 53);
            this.gameLayoutPanel1.Name = "gameLayoutPanel1";
            this.gameLayoutPanel1.RowCount = 2;
            this.gameLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gameLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gameLayoutPanel1.Size = new System.Drawing.Size(86, 81);
            this.gameLayoutPanel1.TabIndex = 2;
            // 
            // GameBoardF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.gameLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameBoardF";
            this.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.Text = "GameBoardF";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameBoardForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel gameLayoutPanel1;
    }
}