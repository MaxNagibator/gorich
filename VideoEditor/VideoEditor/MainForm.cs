using AviFile;
using System;
using System.Drawing;
using System.Linq;
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
            return uiAviFileNameTextBox.Text.Substring(0, uiAviFileNameTextBox.Text.LastIndexOf("\\", StringComparison.Ordinal) + 1);
        }

        private String GetCurrentFileName()
        {
            return uiAviFileNameTextBox.Text.Substring(uiAviFileNameTextBox.Text.LastIndexOf("\\", StringComparison.Ordinal) + 1,
                                                       uiAviFileNameTextBox.Text.Length -
                                                       uiAviFileNameTextBox.Text.LastIndexOf("\\", StringComparison.Ordinal) - 1);
        }

        private void AddFile()
        {
            if (System.IO.File.Exists(uiAviFileNameTextBox.Text))
            {
                try
                {
                    var aviManager = new AviManager(uiAviFileNameTextBox.Text, true);
                    var videoStream = aviManager.GetVideoStream();
                    videoStream.GetFrameOpen();
                    Bitmap bmp = videoStream.GetBitmap(videoStream.CountFrames / 2);
                    var videoStreamControl = new BrowseControl {Dock = DockStyle.Top};
                    videoStreamControl.SetFileName(GetCurrentFileName());
                    videoStreamControl.SetFrame(GetResizedBitmap(bmp, 50, 50));
                    videoStreamControl.VideoStream = videoStream;
                    videoStreamControl.SelectVideoStream += SelectVideoStreamControl;
                    uiVideoStreamBrowseControl.Controls.Add(videoStreamControl);
                    _selectedVideoStreamBrowseControl = videoStreamControl;
                    foreach (
                        BrowseControl browseControl in
                            uiVideoStreamBrowseControl.Controls.OfType<BrowseControl>())
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

        private BrowseControl _selectedVideoStreamBrowseControl;

        private void SelectVideoStreamControl(object sender, VideoStreamEventArgs e)
        {
            foreach (
                BrowseControl browseControl in
                    uiVideoStreamBrowseControl.Controls.OfType<BrowseControl>())
            {
                (browseControl).uiMainPanel.BackColor = Color.Lavender;
            }
            _selectedVideoStreamBrowseControl = ((BrowseControl) sender);
            ((BrowseControl) sender).uiMainPanel.BackColor = Color.Aquamarine;
            var videoStream = e.EditableVideoStream;
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

        private void uiAddVideoStreamButton_Click(object sender, EventArgs e)
        {
            if (_selectedVideoStreamBrowseControl != null)
            {
                uiVideoStreamViewCollectionControl.AddVideoStreamView(
                    new RoadControl(_selectedVideoStreamBrowseControl.VideoStream));
            }
        }

        private void uiDeleteVideoStreamButton_Click(object sender, EventArgs e)
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
            const string targetName = "VideoEditor";
            var localProcs = System.Diagnostics.Process.GetProcesses();
            try
            {
                System.Diagnostics.Process targetProc = localProcs.First(p => p.ProcessName == targetName);
                targetProc.Kill();
            }
            catch
            {
                
            }
        }
    }
}
