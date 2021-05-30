using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyGame
{
    public abstract class Player : ActivElement, IOject
    {
        public Animator _animator { get; set; } = new Animator();

        public abstract Bitmap Sprite { get; set; }

        public RectangleF BoxElement => new RectangleF(Location, Size);

        public abstract PointF Location { get; set; }
        public abstract SizeF Size { get; set; }

        public Player()
        {
            EventUpdate += () => _animator.Update();
        }
    }
}
