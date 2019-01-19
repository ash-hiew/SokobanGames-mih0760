namespace Sokoban
{
    partial class FilerForm
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.labelLoadItem = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SaveItemLabel = new System.Windows.Forms.Label();
            this.labelRecentSave = new System.Windows.Forms.Label();
            this.linkRecent = new System.Windows.Forms.LinkLabel();
            this.labelFileLocation = new System.Windows.Forms.Label();
            this.recentPathLabel = new System.Windows.Forms.Label();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.labelFiles = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listMsg = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(114, 32);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // labelLoadItem
            // 
            this.labelLoadItem.AutoSize = true;
            this.labelLoadItem.Location = new System.Drawing.Point(215, 37);
            this.labelLoadItem.Name = "labelLoadItem";
            this.labelLoadItem.Size = new System.Drawing.Size(111, 13);
            this.labelLoadItem.TabIndex = 1;
            this.labelLoadItem.Text = "No Selected Filename";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(114, 75);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // SaveItemLabel
            // 
            this.SaveItemLabel.AutoSize = true;
            this.SaveItemLabel.Location = new System.Drawing.Point(215, 80);
            this.SaveItemLabel.Name = "SaveItemLabel";
            this.SaveItemLabel.Size = new System.Drawing.Size(111, 13);
            this.SaveItemLabel.TabIndex = 3;
            this.SaveItemLabel.Text = "No Selected Filename";
            // 
            // labelRecentSave
            // 
            this.labelRecentSave.AutoSize = true;
            this.labelRecentSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecentSave.Location = new System.Drawing.Point(72, 399);
            this.labelRecentSave.Name = "labelRecentSave";
            this.labelRecentSave.Size = new System.Drawing.Size(125, 13);
            this.labelRecentSave.TabIndex = 4;
            this.labelRecentSave.Text = "Recently Saved File:";
            // 
            // linkRecent
            // 
            this.linkRecent.AutoSize = true;
            this.linkRecent.Location = new System.Drawing.Point(212, 399);
            this.linkRecent.Name = "linkRecent";
            this.linkRecent.Size = new System.Drawing.Size(33, 13);
            this.linkRecent.TabIndex = 5;
            this.linkRecent.TabStop = true;
            this.linkRecent.Text = "None";
            this.linkRecent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRecent_LinkClicked_1);
            // 
            // labelFileLocation
            // 
            this.labelFileLocation.AutoSize = true;
            this.labelFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileLocation.Location = new System.Drawing.Point(72, 428);
            this.labelFileLocation.Name = "labelFileLocation";
            this.labelFileLocation.Size = new System.Drawing.Size(84, 13);
            this.labelFileLocation.TabIndex = 6;
            this.labelFileLocation.Text = "File Location:";
            // 
            // recentPathLabel
            // 
            this.recentPathLabel.AutoSize = true;
            this.recentPathLabel.Location = new System.Drawing.Point(162, 428);
            this.recentPathLabel.Name = "recentPathLabel";
            this.recentPathLabel.Size = new System.Drawing.Size(33, 13);
            this.recentPathLabel.TabIndex = 7;
            this.recentPathLabel.Text = "None";
            // 
            // listFiles
            // 
            this.listFiles.FormattingEnabled = true;
            this.listFiles.Location = new System.Drawing.Point(74, 216);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(296, 173);
            this.listFiles.TabIndex = 8;
            // 
            // labelFiles
            // 
            this.labelFiles.AutoSize = true;
            this.labelFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFiles.Location = new System.Drawing.Point(72, 200);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(77, 13);
            this.labelFiles.TabIndex = 9;
            this.labelFiles.Text = "Saved Files:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(305, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // listMsg
            // 
            this.listMsg.FormattingEnabled = true;
            this.listMsg.Location = new System.Drawing.Point(74, 141);
            this.listMsg.Name = "listMsg";
            this.listMsg.Size = new System.Drawing.Size(296, 43);
            this.listMsg.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Result:";
            // 
            // FilerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(446, 499);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelFiles);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.recentPathLabel);
            this.Controls.Add(this.labelFileLocation);
            this.Controls.Add(this.linkRecent);
            this.Controls.Add(this.labelRecentSave);
            this.Controls.Add(this.SaveItemLabel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelLoadItem);
            this.Controls.Add(this.btnLoad);
            this.Name = "FilerForm";
            this.Text = "Filer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label labelLoadItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label SaveItemLabel;
        private System.Windows.Forms.Label labelRecentSave;
        private System.Windows.Forms.LinkLabel linkRecent;
        private System.Windows.Forms.Label labelFileLocation;
        private System.Windows.Forms.Label recentPathLabel;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox listMsg;
        private System.Windows.Forms.Label label2;
    }
}