using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MyGame
{
    public interface IOject
    {
        public Bitmap Sprite { get; }
        public RectangleF BoxElement { get; }
        public PointF Location { get; set; }
        public SizeF Size { get; set; }
    }
}