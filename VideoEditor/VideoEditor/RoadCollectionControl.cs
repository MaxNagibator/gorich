using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AviFile;

namespace VideoEditor
{
    public partial class RoadCollectionControl : UserControl
    {
        public RoadControl ActiveVideoStreamRoadControl { get; set; }
        public event EventHandler<FrameEventArgs> ChangeImageRoadsControl;
        private int _maxRoadLength;
        private bool _isPlayToBack;
        private List<RoadPartControl> _allRoadPartControls = new List<RoadPartControl>();
        private VideoStream _streamForPlay;

        public RoadCollectionControl()
        {
            InitializeComponent();
        }

        public void AddVideoStreamView(RoadControl videoStreamRoadControl)
        {
            videoStreamRoadControl.Width = videoStreamRoadControl.VideoStream.CountFrames;
            videoStreamRoadControl.Location = new Point(0,GetSumHeightAllVideoStreamViewControl());
            videoStreamRoadControl.button1.Text = videoStreamRoadControl.Location.Y.ToString();
            videoStreamRoadControl.SelectVideoStreamViewControl += SelectVideoStreamViewControl;
            videoStreamRoadControl.AddVideoStreamRoadPart(new RoadPartControl(videoStreamRoadControl.VideoStream));
            videoStreamRoadControl.ChangeImageRoadPartControl += ChangeImageRoadPartControl;
            uiMainPanel.Controls.Add(videoStreamRoadControl);
            uiMainPanel.Height = GetSumHeightAllVideoStreamViewControl();
            SetMainPanelMinWidth();
            cursorPlayUpPanel.SendToBack();
        }

        private int GetSumHeightAllVideoStreamViewControl()
        {
            return uiMainPanel.Controls.OfType<RoadControl>().Sum(control => (control).Height+4);
        }

        private void SelectVideoStreamViewControl(object sender, EventArgs e)
        {
            ActiveVideoStreamRoadControl = (RoadControl)sender;
            foreach (var control in uiMainPanel.Controls.OfType<RoadControl>())
            {
                (control).SetInactive();
            }
            ActiveVideoStreamRoadControl.SetActive();
        }

        public void ChangeImageRoadPartControl(object sender, FrameEventArgs e)
        {
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
            foreach (var c in uiMainPanel.Controls.OfType<RoadControl>().Where(control => control.Location.Y > deletedLocationY))
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
            var maxWidth = uiMainPanel.Controls.OfType<RoadControl>().Max(control => (control).Width);
            uiMainPanel.Width = maxWidth;
        }

        // vse chto nizhe peredelat'
        private void button1_Click(object sender, EventArgs e)
        {
            _isPlayToBack = false;
            Play();
        }

        private void Play()
        {
            if (!uiMainPanel.Controls.OfType<RoadControl>().Any()) return;
            _maxRoadLength = uiMainPanel.Controls.OfType<RoadControl>().Max(control => (control).Width);
            uiPlayTimer.Interval = 1000/24;
            uiPlayTimer.Start();
        }

        private void uiPlayTimer_Tick(object sender, EventArgs e)
        {

            var step = _isPlayToBack ? -1  : 1;
            cursorPlayUpPanel.Location = new Point(cursorPlayDownPanel.Location.X + step, cursorPlayDownPanel.Location.Y);
            cursorPlayDownPanel.Location = new Point(cursorPlayDownPanel.Location.X + step, cursorPlayDownPanel.Location.Y);
            try
            {

                var a = _streamForPlay.GetBitmap(cursorPlayDownPanel.Location.X);
                FireChangeImageRoadPartControl(new FrameEventArgs() { Frame = a });
                button4.Text = "+";
            }
            catch (Exception)
            {
                button3.Text = "-";
            }
            checkStop();
        }

        private void checkStop()
        {
            if (cursorPlayDownPanel.Location.X > _maxRoadLength-1 || cursorPlayDownPanel.Location.X < 1)
            {
                uiPlayTimer.Stop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _isPlayToBack = true;
            Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uiPlayTimer.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _allRoadPartControls.Clear();
            GetAllRoadPartControl(uiMainPanel);
            var c = _allRoadPartControls;
            var a = c.OrderBy(b => b.LeftCoordinate);
            var totalVideoStream = new EditableVideoStream(a.First().VideoStream);
            IntPtr copiedData2 = totalVideoStream.Copy(0, 1);
            totalVideoStream.Cut(0, totalVideoStream.CountFrames);
            var tempVideoStream = new EditableVideoStream(totalVideoStream);

            for (int i = 0; i < 1000; i++)
            {
                tempVideoStream.Paste(copiedData2, 0, tempVideoStream.CountFrames, 1);
            }

            foreach (var roadPartControl in a)
            {
                var editableVideoStream = new EditableVideoStream(roadPartControl.VideoStream);
                IntPtr copiedData = editableVideoStream.Copy(0, editableVideoStream.CountFrames);
                if (roadPartControl.LeftCoordinate > totalVideoStream.CountFrames)
                {
                    totalVideoStream.Paste(tempVideoStream.Copy(0, roadPartControl.LeftCoordinate - totalVideoStream.CountFrames), 0, totalVideoStream.CountFrames, tempVideoStream.CountFrames);

                    //AviManager.MakeFileFromStream("D:\\test" + roadPartControl.LeftCoordinate + ".avi", totalVideoStream);
                }
                totalVideoStream.Paste(copiedData, 0, roadPartControl.LeftCoordinate, editableVideoStream.CountFrames);
            }
            _streamForPlay = new VideoStream(0,totalVideoStream.Copy(0,totalVideoStream.CountFrames));
            _streamForPlay.GetFrameOpen();
                                AviManager.MakeFileFromStream("D:\\test.avi", totalVideoStream);
                totalVideoStream.Close();
        }


        private void GetAllRoadPartControl(Control ctrl)
        {
            foreach (Control control in ctrl.Controls)
            {
                var roadPartControl = control as RoadPartControl;
                if (roadPartControl != null)
                {
                    _allRoadPartControls.Add(roadPartControl);
                }
                GetAllRoadPartControl(control);
            }
        }
    }
}
