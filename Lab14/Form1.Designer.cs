namespace Lab14
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxDrives = new System.Windows.Forms.ComboBox();
            this.txtCurrentPath = new System.Windows.Forms.TextBox();
            this.btnGoUp = new System.Windows.Forms.Button();
            this.listBoxFolders = new System.Windows.Forms.ListBox();
            this.txtFilterFolders = new System.Windows.Forms.TextBox();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.txtFilterFiles = new System.Windows.Forms.TextBox();
            this.rtbInfoAndContent = new System.Windows.Forms.RichTextBox();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.btnCreateFolder = new System.Windows.Forms.Button();
            this.btnDeleteFolder = new System.Windows.Forms.Button();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.chkReadOnly = new System.Windows.Forms.CheckBox();
            this.chkHidden = new System.Windows.Forms.CheckBox();
            this.chkArchive = new System.Windows.Forms.CheckBox();
            this.btnApplyAttributes = new System.Windows.Forms.Button();
            this.btnSaveText = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.btnZip = new System.Windows.Forms.Button();
            this.btnUnzip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.FormattingEnabled = true;
            this.comboBoxDrives.Location = new System.Drawing.Point(12, 12);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDrives.TabIndex = 0;
            this.comboBoxDrives.SelectedIndexChanged += new System.EventHandler(this.comboBoxDrives_SelectedIndexChanged);
            // 
            // txtCurrentPath
            // 
            this.txtCurrentPath.Location = new System.Drawing.Point(139, 12);
            this.txtCurrentPath.Name = "txtCurrentPath";
            this.txtCurrentPath.ReadOnly = true;
            this.txtCurrentPath.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentPath.TabIndex = 1;
            // 
            // btnGoUp
            // 
            this.btnGoUp.Location = new System.Drawing.Point(816, 10);
            this.btnGoUp.Name = "btnGoUp";
            this.btnGoUp.Size = new System.Drawing.Size(75, 23);
            this.btnGoUp.TabIndex = 2;
            this.btnGoUp.Text = "Назад";
            this.btnGoUp.UseVisualStyleBackColor = true;
            this.btnGoUp.Click += new System.EventHandler(this.btnGoUp_Click);
            // 
            // listBoxFolders
            // 
            this.listBoxFolders.FormattingEnabled = true;
            this.listBoxFolders.Location = new System.Drawing.Point(12, 67);
            this.listBoxFolders.Name = "listBoxFolders";
            this.listBoxFolders.Size = new System.Drawing.Size(244, 147);
            this.listBoxFolders.TabIndex = 3;
            this.listBoxFolders.SelectedIndexChanged += new System.EventHandler(this.listBoxFolders_SelectedIndexChanged);
            this.listBoxFolders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxFolders_MouseDoubleClick);
            // 
            // txtFilterFolders
            // 
            this.txtFilterFolders.Location = new System.Drawing.Point(12, 41);
            this.txtFilterFolders.Name = "txtFilterFolders";
            this.txtFilterFolders.Size = new System.Drawing.Size(244, 20);
            this.txtFilterFolders.TabIndex = 4;
            this.txtFilterFolders.TextChanged += new System.EventHandler(this.txtFilterFolders_TextChanged);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.Location = new System.Drawing.Point(12, 246);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(244, 147);
            this.listBoxFiles.TabIndex = 5;
            this.listBoxFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxFiles_SelectedIndexChanged);
            // 
            // txtFilterFiles
            // 
            this.txtFilterFiles.Location = new System.Drawing.Point(12, 220);
            this.txtFilterFiles.Name = "txtFilterFiles";
            this.txtFilterFiles.Size = new System.Drawing.Size(244, 20);
            this.txtFilterFiles.TabIndex = 6;
            this.txtFilterFiles.TextChanged += new System.EventHandler(this.txtFilterFiles_TextChanged);
            // 
            // rtbInfoAndContent
            // 
            this.rtbInfoAndContent.Location = new System.Drawing.Point(596, 331);
            this.rtbInfoAndContent.Name = "rtbInfoAndContent";
            this.rtbInfoAndContent.Size = new System.Drawing.Size(244, 94);
            this.rtbInfoAndContent.TabIndex = 7;
            this.rtbInfoAndContent.Text = "";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(596, 50);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(295, 173);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 8;
            this.pictureBoxPreview.TabStop = false;
            // 
            // btnCreateFolder
            // 
            this.btnCreateFolder.Location = new System.Drawing.Point(337, 114);
            this.btnCreateFolder.Name = "btnCreateFolder";
            this.btnCreateFolder.Size = new System.Drawing.Size(113, 23);
            this.btnCreateFolder.TabIndex = 9;
            this.btnCreateFolder.Text = "Створити папку";
            this.btnCreateFolder.UseVisualStyleBackColor = true;
            this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
            // 
            // btnDeleteFolder
            // 
            this.btnDeleteFolder.Location = new System.Drawing.Point(337, 145);
            this.btnDeleteFolder.Name = "btnDeleteFolder";
            this.btnDeleteFolder.Size = new System.Drawing.Size(113, 23);
            this.btnDeleteFolder.TabIndex = 10;
            this.btnDeleteFolder.Text = "Видалити папку";
            this.btnDeleteFolder.UseVisualStyleBackColor = true;
            this.btnDeleteFolder.Click += new System.EventHandler(this.btnDeleteFolder_Click);
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new System.Drawing.Point(337, 283);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(113, 23);
            this.btnCreateFile.TabIndex = 11;
            this.btnCreateFile.Text = "Створити файл";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(337, 312);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(113, 23);
            this.btnDeleteFile.TabIndex = 12;
            this.btnDeleteFile.Text = "Видалити файл";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(297, 358);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 13;
            this.btnCopy.Text = "Копіювати";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(297, 401);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 14;
            this.btnMove.Text = "Перенести";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // chkReadOnly
            // 
            this.chkReadOnly.AutoSize = true;
            this.chkReadOnly.Location = new System.Drawing.Point(596, 246);
            this.chkReadOnly.Name = "chkReadOnly";
            this.chkReadOnly.Size = new System.Drawing.Size(123, 17);
            this.chkReadOnly.TabIndex = 15;
            this.chkReadOnly.Text = "Тільки для читання";
            this.chkReadOnly.UseVisualStyleBackColor = true;
            // 
            // chkHidden
            // 
            this.chkHidden.AutoSize = true;
            this.chkHidden.Location = new System.Drawing.Point(728, 246);
            this.chkHidden.Name = "chkHidden";
            this.chkHidden.Size = new System.Drawing.Size(87, 17);
            this.chkHidden.TabIndex = 16;
            this.chkHidden.Text = "Прихований";
            this.chkHidden.UseVisualStyleBackColor = true;
            // 
            // chkArchive
            // 
            this.chkArchive.AutoSize = true;
            this.chkArchive.Location = new System.Drawing.Point(821, 246);
            this.chkArchive.Name = "chkArchive";
            this.chkArchive.Size = new System.Drawing.Size(70, 17);
            this.chkArchive.TabIndex = 17;
            this.chkArchive.Text = "Архівний";
            this.chkArchive.UseVisualStyleBackColor = true;
            // 
            // btnApplyAttributes
            // 
            this.btnApplyAttributes.Location = new System.Drawing.Point(596, 282);
            this.btnApplyAttributes.Name = "btnApplyAttributes";
            this.btnApplyAttributes.Size = new System.Drawing.Size(131, 23);
            this.btnApplyAttributes.TabIndex = 18;
            this.btnApplyAttributes.Text = "Застосувати атрибути";
            this.btnApplyAttributes.UseVisualStyleBackColor = true;
            this.btnApplyAttributes.Click += new System.EventHandler(this.btnApplyAttributes_Click);
            // 
            // btnSaveText
            // 
            this.btnSaveText.Location = new System.Drawing.Point(781, 282);
            this.btnSaveText.Name = "btnSaveText";
            this.btnSaveText.Size = new System.Drawing.Size(98, 23);
            this.btnSaveText.TabIndex = 19;
            this.btnSaveText.Text = "Зберегти зміни";
            this.btnSaveText.UseVisualStyleBackColor = true;
            this.btnSaveText.Click += new System.EventHandler(this.btnSaveText_Click);
            // 
            // txtDestinationPath
            // 
            this.txtDestinationPath.Location = new System.Drawing.Point(337, 24);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.Size = new System.Drawing.Size(100, 20);
            this.txtDestinationPath.TabIndex = 20;
            // 
            // btnBrowseDestination
            // 
            this.btnBrowseDestination.Location = new System.Drawing.Point(337, 50);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDestination.TabIndex = 21;
            this.btnBrowseDestination.Text = "Вибір папки";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // btnZip
            // 
            this.btnZip.Location = new System.Drawing.Point(425, 358);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(111, 23);
            this.btnZip.TabIndex = 22;
            this.btnZip.Text = "Архівувати в ZIP";
            this.btnZip.UseVisualStyleBackColor = true;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // btnUnzip
            // 
            this.btnUnzip.Location = new System.Drawing.Point(425, 401);
            this.btnUnzip.Name = "btnUnzip";
            this.btnUnzip.Size = new System.Drawing.Size(111, 23);
            this.btnUnzip.TabIndex = 23;
            this.btnUnzip.Text = "Розпакувати з ZIP";
            this.btnUnzip.UseVisualStyleBackColor = true;
            this.btnUnzip.Click += new System.EventHandler(this.btnUnzip_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 471);
            this.Controls.Add(this.btnUnzip);
            this.Controls.Add(this.btnZip);
            this.Controls.Add(this.btnBrowseDestination);
            this.Controls.Add(this.txtDestinationPath);
            this.Controls.Add(this.btnSaveText);
            this.Controls.Add(this.btnApplyAttributes);
            this.Controls.Add(this.chkArchive);
            this.Controls.Add(this.chkHidden);
            this.Controls.Add(this.chkReadOnly);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.btnCreateFile);
            this.Controls.Add(this.btnDeleteFolder);
            this.Controls.Add(this.btnCreateFolder);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.rtbInfoAndContent);
            this.Controls.Add(this.txtFilterFiles);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.txtFilterFolders);
            this.Controls.Add(this.listBoxFolders);
            this.Controls.Add(this.btnGoUp);
            this.Controls.Add(this.txtCurrentPath);
            this.Controls.Add(this.comboBoxDrives);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDrives;
        private System.Windows.Forms.TextBox txtCurrentPath;
        private System.Windows.Forms.Button btnGoUp;
        private System.Windows.Forms.ListBox listBoxFolders;
        private System.Windows.Forms.TextBox txtFilterFolders;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.TextBox txtFilterFiles;
        private System.Windows.Forms.RichTextBox rtbInfoAndContent;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button btnCreateFolder;
        private System.Windows.Forms.Button btnDeleteFolder;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.CheckBox chkReadOnly;
        private System.Windows.Forms.CheckBox chkHidden;
        private System.Windows.Forms.CheckBox chkArchive;
        private System.Windows.Forms.Button btnApplyAttributes;
        private System.Windows.Forms.Button btnSaveText;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.Button btnZip;
        private System.Windows.Forms.Button btnUnzip;
    }
}

