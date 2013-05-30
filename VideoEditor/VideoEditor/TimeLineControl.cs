using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VideoEditor
{
    public partial class TimeLineControl : UserControl
    {
        private int _stepWidth = 50;
        public TimeLineControl()
        {
            InitializeComponent();
            UpdateTimeLine();
        }
        public void SetStepWidth(int stepWidth)
        {
            _stepWidth = stepWidth;
        }

        public void UpdateTimeLine()
        {
            DeleteAllTimeLinePartControl();
            for (int currentFrame = 0; currentFrame < Width / _stepWidth; currentFrame++)
            {            
                var timeLinePartControl = new TimeLinePartControl();
                timeLinePartControl.SetFrameNumber(currentFrame * _stepWidth);
                timeLinePartControl.Location = new Point(currentFrame * _stepWidth, 0);
                Controls.Add(timeLinePartControl);
            }
        }

        private void DeleteAllTimeLinePartControl()
        {
            foreach (var control in Controls.OfType<TimeLinePartControl>())
            {
                Controls.Remove(control);
            }
        }

        private void TimeLineControl_SizeChanged(object sender, System.EventArgs e)
        {
            UpdateTimeLine();
        }
    }
}
