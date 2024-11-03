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
        private readonly string remainingInBatch = "Remaining in batch: ";
        private readonly string remainingInFolder = "Remaining in folder: ";

        private Config config { get; set; } = new Config();
        private bool canWriteConfig = false;
        private bool isClassifying = false;
        private string lastDestinationFolderPath = string.Empty;
        private string lastDestinationFilePath = string.Empty;
        private string lastDestinationFileName = string.Empty;
        private ListView? lastLvClassified = null;
        private int remainingInBatchCount = 0;
        private int remainingInFolderCount = 0;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (KeyPressHandler(keyData))
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected string LeftClassifiedLabel =>
            lvLeftArrowKey.Items.Count > 0
                ? $"{config.LeftArrowClassName} ({lvLeftArrowKey.Items.Count})"
                : config.LeftArrowClassName;

        protected string RightClassifiedLabel =>
            lvRightArrowKey.Items.Count > 0
                ? $"{config.RightArrowClass} ({lvRightArrowKey.Items.Count})"
                : config.RightArrowClass;

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
            lvSource.Columns.Add("Name", 314);
            lvSource.Columns.Add("Last Accessed", 126);
            LoadSourceFilesList(loadImage: false);

            lvLeftArrowKey.View = View.Details;
            lvLeftArrowKey.FullRowSelect = true;
            lvLeftArrowKey.GridLines = true;
            lvLeftArrowKey.Columns.Add("Name", 180);
            lvLeftArrowKey.Columns.Add("Last Accessed", 126);
            LoadClassifiedFilesList(Path.Combine(config.SourceFolder, resultsFolder, config.LeftArrowClassName), lvLeftArrowKey);

            lvRightArrowKey.View = View.Details;
            lvRightArrowKey.FullRowSelect = true;
            lvRightArrowKey.GridLines = true;
            lvRightArrowKey.Columns.Add("Name", 180);
            lvRightArrowKey.Columns.Add("Last Accessed", 126);
            LoadClassifiedFilesList(Path.Combine(config.SourceFolder, resultsFolder, config.RightArrowClass), lvRightArrowKey);

            picImage.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void LoadImage()
        {
            var imagePath = lvSource.Items.Count > 0 ? $"{txtPathSource.Text}\\{lvSource.Items[0].Text}" : string.Empty;
            if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath))
            {
                picImage.Image = null;
            }
            else
            {
                using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    using (Image image = Image.FromStream(fileStream))
                    {
                        picImage.Image = new Bitmap(image);
                    }
                }
                lvSource.SelectedItems.Clear();
                lvSource.Items[0].Selected = true;
            }
        }

        private string GetClassifiedFolderPath(string className)
        {
            return Path.Combine(config.SourceFolder, $"{resultsFolder}\\{className}");
        }

        private void WriteConfig()
        {
            if (!canWriteConfig) return;
            config.SourceFolder = txtPathSource.Text;
            config.LeftArrowClassName = txtLeftArrowClass.Text.Trim().Replace(" ", "");
            config.RightArrowClass = txtRightArrowClass.Text.Trim().Replace(" ", "");
            File.WriteAllText(configPath, JsonSerializer.Serialize(config));
        }

        private void LoadSourceFilesList(bool loadImage = true, bool readFiles = true)
        {
            if (readFiles || lvSource.Items.Count == 0)
            {
                lvSource.Items.Clear();
                remainingInFolderCount = this.imagesFileFilter.SelectMany(f => Directory.EnumerateFiles(config.SourceFolder, f, new EnumerationOptions()
                {
                    RecurseSubdirectories = false,
                }))
                    .Count();

                var files = this.imagesFileFilter.SelectMany(f => Directory.EnumerateFiles(config.SourceFolder, f, new EnumerationOptions()
                {
                    RecurseSubdirectories = false,
                })
                    .OrderBy(f => new FileInfo(f).Name)
                    .Take(100))
                    .Select(f => new FileInfo(f));

                remainingInBatchCount = files.Count();

                /* Add to view list only the first 100 files to make it lighter and faster */
                foreach (var file in files)
                {
                    var item = new ListViewItem(file.Name);
                    item.SubItems.Add(file.LastAccessTime.ToString());
                    lvSource.Items.Add(item);
                }
            }

            lblRemainingInBatch.Text = $"{remainingInBatch}{remainingInBatchCount}";
            lblRemainingInFolder.Text = $"{remainingInFolder}{remainingInFolderCount}";

            if (lvSource.Items.Count > 0)
            {
                lbStatus.Visible = true;
                btnStart.Enabled = true;
                if (loadImage)
                {
                    LoadImage();
                }
            }
            else
            {
                lbStatus.Visible = false;
                btnStart.Enabled = false;
                if (isClassifying)
                {
                    Stop();
                }
            }
        }

        private void SetLbImagesTexts()
        {
            lbNegativeImages.Text = LeftClassifiedLabel;
            lbPositiveImages.Text = RightClassifiedLabel;
        }

        private void LoadClassifiedFilesList(string folderPath, ListView? lv)
        {
            if (lv is null)
            {
                return;
            }

            lv.Items.Clear();

            if (!Directory.Exists(folderPath))
            {
                SetLbImagesTexts();
                return;
            }

            var files = this.imagesFileFilter.SelectMany(f => Directory.GetFiles(folderPath, f))
                                             .Select(f => new FileInfo(f));

            if (files is null || files.Count() == 0)
            {
                SetLbImagesTexts();
                return;
            }

            foreach (var file in files)
            {
                var item = new ListViewItem(file.Name);
                item.SubItems.Add(file.LastAccessTime.ToString());
                lv.Items.Add(item);
            }

            lvLeftArrowKey.SelectedItems.Clear();
            lvRightArrowKey.SelectedItems.Clear();
            lv.Sorting = SortOrder.Descending;
            lv.Sort();
            lv.Items[0].Selected = true;
            SetLbImagesTexts();
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
                    LoadSourceFilesList(loadImage: false);
                    LoadClassifiedFilesList(GetClassifiedFolderPath(config.LeftArrowClassName), lvLeftArrowKey);
                    LoadClassifiedFilesList(GetClassifiedFolderPath(config.RightArrowClass), lvRightArrowKey);
                    isSourceEmpty();
                }
            }
        }

        private void Start()
        {
            LoadSourceFilesList();
            if (lvSource.Items.Count == 0)
            {
                MessageBox.Show("No images to classify", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            isClassifying = true;
            txtLeftArrowClass.Enabled = false;
            txtRightArrowClass.Enabled = false;
            txtPathSource.Enabled = false;
            btnFolderSource.Enabled = false;
            btnStart.Text = "Stop (ESC)";
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
            if (!Directory.Exists(GetClassifiedFolderPath(unknownFolder)))
            {
                Directory.CreateDirectory(GetClassifiedFolderPath(unknownFolder));
            }
        }

        private void Stop()
        {
            isClassifying = false;
            txtLeftArrowClass.Enabled = true;
            txtRightArrowClass.Enabled = true;
            txtPathSource.Enabled = true;
            btnFolderSource.Enabled = true;
            btnStart.Text = "Start (F5)";
            lbStatus.Text = statusTextOff;
            if (picImage.Image != null)
            {
                picImage.Image.Dispose();
                picImage.Image = null;
            }
            lvSource.SelectedItems.Clear();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isClassifying)
            {
                Stop();
            }
            else
            {
                Start();
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

        private void PrepareClassification(
            out string sourceFilePath,
            out string classfiedFolderPath,
            out string destinationFilePath,
            out string destinationFileName,
            string className,
            ListView? lvClassified)
        {
            destinationFileName = lvSource.SelectedItems[0].Text;
            lvSource.Items.RemoveAt(0);

            sourceFilePath = Path.Combine(config.SourceFolder, destinationFileName);
            var destinationFolderPath = classfiedFolderPath = GetClassifiedFolderPath(className);
            destinationFilePath = Path.Combine(destinationFolderPath, destinationFileName);
            lastDestinationFileName = destinationFileName;
            lastDestinationFilePath = destinationFilePath;
            lastDestinationFolderPath = destinationFolderPath;
            lastLvClassified = lvClassified;

            remainingInBatchCount--;
            remainingInFolderCount--;
        }

        private bool Classify(Keys keyData)
        {
            try
            {
                if (!(keyData == Keys.Up ||
                        keyData == Keys.Right ||
                        keyData == Keys.Down ||
                        keyData == Keys.Left ||
                        keyData == Keys.Z))
                {
                    return true;
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
                        PrepareClassification(
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
                        PrepareClassification(
                            out sourceFilePath,
                            out classfiedFolderPath,
                            out destinationFilePath,
                            out destinationFileName,
                            config.RightArrowClass,
                            lvRightArrowKey);
                        break;
                    case Keys.Up:/* Skip - Unknown */
                    case Keys.Down: /* Skip - Unknown */
                        if (isSourceEmpty())
                        {
                            return true;
                        }
                        PrepareClassification(
                            out sourceFilePath,
                            out classfiedFolderPath,
                            out destinationFilePath,
                            out destinationFileName,
                            unknownFolder,
                            null);
                        break;
                    case Keys.Z: /* Undo - only last Left/Right/Down key - it doesn't have a full history atm */
                        if (string.IsNullOrWhiteSpace(lastDestinationFilePath))
                        {
                            MessageBox.Show("Can't undo", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        sourceFilePath = lastDestinationFilePath;
                        lvClassified = lastLvClassified;
                        classfiedFolderPath = lastDestinationFolderPath;
                        destinationFilePath = Path.Combine(config.SourceFolder, lastDestinationFileName);

                        remainingInBatchCount++;
                        remainingInFolderCount++;
                        
                        var item = new ListViewItem(lastDestinationFileName);
                        item.SubItems.Add(File.GetLastAccessTime(lastDestinationFilePath).ToString());
                        lvSource.Items.Insert(0, item);

                        lastDestinationFileName = string.Empty;
                        lastDestinationFilePath = string.Empty;
                        lastDestinationFolderPath = string.Empty;
                        lastLvClassified = null;
                        break;
                    default:
                        return true;
                }

                picImage.Image?.Dispose();
                picImage.Image = null;
                picImage.Update();

                File.Move(sourceFilePath, destinationFilePath);
                
                LoadClassifiedFilesList(classfiedFolderPath, lvClassified);
                LoadSourceFilesList(readFiles: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        private bool KeyPressHandler(Keys keyData)
        {
            if (isClassifying)
            {
                if (keyData == Keys.Escape)
                {
                    Stop();
                    return true;
                }
                return Classify(keyData);
            }
            else if (keyData == Keys.F5)
            {
                Start();
            }
            return false;
        }
    }
}
