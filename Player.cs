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
    class Player: IElement
    {
        private PointF _location = new PointF (0,0);
        public PointF Location { get =>_location;}

        public float WalkSpeed = 3;
        public float JumpForce = 10;

        public bool isActiv { get; set; } = false;

        public Bitmap Sprite { get; set; } = Properties.Resources.Слой_1;

        public Player()
        {
            Sprite = Properties.Resources.Слой_1;
        }

        public void Start()
        {
            isActiv = true;
            //new Thread(new ThreadStart(() => { while (isActiv) Update(); })).Start();
        }

        public void Left()
        {
            _location.X -= 10;
            Thread.Sleep(1);
        }

        public void Right()
        {
            _location.X += 10;
            Thread.Sleep(1);
        }

        public void Down()
        {
            _location.Y += 10;
            Thread.Sleep(1);
        }

        public void Up()
        {
            _location.Y -= 10;
            Thread.Sleep(1);
        }

        public void Update()
        {

        }

        public void Stop()
        {
        }
    }
}
