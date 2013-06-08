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
            this.uiUnionAllPartsButton = new System.Windows.Forms.Button();
            this.uiStopButton = new System.Windows.Forms.Button();
            this.uiPlayBackButton = new System.Windows.Forms.Button();
            this.cursorPlayDownPanel = new System.Windows.Forms.Panel();
            this.uiPlayButton = new System.Windows.Forms.Button();
            this.uiMainPanel = new System.Windows.Forms.Panel();
            this.cursorPlayUpPanel = new System.Windows.Forms.Panel();
            this.uiPlayTimer = new System.Windows.Forms.Timer(this.components);
            this.uiSaveButton = new System.Windows.Forms.Button();
            this.timeLineControl1 = new VideoEditor.TimeLineControl();
            this.uiTimePanel.SuspendLayout();
            this.uiMainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTimePanel
            // 
            this.uiTimePanel.BackColor = System.Drawing.SystemColors.Info;
            this.uiTimePanel.Controls.Add(this.uiSaveButton);
            this.uiTimePanel.Controls.Add(this.uiUnionAllPartsButton);
            this.uiTimePanel.Controls.Add(this.uiStopButton);
            this.uiTimePanel.Controls.Add(this.uiPlayBackButton);
            this.uiTimePanel.Controls.Add(this.cursorPlayDownPanel);
            this.uiTimePanel.Controls.Add(this.uiPlayButton);
            this.uiTimePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiTimePanel.Location = new System.Drawing.Point(0, 193);
            this.uiTimePanel.Name = "uiTimePanel";
            this.uiTimePanel.Size = new System.Drawing.Size(1215, 24);
            this.uiTimePanel.TabIndex = 4;
            // 
            // uiUnionAllPartsButton
            // 
            this.uiUnionAllPartsButton.Location = new System.Drawing.Point(387, 2);
            this.uiUnionAllPartsButton.Name = "uiUnionAllPartsButton";
            this.uiUnionAllPartsButton.Size = new System.Drawing.Size(75, 19);
            this.uiUnionAllPartsButton.TabIndex = 4;
            this.uiUnionAllPartsButton.Text = "склеить";
            this.uiUnionAllPartsButton.UseVisualStyleBackColor = true;
            this.uiUnionAllPartsButton.Click += new System.EventHandler(this.uiUnionAllPartsButton_Click);
            // 
            // uiStopButton
            // 
            this.uiStopButton.Location = new System.Drawing.Point(169, 0);
            this.uiStopButton.Name = "uiStopButton";
            this.uiStopButton.Size = new System.Drawing.Size(44, 21);
            this.uiStopButton.TabIndex = 3;
            this.uiStopButton.Text = "[]";
            this.uiStopButton.UseVisualStyleBackColor = true;
            this.uiStopButton.Click += new System.EventHandler(this.uiStopButton_Click);
            // 
            // uiPlayBackButton
            // 
            this.uiPlayBackButton.Location = new System.Drawing.Point(116, 0);
            this.uiPlayBackButton.Name = "uiPlayBackButton";
            this.uiPlayBackButton.Size = new System.Drawing.Size(47, 21);
            this.uiPlayBackButton.TabIndex = 2;
            this.uiPlayBackButton.Text = "<-";
            this.uiPlayBackButton.UseVisualStyleBackColor = true;
            this.uiPlayBackButton.Click += new System.EventHandler(this.uiPlayBackButton_Click);
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
            // uiPlayButton
            // 
            this.uiPlayButton.Location = new System.Drawing.Point(219, 0);
            this.uiPlayButton.Name = "uiPlayButton";
            this.uiPlayButton.Size = new System.Drawing.Size(43, 21);
            this.uiPlayButton.TabIndex = 0;
            this.uiPlayButton.Text = "->";
            this.uiPlayButton.UseVisualStyleBackColor = true;
            this.uiPlayButton.Click += new System.EventHandler(this.uiPlayButton_Click);
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
            // uiSaveButton
            // 
            this.uiSaveButton.Location = new System.Drawing.Point(468, 2);
            this.uiSaveButton.Name = "uiSaveButton";
            this.uiSaveButton.Size = new System.Drawing.Size(75, 19);
            this.uiSaveButton.TabIndex = 5;
            this.uiSaveButton.Text = "сохранить";
            this.uiSaveButton.UseVisualStyleBackColor = true;
            this.uiSaveButton.Click += new System.EventHandler(this.uiSaveButton_Click);
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
        private System.Windows.Forms.Button uiPlayButton;
        private System.Windows.Forms.Timer uiPlayTimer;
        private System.Windows.Forms.Panel cursorPlayUpPanel;
        private TimeLineControl timeLineControl1;
        private System.Windows.Forms.Button uiPlayBackButton;
        private System.Windows.Forms.Button uiStopButton;
        private System.Windows.Forms.Button uiUnionAllPartsButton;
        private System.Windows.Forms.Button uiSaveButton;
    }
}
