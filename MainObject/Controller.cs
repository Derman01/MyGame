using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    class Controller : IController
    {
        private Hero _player  = new Hero();
        private Hero2 block1 = new Hero2 { Location = new PointF(100, 100) };
        private Hero2 block2 = new Hero2 { Location = new PointF(250, 100) };

        public Controller(Form form) : base(form)
        {
            Elements.Add(_player);
            Elements.Add(block1);
            Elements.Add(block2);

            EventStart += Started;
            EventUpdate += Updated;
        }

        private void Started()
        {
            _player.Start();
        }

        private void Updated()
        {
            if (GetKey(Keys.Right))
                _player.Right();
            if (GetKey(Keys.Down))
                _player.Down();
            if (GetKey(Keys.Left))
                _player.Left();
            if (GetKey(Keys.Up))
                _player.Up();
        }
    }
}

