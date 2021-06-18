using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MyGame
{
    public interface IObject
    {
        public bool isActiv { get; set; }

        public Bitmap Sprite { get; }
        public RectangleF BoxElement { get; }
        public PointF Location { get; set; }
        public SizeF Size { get; set; }

        public void LocationSet(float x, float y);
    }
}