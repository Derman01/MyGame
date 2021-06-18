using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    public class Hero : Player
    {
        private float speed = 400;

        public override Bitmap Sprite { get; set; } = new Bitmap(Properties.Resources.hero1);
        public override SizeF Size { get; set; } = new SizeF(40, 40);
        private double timeNow = 0;
        private double timeSpanBullet = 300;
        private Animator animator = new Animator();

        public Hero()
        {
            animator.AddAnimation(new Animation(this, "start", 10,
                new Bitmap(Properties.Resources.hero2),
                new Bitmap(Properties.Resources.hero3),
                new Bitmap(Properties.Resources.hero4),
                new Bitmap(Properties.Resources.hero1)));
            _location = new PointF(100, 0);
            EventStart += () => animator.Play("start");
            EventUpdate += () => animator.Update();

            EventUpdate += () => {

                Bonus bonus;
                if (Collider.OnTrigger(this, out bonus)){
                    bonus.Delete();
                    timeSpanBullet = 100;
                    new Thread(() => {
                        Thread.Sleep(3000);
                        timeSpanBullet = 300;
                    }).Start();
                }
                var e = new Enemy();
                if (Collider.OnTrigger(this, out e))
                {
                    Delete();
                }
                BulletEnemy bullet;
                if (Collider.OnTrigger(this, out bullet))
                {
                    bullet.Delete();
                    Delete();
                    return;
                }
                if (Location.Y > 1000)
                    Delete();

            };
        }

        public void CreateBullet()
        {
            timeNow += deltaTime * 1000;

            if (timeNow >= timeSpanBullet)
            {
                new Bullet(this).Start();
                timeNow -= timeSpanBullet;
            }
        }

        public void Left()
        {
            if (!(_moveState.Horizontal is MoveStateX.Left))
            {
                //_animator.Play("Left");
                _moveState.Horizontal = MoveStateX.Left;
            }

            Location = new PointF(Location.X - speed * deltaTime, Location.Y);
        }

        public void Right()
        {
            if (!(_moveState.Horizontal is MoveStateX.Rigth))
            {
                //_animator.Play("Right");
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
}
