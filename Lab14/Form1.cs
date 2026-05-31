using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace Lab14
{
    public partial class Form1 : Form
    {
        private string currentPath = "";
        private string selectedItemPath = "";
        private bool isFileSelected = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDrives();
            btnSaveText.Enabled = false;
        }

        private void LoadDrives()
        {
            comboBoxDrives.Items.Clear();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                comboBoxDrives.Items.Add(drive.Name);
            }
            if (comboBoxDrives.Items.Count > 0) comboBoxDrives.SelectedIndex = 0;
        }

        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDrives.SelectedItem == null) return;
            string driveName = comboBoxDrives.SelectedItem.ToString();
            DriveInfo drive = new DriveInfo(driveName);

            rtbInfoAndContent.Clear();
            rtbInfoAndContent.AppendText($"ВЛАСТИВОСТІ ДИСКА {drive.Name}\n");
            if (drive.IsReady)
            {
                rtbInfoAndContent.AppendText($"Файлова система: {drive.DriveFormat}\n");
                rtbInfoAndContent.AppendText($"Тип диска: {drive.DriveType}\n");
                rtbInfoAndContent.AppendText($"Загальний розмір: {drive.TotalSize / 1024 / 1024 / 1024} ГБ\n");
                rtbInfoAndContent.AppendText($"Вільне місце: {drive.TotalFreeSpace / 1024 / 1024 / 1024} ГБ\n");

                currentPath = drive.RootDirectory.FullName;
                UpdateNavigation();
            }
            else
            {
                rtbInfoAndContent.AppendText("Диск не готовий до роботи\n");
            }
        }

        private void UpdateNavigation()
        {
            txtCurrentPath.Text = currentPath;

            if (pictureBoxPreview.Image != null)
            {
                pictureBoxPreview.Image.Dispose();
                pictureBoxPreview.Image = null;
            }

            listBoxFolders.Items.Clear();
            listBoxFiles.Items.Clear();

            if (!Directory.Exists(currentPath)) return;

            string folderFilter = txtFilterFolders.Text.ToLower();
            string fileFilter = txtFilterFiles.Text.ToLower();

            try
            {
                string[] folders = Directory.GetDirectories(currentPath);
                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    if (string.IsNullOrEmpty(folderFilter) || name.ToLower().Contains(folderFilter))
                        listBoxFolders.Items.Add(name);
                }

                string[] files = Directory.GetFiles(currentPath);
                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    if (string.IsNullOrEmpty(fileFilter) || name.ToLower().Contains(fileFilter))
                        listBoxFiles.Items.Add(name);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Доступ до цієї папки обмежено правами доступу Windows", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBoxFolders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxFolders.SelectedItem == null) return;
            currentPath = Path.Combine(currentPath, listBoxFolders.SelectedItem.ToString());
            UpdateNavigation();
        }

        private void btnGoUp_Click(object sender, EventArgs e)
        {
            DirectoryInfo parentDir = Directory.GetParent(currentPath);
            if (parentDir != null)
            {
                currentPath = parentDir.FullName;
                UpdateNavigation();
            }
        }

        private void listBoxFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFolders.SelectedItem == null) return;

            selectedItemPath = Path.Combine(currentPath, listBoxFolders.SelectedItem.ToString());
            isFileSelected = false;
            btnSaveText.Enabled = false;

            DirectoryInfo dirInfo = new DirectoryInfo(selectedItemPath);
            rtbInfoAndContent.Clear();
            rtbInfoAndContent.AppendText($"ВЛАСТИВОСТІ ПАПКИ: {dirInfo.Name}\n");
            rtbInfoAndContent.AppendText($"Повний шлях: {dirInfo.FullName}\n");
            rtbInfoAndContent.AppendText($"Час створення: {dirInfo.CreationTime}\n");
            rtbInfoAndContent.AppendText($"Остання зміна: {dirInfo.LastWriteTime}\n");

            LoadAttributes(dirInfo.Attributes);
        }

        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;

            selectedItemPath = Path.Combine(currentPath, listBoxFiles.SelectedItem.ToString());
            isFileSelected = true;
            btnSaveText.Enabled = false;

            if (pictureBoxPreview.Image != null)
            {
                pictureBoxPreview.Image.Dispose();
                pictureBoxPreview.Image = null;
            }

            FileInfo fileInfo = new FileInfo(selectedItemPath);
            rtbInfoAndContent.Clear();

            rtbInfoAndContent.AppendText($"ВЛАСТИВОСТІ ФАЙЛУ: {fileInfo.Name}\n");
            rtbInfoAndContent.AppendText($"Розширення: {fileInfo.Extension}\n");
            rtbInfoAndContent.AppendText($"Розмір: {fileInfo.Length} байт\n");
            rtbInfoAndContent.AppendText($"Час створення: {fileInfo.CreationTime}\n");

            LoadAttributes(fileInfo.Attributes);

            string ext = fileInfo.Extension.ToLower();

            try
            {
                if (ext == ".txt" || ext == ".ini" || ext == ".log" || ext == ".json" || ext == ".cs")
                {
                    using (StreamReader sr = new StreamReader(selectedItemPath))
                    {
                        rtbInfoAndContent.Text = sr.ReadToEnd();
                    }
                    btnSaveText.Enabled = true;
                }

                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".gif")
                {
                    using (FileStream fs = new FileStream(selectedItemPath, FileMode.Open, FileAccess.Read))
                    {
                        pictureBoxPreview.Image = Image.FromStream(fs);
                    }
                }
            }
            catch (Exception ex)
            {
                rtbInfoAndContent.AppendText($"\n[Помилка читання вмісту: {ex.Message}]");
            }
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            string newFolderPath = Path.Combine(currentPath, "Нова папка");
            if (!Directory.Exists(newFolderPath))
            {
                Directory.CreateDirectory(newFolderPath);
                UpdateNavigation();
            }
        }

        private void btnDeleteFolder_Click(object sender, EventArgs e)
        {
            if (listBoxFolders.SelectedItem == null || isFileSelected) return;

            DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити цей каталог?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Directory.Delete(selectedItemPath, true);
                    UpdateNavigation();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка видалення папки: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            string newFilePath = Path.Combine(currentPath, "newfile.txt");
            if (!File.Exists(newFilePath))
            {
                File.Create(newFilePath).Close();
                UpdateNavigation();
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null || !isFileSelected) return;

            DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити цей файл?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (pictureBoxPreview.Image != null)
                    {
                        pictureBoxPreview.Image.Dispose();
                        pictureBoxPreview.Image = null;
                    }

                    File.Delete(selectedItemPath);
                    UpdateNavigation();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка видалення файлу: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDestinationPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string destDir = txtDestinationPath.Text;
            if (string.IsNullOrEmpty(selectedItemPath) || string.IsNullOrEmpty(destDir)) return;

            string destPath = Path.Combine(destDir, Path.GetFileName(selectedItemPath));

            try
            {
                if (isFileSelected)
                {
                    File.Copy(selectedItemPath, destPath, true);
                    MessageBox.Show("Файл успішно скопійовано!");
                }
                UpdateNavigation();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка копіювання: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            string destDir = txtDestinationPath.Text;
            if (string.IsNullOrEmpty(selectedItemPath) || string.IsNullOrEmpty(destDir)) return;

            string destPath = Path.Combine(destDir, Path.GetFileName(selectedItemPath));

            try
            {
                if (pictureBoxPreview.Image != null)
                {
                    pictureBoxPreview.Image.Dispose();
                    pictureBoxPreview.Image = null;
                }

                rtbInfoAndContent.Clear();

                if (isFileSelected)
                    File.Move(selectedItemPath, destPath);
                else
                    Directory.Move(selectedItemPath, destPath);

                MessageBox.Show("Об'єкт успішно перенесено!");
                selectedItemPath = "";
                UpdateNavigation();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка перенесення: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnZip_Click(object sender, EventArgs e)
        {
            string destDir = txtDestinationPath.Text;

            if (string.IsNullOrEmpty(selectedItemPath) || string.IsNullOrEmpty(destDir))
            {
                MessageBox.Show("Оберіть файл/папку у списку та вкажіть директорію призначення!", "Увага");
                return;
            }

            try
            {
                string archiveName = Path.GetFileName(selectedItemPath) + ".zip";
                string fullZipPath = Path.Combine(destDir, archiveName);

                if (File.Exists(fullZipPath))
                {
                    MessageBox.Show("Архів із такою назвою вже існує у папці призначення!", "Помилка");
                    return;
                }

                string arguments = $"Compress-Archive -Path '{selectedItemPath}' -DestinationPath '{fullZipPath}'";

                Process.Start(new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = arguments,
                    WindowStyle = ProcessWindowStyle.Hidden
                }).WaitForExit();

                MessageBox.Show("Об'єкт успішно заархівовано в ZIP!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateNavigation();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка архівації: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnzip_Click(object sender, EventArgs e)
        {
            string destDir = txtDestinationPath.Text;

            if (!isFileSelected || string.IsNullOrEmpty(selectedItemPath) || !selectedItemPath.ToLower().EndsWith(".zip"))
            {
                MessageBox.Show("Оберіть ZIP-архів у списку файлів!", "Увага");
                return;
            }

            if (string.IsNullOrEmpty(destDir))
            {
                MessageBox.Show("Вкажіть шлях призначення (куди розпакувати архів)!", "Увага");
                return;
            }

            try
            {
                if (pictureBoxPreview.Image != null)
                {
                    pictureBoxPreview.Image.Dispose();
                    pictureBoxPreview.Image = null;
                }
                rtbInfoAndContent.Clear();

                string arguments = $"Expand-Archive -Path '{selectedItemPath}' -DestinationPath '{destDir}' -Force";

                Process.Start(new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = arguments,
                    WindowStyle = ProcessWindowStyle.Hidden
                }).WaitForExit();

                MessageBox.Show("Архів успішно розпаковано у вказану папку!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateNavigation();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка розпакування: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveText_Click(object sender, EventArgs e)
        {
            if (isFileSelected && File.Exists(selectedItemPath))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(selectedItemPath, false))
                    {
                        sw.Write(rtbInfoAndContent.Text);
                    }
                    MessageBox.Show("Зміни збережено!");
                    UpdateNavigation();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка збереження: " + ex.Message);
                }
            }
        }

        private void LoadAttributes(FileAttributes attributes)
        {
            chkReadOnly.Checked = (attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
            chkHidden.Checked = (attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
            chkArchive.Checked = (attributes & FileAttributes.Archive) == FileAttributes.Archive;
        }

        private void btnApplyAttributes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedItemPath)) return;

            try
            {
                FileAttributes attributes = File.GetAttributes(selectedItemPath);

                if (chkReadOnly.Checked) attributes |= FileAttributes.ReadOnly;
                else attributes &= ~FileAttributes.ReadOnly;

                if (chkHidden.Checked) attributes |= FileAttributes.Hidden;
                else attributes &= ~FileAttributes.Hidden;

                if (chkArchive.Checked) attributes |= FileAttributes.Archive;
                else attributes &= ~FileAttributes.Archive;

                File.SetAttributes(selectedItemPath, attributes);
                MessageBox.Show("Атрибути успішно змінено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка зміни атрибутів: " + ex.Message);
            }
        }

        private void txtFilterFolders_TextChanged(object sender, EventArgs e) { UpdateNavigation(); }
        private void txtFilterFiles_TextChanged(object sender, EventArgs e) { UpdateNavigation(); }
    }
}