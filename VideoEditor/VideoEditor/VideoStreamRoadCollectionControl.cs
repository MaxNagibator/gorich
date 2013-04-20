using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AviFile;

namespace VideoEditor
{
    public partial class VideoStreamRoadCollectionControl : UserControl
    {
        public VideoStreamRoadControl ActiveVideoStreamRoadControl { get; set; }
        public VideoStreamRoadCollectionControl()
        {
            InitializeComponent();
        }

        public void AddVideoStreamView(VideoStreamRoadControl videoStreamRoadControl)
        {
            videoStreamRoadControl.Location = new Point(0,GetSumHeightAllVideoStreamViewControl());
            videoStreamRoadControl.SelectVideStreaViewControl += SelectVideStreaViewControl;
            uiMainPanel.Controls.Add(videoStreamRoadControl);
            uiMainPanel.Height = GetSumHeightAllVideoStreamViewControl();
            SetMainPanelMinWidth();
        }

        private int GetSumHeightAllVideoStreamViewControl()
        {
            return uiMainPanel.Controls.OfType<VideoStreamRoadControl>().Sum(control => (control).Height);
        }

        private void SelectVideStreaViewControl(object sender, EventArgs e)
        {
            ActiveVideoStreamRoadControl = (VideoStreamRoadControl)sender;
            foreach (var control in uiMainPanel.Controls.OfType<VideoStreamRoadControl>())
            {
                (control).SetInactive();
            }
            ActiveVideoStreamRoadControl.SetActive();
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
