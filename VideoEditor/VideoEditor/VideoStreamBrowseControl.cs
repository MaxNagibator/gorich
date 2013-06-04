using System;
using System.Drawing;
using System.Windows.Forms;
using AviFile;

namespace VideoEditor
{
    public partial class VideoStreamBrowseControl : UserControl
    {
        public Guid Guid { get; set; }
        public bool IsSelected { get; set; }
        public EditableVideoStream EditableVideoStream { get; set; }

        public VideoStreamBrowseControl()
        {
            InitializeComponent();
        }

        public void SetFrame(Bitmap bitmap)
        {
            uiFaramePictureBox.Image = bitmap;
        }

        private void SelectVideoControl_SizeChanged(object sender, EventArgs e)
        {
            uiMainPanel.Size = new Size(Width - 2, Height - 2);
        }

        public void SetFileName(string fileName)
        {
            uiNameLabel.Text = fileName;
        }

        private void uiMainPanel_Click(object sender, EventArgs e)
        {
            var videoStreamEventArgs = new VideoStreamEventArgs {EditableVideoStream = EditableVideoStream};
            FireSelectVideoStream(videoStreamEventArgs);
        }

        public void FireSelectVideoStream(VideoStreamEventArgs e)
        {
            EventHandler<VideoStreamEventArgs> handler = SelectVideoStream;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<VideoStreamEventArgs> SelectVideoStream;
    }
}
