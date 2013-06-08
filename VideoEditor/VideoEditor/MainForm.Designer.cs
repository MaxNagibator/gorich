namespace VideoEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiBrowseButton = new System.Windows.Forms.Button();
            this.uiAviFileNameTextBox = new System.Windows.Forms.TextBox();
            this.uiVideoStreamBrowseControl = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uiDecreaseRoadCollectionWidthButton = new System.Windows.Forms.Button();
            this.uiIncreaseRoadCollectionWidthButton = new System.Windows.Forms.Button();
            this.uiDeleteVideoStreamButton = new System.Windows.Forms.Button();
            this.uiAddVideoStreamButton = new System.Windows.Forms.Button();
            this.uiVideoStreamViewCollectionControl = new VideoEditor.RoadCollectionControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBrowseButton
            // 
            this.uiBrowseButton.Location = new System.Drawing.Point(3, 3);
            this.uiBrowseButton.Name = "uiBrowseButton";
            this.uiBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.uiBrowseButton.TabIndex = 0;
            this.uiBrowseButton.Text = "Browse";
            this.uiBrowseButton.UseVisualStyleBackColor = true;
            this.uiBrowseButton.Click += new System.EventHandler(this.uiBrowseButton_Click);
            // 
            // uiAviFileNameTextBox
            // 
            this.uiAviFileNameTextBox.Location = new System.Drawing.Point(84, 3);
            this.uiAviFileNameTextBox.Name = "uiAviFileNameTextBox";
            this.uiAviFileNameTextBox.Size = new System.Drawing.Size(179, 20);
            this.uiAviFileNameTextBox.TabIndex = 1;
            // 
            // uiVideoStreamBrowseControl
            // 
            this.uiVideoStreamBrowseControl.AutoScroll = true;
            this.uiVideoStreamBrowseControl.BackColor = System.Drawing.SystemColors.Info;
            this.uiVideoStreamBrowseControl.Location = new System.Drawing.Point(3, 29);
            this.uiVideoStreamBrowseControl.Name = "uiVideoStreamBrowseControl";
            this.uiVideoStreamBrowseControl.Size = new System.Drawing.Size(260, 280);
            this.uiVideoStreamBrowseControl.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(543, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(733, 312);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.uiBrowseButton);
            this.splitContainer1.Panel1.Controls.Add(this.uiAviFileNameTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.uiVideoStreamBrowseControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uiDecreaseRoadCollectionWidthButton);
            this.splitContainer1.Panel2.Controls.Add(this.uiIncreaseRoadCollectionWidthButton);
            this.splitContainer1.Panel2.Controls.Add(this.uiDeleteVideoStreamButton);
            this.splitContainer1.Panel2.Controls.Add(this.uiAddVideoStreamButton);
            this.splitContainer1.Panel2.Controls.Add(this.uiVideoStreamViewCollectionControl);
            this.splitContainer1.Size = new System.Drawing.Size(1276, 602);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.TabIndex = 5;
            // 
            // uiDecreaseRoadCollectionWidthButton
            // 
            this.uiDecreaseRoadCollectionWidthButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDecreaseRoadCollectionWidthButton.Location = new System.Drawing.Point(1200, 259);
            this.uiDecreaseRoadCollectionWidthButton.Name = "uiDecreaseRoadCollectionWidthButton";
            this.uiDecreaseRoadCollectionWidthButton.Size = new System.Drawing.Size(29, 24);
            this.uiDecreaseRoadCollectionWidthButton.TabIndex = 9;
            this.uiDecreaseRoadCollectionWidthButton.Text = "-";
            this.uiDecreaseRoadCollectionWidthButton.UseVisualStyleBackColor = true;
            this.uiDecreaseRoadCollectionWidthButton.Click += new System.EventHandler(this.uiDecreaseRoadCollectionWidthButton_Click);
            // 
            // uiIncreaseRoadCollectionWidthButton
            // 
            this.uiIncreaseRoadCollectionWidthButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiIncreaseRoadCollectionWidthButton.Location = new System.Drawing.Point(1235, 259);
            this.uiIncreaseRoadCollectionWidthButton.Name = "uiIncreaseRoadCollectionWidthButton";
            this.uiIncreaseRoadCollectionWidthButton.Size = new System.Drawing.Size(29, 24);
            this.uiIncreaseRoadCollectionWidthButton.TabIndex = 8;
            this.uiIncreaseRoadCollectionWidthButton.Text = "+";
            this.uiIncreaseRoadCollectionWidthButton.UseVisualStyleBackColor = true;
            this.uiIncreaseRoadCollectionWidthButton.Click += new System.EventHandler(this.uiIncreaseRoadCollectionWidthButton_Click);
            // 
            // uiDeleteVideoStreamButton
            // 
            this.uiDeleteVideoStreamButton.Location = new System.Drawing.Point(3, 32);
            this.uiDeleteVideoStreamButton.Name = "uiDeleteVideoStreamButton";
            this.uiDeleteVideoStreamButton.Size = new System.Drawing.Size(75, 23);
            this.uiDeleteVideoStreamButton.TabIndex = 5;
            this.uiDeleteVideoStreamButton.Text = "delete";
            this.uiDeleteVideoStreamButton.UseVisualStyleBackColor = true;
            this.uiDeleteVideoStreamButton.Click += new System.EventHandler(this.uiDeleteVideoStreamButton_Click);
            // 
            // uiAddVideoStreamButton
            // 
            this.uiAddVideoStreamButton.Location = new System.Drawing.Point(3, 3);
            this.uiAddVideoStreamButton.Name = "uiAddVideoStreamButton";
            this.uiAddVideoStreamButton.Size = new System.Drawing.Size(75, 23);
            this.uiAddVideoStreamButton.TabIndex = 4;
            this.uiAddVideoStreamButton.Text = "->";
            this.uiAddVideoStreamButton.UseVisualStyleBackColor = true;
            this.uiAddVideoStreamButton.Click += new System.EventHandler(this.uiAddVideoStreamButton_Click);
            // 
            // uiVideoStreamViewCollectionControl
            // 
            this.uiVideoStreamViewCollectionControl.ActiveVideoStreamRoadControl = null;
            this.uiVideoStreamViewCollectionControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiVideoStreamViewCollectionControl.AutoScroll = true;
            this.uiVideoStreamViewCollectionControl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.uiVideoStreamViewCollectionControl.Location = new System.Drawing.Point(84, 3);
            this.uiVideoStreamViewCollectionControl.Name = "uiVideoStreamViewCollectionControl";
            this.uiVideoStreamViewCollectionControl.Size = new System.Drawing.Size(1189, 253);
            this.uiVideoStreamViewCollectionControl.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 602);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "VideoEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uiBrowseButton;
        private System.Windows.Forms.TextBox uiAviFileNameTextBox;
        private System.Windows.Forms.Panel uiVideoStreamBrowseControl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RoadCollectionControl uiVideoStreamViewCollectionControl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button uiAddVideoStreamButton;
        private System.Windows.Forms.Button uiDeleteVideoStreamButton;
        private System.Windows.Forms.Button uiDecreaseRoadCollectionWidthButton;
        private System.Windows.Forms.Button uiIncreaseRoadCollectionWidthButton;
    }
}

