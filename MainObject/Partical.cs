using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace MyGame
{
    class Partical : Player
    {
        public override Bitmap Sprite { get; set; } = new Bitmap(Properties.Resources.p1);
        public override SizeF Size { get; set; } = new SizeF(40, 40);

        private Animator animator = new Animator();

        public Partical(IObject obj)
        {
            var x = obj.Location.X + obj.Size.Width / 2 - Size.Width / 2;
            var y = obj.Location.Y + obj.Size.Height / 2 - Size.Height / 2;
            LocationSet(x, y);

            animator.AddAnimation(new Animation(this, "update", 10,
               new Bitmap(Properties.Resources.p1),
               new Bitmap(Properties.Resources.p2),
               new Bitmap(Properties.Resources.p3),
               new Bitmap(Properties.Resources.p4),
               new Bitmap(Properties.Resources.p5),
               new Bitmap(Properties.Resources.p6),
               new Bitmap(Properties.Resources.p7),
               new Bitmap(Properties.Resources.p8),
               new Bitmap(Properties.Resources.p9),
               new Bitmap(Properties.Resources.p10),
               new Bitmap(Properties.Resources.p11),
               new Bitmap(Properties.Resources.p12),
               new Bitmap(Properties.Resources.p13),
               new Bitmap(Properties.Resources.p14),
               new Bitmap(Properties.Resources.p15),
               new Bitmap(Properties.Resources.p16)
               ));

            EventStart += () => animator.Play("update");
            EventStart += () =>
            {
                new Thread(() =>
                {
                    Thread.Sleep(1600);
                    animator.Stop();
                    Delete();
                }
                ).Start();
            };
            EventUpdate += animator.Update;
        }
    }
}
