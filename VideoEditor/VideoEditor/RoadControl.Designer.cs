﻿namespace VideoEditor
{
    partial class RoadControl
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
            this.uiMainPanel = new System.Windows.Forms.Panel();
            this.uiMainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uiDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiSplitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiMainContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiMainPanel
            // 
            this.uiMainPanel.AllowDrop = true;
            this.uiMainPanel.BackColor = System.Drawing.Color.Cornsilk;
            this.uiMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiMainPanel.Location = new System.Drawing.Point(0, 0);
            this.uiMainPanel.Name = "uiMainPanel";
            this.uiMainPanel.Size = new System.Drawing.Size(717, 75);
            this.uiMainPanel.TabIndex = 6;
            this.uiMainPanel.Click += new System.EventHandler(this.uiMainPanel_Click);
            this.uiMainPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.uiMainPanel_DragDrop);
            this.uiMainPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.uiMainPanel_DragOver);
            // 
            // uiMainContextMenuStrip
            // 
            this.uiMainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiDeleteToolStripMenuItem,
            this.uiSplitToolStripMenuItem});
            this.uiMainContextMenuStrip.Name = "uiMainContextMenuStrip";
            this.uiMainContextMenuStrip.Size = new System.Drawing.Size(128, 48);
            // 
            // uiDeleteToolStripMenuItem
            // 
            this.uiDeleteToolStripMenuItem.Name = "uiDeleteToolStripMenuItem";
            this.uiDeleteToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.uiDeleteToolStripMenuItem.Text = "Удалить";
            this.uiDeleteToolStripMenuItem.Click += new System.EventHandler(this.uiDeleteToolStripMenuItem_Click);
            // 
            // uiSplitToolStripMenuItem
            // 
            this.uiSplitToolStripMenuItem.Name = "uiSplitToolStripMenuItem";
            this.uiSplitToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.uiSplitToolStripMenuItem.Text = "Разрезать";
            this.uiSplitToolStripMenuItem.Click += new System.EventHandler(this.uiSplitToolStripMenuItem_Click);
            // 
            // RoadControl
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.uiMainPanel);
            this.Name = "RoadControl";
            this.Size = new System.Drawing.Size(717, 75);
            this.uiMainContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel uiMainPanel;
        private System.Windows.Forms.ContextMenuStrip uiMainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem uiDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uiSplitToolStripMenuItem;
    }
}
