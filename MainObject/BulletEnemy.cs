using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MyGame 
{ 
    class BulletEnemy : Player
    {
        public override Bitmap Sprite { get; set; } = new Bitmap(Properties.Resources.bulletEnemy);
        public override SizeF Size { get; set; } = new SizeF(10, 20);

        private float speed = 200;

        public BulletEnemy() { }

        public BulletEnemy(IObject obj)
        {
            var x = obj.Location.X + obj.Size.Width / 2 - Size.Width / 2;
            var y = obj.Location.Y + obj.Size.Height;
            _location = new PointF(x, y);

            EventUpdate += Updated;
        }

        private void Updated()
        {
            _location.Y += speed * deltaTime;
        }
    }
}
