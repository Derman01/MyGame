using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MyGame
{
    class Bonus : Player
    {
        public override Bitmap Sprite { get; set; } = Properties.Resources.bonus;
        public override SizeF Size { get; set; } = new SizeF(30, 30);

        public Bonus(float x, float y)
        {
            LocationSet(x, y);
            EventUpdate += () =>
            {
                _location.Y += 100 * deltaTime;
            };
        }

        public Bonus() { }
    }
}
