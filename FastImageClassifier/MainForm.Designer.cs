namespace FastImageLabeler
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            gpbSetup = new GroupBox();
            lbStatus = new Label();
            lbInstructions = new Label();
            txtPathSource = new TextBox();
            btnFolderSource = new Button();
            lbSource = new Label();
            label2 = new Label();
            label1 = new Label();
            lblRightArrow = new Label();
            lblLeftArrow = new Label();
            txtRightArrowLabel = new TextBox();
            txtLeftArrowLabel = new TextBox();
            foderDestination = new FolderBrowserDialog();
            picImage = new PictureBox();
            btnStart = new Button();
            lvSource = new ListView();
            lvLeftArrowKey = new ListView();
            lvRightArrowKey = new ListView();
            lbSourceList = new Label();
            lbNegativeImages = new Label();
            lbPositiveImages = new Label();
            gpbImage = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlSourceStart = new Panel();
            lblRemainingInBatch = new Label();
            lblRemainingInFolder = new Label();
            pnlLabeled = new Panel();
            pnlLabeledRight = new Panel();
            pnlLabeledLeft = new Panel();
            gpbSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            gpbImage.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlSourceStart.SuspendLayout();
            pnlLabeled.SuspendLayout();
            pnlLabeledRight.SuspendLayout();
            pnlLabeledLeft.SuspendLayout();
            SuspendLayout();
            // 
            // gpbSetup
            // 
            gpbSetup.Controls.Add(lbStatus);
            gpbSetup.Controls.Add(lbInstructions);
            gpbSetup.Controls.Add(txtPathSource);
            gpbSetup.Controls.Add(btnFolderSource);
            gpbSetup.Controls.Add(lbSource);
            gpbSetup.Controls.Add(label2);
            gpbSetup.Controls.Add(label1);
            gpbSetup.Controls.Add(lblRightArrow);
            gpbSetup.Controls.Add(lblLeftArrow);
            gpbSetup.Controls.Add(txtRightArrowLabel);
            gpbSetup.Controls.Add(txtLeftArrowLabel);
            gpbSetup.Location = new Point(13, 13);
            gpbSetup.Name = "gpbSetup";
            gpbSetup.Size = new Size(444, 401);
            gpbSetup.TabIndex = 0;
            gpbSetup.TabStop = false;
            gpbSetup.Text = "Setup";
            // 
            // lbStatus
            // 
            lbStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbStatus.Location = new Point(6, 350);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(427, 48);
            lbStatus.TabIndex = 12;
            lbStatus.TextAlign = ContentAlignment.MiddleCenter;
            lbStatus.Visible = false;
            // 
            // lbInstructions
            // 
            lbInstructions.Location = new Point(6, 215);
            lbInstructions.Name = "lbInstructions";
            lbInstructions.Size = new Size(427, 125);
            lbInstructions.TabIndex = 11;
            lbInstructions.Text = resources.GetString("lbInstructions.Text");
            // 
            // txtPathSource
            // 
            txtPathSource.Enabled = false;
            txtPathSource.Location = new Point(179, 147);
            txtPathSource.Name = "txtPathSource";
            txtPathSource.Size = new Size(254, 23);
            txtPathSource.TabIndex = 10;
            // 
            // btnFolderSource
            // 
            btnFolderSource.Location = new Point(179, 176);
            btnFolderSource.Name = "btnFolderSource";
            btnFolderSource.Size = new Size(254, 23);
            btnFolderSource.TabIndex = 3;
            btnFolderSource.Text = "Select folder";
            btnFolderSource.UseVisualStyleBackColor = true;
            btnFolderSource.Click += btnFolderSource_Click;
            // 
            // lbSource
            // 
            lbSource.AutoSize = true;
            lbSource.Location = new Point(6, 150);
            lbSource.Name = "lbSource";
            lbSource.Size = new Size(117, 15);
            lbSource.TabIndex = 8;
            lbSource.Text = "Images source folder";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F);
            label2.Location = new Point(179, 115);
            label2.Name = "label2";
            label2.Size = new Size(132, 13);
            label2.TabIndex = 5;
            label2.Text = "(Spaces will be removed)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F);
            label1.Location = new Point(179, 60);
            label1.Name = "label1";
            label1.Size = new Size(132, 13);
            label1.TabIndex = 4;
            label1.Text = "(Spaces will be removed)";
            // 
            // lblRightArrow
            // 
            lblRightArrow.AutoSize = true;
            lblRightArrow.Location = new Point(6, 92);
            lblRightArrow.Name = "lblRightArrow";
            lblRightArrow.Size = new Size(160, 15);
            lblRightArrow.TabIndex = 2;
            lblRightArrow.Text = "\"Right arrow key\" label name";
            // 
            // lblLeftArrow
            // 
            lblLeftArrow.AutoSize = true;
            lblLeftArrow.Location = new Point(6, 37);
            lblLeftArrow.Name = "lblLeftArrow";
            lblLeftArrow.Size = new Size(152, 15);
            lblLeftArrow.TabIndex = 0;
            lblLeftArrow.Text = "\"Left arrow key\" label name";
            // 
            // txtRightArrowLabel
            // 
            txtRightArrowLabel.Location = new Point(179, 89);
            txtRightArrowLabel.Name = "txtRightArrowLabel";
            txtRightArrowLabel.Size = new Size(254, 23);
            txtRightArrowLabel.TabIndex = 2;
            txtRightArrowLabel.Text = "Positive";
            txtRightArrowLabel.TextChanged += txtRightArrowLabel_TextChanged;
            // 
            // txtLeftArrowLabel
            // 
            txtLeftArrowLabel.Location = new Point(179, 34);
            txtLeftArrowLabel.Name = "txtLeftArrowLabel";
            txtLeftArrowLabel.Size = new Size(254, 23);
            txtLeftArrowLabel.TabIndex = 1;
            txtLeftArrowLabel.Text = "Negative";
            txtLeftArrowLabel.TextChanged += txtLeftArrowLabel_TextChanged;
            // 
            // picImage
            // 
            picImage.Dock = DockStyle.Fill;
            picImage.Location = new Point(3, 19);
            picImage.Name = "picImage";
            picImage.Size = new Size(630, 370);
            picImage.TabIndex = 1;
            picImage.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.Enabled = false;
            btnStart.Font = new Font("Segoe UI", 12F);
            btnStart.Location = new Point(0, 180);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(444, 55);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start (F5)";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lvSource
            // 
            lvSource.Enabled = false;
            lvSource.Font = new Font("Segoe UI", 8F);
            lvSource.Location = new Point(0, 24);
            lvSource.Name = "lvSource";
            lvSource.Scrollable = false;
            lvSource.Size = new Size(444, 141);
            lvSource.TabIndex = 3;
            lvSource.UseCompatibleStateImageBehavior = false;
            // 
            // lvLeftArrowKey
            // 
            lvLeftArrowKey.Enabled = false;
            lvLeftArrowKey.Font = new Font("Segoe UI", 8F);
            lvLeftArrowKey.ForeColor = Color.MediumOrchid;
            lvLeftArrowKey.Location = new Point(0, 24);
            lvLeftArrowKey.Name = "lvLeftArrowKey";
            lvLeftArrowKey.Scrollable = false;
            lvLeftArrowKey.Size = new Size(310, 210);
            lvLeftArrowKey.TabIndex = 4;
            lvLeftArrowKey.UseCompatibleStateImageBehavior = false;
            // 
            // lvRightArrowKey
            // 
            lvRightArrowKey.Enabled = false;
            lvRightArrowKey.Font = new Font("Segoe UI", 8F);
            lvRightArrowKey.ForeColor = Color.SlateBlue;
            lvRightArrowKey.Location = new Point(0, 24);
            lvRightArrowKey.Name = "lvRightArrowKey";
            lvRightArrowKey.Scrollable = false;
            lvRightArrowKey.Size = new Size(310, 210);
            lvRightArrowKey.TabIndex = 5;
            lvRightArrowKey.UseCompatibleStateImageBehavior = false;
            // 
            // lbSourceList
            // 
            lbSourceList.AutoSize = true;
            lbSourceList.Location = new Point(3, 6);
            lbSourceList.Name = "lbSourceList";
            lbSourceList.Size = new Size(43, 15);
            lbSourceList.TabIndex = 6;
            lbSourceList.Text = "Source";
            // 
            // lbNegativeImages
            // 
            lbNegativeImages.AutoSize = true;
            lbNegativeImages.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbNegativeImages.ForeColor = Color.MediumOrchid;
            lbNegativeImages.Location = new Point(0, 6);
            lbNegativeImages.Name = "lbNegativeImages";
            lbNegativeImages.Size = new Size(58, 15);
            lbNegativeImages.TabIndex = 7;
            lbNegativeImages.Text = "Negative";
            // 
            // lbPositiveImages
            // 
            lbPositiveImages.AutoSize = true;
            lbPositiveImages.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbPositiveImages.ForeColor = Color.SlateBlue;
            lbPositiveImages.Location = new Point(3, 6);
            lbPositiveImages.Name = "lbPositiveImages";
            lbPositiveImages.Size = new Size(51, 15);
            lbPositiveImages.TabIndex = 8;
            lbPositiveImages.Text = "Positive";
            // 
            // gpbImage
            // 
            gpbImage.AutoSize = true;
            gpbImage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gpbImage.Controls.Add(picImage);
            gpbImage.Dock = DockStyle.Fill;
            gpbImage.Location = new Point(467, 13);
            gpbImage.Margin = new Padding(7, 3, 3, 3);
            gpbImage.Name = "gpbImage";
            gpbImage.Padding = new Padding(3, 3, 3, 12);
            gpbImage.Size = new Size(636, 401);
            gpbImage.TabIndex = 9;
            gpbImage.TabStop = false;
            gpbImage.Text = "Image";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(pnlSourceStart, 0, 1);
            tableLayoutPanel1.Controls.Add(gpbImage, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlLabeled, 1, 1);
            tableLayoutPanel1.Controls.Add(gpbSetup, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 62.8698235F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 37.1301765F));
            tableLayoutPanel1.Size = new Size(1116, 668);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // pnlSourceStart
            // 
            pnlSourceStart.Controls.Add(lblRemainingInBatch);
            pnlSourceStart.Controls.Add(lblRemainingInFolder);
            pnlSourceStart.Controls.Add(lvSource);
            pnlSourceStart.Controls.Add(btnStart);
            pnlSourceStart.Controls.Add(lbSourceList);
            pnlSourceStart.Dock = DockStyle.Bottom;
            pnlSourceStart.Location = new Point(13, 420);
            pnlSourceStart.Name = "pnlSourceStart";
            pnlSourceStart.Size = new Size(444, 235);
            pnlSourceStart.TabIndex = 0;
            // 
            // lblRemainingInBatch
            // 
            lblRemainingInBatch.AutoSize = true;
            lblRemainingInBatch.Location = new Point(112, 6);
            lblRemainingInBatch.Name = "lblRemainingInBatch";
            lblRemainingInBatch.Size = new Size(122, 15);
            lblRemainingInBatch.TabIndex = 8;
            lblRemainingInBatch.Text = "Remaining in batch: 0";
            // 
            // lblRemainingInFolder
            // 
            lblRemainingInFolder.Location = new Point(293, 6);
            lblRemainingInFolder.Name = "lblRemainingInFolder";
            lblRemainingInFolder.Size = new Size(148, 15);
            lblRemainingInFolder.TabIndex = 7;
            lblRemainingInFolder.Text = "Remaining in folder: 0";
            lblRemainingInFolder.TextAlign = ContentAlignment.TopRight;
            // 
            // pnlLabeled
            // 
            pnlLabeled.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlLabeled.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlLabeled.Controls.Add(pnlLabeledRight);
            pnlLabeled.Controls.Add(pnlLabeledLeft);
            pnlLabeled.Location = new Point(463, 420);
            pnlLabeled.Name = "pnlLabeled";
            pnlLabeled.Padding = new Padding(2, 0, 0, 0);
            pnlLabeled.Size = new Size(640, 235);
            pnlLabeled.TabIndex = 1;
            // 
            // pnlLabeledRight
            // 
            pnlLabeledRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlLabeledRight.Controls.Add(lvRightArrowKey);
            pnlLabeledRight.Controls.Add(lbPositiveImages);
            pnlLabeledRight.Location = new Point(330, 0);
            pnlLabeledRight.Name = "pnlLabeledRight";
            pnlLabeledRight.Size = new Size(310, 236);
            pnlLabeledRight.TabIndex = 1;
            // 
            // pnlLabeleddLeft
            // 
            pnlLabeledLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pnlLabeledLeft.Controls.Add(lvLeftArrowKey);
            pnlLabeledLeft.Controls.Add(lbNegativeImages);
            pnlLabeledLeft.Location = new Point(5, 0);
            pnlLabeledLeft.Name = "pnlLabeleddLeft";
            pnlLabeledLeft.Size = new Size(310, 236);
            pnlLabeledLeft.TabIndex = 0;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 668);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FaBIL - Fast Binary Image Labeler";
            gpbSetup.ResumeLayout(false);
            gpbSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            gpbImage.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlSourceStart.ResumeLayout(false);
            pnlSourceStart.PerformLayout();
            pnlLabeled.ResumeLayout(false);
            pnlLabeledRight.ResumeLayout(false);
            pnlLabeledRight.PerformLayout();
            pnlLabeledLeft.ResumeLayout(false);
            pnlLabeledLeft.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gpbSetup;
        private Label lblLeftArrow;
        private TextBox txtLeftArrowLabel;
        private Label lblRightArrow;
        private TextBox txtRightArrowLabel;
        private Label label1;
        private Label label2;
        private FolderBrowserDialog foderDestination;
        private Button btnFolderSource;
        private Label lbSource;
        private TextBox txtPathSource;
        private PictureBox picImage;
        private Button btnStart;
        private ListView lvSource;
        private ListView lvLeftArrowKey;
        private ListView lvRightArrowKey;
        private Label lbInstructions;
        private Label lbSourceList;
        private Label lbNegativeImages;
        private Label lbPositiveImages;
        private GroupBox gpbImage;
        private Label lbStatus;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlSourceStart;
        private Panel pnlLabeled;
        private Panel pnlLabeledRight;
        private Panel pnlLabeledLeft;
        private Label lblRemainingInFolder;
        private Label lblRemainingInBatch;
    }
}
