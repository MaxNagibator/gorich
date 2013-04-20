using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AviFile;

namespace VideoEditor
{
    public partial class VideoStreamRoadPartControl : UserControl
    {
        public VideoStreamRoadPartControl()
        {
            InitializeComponent();
            MoveEnable = true;
        }

        public VideoStream VideoStream { get; set; }
        private const int MOVING_AREA_HEIGHT = 20;
        private int _selectedPartX1;
        private int _selectedPartX2;
        private bool _isselected;
        private Panel _selectedPart;
        public bool MoveEnable { get; set; }

        public int RightCoordinate
        {
            set { uiRightCoordinateLabel.Text = value.ToString(); }
        }

        public int LeftCoordinate
        {
            set { uiLeftCoordinateLabel.Text = value.ToString(); }
        }

        private void VideoStreamRoadPartControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y > MOVING_AREA_HEIGHT)
            {
                MoveEnable = false;
                StartSelect(e.X);
            }
            else if(e.X > _selectedPartX1 && e.X < _selectedPartX2)
            {
                var eventArgs = new SelectedPartVideoStreamEventArgs { LeftCoordinate = _selectedPartX1, RightCoordinate = _selectedPartX2 };
                FireSplitSelectVideoPartStream(eventArgs);
            }
        }

        private void StartSelect(int x)
        {
            _isselected = true;
            SelectClear();
            _selectedPart = new Panel { Tag = "SelectedArea", BackColor = Color.Red, Location = new Point(x, MOVING_AREA_HEIGHT) };
            Controls.Add(_selectedPart);
            _selectedPartX1 = x;
            _selectedPartX2 = x;
        }

        public void SelectClear()
        {
            Controls.Remove(_selectedPart);
        }

        private void VideoStreamRoadPartControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isselected)
            {
                _selectedPartX2 = e.X;
                _selectedPart.Location = new Point(Math.Min(_selectedPartX1, _selectedPartX2), MOVING_AREA_HEIGHT);
                _selectedPart.Width = Math.Max(_selectedPartX1, _selectedPartX2) - Math.Min(_selectedPartX1, _selectedPartX2);
            }
        }

        private void VideoStreamRoadPartControl_MouseUp(object sender, MouseEventArgs e)
        {
            _isselected = false;
            MoveEnable = true;
        }

        public void FireSplitSelectVideoPartStream(SelectedPartVideoStreamEventArgs e)
        {
            EventHandler<SelectedPartVideoStreamEventArgs> handler = SplitSelectedPartVideoStream;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<SelectedPartVideoStreamEventArgs> SplitSelectedPartVideoStream;
    }

    public class SelectedPartVideoStreamEventArgs : EventArgs
    {
        public int LeftCoordinate { get; set; }
        public int RightCoordinate { get; set; }
    }
}
