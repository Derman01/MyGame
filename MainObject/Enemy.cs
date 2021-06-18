using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Text;

namespace MyGame
{
    public class Enemy : Player
    {
        public override Bitmap Sprite { get; set; } = Properties.Resources.enemy1;
        public override SizeF Size { get; set; } = new SizeF(30, 30);
        private Animator animator = new Animator();
        private int health = 500;
        private float speed = 70;

        private float timeNow = 3500;
        private float timeSpanBullet = 3500;

        public Enemy(float x, float y)
        {
            _location = new PointF(x, y);
            animator.AddAnimation(
                new Animation(this, "start", 5,
                new Bitmap(Properties.Resources.enemy2),
                new Bitmap(Properties.Resources.enemy3),
                new Bitmap(Properties.Resources.enemy1)
                ));
            EventStart += () => animator.Play("start");
            EventUpdate += Updated;
        }

        private void Updated()
        {
            _location.Y += speed * deltaTime;
            animator.Update();
            if (_location.Y > 650)
                LocationSet(new Random().Next(0, 1000), -30);

            timeNow += deltaTime * 1000;
            if (timeNow > timeSpanBullet)
            {
                new BulletEnemy(this).Start();
                timeNow = 0;
            }
        }

        public Enemy() { }

        public void takeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                new Partical(this).Start();
                Delete();
            }
        }
    }
}
