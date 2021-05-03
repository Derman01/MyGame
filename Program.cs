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
            Controls.Add(Input.Keypad);

            Input.Activ();
            player = new Player(this);


            Paint += Program_Paint;

            var timer = new System.Windows.Forms.Timer();
            timer.Tick += (s, e) => Invalidate();
            timer.Interval = 40;
            timer.Start();
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(507, 276);
            this.Name = "Program";
            this.ResumeLayout(false);

        }
    }
}
