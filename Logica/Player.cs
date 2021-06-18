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
    public abstract class Player : ActivElement, IObject
    {
        public event Action EventDeleted;
        public Animator _animator { get; set; } = new Animator();

        public abstract Bitmap Sprite { get; set; }
        public abstract SizeF Size { get; set; }

        public RectangleF BoxElement => new RectangleF(Location, Size);

        protected PointF _location = new PointF(0, 0);
        public  PointF Location 
        {
            get => _location;
            set
            {
                _location = value;
            }
        }

        bool IObject.isActiv { get; set; } = true;

        public void LocationSet(float x, float y)
            =>_location = new PointF(x, y);

        public void Delete()
        {
            IController.DeleteElement(this);
            isActiv = false;
            Collider.Delete(this);
            Stop();
            EventDeleted?.Invoke();
            Sprite.Dispose();
        }


        public Player()
        {
            Collider.Add(this);

            EventStart += () => { IController.AddElement(this); };
            EventUpdate += () =>
            {
                if (_animator.isActiv)
                    _animator.Update();
            };
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
