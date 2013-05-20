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
            this.components = new System.ComponentModel.Container();
            this.uiTimePanel = new System.Windows.Forms.Panel();
            this.cursorPlayPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.uiMainPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiPlayTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiTimePanel.SuspendLayout();
            this.uiMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTimePanel
            // 
            this.uiTimePanel.BackColor = System.Drawing.SystemColors.Info;
            this.uiTimePanel.Controls.Add(this.cursorPlayPanel);
            this.uiTimePanel.Controls.Add(this.button1);
            this.uiTimePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiTimePanel.Location = new System.Drawing.Point(0, 78);
            this.uiTimePanel.Name = "uiTimePanel";
            this.uiTimePanel.Size = new System.Drawing.Size(1150, 24);
            this.uiTimePanel.TabIndex = 4;
            // 
            // cursorPlayPanel
            // 
            this.cursorPlayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cursorPlayPanel.BackColor = System.Drawing.Color.Red;
            this.cursorPlayPanel.Location = new System.Drawing.Point(56, 0);
            this.cursorPlayPanel.Name = "cursorPlayPanel";
            this.cursorPlayPanel.Size = new System.Drawing.Size(10, 24);
            this.cursorPlayPanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 10);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiMainPanel
            // 
            this.uiMainPanel.BackColor = System.Drawing.Color.Cornsilk;
            this.uiMainPanel.Controls.Add(this.panel1);
            this.uiMainPanel.Location = new System.Drawing.Point(0, 0);
            this.uiMainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.uiMainPanel.Name = "uiMainPanel";
            this.uiMainPanel.Size = new System.Drawing.Size(1150, 0);
            this.uiMainPanel.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(631, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 78);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // uiPlayTimer
            // 
            this.uiPlayTimer.Tick += new System.EventHandler(this.uiPlayTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(56, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 0);
            this.panel1.TabIndex = 2;
            // 
            // VideoStreamRoadCollectionControl
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uiMainPanel);
            this.Controls.Add(this.uiTimePanel);
            this.Name = "VideoStreamRoadCollectionControl";
            this.Size = new System.Drawing.Size(1132, 66);
            this.uiTimePanel.ResumeLayout(false);
            this.uiMainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uiMainPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel uiTimePanel;
        private System.Windows.Forms.Panel cursorPlayPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer uiPlayTimer;
        private System.Windows.Forms.Panel panel1;
    }
}
