using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MyGame
{
    class Hero : Player
    {
        private MoveState _moveState = MoveState.Right;
        private float speed = 300;

        public override Bitmap Sprite { get; set; } = new Bitmap(Properties.Resources.Слой_1);

        public override PointF Location { get; set; } = new PointF(100, 0);
        public override SizeF Size { get; set; } = new SizeF(50, 50);

        public Hero()
        {
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
            if (!(_moveState is MoveState.Left))
            {
                _animator.Play("Left");
                _moveState = MoveState.Left;
            }

            Location = new PointF(Location.X - speed * deltaTime, Location.Y);
        }

        public void Right()
        {
            if (!(_moveState is MoveState.Right))
            {
                _animator.Play("Right");
                _moveState = MoveState.Right;
            }
            Location = new PointF(Location.X + speed * deltaTime, Location.Y);
        }

        public void Down()
        {
            Location = new PointF(Location.X, Location.Y + speed * deltaTime);
        }

        public void Up()
        {
            Location = new PointF(Location.X, Location.Y - speed * deltaTime);
        }

        enum MoveState
        {
            Right,
            Left
        }
    }
}
