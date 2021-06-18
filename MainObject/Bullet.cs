using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyGame
{
    public class Bullet : Player
    {
        public override Bitmap Sprite { get; set; } = Properties.Resources.bullet;
        public override SizeF Size { get; set; } = new SizeF(5, 10);
        float speed = 300;
        private readonly int power = 150;

        public Bullet(IObject obj)
        {
            var x = obj.Location.X + obj.Size.Width / 2 - Size.Width / 2;
            var y = obj.Location.Y - Size.Height;
            LocationSet(x, y);
            EventUpdate += Update;
        }

        private new void Update()
        {
            _location.Y += -speed * deltaTime;
            Enemy enemy;
            if (Collider.OnTrigger(this, out enemy))
            {
                enemy.takeDamage(power);
                Delete();
                return;
            }
            if (Location.Y < 20)
                Delete();
        }
    }
}
