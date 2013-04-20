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
    public partial class VideoStreamViewControl : UserControl
    {
        public Guid Guid { get; set; }

        public VideoStream VideoStream { get; set; }

        private int _dx;
        private bool _first = true;
        public bool IsMoving { get; set; }

        public VideoStreamViewControl()
        {
            InitializeComponent();
        }

        private void uiMainPanel_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void uiMainPanel_DragDrop(object sender, DragEventArgs e)
        {
            uiVideoStreamPanel.Location = new Point(uiVideoStreamPanel.Location.X,uiVideoStreamPanel.Location.Y);
            IsMoving = false;
        }

        private void uiVideoStreamPanel_MouseDown(object sender, MouseEventArgs e)
        {
            var videoStreamEventArgs = new VideoStreamEventArgs { VideoStream = VideoStream };
            FireSelectVideoStreamViewControl(videoStreamEventArgs);
            IsMoving = true;
            _first = true;
            uiVideoStreamPanel.DoDragDrop(uiVideoStreamPanel, DragDropEffects.All);
        }

        private void uiMainPanel_DragOver(object sender, DragEventArgs e)
        {
            if (IsMoving == false) return;

            int move;
            if (_first)
            {
                move = uiVideoStreamPanel.Location.X;
                _first = false;
            }
            else
            {
                move = uiVideoStreamPanel.Location.X + e.X - _dx;
            }
            uiVideoStreamPanel.Location = new Point(move, uiVideoStreamPanel.Location.Y);
            _dx = e.X;
            e.Effect = DragDropEffects.Move;
            var leftCoordinate = uiVideoStreamPanel.Location.X;
            var rightCoordinate = uiVideoStreamPanel.Location.X + uiVideoStreamPanel.Width;
            uiLeftCoordinateLabel.Text = leftCoordinate.ToString();
            uiRightCoordinateLabel.Text = rightCoordinate.ToString();
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

        //public int VideoStreamRigthCoordinate
        //{
        //    get { return uiVideoStreamPanel.Location.X; }
        //}
    
        private void uiMainPanel_Click(object sender, EventArgs e)
        {
            var videoStreamEventArgs = new VideoStreamEventArgs { VideoStream = VideoStream };
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
