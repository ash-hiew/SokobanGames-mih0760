namespace Sokoban
{
    partial class LevelDesignerForm
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
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.xSize = new System.Windows.Forms.NumericUpDown();
            this.ySize = new System.Windows.Forms.NumericUpDown();
            this.buildMapBtn = new System.Windows.Forms.Button();
            this.mapSizeContainer = new System.Windows.Forms.GroupBox();
            this.mapElementsContainer = new System.Windows.Forms.GroupBox();
            this.addEmptyBtn = new System.Windows.Forms.RadioButton();
            this.addGoalBtn = new System.Windows.Forms.RadioButton();
            this.addPlayerBtn = new System.Windows.Forms.RadioButton();
            this.addBlockBtn = new System.Windows.Forms.RadioButton();
            this.addWallBtn = new System.Windows.Forms.RadioButton();
            this.errorListBox = new System.Windows.Forms.ListBox();
            this.errorCheckContainer = new System.Windows.Forms.GroupBox();
            this.errorCheckBtn = new System.Windows.Forms.Button();
            this.loadSaveContainer = new System.Windows.Forms.GroupBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.mapContainer = new System.Windows.Forms.GroupBox();
            this.testBtn = new System.Windows.Forms.Button();
            this.testContainer = new System.Windows.Forms.GroupBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.addPlayerOnGoalBtn = new System.Windows.Forms.RadioButton();
            this.addBlockOnGoalBtn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.xSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySize)).BeginInit();
            this.mapSizeContainer.SuspendLayout();
            this.mapElementsContainer.SuspendLayout();
            this.errorCheckContainer.SuspendLayout();
            this.loadSaveContainer.SuspendLayout();
            this.testContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(14, 31);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 1;
            this.widthLabel.Text = "Width";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(14, 62);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(38, 13);
            this.heightLabel.TabIndex = 2;
            this.heightLabel.Text = "Height";
            // 
            // xSize
            // 
            this.xSize.Location = new System.Drawing.Point(56, 29);
            this.xSize.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.xSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.xSize.Name = "xSize";
            this.xSize.Size = new System.Drawing.Size(120, 20);
            this.xSize.TabIndex = 3;
            this.xSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // ySize
            // 
            this.ySize.Location = new System.Drawing.Point(56, 60);
            this.ySize.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.ySize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ySize.Name = "ySize";
            this.ySize.Size = new System.Drawing.Size(120, 20);
            this.ySize.TabIndex = 4;
            this.ySize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // buildMapBtn
            // 
            this.buildMapBtn.Location = new System.Drawing.Point(56, 93);
            this.buildMapBtn.Name = "buildMapBtn";
            this.buildMapBtn.Size = new System.Drawing.Size(75, 23);
            this.buildMapBtn.TabIndex = 5;
            this.buildMapBtn.Text = "Generate";
            this.buildMapBtn.UseVisualStyleBackColor = true;
            this.buildMapBtn.Click += new System.EventHandler(this.buildMapBtn_Click);
            // 
            // mapSizeContainer
            // 
            this.mapSizeContainer.Controls.Add(this.buildMapBtn);
            this.mapSizeContainer.Controls.Add(this.xSize);
            this.mapSizeContainer.Controls.Add(this.ySize);
            this.mapSizeContainer.Controls.Add(this.heightLabel);
            this.mapSizeContainer.Controls.Add(this.widthLabel);
            this.mapSizeContainer.Location = new System.Drawing.Point(43, 35);
            this.mapSizeContainer.Name = "mapSizeContainer";
            this.mapSizeContainer.Size = new System.Drawing.Size(200, 125);
            this.mapSizeContainer.TabIndex = 6;
            this.mapSizeContainer.TabStop = false;
            this.mapSizeContainer.Text = "Select Map Size";
            // 
            // mapElementsContainer
            // 
            this.mapElementsContainer.Controls.Add(this.addBlockOnGoalBtn);
            this.mapElementsContainer.Controls.Add(this.addPlayerOnGoalBtn);
            this.mapElementsContainer.Controls.Add(this.addEmptyBtn);
            this.mapElementsContainer.Controls.Add(this.addGoalBtn);
            this.mapElementsContainer.Controls.Add(this.addPlayerBtn);
            this.mapElementsContainer.Controls.Add(this.addBlockBtn);
            this.mapElementsContainer.Controls.Add(this.addWallBtn);
            this.mapElementsContainer.Location = new System.Drawing.Point(43, 166);
            this.mapElementsContainer.Name = "mapElementsContainer";
            this.mapElementsContainer.Size = new System.Drawing.Size(200, 183);
            this.mapElementsContainer.TabIndex = 7;
            this.mapElementsContainer.TabStop = false;
            this.mapElementsContainer.Text = "Add Map Elements";
            // 
            // addEmptyBtn
            // 
            this.addEmptyBtn.AutoSize = true;
            this.addEmptyBtn.Location = new System.Drawing.Point(17, 160);
            this.addEmptyBtn.Name = "addEmptyBtn";
            this.addEmptyBtn.Size = new System.Drawing.Size(74, 17);
            this.addEmptyBtn.TabIndex = 3;
            this.addEmptyBtn.TabStop = true;
            this.addEmptyBtn.Text = "Empty Tile";
            this.addEmptyBtn.UseVisualStyleBackColor = true;
            this.addEmptyBtn.CheckedChanged += new System.EventHandler(this.addEmptyBtn_CheckedChanged);
            // 
            // addGoalBtn
            // 
            this.addGoalBtn.AutoSize = true;
            this.addGoalBtn.Location = new System.Drawing.Point(17, 92);
            this.addGoalBtn.Name = "addGoalBtn";
            this.addGoalBtn.Size = new System.Drawing.Size(47, 17);
            this.addGoalBtn.TabIndex = 2;
            this.addGoalBtn.TabStop = true;
            this.addGoalBtn.Text = "Goal";
            this.addGoalBtn.UseVisualStyleBackColor = true;
            this.addGoalBtn.CheckedChanged += new System.EventHandler(this.addGoalBtn_CheckedChanged);
            // 
            // addPlayerBtn
            // 
            this.addPlayerBtn.AutoSize = true;
            this.addPlayerBtn.Location = new System.Drawing.Point(17, 45);
            this.addPlayerBtn.Name = "addPlayerBtn";
            this.addPlayerBtn.Size = new System.Drawing.Size(54, 17);
            this.addPlayerBtn.TabIndex = 1;
            this.addPlayerBtn.TabStop = true;
            this.addPlayerBtn.Text = "Player";
            this.addPlayerBtn.UseVisualStyleBackColor = true;
            this.addPlayerBtn.CheckedChanged += new System.EventHandler(this.addPlayerBtn_CheckedChanged);
            // 
            // addBlockBtn
            // 
            this.addBlockBtn.AutoSize = true;
            this.addBlockBtn.Location = new System.Drawing.Point(17, 68);
            this.addBlockBtn.Name = "addBlockBtn";
            this.addBlockBtn.Size = new System.Drawing.Size(52, 17);
            this.addBlockBtn.TabIndex = 0;
            this.addBlockBtn.TabStop = true;
            this.addBlockBtn.Text = "Block";
            this.addBlockBtn.UseVisualStyleBackColor = true;
            this.addBlockBtn.CheckedChanged += new System.EventHandler(this.addBlockBtn_CheckedChanged);
            // 
            // addWallBtn
            // 
            this.addWallBtn.AutoSize = true;
            this.addWallBtn.Location = new System.Drawing.Point(17, 21);
            this.addWallBtn.Name = "addWallBtn";
            this.addWallBtn.Size = new System.Drawing.Size(46, 17);
            this.addWallBtn.TabIndex = 0;
            this.addWallBtn.TabStop = true;
            this.addWallBtn.Text = "Wall";
            this.addWallBtn.UseVisualStyleBackColor = true;
            this.addWallBtn.CheckedChanged += new System.EventHandler(this.addWallBtn_CheckedChanged);
            // 
            // errorListBox
            // 
            this.errorListBox.FormattingEnabled = true;
            this.errorListBox.Location = new System.Drawing.Point(6, 19);
            this.errorListBox.Name = "errorListBox";
            this.errorListBox.Size = new System.Drawing.Size(188, 147);
            this.errorListBox.TabIndex = 8;
            // 
            // errorCheckContainer
            // 
            this.errorCheckContainer.Controls.Add(this.errorCheckBtn);
            this.errorCheckContainer.Controls.Add(this.errorListBox);
            this.errorCheckContainer.Location = new System.Drawing.Point(43, 355);
            this.errorCheckContainer.Name = "errorCheckContainer";
            this.errorCheckContainer.Size = new System.Drawing.Size(200, 204);
            this.errorCheckContainer.TabIndex = 10;
            this.errorCheckContainer.TabStop = false;
            this.errorCheckContainer.Text = "Error Checker";
            // 
            // errorCheckBtn
            // 
            this.errorCheckBtn.Location = new System.Drawing.Point(56, 172);
            this.errorCheckBtn.Name = "errorCheckBtn";
            this.errorCheckBtn.Size = new System.Drawing.Size(75, 23);
            this.errorCheckBtn.TabIndex = 9;
            this.errorCheckBtn.Text = "Check";
            this.errorCheckBtn.UseVisualStyleBackColor = true;
            this.errorCheckBtn.Click += new System.EventHandler(this.errorCheckBtn_Click);
            // 
            // loadSaveContainer
            // 
            this.loadSaveContainer.Controls.Add(this.saveBtn);
            this.loadSaveContainer.Controls.Add(this.loadBtn);
            this.loadSaveContainer.Location = new System.Drawing.Point(43, 566);
            this.loadSaveContainer.Name = "loadSaveContainer";
            this.loadSaveContainer.Size = new System.Drawing.Size(200, 56);
            this.loadSaveContainer.TabIndex = 11;
            this.loadSaveContainer.TabStop = false;
            this.loadSaveContainer.Text = "Load/Save Map";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(110, 20);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(17, 20);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(75, 23);
            this.loadBtn.TabIndex = 0;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // mapContainer
            // 
            this.mapContainer.Location = new System.Drawing.Point(250, 35);
            this.mapContainer.Name = "mapContainer";
            this.mapContainer.Size = new System.Drawing.Size(676, 674);
            this.mapContainer.TabIndex = 12;
            this.mapContainer.TabStop = false;
            this.mapContainer.Text = "Map Environment";
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(56, 19);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(75, 23);
            this.testBtn.TabIndex = 0;
            this.testBtn.Text = "Test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.testBtn_Click_1);
            // 
            // testContainer
            // 
            this.testContainer.Controls.Add(this.testBtn);
            this.testContainer.Location = new System.Drawing.Point(43, 629);
            this.testContainer.Name = "testContainer";
            this.testContainer.Size = new System.Drawing.Size(200, 51);
            this.testContainer.TabIndex = 13;
            this.testContainer.TabStop = false;
            this.testContainer.Text = "Test Map Creation";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(153, 686);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 14;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(49, 686);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 23);
            this.resetBtn.TabIndex = 15;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // addPlayerOnGoalBtn
            // 
            this.addPlayerOnGoalBtn.AutoSize = true;
            this.addPlayerOnGoalBtn.Location = new System.Drawing.Point(17, 115);
            this.addPlayerOnGoalBtn.Name = "addPlayerOnGoalBtn";
            this.addPlayerOnGoalBtn.Size = new System.Drawing.Size(94, 17);
            this.addPlayerOnGoalBtn.TabIndex = 4;
            this.addPlayerOnGoalBtn.TabStop = true;
            this.addPlayerOnGoalBtn.Text = "Player on Goal";
            this.addPlayerOnGoalBtn.UseVisualStyleBackColor = true;
            this.addPlayerOnGoalBtn.CheckedChanged += new System.EventHandler(this.addPlayerOnGoalBtn_CheckedChanged);
            // 
            // addBlockOnGoalBtn
            // 
            this.addBlockOnGoalBtn.AutoSize = true;
            this.addBlockOnGoalBtn.Location = new System.Drawing.Point(17, 139);
            this.addBlockOnGoalBtn.Name = "addBlockOnGoalBtn";
            this.addBlockOnGoalBtn.Size = new System.Drawing.Size(92, 17);
            this.addBlockOnGoalBtn.TabIndex = 5;
            this.addBlockOnGoalBtn.TabStop = true;
            this.addBlockOnGoalBtn.Text = "Block on Goal";
            this.addBlockOnGoalBtn.UseVisualStyleBackColor = true;
            this.addBlockOnGoalBtn.CheckedChanged += new System.EventHandler(this.addBlockOnGoalBtn_CheckedChanged);
            // 
            // LevelDesignerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(965, 749);
            this.ControlBox = false;
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.loadSaveContainer);
            this.Controls.Add(this.errorCheckContainer);
            this.Controls.Add(this.mapElementsContainer);
            this.Controls.Add(this.mapSizeContainer);
            this.Controls.Add(this.testContainer);
            this.Controls.Add(this.mapContainer);
            this.Name = "LevelDesignerForm";
            this.Text = "Level Designer";
            ((System.ComponentModel.ISupportInitialize)(this.xSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ySize)).EndInit();
            this.mapSizeContainer.ResumeLayout(false);
            this.mapSizeContainer.PerformLayout();
            this.mapElementsContainer.ResumeLayout(false);
            this.mapElementsContainer.PerformLayout();
            this.errorCheckContainer.ResumeLayout(false);
            this.loadSaveContainer.ResumeLayout(false);
            this.testContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.NumericUpDown xSize;
        private System.Windows.Forms.NumericUpDown ySize;
        private System.Windows.Forms.Button buildMapBtn;
        private System.Windows.Forms.GroupBox mapSizeContainer;
        private System.Windows.Forms.GroupBox mapElementsContainer;
        private System.Windows.Forms.RadioButton addEmptyBtn;
        private System.Windows.Forms.RadioButton addGoalBtn;
        private System.Windows.Forms.RadioButton addPlayerBtn;
        private System.Windows.Forms.RadioButton addBlockBtn;
        private System.Windows.Forms.RadioButton addWallBtn;
        private System.Windows.Forms.ListBox errorListBox;
        private System.Windows.Forms.GroupBox errorCheckContainer;
        private System.Windows.Forms.Button errorCheckBtn;
        private System.Windows.Forms.GroupBox loadSaveContainer;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.GroupBox mapContainer;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.GroupBox testContainer;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.RadioButton addBlockOnGoalBtn;
        private System.Windows.Forms.RadioButton addPlayerOnGoalBtn;
    }
}