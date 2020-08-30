namespace Make_Post
{
    partial class BaseInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseInterface));
            this.btn_chooseFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tbox_path = new System.Windows.Forms.TextBox();
            this.lbl_filePath = new System.Windows.Forms.Label();
            this.tbox_fileContent = new System.Windows.Forms.RichTextBox();
            this.btn_createNewFile = new System.Windows.Forms.Button();
            this.tbox_LastPost = new System.Windows.Forms.TextBox();
            this.lbl_lastPost = new System.Windows.Forms.Label();
            this.cmbbox_postType = new System.Windows.Forms.ComboBox();
            this.lbl_postType = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_putFiles = new System.Windows.Forms.Button();
            this.gBox_sftpControls = new System.Windows.Forms.GroupBox();
            this.btn_editlastPost = new System.Windows.Forms.Button();
            this.gBox_sftpControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_chooseFile
            // 
            this.btn_chooseFile.BackColor = System.Drawing.Color.White;
            this.btn_chooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chooseFile.ForeColor = System.Drawing.Color.Black;
            this.btn_chooseFile.Location = new System.Drawing.Point(12, 12);
            this.btn_chooseFile.Name = "btn_chooseFile";
            this.btn_chooseFile.Size = new System.Drawing.Size(123, 41);
            this.btn_chooseFile.TabIndex = 0;
            this.btn_chooseFile.Text = "Choose File";
            this.btn_chooseFile.UseVisualStyleBackColor = false;
            this.btn_chooseFile.Click += new System.EventHandler(this.btn_chooseFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "\"txt files (*.txt)|*.txt|All files (*.*)|*.*\"";
            // 
            // tbox_path
            // 
            this.tbox_path.Location = new System.Drawing.Point(311, 19);
            this.tbox_path.Name = "tbox_path";
            this.tbox_path.Size = new System.Drawing.Size(477, 26);
            this.tbox_path.TabIndex = 1;
            // 
            // lbl_filePath
            // 
            this.lbl_filePath.AutoSize = true;
            this.lbl_filePath.ForeColor = System.Drawing.Color.White;
            this.lbl_filePath.Location = new System.Drawing.Point(230, 22);
            this.lbl_filePath.Name = "lbl_filePath";
            this.lbl_filePath.Size = new System.Drawing.Size(75, 20);
            this.lbl_filePath.TabIndex = 2;
            this.lbl_filePath.Text = "File Path:";
            // 
            // tbox_fileContent
            // 
            this.tbox_fileContent.Location = new System.Drawing.Point(311, 70);
            this.tbox_fileContent.Name = "tbox_fileContent";
            this.tbox_fileContent.Size = new System.Drawing.Size(477, 368);
            this.tbox_fileContent.TabIndex = 3;
            this.tbox_fileContent.Text = "";
            // 
            // btn_createNewFile
            // 
            this.btn_createNewFile.BackColor = System.Drawing.Color.Red;
            this.btn_createNewFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_createNewFile.ForeColor = System.Drawing.Color.White;
            this.btn_createNewFile.Location = new System.Drawing.Point(12, 126);
            this.btn_createNewFile.Name = "btn_createNewFile";
            this.btn_createNewFile.Size = new System.Drawing.Size(197, 41);
            this.btn_createNewFile.TabIndex = 4;
            this.btn_createNewFile.Text = "Create HTML File";
            this.btn_createNewFile.UseVisualStyleBackColor = false;
            this.btn_createNewFile.Click += new System.EventHandler(this.btn_createNewFile_Click);
            // 
            // tbox_LastPost
            // 
            this.tbox_LastPost.Location = new System.Drawing.Point(12, 412);
            this.tbox_LastPost.Name = "tbox_LastPost";
            this.tbox_LastPost.Size = new System.Drawing.Size(196, 26);
            this.tbox_LastPost.TabIndex = 5;
            // 
            // lbl_lastPost
            // 
            this.lbl_lastPost.AutoSize = true;
            this.lbl_lastPost.ForeColor = System.Drawing.Color.White;
            this.lbl_lastPost.Location = new System.Drawing.Point(12, 389);
            this.lbl_lastPost.Name = "lbl_lastPost";
            this.lbl_lastPost.Size = new System.Drawing.Size(80, 20);
            this.lbl_lastPost.TabIndex = 6;
            this.lbl_lastPost.Text = "Last Post:";
            // 
            // cmbbox_postType
            // 
            this.cmbbox_postType.FormattingEnabled = true;
            this.cmbbox_postType.Items.AddRange(new object[] {
            "Thought",
            "Book Summary"});
            this.cmbbox_postType.Location = new System.Drawing.Point(13, 92);
            this.cmbbox_postType.Name = "cmbbox_postType";
            this.cmbbox_postType.Size = new System.Drawing.Size(208, 28);
            this.cmbbox_postType.TabIndex = 7;
            // 
            // lbl_postType
            // 
            this.lbl_postType.AutoSize = true;
            this.lbl_postType.ForeColor = System.Drawing.Color.White;
            this.lbl_postType.Location = new System.Drawing.Point(12, 69);
            this.lbl_postType.Name = "lbl_postType";
            this.lbl_postType.Size = new System.Drawing.Size(83, 20);
            this.lbl_postType.TabIndex = 8;
            this.lbl_postType.Text = "Post Type:";
            // 
            // btn_connect
            // 
            this.btn_connect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_connect.BackColor = System.Drawing.Color.White;
            this.btn_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect.ForeColor = System.Drawing.Color.Black;
            this.btn_connect.Location = new System.Drawing.Point(6, 25);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(153, 41);
            this.btn_connect.TabIndex = 9;
            this.btn_connect.Text = "Test Connection";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_putFiles
            // 
            this.btn_putFiles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_putFiles.BackColor = System.Drawing.Color.Red;
            this.btn_putFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_putFiles.ForeColor = System.Drawing.Color.White;
            this.btn_putFiles.Location = new System.Drawing.Point(6, 72);
            this.btn_putFiles.Name = "btn_putFiles";
            this.btn_putFiles.Size = new System.Drawing.Size(153, 41);
            this.btn_putFiles.TabIndex = 10;
            this.btn_putFiles.Text = "Show World";
            this.btn_putFiles.UseVisualStyleBackColor = false;
            this.btn_putFiles.Click += new System.EventHandler(this.btn_putFiles_Click);
            // 
            // gBox_sftpControls
            // 
            this.gBox_sftpControls.Controls.Add(this.btn_putFiles);
            this.gBox_sftpControls.Controls.Add(this.btn_connect);
            this.gBox_sftpControls.ForeColor = System.Drawing.Color.White;
            this.gBox_sftpControls.Location = new System.Drawing.Point(12, 193);
            this.gBox_sftpControls.Name = "gBox_sftpControls";
            this.gBox_sftpControls.Size = new System.Drawing.Size(177, 122);
            this.gBox_sftpControls.TabIndex = 11;
            this.gBox_sftpControls.TabStop = false;
            this.gBox_sftpControls.Text = "SFTP";
            // 
            // btn_editlastPost
            // 
            this.btn_editlastPost.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_editlastPost.BackColor = System.Drawing.Color.White;
            this.btn_editlastPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editlastPost.ForeColor = System.Drawing.Color.Black;
            this.btn_editlastPost.Location = new System.Drawing.Point(12, 345);
            this.btn_editlastPost.Name = "btn_editlastPost";
            this.btn_editlastPost.Size = new System.Drawing.Size(137, 41);
            this.btn_editlastPost.TabIndex = 12;
            this.btn_editlastPost.Text = "Edit Last Post";
            this.btn_editlastPost.UseVisualStyleBackColor = false;
            this.btn_editlastPost.Click += new System.EventHandler(this.btn_editlastPost_Click);
            // 
            // BaseInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_editlastPost);
            this.Controls.Add(this.gBox_sftpControls);
            this.Controls.Add(this.lbl_postType);
            this.Controls.Add(this.cmbbox_postType);
            this.Controls.Add(this.lbl_lastPost);
            this.Controls.Add(this.tbox_LastPost);
            this.Controls.Add(this.btn_createNewFile);
            this.Controls.Add(this.tbox_fileContent);
            this.Controls.Add(this.lbl_filePath);
            this.Controls.Add(this.tbox_path);
            this.Controls.Add(this.btn_chooseFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseInterface";
            this.Text = "Show the World";
            this.Load += new System.EventHandler(this.BaseInterface_Load);
            this.gBox_sftpControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_chooseFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox tbox_path;
        private System.Windows.Forms.Label lbl_filePath;
        private System.Windows.Forms.RichTextBox tbox_fileContent;
        private System.Windows.Forms.Button btn_createNewFile;
        private System.Windows.Forms.TextBox tbox_LastPost;
        private System.Windows.Forms.Label lbl_lastPost;
        private System.Windows.Forms.ComboBox cmbbox_postType;
        private System.Windows.Forms.Label lbl_postType;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_putFiles;
        private System.Windows.Forms.GroupBox gBox_sftpControls;
        private System.Windows.Forms.Button btn_editlastPost;
    }
}

