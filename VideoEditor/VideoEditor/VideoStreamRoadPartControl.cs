using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoEditor
{
    public partial class VideoStreamRoadPartControl : UserControl
    {
        public VideoStreamRoadPartControl()
        {
            InitializeComponent();
        }

        public int RightCoordinate
        {
            set { uiRightCoordinateLabel.Text = value.ToString(); }
        }

        public int LeftCoordinate
        {
            set { uiLeftCoordinateLabel.Text = value.ToString(); }
        }
    }
}
