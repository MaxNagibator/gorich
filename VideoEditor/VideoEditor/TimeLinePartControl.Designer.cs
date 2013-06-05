namespace VideoEditor
{
    partial class TimeLinePartControl
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
            this.uiFramePositionPanel = new System.Windows.Forms.Panel();
            this.uiFrameNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiFramePositionPanel
            // 
            this.uiFramePositionPanel.BackColor = System.Drawing.Color.CadetBlue;
            this.uiFramePositionPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiFramePositionPanel.Location = new System.Drawing.Point(0, 0);
            this.uiFramePositionPanel.Name = "uiFramePositionPanel";
            this.uiFramePositionPanel.Size = new System.Drawing.Size(3, 20);
            this.uiFramePositionPanel.TabIndex = 0;
            // 
            // uiFrameNumberLabel
            // 
            this.uiFrameNumberLabel.AutoSize = true;
            this.uiFrameNumberLabel.Location = new System.Drawing.Point(8, 3);
            this.uiFrameNumberLabel.Name = "uiFrameNumberLabel";
            this.uiFrameNumberLabel.Size = new System.Drawing.Size(10, 13);
            this.uiFrameNumberLabel.TabIndex = 1;
            this.uiFrameNumberLabel.Text = "-";
            // 
            // TimeLinePartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiFrameNumberLabel);
            this.Controls.Add(this.uiFramePositionPanel);
            this.Name = "TimeLinePartControl";
            this.Size = new System.Drawing.Size(50, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel uiFramePositionPanel;
        private System.Windows.Forms.Label uiFrameNumberLabel;
    }
}
