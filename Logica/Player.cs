using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyGame.ICollider;

namespace MyGame
{
    public abstract class Player : ActivElement, IOject
    {
        public Animator _animator { get; set; } = new Animator();

        public abstract Bitmap Sprite { get; set; }

        public RectangleF BoxElement => new RectangleF(Location, Size);

        protected PointF _location = new PointF(0, 0);
        public  PointF Location 
        {
            get => _location;
            set
            {
                if (this is ICollider box && Collider.OnTriger(box))
                    if (_moveState.Horizontal == MoveStateX.Rigth && !box.CanMove[Sect.Rigth]
                        || _moveState.Vertical == MoveStateY.Bottom && !box.CanMove[Sect.Bottom]
                        || _moveState.Horizontal == MoveStateX.Left && !box.CanMove[Sect.Left]
                        || _moveState.Vertical == MoveStateY.Top && !box.CanMove[Sect.Top])
                        return;
                _location = value;
            }
        }

        public void LocationSet(float x, float y)
        {
            _location = new PointF(x , y);
        }

        public abstract SizeF Size { get; set; }

        public Player()
        {
            EventUpdate += () => _animator.Update();
        }

        protected (MoveStateX Horizontal, MoveStateY Vertical) _moveState = (MoveStateX.None, MoveStateY.None);

        protected enum MoveStateY
        {
            Bottom,
            Top,
            None
        }
        protected enum MoveStateX
        {
            Rigth,
            Left,
            None
        }
    }
}
