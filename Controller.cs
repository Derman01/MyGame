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
        Player player;

        public Controller(Form form) : base(form)
        {
            player = new Player();
            Elements.Add(player);
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            if (isPressRight)
                player.Right();
            if (isPressDown)
                player.Down();
            if (isPressLeft)
                player.Left();
            if (isPressUp)
                player.Up();
        }
    }


}

