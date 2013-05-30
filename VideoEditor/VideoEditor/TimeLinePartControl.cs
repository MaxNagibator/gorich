using System.Windows.Forms;

namespace VideoEditor
{
    public partial class TimeLinePartControl : UserControl
    {
        public TimeLinePartControl()
        {
            InitializeComponent();
        }

        public void SetFrameNumber(int frameNumber)
        {
            uiFrameNumberLabel.Text = frameNumber.ToString();
        }
    }
}
