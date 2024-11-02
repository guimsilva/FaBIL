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
        private readonly string resultsFolder = "Results";
        private readonly string unknownFolder = "Unknown";

        private Config config { get; set; } = new Config();
        private bool canWriteConfig = false;
        private bool isClassifying = false;
        private string lastDestinationFolderPath = string.Empty;
        private string lastDestinationFilePath = string.Empty;
        private string lastDestinationFileName = string.Empty;
        private ListView? lastLvClassified = null;

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
                config = JsonSerializer.Deserialize<Config>(File.ReadAllText("Config.json"))!;
            }
            else
            {
                File.WriteAllText(configPath, JsonSerializer.Serialize(config));
            }

            txtPathSource.Text = config.SourceFolder;
            lbNegativeImages.Text = txtLeftArrowClass.Text = config.LeftArrowClassName;
            lbPositiveImages.Text = txtRightArrowClass.Text = config.RightArrowClass;
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
            LoadClassifiedFilesList(Path.Combine(config.SourceFolder, resultsFolder, config.LeftArrowClassName), lvLeftArrowKey);

            lvRightArrowKey.View = View.Details;
            lvRightArrowKey.FullRowSelect = true;
            lvRightArrowKey.GridLines = true;
            lvRightArrowKey.Columns.Add("Name", 200);
            lvRightArrowKey.Columns.Add("Date Modified", 93);
            LoadClassifiedFilesList(Path.Combine(config.SourceFolder, resultsFolder, config.RightArrowClass), lvRightArrowKey);

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

        private string GetClassifiedFolderPath(string className)
        {
            return Path.Combine(config.SourceFolder, $"{resultsFolder}/{className}");
        }

        private void WriteConfig()
        {
            if (!canWriteConfig) return;
            config.SourceFolder = txtPathSource.Text;
            config.LeftArrowClassName = txtLeftArrowClass.Text.Trim().Replace(" ", "");
            config.RightArrowClass = txtRightArrowClass.Text.Trim().Replace(" ", "");
            File.WriteAllText(configPath, JsonSerializer.Serialize(config));
        }

        private void LoadSourceFilesList(bool loadImage = true)
        {
            lvSource.Items.Clear();
            var files = this.imagesFileFilter.SelectMany(f => Directory.GetFiles(config.SourceFolder, f))
                                             .Select(f => new FileInfo(f));

            foreach (var file in files)
            {
                var item = new ListViewItem(file.Name);
                item.SubItems.Add(file.Length.ToString());
                item.SubItems.Add(file.LastWriteTime.ToString());
                lvSource.Items.Add(item);
            }

            lbStatus.Visible = lvSource.Items.Count > 0;
            btnStart.Enabled = lvSource.Items.Count > 0;
            if (loadImage)
            {
                LoadImage();
            }
        }

        private void LoadClassifiedFilesList(string folderPath, ListView? lv)
        {
            if (lv is null || !Directory.Exists(folderPath))
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
                if (!Directory.Exists(Path.Combine(config.SourceFolder, resultsFolder)))
                {
                    Directory.CreateDirectory(Path.Combine(config.SourceFolder, resultsFolder));
                }
                if (!Directory.Exists(GetClassifiedFolderPath(config.LeftArrowClassName)))
                {
                    Directory.CreateDirectory(GetClassifiedFolderPath(config.LeftArrowClassName));
                }
                if (!Directory.Exists(GetClassifiedFolderPath(config.RightArrowClass)))
                {
                    Directory.CreateDirectory(GetClassifiedFolderPath(config.RightArrowClass));
                }
            }
        }

        private void txtLeftArrowClass_TextChanged(object sender, EventArgs e)
        {
            lbNegativeImages.Text = txtLeftArrowClass.Text.Trim().Replace(" ", "");
            WriteConfig();
        }

        private void txtRightArrowClass_TextChanged(object sender, EventArgs e)
        {
            lbPositiveImages.Text = txtRightArrowClass.Text.Trim().Replace(" ", "");
            WriteConfig();
        }

        private bool isSourceEmpty()
        {
            if (lvSource.Items.Count == 0)
            {
                MessageBox.Show("No images to classify", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        private void PrepareLeftRightActions(
            out string sourceFilePath,
            out string classfiedFolderPath,
            out string destinationFilePath,
            out string destinationFileName,
            string className,
            ListView? lvClassified)
        {
            destinationFileName = lvSource.SelectedItems[0].Text;
            sourceFilePath = Path.Combine(config.SourceFolder, destinationFileName);
            var destinationFolderPath = classfiedFolderPath = GetClassifiedFolderPath(className);
            destinationFilePath = Path.Combine(destinationFolderPath, destinationFileName);
            lastDestinationFileName = destinationFileName;
            lastDestinationFilePath = destinationFilePath;
            lastDestinationFolderPath = destinationFolderPath;
            lastLvClassified = lvClassified;
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

                    if (!Directory.Exists(Path.Combine(config.SourceFolder, resultsFolder)))
                    {
                        Directory.CreateDirectory(Path.Combine(config.SourceFolder, resultsFolder));
                    }

                    var destinationFilePath = string.Empty;
                    var destinationFileName = string.Empty;
                    var sourceFilePath = string.Empty;
                    var classfiedFolderPath = string.Empty;
                    ListView? lvClassified = null;
                    switch (keyData)
                    {
                        case Keys.Left:
                            if (isSourceEmpty())
                            {
                                return true;
                            }
                            lvClassified = lvLeftArrowKey;
                            PrepareLeftRightActions(
                                out sourceFilePath,
                                out classfiedFolderPath,
                                out destinationFilePath,
                                out destinationFileName,
                                config.LeftArrowClassName,
                                lvLeftArrowKey);
                            break;
                        case Keys.Right:
                            if (isSourceEmpty())
                            {
                                return true;
                            }
                            lvClassified = lvRightArrowKey;
                            PrepareLeftRightActions(
                                out sourceFilePath,
                                out classfiedFolderPath,
                                out destinationFilePath,
                                out destinationFileName,
                                config.RightArrowClass,
                                lvRightArrowKey);
                            break;
                        case Keys.Down: /* Skip */
                            if (isSourceEmpty())
                            {
                                return true;
                            }
                            PrepareLeftRightActions(
                                out sourceFilePath,
                                out classfiedFolderPath,
                                out destinationFilePath,
                                out destinationFileName,
                                unknownFolder,
                                null);
                            break;
                        case Keys.Up: /* Undo */
                            if (string.IsNullOrWhiteSpace(lastDestinationFilePath))
                            {
                                MessageBox.Show("Can't undo", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                            sourceFilePath = lastDestinationFilePath;
                            lvClassified = lastLvClassified;
                            classfiedFolderPath = lastDestinationFolderPath;
                            destinationFilePath = Path.Combine(config.SourceFolder, lastDestinationFileName);

                            lastDestinationFileName = string.Empty;
                            lastDestinationFilePath = string.Empty;
                            lastDestinationFolderPath = string.Empty;
                            lastLvClassified = null;
                            break;
                    }

                    picImage.Image?.Dispose();
                    picImage.Image = null;
                    File.Move(sourceFilePath, destinationFilePath);
                    LoadClassifiedFilesList(classfiedFolderPath, lvClassified);
                    LoadSourceFilesList();
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
