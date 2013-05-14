using System;
using System.Drawing;
using System.Windows.Forms;
using AviFile;

namespace VideoEditor
{
    public partial class VideoStreamRoadPartControl : UserControl
    {
        public VideoStream VideoStream { get; set; }
        public VideoStreamRoadPartControl()
        {
            InitializeComponent();
            MoveEnable = true;
            LeftCoordinate = 0;
            RightCoordinate = Width;
        }

        public VideoStreamRoadPartControl(VideoStream videoStream)
        {
            InitializeComponent();
            Width = videoStream.CountFrames;
            VideoStream = videoStream;
            MoveEnable = true;
            LeftCoordinate = 0;
            RightCoordinate = Width;
        }
        private const int MOVING_AREA_HEIGHT = 25;

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

        private void VideoStreamRoadPartControl_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as VideoStreamRoadPartControl;
            var g = e.Graphics;

            //g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Black)), p.DisplayRectangle);

            var points = new Point[4];
            points[0] = new Point(0, 0);
            points[1] = new Point(p.Width, 0);
            points[2] = new Point(p.Width, MOVING_AREA_HEIGHT);
            points[3] = new Point(0, MOVING_AREA_HEIGHT);

            Brush brush = new SolidBrush(Color.DarkGreen);

            g.FillPolygon(brush, points);
        }
    }
}
