namespace FastImageClassifier
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmMain_Load);
        }

        private readonly List<string> imagesFileFilter = new List<string> { "*.jpg", "*.jpeg", "*.png", "*.gif" };

        private void FrmMain_Load(object? sender, EventArgs e)
        {
            txtPathSource.Text = Environment.SpecialFolder.MyDocuments.ToString();
            lbNegativeImages.Text = txtLeftArrowClass.Text;
            lbPositiveImages.Text = txtRightArrowClass.Text;

            lvSource.View = View.Details;
            lvSource.FullRowSelect = true;
            lvSource.GridLines = true;
            lvSource.Columns.Add("Name", 240);
            lvSource.Columns.Add("Size", 60);
            lvSource.Columns.Add("Date Modified", 139);
            LoadSourceFilesList(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            lvLeftArrowKey.View = View.Details;
            lvLeftArrowKey.FullRowSelect = true;
            lvLeftArrowKey.GridLines = true;
            lvLeftArrowKey.Columns.Add("Name", 200);
            lvLeftArrowKey.Columns.Add("Date Modified", 93);
            LoadClassifiedFilesList(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), lvLeftArrowKey);

            lvRightArrowKey.View = View.Details;
            lvRightArrowKey.FullRowSelect = true;
            lvRightArrowKey.GridLines = true;
            lvRightArrowKey.Columns.Add("Name", 200);
            lvRightArrowKey.Columns.Add("Date Modified", 93);
            LoadClassifiedFilesList(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), lvLeftArrowKey);

            picImage.SizeMode = PictureBoxSizeMode.StretchImage;
            var imagePath = lvSource.Items.Count > 0 ? txtPathSource.Text + lvSource.Items[0].Text : string.Empty;
            if (!string.IsNullOrWhiteSpace(imagePath))
            {
                picImage.Image = Image.FromFile(imagePath);
            }
        }

        private void LoadSourceFilesList(string folderPath)
        {
            lvSource.Items.Clear();
            var files = this.imagesFileFilter.SelectMany(f => Directory.GetFiles(folderPath, f))
                               .Select(f => new FileInfo(f));

            foreach (var file in files)
            {
                var item = new ListViewItem(file.Name);
                item.SubItems.Add(file.Length.ToString());
                item.SubItems.Add(file.LastWriteTime.ToString());
                lvSource.Items.Add(item);
            }
        }

        private void LoadClassifiedFilesList(string folderPath, ListView lv)
        {
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
                    string selectedPath = folderBrowserDialog.SelectedPath;
                    txtPathSource.Text = selectedPath;
                    LoadSourceFilesList(selectedPath);
                }
            }
        }

        private void btnFolderDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyDocuments;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void txtLeftArrowClass_TextChanged(object sender, EventArgs e)
        {
            lbNegativeImages.Text = txtLeftArrowClass.Text;
        }

        private void txtRightArrowClass_TextChanged(object sender, EventArgs e)
        {
            lbPositiveImages.Text = txtRightArrowClass.Text;
        }
    }
}
