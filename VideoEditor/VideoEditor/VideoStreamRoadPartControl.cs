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
            LeftCoordinate = 0;
            RightCoordinate = Width;
        }

        public VideoStream VideoStream { get; set; }
        private const int MOVING_AREA_HEIGHT = 20;

        public int SelectedPartX1 { get;set;}
        public int SelectedPartX2 { get; set; }
        private bool _isselected;
        public Panel SelectedPart { get; set; }
        public bool MoveEnable { get; set; }

        public int RightCoordinate
        {
            get { return Convert.ToInt32(uiRightCoordinateLabel.Text); }
            set { uiRightCoordinateLabel.Text = value.ToString(); }
        }

        public int LeftCoordinate
        {
            get { return Convert.ToInt32(uiLeftCoordinateLabel.Text); }
            set { uiLeftCoordinateLabel.Text = value.ToString(); }
        }

        private void VideoStreamRoadPartControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y > MOVING_AREA_HEIGHT)
            {
                MoveEnable = false;
                StartSelect(e.X);
            }
        }

        private void StartSelect(int x)
        {
            _isselected = true;
            SelectClear();
            SelectedPart = new Panel { Tag = "SelectedArea", BackColor = Color.Red, Location = new Point(x, MOVING_AREA_HEIGHT) };
            Controls.Add(SelectedPart);
            SelectedPartX1 = x;
            SelectedPartX2 = x;
        }

        public void SelectClear()
        {
            Controls.Remove(SelectedPart);
        }

        private void VideoStreamRoadPartControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isselected)
            {
                SelectedPartX2 = e.X;
                SelectedPart.Location = new Point(Math.Min(SelectedPartX1, SelectedPartX2), MOVING_AREA_HEIGHT);
                SelectedPart.Width = Math.Max(SelectedPartX1, SelectedPartX2) - Math.Min(SelectedPartX1, SelectedPartX2);
            }
        }

        private void VideoStreamRoadPartControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (SelectedPart.Location.X < 0)
            {
                SelectedPart.Width += SelectedPart.Location.X;
                SelectedPart.Location = new Point(0, MOVING_AREA_HEIGHT);
            }
            if (SelectedPart.Location.X + SelectedPart.Width > Width)
            {
                SelectedPart.Width = Width - SelectedPartX1;
            }
            SelectedPartX1 = SelectedPart.Location.X;
            SelectedPartX2 = SelectedPart.Width + SelectedPart.Location.X;
            _isselected = false;
            MoveEnable = true;
        }
    }
}
