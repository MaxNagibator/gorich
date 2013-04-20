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
    public partial class VideoStreamViewCollectionControl : UserControl
    {
        public VideoStreamViewControl ActiveVideoStreamControl { get; set; }
        public VideoStreamViewCollectionControl()
        {
            InitializeComponent();
        }

        public void AddVideoStreamView(VideoStreamViewControl videoStreamViewControl)
        {
            videoStreamViewControl.Location = new Point(0,GetSumHeightAllVideoStreamViewControl());
            videoStreamViewControl.SelectVideStreaViewControl += SelectVideStreaViewControl;
            videoStreamViewControl.SizeChanged += uiMainPanelSizeChange;
            uiMainPanel.Controls.Add(videoStreamViewControl);
            uiMainPanel.Height = GetSumHeightAllVideoStreamViewControl();
            SetMainPanelMinimuWidth();
        }

        private int GetSumHeightAllVideoStreamViewControl()
        {
            return uiMainPanel.Controls.OfType<VideoStreamViewControl>().Sum(control => (control).Height);
        }

        private void SelectVideStreaViewControl(object sender, EventArgs e)
        {
            ActiveVideoStreamControl = (VideoStreamViewControl)sender;
            foreach (var control in uiMainPanel.Controls.OfType<VideoStreamViewControl>())
            {
                (control).SetInactive();
            }
            ActiveVideoStreamControl.SetActive();
        }

        private void uiMainPanelSizeChange(object sender, EventArgs e)
        {
            SetMainPanelMinimuWidth();
        }

        private void SetMainPanelMinimuWidth()
        {
            var maxWidth = uiMainPanel.Controls.OfType<VideoStreamViewControl>().Max(control => (control).Width);
            uiMainPanel.Width = maxWidth;
        }

        public void DeleteVideoStreamView()
        {
            if (ActiveVideoStreamControl == null) return;
            var deletedLocationY = ActiveVideoStreamControl.Location.Y;
            var deletedHeight = ActiveVideoStreamControl.Height;
            uiMainPanel.Controls.Remove(ActiveVideoStreamControl);

            foreach (var control in uiMainPanel.Controls.OfType<VideoStreamViewControl>().Where(control => control.Location.Y > deletedLocationY))
            {
                control.Location = new Point(control.Location.X,control.Location.Y-deletedHeight);
            }
            uiMainPanel.Height = GetSumHeightAllVideoStreamViewControl();
            ActiveVideoStreamControl = null;
        }
    }
}
