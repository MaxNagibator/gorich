using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AviFile;

namespace VideoEditor
{
    public partial class VideoStreamRoadControl : UserControl
    {
        private VideoStreamRoadPartControl _selectedVideoStreamRoadPartControl;
        private int _dx;
        private bool _first = true;

        public Guid Guid { get; set; }

        public VideoStream VideoStream { get; set; }

        public bool IsMoving { get; set; }

        public VideoStreamRoadControl(VideoStream videoStream)
        {
            InitializeComponent();
            VideoStream = videoStream;
        }

        public void AddVideoStreamRoadPart(VideoStreamRoadPartControl videoStreamRoadPartControl)
        {
            videoStreamRoadPartControl.MouseDown += videoStreamRoadPartControl_MouseDown;
            videoStreamRoadPartControl.MouseMove += videoStreamRoadPartControl_MouseEnter;
            uiMainPanel.Controls.Add(videoStreamRoadPartControl);
        }

        public void SplitVideoStreamPart()
        {
            if (_selectedVideoStreamRoadPartControl.SelectedPart == null) return;
            CreateFirstPart();
            CreateMiddlePart();
            CreateLastPart();
            uiMainPanel.Controls.Remove(_selectedVideoStreamRoadPartControl);
        }

        private void CreateMiddlePart()
        {
            if (_selectedVideoStreamRoadPartControl.SelectedPartX2 -
                _selectedVideoStreamRoadPartControl.SelectedPartX1 <= 0) return;
            var videoStreamRoadPartControl = new VideoStreamRoadPartControl
                                                 {
                                                     Location =
                                                         new Point(
                                                         _selectedVideoStreamRoadPartControl.Location.X +
                                                         _selectedVideoStreamRoadPartControl.SelectedPartX1, 0),
                                                     Width =
                                                         _selectedVideoStreamRoadPartControl.SelectedPartX2 -
                                                         _selectedVideoStreamRoadPartControl.SelectedPartX1
                                                 };
            AddVideoStreamRoadPart(videoStreamRoadPartControl);
        }

        private void CreateFirstPart()
        {
            if (_selectedVideoStreamRoadPartControl.SelectedPartX1 <= 0) return;
            var videoStreamRoadPartControl = new VideoStreamRoadPartControl
                                                 {
                                                     Location =
                                                         new Point(_selectedVideoStreamRoadPartControl.Location.X, 0),
                                                     Width = _selectedVideoStreamRoadPartControl.SelectedPartX1
                                                 };
            AddVideoStreamRoadPart(videoStreamRoadPartControl);
        }

        private void CreateLastPart()
        {
            if (_selectedVideoStreamRoadPartControl.Width -
                _selectedVideoStreamRoadPartControl.SelectedPartX2 <= 0) return;
            var streamRoadPartControl = new VideoStreamRoadPartControl
                                            {
                                                Location =
                                                    new Point(
                                                    _selectedVideoStreamRoadPartControl.Location.X +
                                                    _selectedVideoStreamRoadPartControl.SelectedPartX2, 0),
                                                Width =
                                                    _selectedVideoStreamRoadPartControl.Width -
                                                    _selectedVideoStreamRoadPartControl.SelectedPartX2
                                            };
            AddVideoStreamRoadPart(streamRoadPartControl);
        }

        private void uiMainPanel_DragDrop(object sender, DragEventArgs e)
        {
            _selectedVideoStreamRoadPartControl.Location = new Point(_selectedVideoStreamRoadPartControl.Location.X,
                                                                     _selectedVideoStreamRoadPartControl.Location.Y);
            IsMoving = false;
        }


        private void videoStreamRoadPartControl_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedVideoStreamRoadPartControl = (VideoStreamRoadPartControl) sender;
            var videoStreamEventArgs = new VideoStreamEventArgs {VideoStream = VideoStream};
            FireSelectVideoStreamViewControl(videoStreamEventArgs);
            if (_selectedVideoStreamRoadPartControl.MoveEnable)
            {
                IsMoving = true;
                _first = true;
                _selectedVideoStreamRoadPartControl.SelectClear();
                _selectedVideoStreamRoadPartControl.DoDragDrop(_selectedVideoStreamRoadPartControl, DragDropEffects.All);
            }
        }

        private void uiMainPanel_DragOver(object sender, DragEventArgs e)
        {
            if (IsMoving == false) return;
            int move;
            if (_first)
            {
                move = _selectedVideoStreamRoadPartControl.Location.X;
                _first = false;
            }
            else
            {
                move = _selectedVideoStreamRoadPartControl.Location.X + e.X - _dx;
            }
            _selectedVideoStreamRoadPartControl.Location = new Point(move,
                                                                     _selectedVideoStreamRoadPartControl.Location.Y);
            _dx = e.X;
            e.Effect = DragDropEffects.Move;
            var leftCoordinate = _selectedVideoStreamRoadPartControl.Location.X;
            var rightCoordinate = _selectedVideoStreamRoadPartControl.Location.X +
                                  _selectedVideoStreamRoadPartControl.Width;
            _selectedVideoStreamRoadPartControl.LeftCoordinate = leftCoordinate;
            _selectedVideoStreamRoadPartControl.RightCoordinate = rightCoordinate;
            CheckRoadSize();
        }

        private void CheckRoadSize()
        {
            int max =
                uiMainPanel.Controls.OfType<VideoStreamRoadPartControl>().Select(control => (control).RightCoordinate).
                    Concat(new[] {0}).Max();
            Width = max;
        }

        public void SetActive()
        {
            uiMainPanel.BackColor = Color.DarkOliveGreen;
        }

        public void SetInactive()
        {
            uiMainPanel.BackColor = Color.Cornsilk;
        }


        private void videoStreamRoadPartControl_MouseEnter(object sender, MouseEventArgs e)
        {
            var a = VideoStream.GetBitmap(e.X);
            var videoStreamEventArgs = new FrameEventArgs {Frame = a};
            FireChangeImageRoadPartControl(videoStreamEventArgs);
        }

        public void FireChangeImageRoadPartControl(FrameEventArgs e)
        {
            EventHandler<FrameEventArgs> handler = ChangeImageRoadPartControl;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<FrameEventArgs> ChangeImageRoadPartControl;

        private void uiMainPanel_Click(object sender, EventArgs e)
        {
            var videoStreamEventArgs = new VideoStreamEventArgs {VideoStream = VideoStream};
            FireSelectVideoStreamViewControl(videoStreamEventArgs);
        }

        public void FireSelectVideoStreamViewControl(VideoStreamEventArgs e)
        {
            EventHandler<VideoStreamEventArgs> handler = SelectVideoStreamViewControl;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<VideoStreamEventArgs> SelectVideoStreamViewControl;

        private void button1_Click(object sender, EventArgs e)
        {
            SplitVideoStreamPart();
        }
    }
}
