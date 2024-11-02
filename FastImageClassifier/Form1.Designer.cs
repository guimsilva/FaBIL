namespace FastImageClassifier
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
            txtRightArrowClass = new TextBox();
            txtLeftArrowClass = new TextBox();
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
            pnlClassified = new Panel();
            pnlClassifiedRight = new Panel();
            pnlClassifiedLeft = new Panel();
            gpbSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            gpbImage.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlSourceStart.SuspendLayout();
            pnlClassified.SuspendLayout();
            pnlClassifiedRight.SuspendLayout();
            pnlClassifiedLeft.SuspendLayout();
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
            gpbSetup.Controls.Add(txtRightArrowClass);
            gpbSetup.Controls.Add(txtLeftArrowClass);
            gpbSetup.Location = new Point(13, 13);
            gpbSetup.Name = "gpbSetup";
            gpbSetup.Size = new Size(438, 401);
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
            lblRightArrow.Text = "\"Right arrow key\" class name";
            // 
            // lblLeftArrow
            // 
            lblLeftArrow.AutoSize = true;
            lblLeftArrow.Location = new Point(6, 37);
            lblLeftArrow.Name = "lblLeftArrow";
            lblLeftArrow.Size = new Size(152, 15);
            lblLeftArrow.TabIndex = 0;
            lblLeftArrow.Text = "\"Left arrow key\" class name";
            // 
            // txtRightArrowClass
            // 
            txtRightArrowClass.Location = new Point(179, 89);
            txtRightArrowClass.Name = "txtRightArrowClass";
            txtRightArrowClass.Size = new Size(254, 23);
            txtRightArrowClass.TabIndex = 2;
            txtRightArrowClass.Text = "Positive";
            txtRightArrowClass.TextChanged += txtRightArrowClass_TextChanged;
            // 
            // txtLeftArrowClass
            // 
            txtLeftArrowClass.Location = new Point(179, 34);
            txtLeftArrowClass.Name = "txtLeftArrowClass";
            txtLeftArrowClass.Size = new Size(254, 23);
            txtLeftArrowClass.TabIndex = 1;
            txtLeftArrowClass.Text = "Negative";
            txtLeftArrowClass.TextChanged += txtLeftArrowClass_TextChanged;
            // 
            // picImage
            // 
            picImage.Dock = DockStyle.Fill;
            picImage.Location = new Point(3, 19);
            picImage.Name = "picImage";
            picImage.Size = new Size(634, 379);
            picImage.TabIndex = 1;
            picImage.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.Enabled = false;
            btnStart.Font = new Font("Segoe UI", 12F);
            btnStart.Location = new Point(0, 180);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(438, 55);
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
            lvSource.Size = new Size(438, 141);
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
            lvLeftArrowKey.Size = new Size(307, 210);
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
            lvRightArrowKey.Size = new Size(307, 210);
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
            gpbImage.Location = new Point(463, 13);
            gpbImage.Name = "gpbImage";
            gpbImage.Size = new Size(640, 401);
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
            tableLayoutPanel1.Controls.Add(pnlClassified, 1, 1);
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
            pnlSourceStart.Controls.Add(lvSource);
            pnlSourceStart.Controls.Add(btnStart);
            pnlSourceStart.Controls.Add(lbSourceList);
            pnlSourceStart.Dock = DockStyle.Bottom;
            pnlSourceStart.Location = new Point(13, 420);
            pnlSourceStart.Name = "pnlSourceStart";
            pnlSourceStart.Size = new Size(444, 235);
            pnlSourceStart.TabIndex = 0;
            // 
            // pnlClassified
            // 
            pnlClassified.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlClassified.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlClassified.Controls.Add(pnlClassifiedRight);
            pnlClassified.Controls.Add(pnlClassifiedLeft);
            pnlClassified.Location = new Point(463, 420);
            pnlClassified.Name = "pnlClassified";
            pnlClassified.Size = new Size(640, 235);
            pnlClassified.TabIndex = 1;
            // 
            // pnlClassifiedRight
            // 
            pnlClassifiedRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlClassifiedRight.Controls.Add(lvRightArrowKey);
            pnlClassifiedRight.Controls.Add(lbPositiveImages);
            pnlClassifiedRight.Location = new Point(330, 0);
            pnlClassifiedRight.Name = "pnlClassifiedRight";
            pnlClassifiedRight.Size = new Size(310, 236);
            pnlClassifiedRight.TabIndex = 1;
            // 
            // pnlClassifiedLeft
            // 
            pnlClassifiedLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pnlClassifiedLeft.Controls.Add(lvLeftArrowKey);
            pnlClassifiedLeft.Controls.Add(lbNegativeImages);
            pnlClassifiedLeft.Location = new Point(3, 0);
            pnlClassifiedLeft.Name = "pnlClassifiedLeft";
            pnlClassifiedLeft.Size = new Size(310, 236);
            pnlClassifiedLeft.TabIndex = 0;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 668);
            Controls.Add(tableLayoutPanel1);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fast Binary Image Classifier";
            gpbSetup.ResumeLayout(false);
            gpbSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            gpbImage.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlSourceStart.ResumeLayout(false);
            pnlSourceStart.PerformLayout();
            pnlClassified.ResumeLayout(false);
            pnlClassifiedRight.ResumeLayout(false);
            pnlClassifiedRight.PerformLayout();
            pnlClassifiedLeft.ResumeLayout(false);
            pnlClassifiedLeft.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gpbSetup;
        private Label lblLeftArrow;
        private TextBox txtLeftArrowClass;
        private Label lblRightArrow;
        private TextBox txtRightArrowClass;
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
        private Panel pnlClassified;
        private Panel pnlClassifiedRight;
        private Panel pnlClassifiedLeft;
    }
}
