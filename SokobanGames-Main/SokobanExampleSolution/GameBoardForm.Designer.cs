namespace Sokoban
{
    partial class GameBoardForm
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
            this.LoadGameButton = new System.Windows.Forms.Button();
            this.mapDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.MoveCountNumber = new System.Windows.Forms.Label();
            this.PlayerMoveHistoryLabel = new System.Windows.Forms.Label();
            this.PlayerMoveHistory = new System.Windows.Forms.Label();
            this.undoBtn = new System.Windows.Forms.Button();
            this.MoveCountLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveStateBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.loadStateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadGameButton
            // 
            this.LoadGameButton.Location = new System.Drawing.Point(12, 32);
            this.LoadGameButton.Name = "LoadGameButton";
            this.LoadGameButton.Size = new System.Drawing.Size(75, 23);
            this.LoadGameButton.TabIndex = 0;
            this.LoadGameButton.Text = "Load Level";
            this.LoadGameButton.UseVisualStyleBackColor = true;
            this.LoadGameButton.Click += new System.EventHandler(this.Loadbutton_Click);
            // 
            // mapDisplay
            // 
            this.mapDisplay.AutoSize = true;
            this.mapDisplay.BackColor = System.Drawing.Color.LightBlue;
            this.mapDisplay.ColumnCount = 10;
            this.mapDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.Location = new System.Drawing.Point(174, 130);
            this.mapDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.mapDisplay.Name = "mapDisplay";
            this.mapDisplay.Padding = new System.Windows.Forms.Padding(19, 20, 19, 20);
            this.mapDisplay.RowCount = 10;
            this.mapDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mapDisplay.Size = new System.Drawing.Size(131, 132);
            this.mapDisplay.TabIndex = 1;
            this.mapDisplay.Visible = false;
            // 
            // StartGameButton
            // 
            this.StartGameButton.Enabled = false;
            this.StartGameButton.Location = new System.Drawing.Point(174, 32);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(75, 23);
            this.StartGameButton.TabIndex = 2;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // ResetBtn
            // 
            this.ResetBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ResetBtn.Location = new System.Drawing.Point(12, 119);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(75, 23);
            this.ResetBtn.TabIndex = 3;
            this.ResetBtn.Text = "Restart Level";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // MoveCountNumber
            // 
            this.MoveCountNumber.AutoSize = true;
            this.MoveCountNumber.Enabled = false;
            this.MoveCountNumber.Location = new System.Drawing.Point(249, 70);
            this.MoveCountNumber.Name = "MoveCountNumber";
            this.MoveCountNumber.Size = new System.Drawing.Size(13, 13);
            this.MoveCountNumber.TabIndex = 5;
            this.MoveCountNumber.Text = "0";
            // 
            // PlayerMoveHistoryLabel
            // 
            this.PlayerMoveHistoryLabel.AutoSize = true;
            this.PlayerMoveHistoryLabel.Enabled = false;
            this.PlayerMoveHistoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerMoveHistoryLabel.Location = new System.Drawing.Point(172, 96);
            this.PlayerMoveHistoryLabel.Name = "PlayerMoveHistoryLabel";
            this.PlayerMoveHistoryLabel.Size = new System.Drawing.Size(124, 13);
            this.PlayerMoveHistoryLabel.TabIndex = 6;
            this.PlayerMoveHistoryLabel.Text = "Player Move History:";
            // 
            // PlayerMoveHistory
            // 
            this.PlayerMoveHistory.AutoSize = true;
            this.PlayerMoveHistory.Enabled = false;
            this.PlayerMoveHistory.Location = new System.Drawing.Point(296, 96);
            this.PlayerMoveHistory.Name = "PlayerMoveHistory";
            this.PlayerMoveHistory.Size = new System.Drawing.Size(33, 13);
            this.PlayerMoveHistory.TabIndex = 7;
            this.PlayerMoveHistory.Text = "None";
            // 
            // undoBtn
            // 
            this.undoBtn.Location = new System.Drawing.Point(285, 32);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(75, 23);
            this.undoBtn.TabIndex = 8;
            this.undoBtn.Text = "Undo Move";
            this.undoBtn.UseVisualStyleBackColor = true;
            this.undoBtn.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // MoveCountLabel
            // 
            this.MoveCountLabel.AutoSize = true;
            this.MoveCountLabel.Enabled = false;
            this.MoveCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveCountLabel.Location = new System.Drawing.Point(172, 70);
            this.MoveCountLabel.Name = "MoveCountLabel";
            this.MoveCountLabel.Size = new System.Drawing.Size(79, 13);
            this.MoveCountLabel.TabIndex = 4;
            this.MoveCountLabel.Text = "Move Count:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.InitialDirectory = "@\"C:\\\"";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Browse Files";
            // 
            // saveStateBtn
            // 
            this.saveStateBtn.Location = new System.Drawing.Point(12, 61);
            this.saveStateBtn.Name = "saveStateBtn";
            this.saveStateBtn.Size = new System.Drawing.Size(75, 23);
            this.saveStateBtn.TabIndex = 9;
            this.saveStateBtn.Text = "Save State";
            this.saveStateBtn.UseVisualStyleBackColor = true;
            this.saveStateBtn.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(12, 184);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // loadStateBtn
            // 
            this.loadStateBtn.Location = new System.Drawing.Point(12, 90);
            this.loadStateBtn.Name = "loadStateBtn";
            this.loadStateBtn.Size = new System.Drawing.Size(75, 23);
            this.loadStateBtn.TabIndex = 11;
            this.loadStateBtn.Text = "Load State";
            this.loadStateBtn.UseVisualStyleBackColor = true;
            this.loadStateBtn.Click += new System.EventHandler(this.loadStateBtn_Click);
            // 
            // GameBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.ResetBtn;
            this.ClientSize = new System.Drawing.Size(865, 541);
            this.ControlBox = false;
            this.Controls.Add(this.loadStateBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveStateBtn);
            this.Controls.Add(this.undoBtn);
            this.Controls.Add(this.PlayerMoveHistory);
            this.Controls.Add(this.PlayerMoveHistoryLabel);
            this.Controls.Add(this.MoveCountNumber);
            this.Controls.Add(this.MoveCountLabel);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.mapDisplay);
            this.Controls.Add(this.LoadGameButton);
            this.KeyPreview = true;
            this.Name = "GameBoardForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 22, 24);
            this.Text = "GameBoardForm";
            this.Load += new System.EventHandler(this.GameBoardForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameBoardForm_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadGameButton;
        private System.Windows.Forms.TableLayoutPanel mapDisplay;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Label MoveCountNumber;
        private System.Windows.Forms.Label PlayerMoveHistoryLabel;
        private System.Windows.Forms.Label PlayerMoveHistory;
        private System.Windows.Forms.Button undoBtn;
        private System.Windows.Forms.Label MoveCountLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button saveStateBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button loadStateBtn;
    }
}