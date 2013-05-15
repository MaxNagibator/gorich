using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VideoEditor
{
    public partial class VideoStreamRoadCollectionControl : UserControl
    {
        public VideoStreamRoadControl ActiveVideoStreamRoadControl { get; set; }
        public event EventHandler<FrameEventArgs> ChangeImageRoadsControl;

        public VideoStreamRoadCollectionControl()
        {
            InitializeComponent();
        }

        public void AddVideoStreamView(VideoStreamRoadControl videoStreamRoadControl)
        {
            videoStreamRoadControl.Width = videoStreamRoadControl.VideoStream.CountFrames;
            videoStreamRoadControl.Location = new Point(0,GetSumHeightAllVideoStreamViewControl());
            videoStreamRoadControl.SelectVideoStreamViewControl += SelectVideoStreamViewControl;
            videoStreamRoadControl.AddVideoStreamRoadPart(new VideoStreamRoadPartControl(videoStreamRoadControl.VideoStream));
            videoStreamRoadControl.ChangeImageRoadPartControl += ChangeImageRoadPartControl;
            uiMainPanel.Controls.Add(videoStreamRoadControl);
            uiMainPanel.Height = GetSumHeightAllVideoStreamViewControl();
            SetMainPanelMinWidth();
        }

        private int GetSumHeightAllVideoStreamViewControl()
        {
            return uiMainPanel.Controls.OfType<VideoStreamRoadControl>().Sum(control => (control).Height);
        }

        private void SelectVideoStreamViewControl(object sender, EventArgs e)
        {
            ActiveVideoStreamRoadControl = (VideoStreamRoadControl)sender;
            foreach (var control in uiMainPanel.Controls.OfType<VideoStreamRoadControl>())
            {
                (control).SetInactive();
            }
            ActiveVideoStreamRoadControl.SetActive();
        }

        public void ChangeImageRoadPartControl(object sender, FrameEventArgs e)
        {
            pictureBox1.Image = e.Frame;
            FireChangeImageRoadPartControl(e);
        }

        public void FireChangeImageRoadPartControl(FrameEventArgs e)
        {
            EventHandler<FrameEventArgs> handler = ChangeImageRoadsControl;
            handler(this, e);
        }

        public void DeleteVideoStreamView()
        {
            if (ActiveVideoStreamRoadControl == null) return;
            var deletedLocationY = ActiveVideoStreamRoadControl.Location.Y;
            var deletedHeight = ActiveVideoStreamRoadControl.Height;
            uiMainPanel.Controls.Remove(ActiveVideoStreamRoadControl);
            foreach (var c in uiMainPanel.Controls.OfType<VideoStreamRoadControl>().Where(control => control.Location.Y > deletedLocationY))
            {
                c.Location = new Point(c.Location.X,c.Location.Y-deletedHeight);
            }
            uiMainPanel.Height = GetSumHeightAllVideoStreamViewControl();
            ActiveVideoStreamRoadControl = null;
        }

        public void IncreaseRoadCollectionWidth()
        {
            uiMainPanel.Width += 1000;
        }

        public void DecreaseRoadCollection()
        {
            SetMainPanelMinWidth();
        }

        private void SetMainPanelMinWidth()
        {
            var maxWidth = uiMainPanel.Controls.OfType<VideoStreamRoadControl>().Max(control => (control).Width);
            uiMainPanel.Width = maxWidth;
        }
    }
}
