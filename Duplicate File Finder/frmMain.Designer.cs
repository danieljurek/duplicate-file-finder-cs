namespace DFF1
{
    partial class frmMain
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
            this.treeviewDuplicates = new System.Windows.Forms.TreeView();
            this.chklstboxSelectedPaths = new System.Windows.Forms.CheckedListBox();
            this.btnAddPath = new System.Windows.Forms.Button();
            this.folderbrwPathSelector = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRemovePath = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenSelected = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.statusBottomStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusBottomStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeviewDuplicates
            // 
            this.treeviewDuplicates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeviewDuplicates.CheckBoxes = true;
            this.treeviewDuplicates.Location = new System.Drawing.Point(6, 19);
            this.treeviewDuplicates.Name = "treeviewDuplicates";
            this.treeviewDuplicates.Size = new System.Drawing.Size(527, 97);
            this.treeviewDuplicates.TabIndex = 0;
            // 
            // chklstboxSelectedPaths
            // 
            this.chklstboxSelectedPaths.FormattingEnabled = true;
            this.chklstboxSelectedPaths.Location = new System.Drawing.Point(6, 48);
            this.chklstboxSelectedPaths.Name = "chklstboxSelectedPaths";
            this.chklstboxSelectedPaths.Size = new System.Drawing.Size(527, 94);
            this.chklstboxSelectedPaths.TabIndex = 1;
            // 
            // btnAddPath
            // 
            this.btnAddPath.Location = new System.Drawing.Point(6, 19);
            this.btnAddPath.Name = "btnAddPath";
            this.btnAddPath.Size = new System.Drawing.Size(103, 23);
            this.btnAddPath.TabIndex = 2;
            this.btnAddPath.Text = "Add Path";
            this.btnAddPath.UseVisualStyleBackColor = true;
            this.btnAddPath.Click += new System.EventHandler(this.btnAddPath_Click);
            // 
            // folderbrwPathSelector
            // 
            this.folderbrwPathSelector.Description = "Select a folder to search for duplicate files (Note: subfolders will be searched " +
                "as well)";
            this.folderbrwPathSelector.ShowNewFolderButton = false;
            // 
            // btnRemovePath
            // 
            this.btnRemovePath.Location = new System.Drawing.Point(115, 19);
            this.btnRemovePath.Name = "btnRemovePath";
            this.btnRemovePath.Size = new System.Drawing.Size(103, 23);
            this.btnRemovePath.TabIndex = 3;
            this.btnRemovePath.Text = "Remove Checked";
            this.btnRemovePath.UseVisualStyleBackColor = true;
            this.btnRemovePath.Click += new System.EventHandler(this.btnRemovePath_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(430, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(103, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.btnAddPath);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.chklstboxSelectedPaths);
            this.groupBox1.Controls.Add(this.btnRemovePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 156);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Search Folders";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnOpenSelected);
            this.groupBox2.Controls.Add(this.btnDeleteSelected);
            this.groupBox2.Controls.Add(this.treeviewDuplicates);
            this.groupBox2.Location = new System.Drawing.Point(12, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 151);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // btnOpenSelected
            // 
            this.btnOpenSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenSelected.Location = new System.Drawing.Point(6, 122);
            this.btnOpenSelected.Name = "btnOpenSelected";
            this.btnOpenSelected.Size = new System.Drawing.Size(103, 23);
            this.btnOpenSelected.TabIndex = 2;
            this.btnOpenSelected.Text = "Open Selected";
            this.btnOpenSelected.UseVisualStyleBackColor = true;
            this.btnOpenSelected.Click += new System.EventHandler(this.btnOpenSelected_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSelected.Location = new System.Drawing.Point(430, 122);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(103, 23);
            this.btnDeleteSelected.TabIndex = 1;
            this.btnDeleteSelected.Text = "Delete Checked";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // statusBottomStrip
            // 
            this.statusBottomStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusBottomStrip.Location = new System.Drawing.Point(0, 333);
            this.statusBottomStrip.Name = "statusBottomStrip";
            this.statusBottomStrip.Size = new System.Drawing.Size(563, 22);
            this.statusBottomStrip.TabIndex = 7;
            this.statusBottomStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 355);
            this.Controls.Add(this.statusBottomStrip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "Duplicate File Finder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusBottomStrip.ResumeLayout(false);
            this.statusBottomStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeviewDuplicates;
        private System.Windows.Forms.CheckedListBox chklstboxSelectedPaths;
        private System.Windows.Forms.Button btnAddPath;
        private System.Windows.Forms.FolderBrowserDialog folderbrwPathSelector;
        private System.Windows.Forms.Button btnRemovePath;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.StatusStrip statusBottomStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnOpenSelected;
    }
}

