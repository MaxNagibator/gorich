using System;
using System.Drawing;
using System.Windows.Forms;
using AviFile;

namespace VideoEditor
{
    public partial class RoadPartControl : UserControl
    {
        private readonly Color _infoPanelColor = Color.DarkGreen;
        private readonly Color _selectedColor = Color.Orange;
        private const int MOVING_AREA_HEIGHT = 25;
        private bool _isSelected;
        public VideoStream VideoStream { get; set; }
        public int SelectedPartX1 { get; set; }
        public int SelectedPartX2 { get; set; }
        public Panel SelectedPart { get; set; }
        public bool HasSelectPart { get; set; }
        public bool MoveEnable { get; set; }
        public int Level { get; set; }

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

        public RoadPartControl()
        {
            InitializeComponent();
            MoveEnable = true;
            UpdateCoordinatesInfo();
        }

        public RoadPartControl(VideoStream videoStream)
        {
            InitializeComponent();
            uiLeftCoordinateLabel.BackColor = _infoPanelColor;
            uiRightCoordinateLabel.BackColor = _infoPanelColor;
            Width = videoStream.CountFrames;
            VideoStream = videoStream;
            MoveEnable = true;
            UpdateCoordinatesInfo();
        }
        private void VideoStreamRoadPartControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && IsSelectedArea(e))
            {
                MoveEnable = false;
                HasSelectPart = true;
                StartSelect(e.X);
            }
        }

        private bool IsSelectedArea(MouseEventArgs mouseEventArgs)
        {
            HasSelectPart = false;
            return mouseEventArgs.Y > MOVING_AREA_HEIGHT;
        }

        private void StartSelect(int x)
        {
            _isSelected = true;
            SelectClear();
            SelectedPart = new Panel { Tag = "SelectedArea", BackColor = _selectedColor, Location = new Point(x, MOVING_AREA_HEIGHT) };
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
            if (_isSelected)
            {
                SelectedPartX2 = e.X;
                SelectedPart.Location = new Point(Math.Min(SelectedPartX1, SelectedPartX2), MOVING_AREA_HEIGHT);
                SelectedPart.Width = Math.Abs(SelectedPartX1 - SelectedPartX2);
            }
        }

        private void VideoStreamRoadPartControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isSelected)
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
                _isSelected = false;
                MoveEnable = true;
            }
        }

        private void VideoStreamRoadPartControl_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as RoadPartControl;
            var g = e.Graphics;
            if (p == null) return;
            var points = new Point[4];
            points[0] = new Point(0, 0);
            points[1] = new Point(p.Width, 0);
            points[2] = new Point(p.Width, MOVING_AREA_HEIGHT);
            points[3] = new Point(0, MOVING_AREA_HEIGHT);
            Brush brush = new SolidBrush(_infoPanelColor);
            g.FillPolygon(brush, points);
        }

        public void UpdateCoordinatesInfo()
        {
            LeftCoordinate = Location.X;
            RightCoordinate = Location.X + Width-1;
        }
    }
}
