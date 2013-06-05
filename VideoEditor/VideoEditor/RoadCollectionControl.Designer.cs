namespace VideoEditor
{
    partial class RoadCollectionControl
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
            this.cursorPlayDownPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.uiMainPanel = new System.Windows.Forms.Panel();
            this.cursorPlayUpPanel = new System.Windows.Forms.Panel();
            this.uiPlayTimer = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timeLineControl1 = new VideoEditor.TimeLineControl();
            this.uiTimePanel.SuspendLayout();
            this.uiMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTimePanel
            // 
            this.uiTimePanel.BackColor = System.Drawing.SystemColors.Info;
            this.uiTimePanel.Controls.Add(this.button4);
            this.uiTimePanel.Controls.Add(this.button3);
            this.uiTimePanel.Controls.Add(this.button2);
            this.uiTimePanel.Controls.Add(this.cursorPlayDownPanel);
            this.uiTimePanel.Controls.Add(this.button1);
            this.uiTimePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiTimePanel.Location = new System.Drawing.Point(0, 193);
            this.uiTimePanel.Name = "uiTimePanel";
            this.uiTimePanel.Size = new System.Drawing.Size(1215, 24);
            this.uiTimePanel.TabIndex = 4;
            // 
            // cursorPlayDownPanel
            // 
            this.cursorPlayDownPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cursorPlayDownPanel.BackColor = System.Drawing.Color.Red;
            this.cursorPlayDownPanel.Location = new System.Drawing.Point(0, 0);
            this.cursorPlayDownPanel.Name = "cursorPlayDownPanel";
            this.cursorPlayDownPanel.Size = new System.Drawing.Size(10, 24);
            this.cursorPlayDownPanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(843, 19);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiMainPanel
            // 
            this.uiMainPanel.BackColor = System.Drawing.Color.Cornsilk;
            this.uiMainPanel.Controls.Add(this.cursorPlayUpPanel);
            this.uiMainPanel.Location = new System.Drawing.Point(0, 20);
            this.uiMainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.uiMainPanel.Name = "uiMainPanel";
            this.uiMainPanel.Size = new System.Drawing.Size(1215, 0);
            this.uiMainPanel.TabIndex = 5;
            // 
            // cursorPlayUpPanel
            // 
            this.cursorPlayUpPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cursorPlayUpPanel.BackColor = System.Drawing.Color.Red;
            this.cursorPlayUpPanel.Location = new System.Drawing.Point(0, 0);
            this.cursorPlayUpPanel.Name = "cursorPlayUpPanel";
            this.cursorPlayUpPanel.Size = new System.Drawing.Size(10, 0);
            this.cursorPlayUpPanel.TabIndex = 2;
            // 
            // uiPlayTimer
            // 
            this.uiPlayTimer.Tick += new System.EventHandler(this.uiPlayTimer_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 19);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(147, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 19);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(259, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 19);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timeLineControl1
            // 
            this.timeLineControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.timeLineControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeLineControl1.Location = new System.Drawing.Point(0, 0);
            this.timeLineControl1.Name = "timeLineControl1";
            this.timeLineControl1.Size = new System.Drawing.Size(1215, 20);
            this.timeLineControl1.TabIndex = 6;
            // 
            // RoadCollectionControl
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.uiTimePanel);
            this.Controls.Add(this.uiMainPanel);
            this.Controls.Add(this.timeLineControl1);
            this.Name = "RoadCollectionControl";
            this.Size = new System.Drawing.Size(1215, 217);
            this.uiTimePanel.ResumeLayout(false);
            this.uiMainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uiMainPanel;
        private System.Windows.Forms.Panel uiTimePanel;
        private System.Windows.Forms.Panel cursorPlayDownPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer uiPlayTimer;
        private System.Windows.Forms.Panel cursorPlayUpPanel;
        private TimeLineControl timeLineControl1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}
