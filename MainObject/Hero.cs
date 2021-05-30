using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MyGame
{
    class Hero : Player, ICollider
    {
        private float speed = 100;
        public Dictionary<ICollider.Sect, bool> CanMove { get; set; }
            = new Dictionary<ICollider.Sect, bool>
            {
                { ICollider.Sect.Bottom, true },
                { ICollider.Sect.Left, true },
                { ICollider.Sect.Rigth, true },
                { ICollider.Sect.Top, true}
            };

        public override Bitmap Sprite { get; set; } = new Bitmap(Properties.Resources.Слой_1);

        public override SizeF Size { get; set; } = new SizeF(50, 50);

        public Hero()
        {
            Collider.Add(this);
            _location = new PointF(100, 0);
            _animator.AddAnimation( new Animation(this, "Right", 20,
                new Bitmap(Properties.Resources._1),
                new Bitmap(Properties.Resources._2),
                new Bitmap(Properties.Resources._3),
                new Bitmap(Properties.Resources._4)));

            _animator.AddAnimation( new Animation(this, "Left", 5,
                new Bitmap(Properties.Resources._1),
                new Bitmap(Properties.Resources._2),
                new Bitmap(Properties.Resources._3),
                new Bitmap(Properties.Resources._4)));

            _animator.Play("Right");
        }

        public void Left()
        {
            if (!(_moveState.Horizontal is MoveStateX.Left))
            {
                _animator.Play("Left");
                _moveState.Horizontal = MoveStateX.Left;
            }

            Location = new PointF(Location.X - speed * deltaTime, Location.Y);
        }

        public void Right()
        {
            if (!(_moveState.Horizontal is MoveStateX.Rigth))
            {
                _animator.Play("Right");
                _moveState.Horizontal = MoveStateX.Rigth;
            }
            Location = new PointF(Location.X + speed * deltaTime, Location.Y);
        }

        public void Down()
        {
            if (!(_moveState.Vertical is MoveStateY.Bottom))
            {
                _moveState.Vertical = MoveStateY.Bottom;
            }
            Location = new PointF(Location.X, Location.Y + speed * deltaTime);
        }

        public void Up()
        {
            if (!(_moveState.Vertical is MoveStateY.Top))
            {
                _moveState.Vertical = MoveStateY.Top;
            }
            Location = new PointF(Location.X, Location.Y - speed * deltaTime);
        }
    }

    class Hero2 : Player, ICollider
    {
        public override Bitmap Sprite { get; set; } = new Bitmap(Properties.Resources._1);
        public override SizeF Size { get; set; } = new SizeF(50, 200);
        public Dictionary<ICollider.Sect, bool> CanMove { get; set; }
            = new Dictionary<ICollider.Sect, bool> 
            {
                { ICollider.Sect.Bottom, true },
                { ICollider.Sect.Left, true },
                { ICollider.Sect.Rigth, true },
                { ICollider.Sect.Top, true}
            };

        public Hero2()
        {
            _location = new PointF(200, 100);
            Collider.Add(this);
        }
    }

}
