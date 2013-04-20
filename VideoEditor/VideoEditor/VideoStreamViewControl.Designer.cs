namespace VideoEditor
{
    partial class VideoStreamViewControl
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
            this.uiVideoStreamPanel = new System.Windows.Forms.Panel();
            this.uiLeftCoordinateLabel = new System.Windows.Forms.Label();
            this.uiRightCoordinateLabel = new System.Windows.Forms.Label();
            this.uiMainPanel.SuspendLayout();
            this.uiVideoStreamPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiMainPanel
            // 
            this.uiMainPanel.AllowDrop = true;
            this.uiMainPanel.BackColor = System.Drawing.Color.Cornsilk;
            this.uiMainPanel.Controls.Add(this.uiVideoStreamPanel);
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
            // uiVideoStreamPanel
            // 
            this.uiVideoStreamPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uiVideoStreamPanel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.uiVideoStreamPanel.Controls.Add(this.uiRightCoordinateLabel);
            this.uiVideoStreamPanel.Controls.Add(this.uiLeftCoordinateLabel);
            this.uiVideoStreamPanel.Location = new System.Drawing.Point(500, 0);
            this.uiVideoStreamPanel.Name = "uiVideoStreamPanel";
            this.uiVideoStreamPanel.Size = new System.Drawing.Size(217, 75);
            this.uiVideoStreamPanel.TabIndex = 0;
            this.uiVideoStreamPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.uiVideoStreamPanel_MouseDown);
            // 
            // uiLeftCoordinateLabel
            // 
            this.uiLeftCoordinateLabel.AutoSize = true;
            this.uiLeftCoordinateLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLeftCoordinateLabel.Location = new System.Drawing.Point(0, 0);
            this.uiLeftCoordinateLabel.Name = "uiLeftCoordinateLabel";
            this.uiLeftCoordinateLabel.Size = new System.Drawing.Size(10, 13);
            this.uiLeftCoordinateLabel.TabIndex = 0;
            this.uiLeftCoordinateLabel.Text = "-";
            // 
            // uiRightCoordinateLabel
            // 
            this.uiRightCoordinateLabel.AutoSize = true;
            this.uiRightCoordinateLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiRightCoordinateLabel.Location = new System.Drawing.Point(207, 0);
            this.uiRightCoordinateLabel.Name = "uiRightCoordinateLabel";
            this.uiRightCoordinateLabel.Size = new System.Drawing.Size(10, 13);
            this.uiRightCoordinateLabel.TabIndex = 1;
            this.uiRightCoordinateLabel.Text = "-";
            // 
            // VideoStreamViewControl
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.uiMainPanel);
            this.Name = "VideoStreamViewControl";
            this.Size = new System.Drawing.Size(717, 75);
            this.uiMainPanel.ResumeLayout(false);
            this.uiVideoStreamPanel.ResumeLayout(false);
            this.uiVideoStreamPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uiMainPanel;
        private System.Windows.Forms.Panel uiVideoStreamPanel;
        private System.Windows.Forms.Label uiLeftCoordinateLabel;
        private System.Windows.Forms.Label uiRightCoordinateLabel;
    }
}
