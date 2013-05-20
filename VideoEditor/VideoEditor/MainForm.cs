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
            uiVideoStreamViewCollectionControl.ChangeImageRoadsControl += Test;
        }

        private void Test(object sender, FrameEventArgs e)
        {
            pictureBox1.Image = e.Frame;
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
            return uiAviFileNameTextBox.Text.Substring(uiAviFileNameTextBox.Text.LastIndexOf("\\") + 1,
                                                       uiAviFileNameTextBox.Text.Length -
                                                       uiAviFileNameTextBox.Text.LastIndexOf("\\") - 1);
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
                    uiVideoStreamBrowseControl.Controls.Add(videoStreamControl);
                    _selectedVideoStreamBrowseControl = videoStreamControl;
                    foreach (
                        VideoStreamBrowseControl browseControl in
                            uiVideoStreamBrowseControl.Controls.OfType<VideoStreamBrowseControl>())
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
            foreach (
                VideoStreamBrowseControl browseControl in
                    uiVideoStreamBrowseControl.Controls.OfType<VideoStreamBrowseControl>())
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
                uiVideoStreamViewCollectionControl.AddVideoStreamView(
                    new VideoStreamRoadControl(_selectedVideoStreamBrowseControl.VideoStream));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uiVideoStreamViewCollectionControl.DeleteVideoStreamView();
        }

        private void uiIncreaseRoadCollectionWidthButton_Click(object sender, EventArgs e)
        {
            uiVideoStreamViewCollectionControl.IncreaseRoadCollectionWidth();
        }

        private void uiDecreaseRoadCollectionWidthButton_Click(object sender, EventArgs e)
        {
            uiVideoStreamViewCollectionControl.DecreaseRoadCollection();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseAllStreams();
        }

        private void CloseAllStreams()
        {
            CloseAllStreamsInVideoStreamBrowseControl();
            CloseAllStreamsInVideoStreamViewCollectionControl();
        }

        private void CloseAllStreamsInVideoStreamViewCollectionControl()
        {
            foreach (var collectionControl in
                uiVideoStreamViewCollectionControl.Controls.OfType<VideoStreamRoadCollectionControl>())
            {
                CloseAllStreamsInVideoStreamRoadControl(collectionControl);
            }
        }

        private void CloseAllStreamsInVideoStreamRoadControl(VideoStreamRoadCollectionControl collectionControl)
        {
            foreach (var roadControl in collectionControl.Controls.OfType<VideoStreamRoadControl>())
            {
                (roadControl).VideoStream.GetFrameClose();
                CloseAllStreamsInVideoStreamRoadPartControl(roadControl);
            }
        }

        private void CloseAllStreamsInVideoStreamBrowseControl()
        {
            foreach (var browseControl in uiVideoStreamBrowseControl.Controls.OfType<VideoStreamBrowseControl>())
            {
                var videoStream = (browseControl).VideoStream;
                if (videoStream != null) videoStream.GetFrameClose();
            }
        }

        private void CloseAllStreamsInVideoStreamRoadPartControl(VideoStreamRoadControl road)
        {
            foreach (var partControl in (road).Controls.OfType<VideoStreamRoadPartControl>())
            {
                (partControl).VideoStream.GetFrameClose();
            }
        }
    }
}
