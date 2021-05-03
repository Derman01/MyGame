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
    class Player
    {
        public PointF Location = new PointF(0, 0);

        public float WalkSpeed = 3;
        public float JumpForce = 10;

        private bool _isActiv = false;

        public Bitmap Sprite;

        Label l = new Label {Size = new Size(50, 30), Text = "0"};
        Form form;

        public Player(Program form)
        {
            this.form = form;
            form.Controls.Add(l);
            Sprite = Properties.Resources.Слой_1;

            Input.AddEvent(Keys.A, Left);
            Input.AddEvent(Keys.D,  Right);
        }

        private void Left()
        {
            Location.X -= 10;
            Thread.Sleep(1000);
        }

        private void Right()
        {
            Location.X += 10;
            Thread.Sleep(100);
        }

        public void Start()
        {
            _isActiv = true;
            new Thread(new ThreadStart(() => { while (_isActiv) Update(); })).Start();
        }

        public void Update()
        {

        }
    }
}
