using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.Control;

namespace MyGame
{
    class Player: Controller
    {
        public PointF Location = new PointF(0, 0);

        public float WalkSpeed = 3;
        public float JumpForce = 10;

        private bool _isActiv = false;

        public Bitmap Sprite = Properties.Resources.Слой_1;

        public Player(Form form) : base(form)
        {
            Sprite = Properties.Resources.Слой_1;
        }

        public void Start()
        {
            _isActiv = true;
            new Thread(new ThreadStart(() => { while (_isActiv) Update(); })).Start();
        }

        public override void Left()
        {
            Location.X -= 10;
            Thread.Sleep(1);
        }

        public override void Right()
        {
            Location.X += 10;
            Thread.Sleep(1);
        }

        public override void Down()
        {
            Location.Y += 10;
            Thread.Sleep(1);
        }

        public override void Up()
        {
            Location.Y -= 10;
            Thread.Sleep(1);
        }

        public void Update()
        {

        }
    }
}
