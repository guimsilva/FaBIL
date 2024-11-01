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
            gpbClassesDetails = new GroupBox();
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
            label3 = new Label();
            gpbClassesDetails.SuspendLayout();
            SuspendLayout();
            // 
            // gpbClassesDetails
            // 
            gpbClassesDetails.Controls.Add(label3);
            gpbClassesDetails.Controls.Add(txtPathSource);
            gpbClassesDetails.Controls.Add(btnFolderSource);
            gpbClassesDetails.Controls.Add(lbSource);
            gpbClassesDetails.Controls.Add(label2);
            gpbClassesDetails.Controls.Add(label1);
            gpbClassesDetails.Controls.Add(lblRightArrow);
            gpbClassesDetails.Controls.Add(lblLeftArrow);
            gpbClassesDetails.Controls.Add(txtRightArrowClass);
            gpbClassesDetails.Controls.Add(txtLeftArrowClass);
            gpbClassesDetails.Location = new Point(12, 12);
            gpbClassesDetails.Name = "gpbClassesDetails";
            gpbClassesDetails.Size = new Size(439, 331);
            gpbClassesDetails.TabIndex = 0;
            gpbClassesDetails.TabStop = false;
            gpbClassesDetails.Text = "Classes Details";
            // 
            // txtPathSource
            // 
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
            btnFolderSource.TabIndex = 9;
            btnFolderSource.Text = "Select folder";
            btnFolderSource.UseVisualStyleBackColor = true;
            btnFolderSource.Click += btnFolderSource_Click;
            // 
            // lbSource
            // 
            lbSource.AutoSize = true;
            lbSource.Location = new Point(6, 150);
            lbSource.Name = "lbSource";
            lbSource.Size = new Size(43, 15);
            lbSource.TabIndex = 8;
            lbSource.Text = "Source";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(179, 115);
            label2.Name = "label2";
            label2.Size = new Size(138, 15);
            label2.TabIndex = 5;
            label2.Text = "(Spaces will be removed)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(179, 60);
            label1.Name = "label1";
            label1.Size = new Size(138, 15);
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
            txtRightArrowClass.TabIndex = 3;
            txtRightArrowClass.Text = "Positive";
            // 
            // txtLeftArrowClass
            // 
            txtLeftArrowClass.Location = new Point(179, 34);
            txtLeftArrowClass.Name = "txtLeftArrowClass";
            txtLeftArrowClass.Size = new Size(254, 23);
            txtLeftArrowClass.TabIndex = 1;
            txtLeftArrowClass.Text = "Negative";
            // 
            // label3
            // 
            label3.Location = new Point(6, 229);
            label3.Name = "label3";
            label3.Size = new Size(427, 87);
            label3.TabIndex = 14;
            label3.Text = resources.GetString("label3.Text");
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1117, 596);
            Controls.Add(gpbClassesDetails);
            Name = "FrmMain";
            Text = "Fast Image Classifier";
            gpbClassesDetails.ResumeLayout(false);
            gpbClassesDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpbClassesDetails;
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
        private Label label3;
    }
}
