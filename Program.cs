 using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    public partial class Program: Form
    {
        Player player;

        public Program(int width = 1000, int heigth = 500)
        {
            DoubleBuffered = true;
            this.Width = width; this.Height = heigth;

            player = new Player(this);
            Paint += Program_Paint;


            new Thread(() => { while (true) Invalidate(); }).Start();
        }


        private void Program_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Red);
            e.Graphics.DrawImage(player.Sprite, player.Location);
        }

        public static void Main()
        {
            Application.Run(new Program());
        }
    }
}
