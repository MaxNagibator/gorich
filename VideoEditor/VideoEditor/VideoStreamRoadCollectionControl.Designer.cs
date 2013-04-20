namespace VideoEditor
{
    partial class VideoStreamRoadCollectionControl
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
            this.uiTimePanel = new System.Windows.Forms.Panel();
            this.uiMainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // uiTimePanel
            // 
            this.uiTimePanel.BackColor = System.Drawing.SystemColors.Info;
            this.uiTimePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiTimePanel.Location = new System.Drawing.Point(0, 76);
            this.uiTimePanel.Name = "uiTimePanel";
            this.uiTimePanel.Size = new System.Drawing.Size(1200, 24);
            this.uiTimePanel.TabIndex = 4;
            this.uiTimePanel.Click += new System.EventHandler(this.uiTimePanel_Click);
            // 
            // uiMainPanel
            // 
            this.uiMainPanel.BackColor = System.Drawing.Color.Cornsilk;
            this.uiMainPanel.Location = new System.Drawing.Point(0, 0);
            this.uiMainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.uiMainPanel.Name = "uiMainPanel";
            this.uiMainPanel.Size = new System.Drawing.Size(1150, 0);
            this.uiMainPanel.TabIndex = 5;
            // 
            // VideoStreamRoadCollectionControl
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.uiMainPanel);
            this.Controls.Add(this.uiTimePanel);
            this.Name = "VideoStreamRoadCollectionControl";
            this.Size = new System.Drawing.Size(1200, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uiTimePanel;
        private System.Windows.Forms.Panel uiMainPanel;
    }
}
