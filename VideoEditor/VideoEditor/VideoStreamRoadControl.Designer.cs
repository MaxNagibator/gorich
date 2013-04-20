namespace VideoEditor
{
    partial class VideoStreamRoadControl
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
            this.uiMainPanel = new System.Windows.Forms.Panel();
            this.videoStreamRoadPartControl = new VideoEditor.VideoStreamRoadPartControl();
            this.uiMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiMainPanel
            // 
            this.uiMainPanel.AllowDrop = true;
            this.uiMainPanel.BackColor = System.Drawing.Color.Cornsilk;
            this.uiMainPanel.Controls.Add(this.videoStreamRoadPartControl);
            this.uiMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiMainPanel.Location = new System.Drawing.Point(0, 0);
            this.uiMainPanel.Name = "uiMainPanel";
            this.uiMainPanel.Size = new System.Drawing.Size(717, 75);
            this.uiMainPanel.TabIndex = 6;
            this.uiMainPanel.Click += new System.EventHandler(this.uiMainPanel_Click);
            this.uiMainPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.uiMainPanel_DragDrop);
            this.uiMainPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.uiMainPanel_DragEnter);
            this.uiMainPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.uiMainPanel_DragOver);
            // 
            // videoStreamRoadPartControl
            // 
            this.videoStreamRoadPartControl.BackColor = System.Drawing.Color.LimeGreen;
            this.videoStreamRoadPartControl.Location = new System.Drawing.Point(500, 0);
            this.videoStreamRoadPartControl.Name = "videoStreamRoadPartControl";
            this.videoStreamRoadPartControl.Size = new System.Drawing.Size(217, 75);
            this.videoStreamRoadPartControl.TabIndex = 1;
            this.videoStreamRoadPartControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoStreamRoadPartControl1_MouseDown);
            // 
            // VideoStreamRoadControl
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.uiMainPanel);
            this.Name = "VideoStreamRoadControl";
            this.Size = new System.Drawing.Size(717, 75);
            this.uiMainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uiMainPanel;
        private VideoStreamRoadPartControl videoStreamRoadPartControl;
    }
}
