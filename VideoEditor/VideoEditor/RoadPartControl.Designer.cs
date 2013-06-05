namespace VideoEditor
{
    partial class RoadPartControl
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
            this.uiRightCoordinateLabel = new System.Windows.Forms.Label();
            this.uiLeftCoordinateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiRightCoordinateLabel
            // 
            this.uiRightCoordinateLabel.AutoSize = true;
            this.uiRightCoordinateLabel.BackColor = System.Drawing.Color.DarkGreen;
            this.uiRightCoordinateLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.uiRightCoordinateLabel.Location = new System.Drawing.Point(207, 0);
            this.uiRightCoordinateLabel.Name = "uiRightCoordinateLabel";
            this.uiRightCoordinateLabel.Size = new System.Drawing.Size(10, 13);
            this.uiRightCoordinateLabel.TabIndex = 3;
            this.uiRightCoordinateLabel.Text = "-";
            // 
            // uiLeftCoordinateLabel
            // 
            this.uiLeftCoordinateLabel.AutoSize = true;
            this.uiLeftCoordinateLabel.BackColor = System.Drawing.Color.DarkGreen;
            this.uiLeftCoordinateLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiLeftCoordinateLabel.Location = new System.Drawing.Point(0, 0);
            this.uiLeftCoordinateLabel.Name = "uiLeftCoordinateLabel";
            this.uiLeftCoordinateLabel.Size = new System.Drawing.Size(10, 13);
            this.uiLeftCoordinateLabel.TabIndex = 2;
            this.uiLeftCoordinateLabel.Text = "-";
            // 
            // RoadPartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.Controls.Add(this.uiRightCoordinateLabel);
            this.Controls.Add(this.uiLeftCoordinateLabel);
            this.Name = "RoadPartControl";
            this.Size = new System.Drawing.Size(217, 75);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VideoStreamRoadPartControl_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VideoStreamRoadPartControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VideoStreamRoadPartControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VideoStreamRoadPartControl_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uiRightCoordinateLabel;
        private System.Windows.Forms.Label uiLeftCoordinateLabel;
    }
}
