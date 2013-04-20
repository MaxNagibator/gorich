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
            this.uiVideoListPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.videoStreamViewCollectionControl1 = new VideoEditor.VideoStreamRoadCollectionControl();
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
            // uiVideoListPanel
            // 
            this.uiVideoListPanel.AutoScroll = true;
            this.uiVideoListPanel.BackColor = System.Drawing.SystemColors.Info;
            this.uiVideoListPanel.Location = new System.Drawing.Point(3, 29);
            this.uiVideoListPanel.Name = "uiVideoListPanel";
            this.uiVideoListPanel.Size = new System.Drawing.Size(260, 234);
            this.uiVideoListPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(269, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 159);
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
            this.splitContainer1.Panel1.Controls.Add(this.uiVideoListPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.videoStreamViewCollectionControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1286, 602);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // videoStreamViewCollectionControl1
            // 
            this.videoStreamViewCollectionControl1.ActiveVideoStreamRoadControl = null;
            this.videoStreamViewCollectionControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoStreamViewCollectionControl1.AutoScroll = true;
            this.videoStreamViewCollectionControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.videoStreamViewCollectionControl1.Location = new System.Drawing.Point(308, 3);
            this.videoStreamViewCollectionControl1.Name = "videoStreamViewCollectionControl1";
            this.videoStreamViewCollectionControl1.Size = new System.Drawing.Size(966, 271);
            this.videoStreamViewCollectionControl1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 602);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "VideoEditor";
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
        private System.Windows.Forms.Panel uiVideoListPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private VideoStreamRoadCollectionControl videoStreamViewCollectionControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

