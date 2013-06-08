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
        private List<RoadControl> _allRoadControls = new List<RoadControl>();
        private List<RoadPartControl> _allRoadPartControls = new List<RoadPartControl>();
        private VideoStream _streamForPlay;
        private EditableVideoStream _tempVideoStream;
        private EditableVideoStream _totalVideoStream;

        public RoadCollectionControl()
        {
            InitializeComponent();
        }

        public void AddVideoStreamView(RoadControl videoStreamRoadControl)
        {
            videoStreamRoadControl.Width = videoStreamRoadControl.VideoStream.CountFrames;
            videoStreamRoadControl.Location = new Point(0,GetSumHeightAllVideoStreamViewControl());
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

        private void uiPlayButton_Click(object sender, EventArgs e)
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
                FireChangeImageRoadPartControl(new FrameEventArgs { Frame = a });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail", ex.Message);
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

        private void uiPlayBackButton_Click(object sender, EventArgs e)
        {
            _isPlayToBack = true;
            Play();
        }

        private void uiStopButton_Click(object sender, EventArgs e)
        {
            uiPlayTimer.Stop();
        }


        private void GetAllRoadPart(Control ctrl)
        {
            _allRoadPartControls.Clear();
            _allRoadControls.Clear();
            GetAllRoadControl(ctrl);
            var allRoadControlsOrderBy = _allRoadControls.OrderBy(a => a.Location.Y);
            int lvl = 0;
            foreach (var roadControl in allRoadControlsOrderBy)
            {
                GetAllRoadPartControl(roadControl, lvl);
                lvl++;
            }
        }

        private void GetAllRoadPartControl(Control ctrl, int lvl)
        {
            foreach (Control control in ctrl.Controls)
            {
                var roadPartControl = control as RoadPartControl;
                if (roadPartControl != null)
                {
                    roadPartControl.Level = lvl;
                    _allRoadPartControls.Add(roadPartControl);
                }
                GetAllRoadPartControl(control, lvl);
            }
        }

        private void GetAllRoadControl(Control ctrl)
        {
            foreach (Control control in ctrl.Controls)
            {
                var roadControl = control as RoadControl;
                if (roadControl != null)
                {
                    _allRoadControls.Add(roadControl);
                }
                GetAllRoadControl(control);
            }
        }

        private void uiUnionAllPartsButton_Click(object sender, EventArgs e)
        {
            GetAllRoadPart(uiMainPanel);
            var allRoadPartControls = _allRoadPartControls;
            var allRoadPartControlsOrderBy = allRoadPartControls.OrderBy(b => b.LeftCoordinate);
            CreateTotalVideoStream(allRoadPartControlsOrderBy);

            foreach (var roadPartControl in allRoadPartControlsOrderBy)
            {
                var editableVideoStream = new EditableVideoStream(roadPartControl.VideoStream);
                IntPtr copiedData = editableVideoStream.Copy(0, editableVideoStream.CountFrames);
                if (roadPartControl.LeftCoordinate > _totalVideoStream.CountFrames)
                {
                    _totalVideoStream.Paste(
                        _tempVideoStream.Copy(0, roadPartControl.LeftCoordinate - _totalVideoStream.CountFrames), 0,
                        _totalVideoStream.CountFrames, _tempVideoStream.CountFrames);
                }
                _totalVideoStream.Paste(copiedData, 0, roadPartControl.LeftCoordinate, editableVideoStream.CountFrames);
            }
            _streamForPlay = new VideoStream(0, _totalVideoStream.Copy(0, _totalVideoStream.CountFrames));
            _streamForPlay.GetFrameOpen();
        }

        private void CreateTotalVideoStream(IOrderedEnumerable<RoadPartControl> allRoadPartControlsOrderBy)
        {
            _totalVideoStream = new EditableVideoStream(allRoadPartControlsOrderBy.First().VideoStream);
            IntPtr copyFirstFrame = _totalVideoStream.Copy(0, 1);
            _totalVideoStream.Cut(0, _totalVideoStream.CountFrames);
            CreateTempVideoStream(allRoadPartControlsOrderBy, copyFirstFrame);
        }

        private void CreateTempVideoStream(IOrderedEnumerable<RoadPartControl> allRoadPartControlsOrderBy, IntPtr copyFirstFrame)
        {
            _tempVideoStream = new EditableVideoStream(_totalVideoStream);
            for (int i = 0; i < allRoadPartControlsOrderBy.Max(a => a.RightCoordinate); i++)
            {
                _tempVideoStream.Paste(copyFirstFrame, 0, _tempVideoStream.CountFrames, 1);
            }
        }

        private void uiSaveButton_Click(object sender, EventArgs e)
        {
            AviManager.MakeFileFromStream("D:\\test.avi", _streamForPlay);
        }
    }
}
