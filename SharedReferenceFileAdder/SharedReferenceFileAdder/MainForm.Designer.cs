namespace SharedReferenceFileAdder
{
    partial class MainForm
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
            this.fbdMain = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolder = new System.Windows.Forms.Button();
            this.txtSharedFolderPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(12, 38);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(102, 23);
            this.btnFolder.TabIndex = 0;
            this.btnFolder.Text = "Choose Folder"; 
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // txtSharedFolderPath
            // 
            this.txtSharedFolderPath.Location = new System.Drawing.Point(12, 12);
            this.txtSharedFolderPath.Name = "txtSharedFolderPath";
            this.txtSharedFolderPath.Size = new System.Drawing.Size(358, 20);
            this.txtSharedFolderPath.TabIndex = 1;
            this.txtSharedFolderPath.TextChanged += new System.EventHandler(this.txtSharedFolderPath_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 82);
            this.Controls.Add(this.txtSharedFolderPath);
            this.Controls.Add(this.btnFolder);
            this.Name = "MainForm";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout(); 
        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdMain;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.TextBox txtSharedFolderPath;
    }
}

