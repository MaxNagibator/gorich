using AviFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void uiBrowseButton_Click(object sender, EventArgs e)
        {
            string fileName = GetFileName("Videos (*.avi)|*.avi");
            if (fileName != null)
            {
                uiAviFileNameTextBox.Text = fileName;
                AddFile();
            }
        }

        private string GetFileName(String filter)
        {
            var dlg = new OpenFileDialog {Filter = filter, RestoreDirectory = true};
            if (uiAviFileNameTextBox.Text.Length > 0)
            {
                dlg.InitialDirectory = GetCurrentFilePath();
            }
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                return dlg.FileName;
            }
            return null;
        }

        private String GetCurrentFilePath()
        {
            return uiAviFileNameTextBox.Text.Substring(0, uiAviFileNameTextBox.Text.LastIndexOf("\\") + 1);
        }

        private String GetCurrentFileName()
        {
            return uiAviFileNameTextBox.Text.Substring(uiAviFileNameTextBox.Text.LastIndexOf("\\") + 1, uiAviFileNameTextBox.Text.Length - uiAviFileNameTextBox.Text.LastIndexOf("\\")-1);
        }

        private void AddFile()
        {
            if (System.IO.File.Exists(uiAviFileNameTextBox.Text))
            {
                try
                {
                    var aviManager = new AviManager(uiAviFileNameTextBox.Text, true);
                    VideoStream aviStream = aviManager.GetVideoStream();
                    aviStream.GetFrameOpen();
                    Bitmap bmp = aviStream.GetBitmap(aviStream.CountFrames/2);
                    var videoStreamControl = new VideoStreamBrowseControl {Dock = DockStyle.Top};
                    videoStreamControl.SetFileName(GetCurrentFileName());
                    videoStreamControl.SetFrame(GetResizedBitmap(bmp, 50, 50));
                    videoStreamControl.VideoStream = aviStream;
                    videoStreamControl.SelectVideoStream += SelectVideoStreamControl;
                    uiVideoListPanel.Controls.Add(videoStreamControl);
                    _selectedVideoStreamBrowseControl = videoStreamControl;
                    foreach (VideoStreamBrowseControl browseControl in uiVideoListPanel.Controls.OfType<VideoStreamBrowseControl>())
                    {
                        (browseControl).uiMainPanel.BackColor = Color.Lavender;
                    }
                    videoStreamControl.uiMainPanel.BackColor = Color.Aquamarine;
                    aviManager.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private VideoStreamBrowseControl _selectedVideoStreamBrowseControl;
        private void SelectVideoStreamControl(object sender, VideoStreamEventArgs e)
        {
            foreach (VideoStreamBrowseControl browseControl in uiVideoListPanel.Controls.OfType<VideoStreamBrowseControl>())
            {
                (browseControl).uiMainPanel.BackColor = Color.Lavender;
            }
            _selectedVideoStreamBrowseControl = ((VideoStreamBrowseControl) sender);
            ((VideoStreamBrowseControl) sender).uiMainPanel.BackColor = Color.Aquamarine;
            var videoStream = e.VideoStream;
            pictureBox1.Image = videoStream.GetBitmap(videoStream.CountFrames/2);
        }

        private Bitmap GetResizedBitmap(Bitmap bmp, int width, int height)
        {
            var resizedBitmap = new Bitmap(width, height);
            using (var g = Graphics.FromImage(resizedBitmap))
                g.DrawImage(bmp, 0, 0, width, height);
            return resizedBitmap;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_selectedVideoStreamBrowseControl != null)
            {
                videoStreamViewCollectionControl1.AddVideoStreamView(new VideoStreamRoadControl(_selectedVideoStreamBrowseControl.VideoStream));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            videoStreamViewCollectionControl1.DeleteVideoStreamView();
        }

        private void uiIncreaseRoadCollectionWidthButton_Click(object sender, EventArgs e)
        {
            videoStreamViewCollectionControl1.IncreaseRoadCollectionWidth();
        }

        private void uiDecreaseRoadCollectionWidthButton_Click(object sender, EventArgs e)
        {
            videoStreamViewCollectionControl1.DecreaseRoadCollection();
        }
    }
}
