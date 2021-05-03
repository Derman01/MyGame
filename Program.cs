 using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    public partial class Program: Form
    {
        public bool isActiv = true;

        public Program(int width = 1000, int heigth = 500)
        {
            DoubleBuffered = true;
            this.Width = width; this.Height = heigth;
            new Thread(() => { while ( isActiv) Invalidate(); }).Start();
            var controler = new Controller(this);
            controler.Start();
            FormClosed += (s, e) => isActiv = false;
        }


        public static void Main()
        {
            Application.Run(new Program());
        }
    }
}
