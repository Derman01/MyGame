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

        public Controller(Form form) : base(form)
        {
            Elements.Add(_player);
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

