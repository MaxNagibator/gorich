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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiBrowseButton
            // 
            this.uiBrowseButton.Location = new System.Drawing.Point(12, 12);
            this.uiBrowseButton.Name = "uiBrowseButton";
            this.uiBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.uiBrowseButton.TabIndex = 0;
            this.uiBrowseButton.Text = "Browse";
            this.uiBrowseButton.UseVisualStyleBackColor = true;
            this.uiBrowseButton.Click += new System.EventHandler(this.uiBrowseButton_Click);
            // 
            // uiAviFileNameTextBox
            // 
            this.uiAviFileNameTextBox.Location = new System.Drawing.Point(93, 12);
            this.uiAviFileNameTextBox.Name = "uiAviFileNameTextBox";
            this.uiAviFileNameTextBox.Size = new System.Drawing.Size(179, 20);
            this.uiAviFileNameTextBox.TabIndex = 1;
            // 
            // uiVideoListPanel
            // 
            this.uiVideoListPanel.AutoScroll = true;
            this.uiVideoListPanel.BackColor = System.Drawing.SystemColors.Info;
            this.uiVideoListPanel.Location = new System.Drawing.Point(12, 38);
            this.uiVideoListPanel.Name = "uiVideoListPanel";
            this.uiVideoListPanel.Size = new System.Drawing.Size(260, 234);
            this.uiVideoListPanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(500, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 159);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 602);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uiVideoListPanel);
            this.Controls.Add(this.uiAviFileNameTextBox);
            this.Controls.Add(this.uiBrowseButton);
            this.Name = "MainForm";
            this.Text = "VideoEditor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uiBrowseButton;
        private System.Windows.Forms.TextBox uiAviFileNameTextBox;
        private System.Windows.Forms.Panel uiVideoListPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

