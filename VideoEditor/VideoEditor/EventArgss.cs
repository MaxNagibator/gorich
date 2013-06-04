using System;
using System.Drawing;
using AviFile;

namespace VideoEditor
{
    public class FrameEventArgs : EventArgs
    {
        public Bitmap Frame { get; set; }
    }

    public class VideoStreamEventArgs : EventArgs
    {
        public VideoStream EditableVideoStream { get; set; }
    }
}
