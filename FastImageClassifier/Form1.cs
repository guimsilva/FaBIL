using System.Text.Json;

namespace FastImageClassifier
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmMain_Load);
        }

        private readonly string statusTextOff = "Click \"Start\" to start classifying your images";
        private readonly string statusTextOn = "Use your arrow keys to classify the images or click \"Stop\"";
        private readonly string configPath = "Config.json";
        private readonly List<string> imagesFileFilter = new List<string> { "*.jpg", "*.jpeg", "*.png", "*.gif" };
        private Config Config { get; set; } = new Config();
        private bool canWriteConfig = false;
        private bool isClassifying = false;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (KeyPressHandler(keyData))
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmMain_Load(object? sender, EventArgs e)
        {
            if (File.Exists(configPath))
            {
                Config = JsonSerializer.Deserialize<Config>(File.ReadAllText("Config.json"))!;
            }
            else
            {
                File.WriteAllText(configPath, JsonSerializer.Serialize(Config));
            }

            txtPathSource.Text = Config.SourceFolder;
            txtLeftArrowClass.Text = Config.LeftArrowClass;
            txtRightArrowClass.Text = Config.RightArrowClass;
            lbNegativeImages.Text = txtLeftArrowClass.Text;
            lbPositiveImages.Text = txtRightArrowClass.Text;
            lbStatus.Text = statusTextOff;
            canWriteConfig = true;

            lvSource.View = View.Details;
            lvSource.FullRowSelect = true;
            lvSource.GridLines = true;
            lvSource.Columns.Add("Name", 220);
            lvSource.Columns.Add("Size", 80);
            lvSource.Columns.Add("Date Modified", 135);
            LoadSourceFilesList(loadImage: false);

            lvLeftArrowKey.View = View.Details;
            lvLeftArrowKey.FullRowSelect = true;
            lvLeftArrowKey.GridLines = true;
            lvLeftArrowKey.Columns.Add("Name", 200);
            lvLeftArrowKey.Columns.Add("Date Modified", 93);
            LoadClassifiedFilesList(Path.Combine(Config.SourceFolder, "Results", txtLeftArrowClass.Text), lvLeftArrowKey);

            lvRightArrowKey.View = View.Details;
            lvRightArrowKey.FullRowSelect = true;
            lvRightArrowKey.GridLines = true;
            lvRightArrowKey.Columns.Add("Name", 200);
            lvRightArrowKey.Columns.Add("Date Modified", 93);
            LoadClassifiedFilesList(Path.Combine(Config.SourceFolder, "Results", txtRightArrowClass.Text), lvRightArrowKey);

            picImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void LoadImage()
        {
            var imagePath = lvSource.Items.Count > 0 ? $"{txtPathSource.Text}\\{lvSource.Items[0].Text}" : string.Empty;
            if (!string.IsNullOrWhiteSpace(imagePath))
            {
                if (File.Exists(imagePath))
                {
                    picImage.Image = Image.FromFile(imagePath);
                    lvSource.Items[0].Selected = true;
                }
                else
                {
                    picImage.Image = null;
                }
            }
            else
            {
                picImage.Image = null;
            }
        }

        private string GetClassifiedPath(string className)
        {
            return Path.Combine(Config.SourceFolder, $"Results/{className.Trim().Replace(" ", "")}");
        }

        private void WriteConfig()
        {
            if (!canWriteConfig) return;
            Config.SourceFolder = txtPathSource.Text;
            Config.LeftArrowClass = txtLeftArrowClass.Text;
            Config.RightArrowClass = txtRightArrowClass.Text;
            File.WriteAllText(configPath, JsonSerializer.Serialize(Config));
        }

        private void LoadSourceFilesList(bool loadImage = true)
        {
            lvSource.Items.Clear();
            var files = this.imagesFileFilter.SelectMany(f => Directory.GetFiles(Config.SourceFolder, f))
                                             .Select(f => new FileInfo(f));

            foreach (var file in files)
            {
                var item = new ListViewItem(file.Name);
                item.SubItems.Add(file.Length.ToString());
                item.SubItems.Add(file.LastWriteTime.ToString());
                lvSource.Items.Add(item);
            }

            lbStatus.Visible = lvSource.Items.Count > 0;
            if (loadImage)
            {
                LoadImage();
            }
        }

        private void LoadClassifiedFilesList(string folderPath, ListView lv)
        {
            if (!Directory.Exists(folderPath))
            {
                return;
            }

            lv.Items.Clear();
            var files = this.imagesFileFilter.SelectMany(f => Directory.GetFiles(folderPath, f))
                                             .Select(f => new FileInfo(f));

            foreach (var file in files)
            {
                var item = new ListViewItem(file.Name);
                item.SubItems.Add(file.LastWriteTime.ToString());
                lv.Items.Add(item);
            }
        }

        private void btnFolderSource_Click(object? sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyDocuments;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPathSource.Text = folderBrowserDialog.SelectedPath;
                    WriteConfig();
                    LoadSourceFilesList();
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isClassifying)
            {
                isClassifying = false;
                txtLeftArrowClass.Enabled = true;
                txtRightArrowClass.Enabled = true;
                txtPathSource.Enabled = true;
                btnFolderSource.Enabled = true;
                btnStart.Text = "Start";
                lbStatus.Text = statusTextOff;
                picImage.Image = null;
                lvSource.SelectedItems.Clear();
            }
            else
            {
                isClassifying = true;
                txtLeftArrowClass.Enabled = false;
                txtRightArrowClass.Enabled = false;
                txtPathSource.Enabled = false;
                btnFolderSource.Enabled = false;
                btnStart.Text = "Stop";
                lbStatus.Text = statusTextOn;
                LoadImage();
            }
        }

        private void txtLeftArrowClass_TextChanged(object sender, EventArgs e)
        {
            lbNegativeImages.Text = txtLeftArrowClass.Text;
            WriteConfig();
        }

        private void txtRightArrowClass_TextChanged(object sender, EventArgs e)
        {
            lbPositiveImages.Text = txtRightArrowClass.Text;
            WriteConfig();
        }

        private bool KeyPressHandler(Keys keyData)
        {
            if (isClassifying)
            {
                try
                {
                    if (!(keyData == Keys.Up ||
                            keyData == Keys.Right ||
                            keyData == Keys.Down ||
                            keyData == Keys.Left))
                    {
                        return false;
                    }

                    if (!Directory.Exists(Path.Combine(Config.SourceFolder, "Results")))
                    {
                        Directory.CreateDirectory(Path.Combine(Config.SourceFolder, "Results"));
                    }
                    var leftArrowClassPath = GetClassifiedPath(Config.LeftArrowClass);
                    var rightArrowClassPath = GetClassifiedPath(Config.RightArrowClass);
                    if (!Directory.Exists(leftArrowClassPath))
                    {
                        Directory.CreateDirectory(leftArrowClassPath);
                    }
                    if (!Directory.Exists(rightArrowClassPath))
                    {
                        Directory.CreateDirectory(rightArrowClassPath);
                    }

                    var destinationPath = leftArrowClassPath;
                    ListView lv = lvLeftArrowKey;
                    switch (keyData)
                    {
                        case Keys.Right:
                            destinationPath = rightArrowClassPath;
                            lv = lvRightArrowKey;
                            break;
                    }

                    if (lvSource.SelectedItems.Count > 0)
                    {
                        var sourcePath = Path.Combine(Config.SourceFolder, lvSource.SelectedItems[0].Text);
                        var destPath = Path.Combine(destinationPath, lvSource.SelectedItems[0].Text);
                        picImage.Image.Dispose();
                        picImage.Image = null;
                        File.Move(sourcePath, destPath);
                        lvSource.Items.RemoveAt(lvSource.SelectedItems[0].Index);
                        LoadClassifiedFilesList(destinationPath, lv);
                        LoadSourceFilesList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
            }
            else if (!(keyData == Keys.Tab ||
                        keyData == Keys.Enter ||
                        keyData == Keys.Escape ||
                        keyData == Keys.Space))
            {
                /* @TODO: Add custom key press handler here when it's not classifying */
                return false;
            }

            return false;
        }
    }
}
