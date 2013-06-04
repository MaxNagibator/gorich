using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AviFile;

namespace VideoEditor
{
    public partial class RoadControl : UserControl
    {
        private RoadPartControl _selectedVideoStreamRoadPartControl;
        private int _beforeMoveMouseLocationX;
        private int _beforeMoveSelectedVideoStreamRoadPartControlLocationX;

        public Guid Guid { get; set; }
        public VideoStream VideoStream { get; set; }
        public bool IsMoving { get; set; }
        public event EventHandler<FrameEventArgs> ChangeImageRoadPartControl;
        public event EventHandler<VideoStreamEventArgs> SelectVideoStreamViewControl;


        public RoadControl(VideoStream videoStream)
        {
            InitializeComponent();
            VideoStream = videoStream;
        }

        public void AddVideoStreamRoadPart(RoadPartControl videoStreamRoadPartControl)
        {
            videoStreamRoadPartControl.MouseDown += videoStreamRoadPartControl_MouseDown;
            videoStreamRoadPartControl.MouseMove += videoStreamRoadPartControl_MouseEnter;
            videoStreamRoadPartControl.MouseClick += videoStreamRoadPartControl_MouseClick;
            uiMainPanel.Controls.Add(videoStreamRoadPartControl);
        }

        public void SplitVideoStreamPart()
        {
            if (_selectedVideoStreamRoadPartControl.SelectedPart == null) return;
            CreateFirstPart();
            CreateMiddlePart();
            CreateLastPart();
            //_selectedVideoStreamRoadPartControl.VideoStream.GetFrameClose();
            uiMainPanel.Controls.Remove(_selectedVideoStreamRoadPartControl);
        }

        private void CreateFirstPart()
        {
            if (_selectedVideoStreamRoadPartControl.SelectedPartX1 <= 0) return;
            var videoStreamRoadPartControl =
                new RoadPartControl
                    {
                        Location = new Point(_selectedVideoStreamRoadPartControl.Location.X, 0),
                        Width = _selectedVideoStreamRoadPartControl.SelectedPartX1
                    };
            const int start = 0;
            var length = _selectedVideoStreamRoadPartControl.SelectedPartX1;
            AddCutedVideoStream(videoStreamRoadPartControl, start, length);
        }

        private void CreateMiddlePart()
        {
            if (_selectedVideoStreamRoadPartControl.SelectedPartX2 -
                _selectedVideoStreamRoadPartControl.SelectedPartX1 <= 0) return;
            var videoStreamRoadPartControl =
                new RoadPartControl
                    {
                        Location = new Point(
                            _selectedVideoStreamRoadPartControl.Location.X +
                            _selectedVideoStreamRoadPartControl.SelectedPartX1, 0),
                        Width =
                            _selectedVideoStreamRoadPartControl.SelectedPartX2 -
                            _selectedVideoStreamRoadPartControl.SelectedPartX1
                    };
            var start = _selectedVideoStreamRoadPartControl.SelectedPartX1;
            var length = videoStreamRoadPartControl.Width;
            AddCutedVideoStream(videoStreamRoadPartControl, start, length);
        }

        private void CreateLastPart()
        {
            if (_selectedVideoStreamRoadPartControl.Width -
                _selectedVideoStreamRoadPartControl.SelectedPartX2 <= 0) return;
            var videoStreamRoadPartControl =
                new RoadPartControl
                    {
                        Location = new Point(
                            _selectedVideoStreamRoadPartControl.Location.X +
                            _selectedVideoStreamRoadPartControl.SelectedPartX2, 0),
                        Width =
                            _selectedVideoStreamRoadPartControl.Width -
                            _selectedVideoStreamRoadPartControl.SelectedPartX2
                    };
            int start = _selectedVideoStreamRoadPartControl.SelectedPartX2;
            var length = videoStreamRoadPartControl.Width;
            AddCutedVideoStream(videoStreamRoadPartControl, start, length);
        }

        private void AddCutedVideoStream(RoadPartControl videoStreamRoadPartControl, int start, int length)
        {
            var editableVideoStream = new EditableVideoStream(_selectedVideoStreamRoadPartControl.VideoStream);
            IntPtr copiedData = editableVideoStream.Cut(start, length);
            var videoStream = new VideoStream(0, copiedData);
            videoStream.GetFrameOpen();
            videoStreamRoadPartControl.VideoStream = videoStream;
            AddVideoStreamRoadPart(videoStreamRoadPartControl);
        }

        private void uiMainPanel_DragDrop(object sender, DragEventArgs e)
        {
            IsMoving = false;
        }

        private void uiMainPanel_DragOver(object sender, DragEventArgs e)
        {
            if (IsMoving == false) return;
            int move = Cursor.Position.X - _beforeMoveMouseLocationX;
            _selectedVideoStreamRoadPartControl.Location = new Point(_beforeMoveSelectedVideoStreamRoadPartControlLocationX + move,
                                                                     _selectedVideoStreamRoadPartControl.Location.Y);
            e.Effect = DragDropEffects.Move;
            UpdateControlInfo();
            CheckRoadSize();
        }

        private void videoStreamRoadPartControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _selectedVideoStreamRoadPartControl = (RoadPartControl) sender;
                var videoStreamEventArgs = new VideoStreamEventArgs { EditableVideoStream = VideoStream };
                FireSelectVideoStreamViewControl(videoStreamEventArgs);
                if (_selectedVideoStreamRoadPartControl.MoveEnable)
                {
                    IsMoving = true;
                    _beforeMoveMouseLocationX = Cursor.Position.X;
                    _beforeMoveSelectedVideoStreamRoadPartControlLocationX =
                        _selectedVideoStreamRoadPartControl.Location.X;
                    _selectedVideoStreamRoadPartControl.SelectClear();
                    _selectedVideoStreamRoadPartControl.DoDragDrop(_selectedVideoStreamRoadPartControl,
                                                                   DragDropEffects.All);
                }
            }
        }

        private void UpdateControlInfo()
        {
            var leftCoordinate = _selectedVideoStreamRoadPartControl.Location.X;
            var rightCoordinate = _selectedVideoStreamRoadPartControl.Location.X +
                                  _selectedVideoStreamRoadPartControl.Width;
            _selectedVideoStreamRoadPartControl.LeftCoordinate = leftCoordinate;
            _selectedVideoStreamRoadPartControl.RightCoordinate = rightCoordinate;
        }

        private void CheckRoadSize()
        {
            int max = uiMainPanel.Controls.OfType<RoadPartControl>()
                .Select(control => (control).RightCoordinate).Concat(new[] {0}).Max();
            Width = max+100;
        }

        public void SetActive()
        {
            uiMainPanel.BackColor = Color.DarkOliveGreen;
        }

        public void SetInactive()
        {
            uiMainPanel.BackColor = Color.Cornsilk;
        }

        private void videoStreamRoadPartControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _selectedVideoStreamRoadPartControl = (RoadPartControl) sender;
                uiSplitToolStripMenuItem.Enabled = _selectedVideoStreamRoadPartControl.HasSelectPart;
                uiMainContextMenuStrip.Show((Control) sender, e.X, e.Y);
                            
            }
        }

        private void videoStreamRoadPartControl_MouseEnter(object sender, MouseEventArgs e)
        {
            var a = (RoadPartControl)sender;
            var frame = a.VideoStream.GetBitmap(e.X);
            var videoStreamEventArgs = new FrameEventArgs {Frame = frame};
            FireChangeImageRoadPartControl(videoStreamEventArgs);
        }

        private void uiMainPanel_Click(object sender, EventArgs e)
        {
            var videoStreamEventArgs = new VideoStreamEventArgs { EditableVideoStream = VideoStream };
            FireSelectVideoStreamViewControl(videoStreamEventArgs);
        }

        public void FireChangeImageRoadPartControl(FrameEventArgs e)
        {
            EventHandler<FrameEventArgs> handler = ChangeImageRoadPartControl;
            if (handler != null) handler(this, e);
        }

        public void FireSelectVideoStreamViewControl(VideoStreamEventArgs e)
        {
            EventHandler<VideoStreamEventArgs> handler = SelectVideoStreamViewControl;
            if (handler != null) handler(this, e);
        }

        private void uiDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uiMainPanel.Controls.Remove(_selectedVideoStreamRoadPartControl);
            if (!uiMainPanel.Controls.OfType<RoadPartControl>().Any())
            {
                Dispose();
            }
        }

        private void uiSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SplitVideoStreamPart();
        }
    }
}
