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
    public partial class VideoStreamRoadControl : UserControl
    {
        public Guid Guid { get; set; }

        public VideoStream VideoStream { get; set; }

        private int _dx;
        private bool _first = true;
        public bool IsMoving { get; set; }

        public VideoStreamRoadControl()
        {
            InitializeComponent();
        }

        public void AddVideoStreamRoadPart(VideoStreamRoadPartControl videoStreamRoadPartControl)
        {
            videoStreamRoadPartControl.MouseDown += videoStreamRoadPartControl_MouseDown;
            uiMainPanel.Controls.Add(videoStreamRoadPartControl);
        }

        private void uiMainPanel_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void uiMainPanel_DragDrop(object sender, DragEventArgs e)
        {
            videoStreamRoadPartControl.Location = new Point(videoStreamRoadPartControl.Location.X,
                                                            videoStreamRoadPartControl.Location.Y);
            IsMoving = false;
        }


        private void videoStreamRoadPartControl_MouseDown(object sender, MouseEventArgs e)
        {
            var videoStreamEventArgs = new VideoStreamEventArgs {VideoStream = VideoStream};
            FireSelectVideoStreamViewControl(videoStreamEventArgs);
            if (videoStreamRoadPartControl.MoveEnable)
            {
                IsMoving = true;
                _first = true;
                videoStreamRoadPartControl.SelectClear();
                videoStreamRoadPartControl.DoDragDrop(videoStreamRoadPartControl, DragDropEffects.All);
            }
        }

        private void uiMainPanel_DragOver(object sender, DragEventArgs e)
        {
            //if (!(sender is VideoStreamRoadPartControl)) return;
            if (IsMoving == false) return;

            int move;
            if (_first)
            {
                move = videoStreamRoadPartControl.Location.X;
                _first = false;
            }
            else
            {
                move = videoStreamRoadPartControl.Location.X + e.X - _dx;
            }
            videoStreamRoadPartControl.Location = new Point(move, videoStreamRoadPartControl.Location.Y);
            _dx = e.X;
            e.Effect = DragDropEffects.Move;
            var leftCoordinate = videoStreamRoadPartControl.Location.X;
            var rightCoordinate = videoStreamRoadPartControl.Location.X + videoStreamRoadPartControl.Width;
            videoStreamRoadPartControl.LeftCoordinate = leftCoordinate;
            videoStreamRoadPartControl.RightCoordinate = rightCoordinate;
            CheckRoadSize(rightCoordinate);
        }

        private void CheckRoadSize(int rightCoordinate)
        {
            Width = rightCoordinate;
        }

        public void SetActive()
        {
            uiMainPanel.BackColor = Color.DarkOliveGreen;
        }

        public void SetInactive()
        {
            uiMainPanel.BackColor = Color.Cornsilk;
        }

        private void uiMainPanel_Click(object sender, EventArgs e)
        {
            var videoStreamEventArgs = new VideoStreamEventArgs {VideoStream = VideoStream};
            FireSelectVideoStreamViewControl(videoStreamEventArgs);
        }

        public void FireSelectVideoStreamViewControl(VideoStreamEventArgs e)
        {
            EventHandler<EventArgs> handler = SelectVideStreaViewControl;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<EventArgs> SelectVideStreaViewControl;
    }
}
