namespace VideoEditor
{
    partial class VideoStreamControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiFaramePictureBox = new System.Windows.Forms.PictureBox();
            this.uiNameLabel = new System.Windows.Forms.Label();
            this.uiInfoLabel = new System.Windows.Forms.Label();
            this.uiMainPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.uiFaramePictureBox)).BeginInit();
            this.uiMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiFaramePictureBox
            // 
            this.uiFaramePictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiFaramePictureBox.Location = new System.Drawing.Point(148, 0);
            this.uiFaramePictureBox.Name = "uiFaramePictureBox";
            this.uiFaramePictureBox.Size = new System.Drawing.Size(50, 50);
            this.uiFaramePictureBox.TabIndex = 0;
            this.uiFaramePictureBox.TabStop = false;
            // 
            // uiNameLabel
            // 
            this.uiNameLabel.AutoSize = true;
            this.uiNameLabel.Location = new System.Drawing.Point(3, 0);
            this.uiNameLabel.Name = "uiNameLabel";
            this.uiNameLabel.Size = new System.Drawing.Size(33, 13);
            this.uiNameLabel.TabIndex = 1;
            this.uiNameLabel.Text = "name";
            // 
            // uiInfoLabel
            // 
            this.uiInfoLabel.AutoSize = true;
            this.uiInfoLabel.Location = new System.Drawing.Point(3, 25);
            this.uiInfoLabel.Name = "uiInfoLabel";
            this.uiInfoLabel.Size = new System.Drawing.Size(59, 13);
            this.uiInfoLabel.TabIndex = 2;
            this.uiInfoLabel.Text = "uiInfoLabel";
            // 
            // uiMainPanel
            // 
            this.uiMainPanel.BackColor = System.Drawing.Color.Lavender;
            this.uiMainPanel.Controls.Add(this.uiNameLabel);
            this.uiMainPanel.Controls.Add(this.uiFaramePictureBox);
            this.uiMainPanel.Controls.Add(this.uiInfoLabel);
            this.uiMainPanel.Location = new System.Drawing.Point(1, 1);
            this.uiMainPanel.Name = "uiMainPanel";
            this.uiMainPanel.Size = new System.Drawing.Size(198, 50);
            this.uiMainPanel.TabIndex = 3;
            this.uiMainPanel.Click += new System.EventHandler(this.uiMainPanel_Click);
            // 
            // VideoStreamControl
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.uiMainPanel);
            this.Name = "VideoStreamControl";
            this.Size = new System.Drawing.Size(200, 52);
            this.SizeChanged += new System.EventHandler(this.SelectVideoControl_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.uiFaramePictureBox)).EndInit();
            this.uiMainPanel.ResumeLayout(false);
            this.uiMainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox uiFaramePictureBox;
        private System.Windows.Forms.Label uiNameLabel;
        private System.Windows.Forms.Label uiInfoLabel;
        public System.Windows.Forms.Panel uiMainPanel;
    }
}
