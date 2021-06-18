 using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    public partial class Program: Form
    {
        public bool isActiv = true;

        private Controller controller;

        public Program()
        {

            FormBorderStyle = FormBorderStyle.None;

            DoubleBuffered = true;
            this.WindowState = FormWindowState.Maximized;
            controller = new Controller(this);
            controller.Start();
            controller.EventStop += () => 
            {
                isActiv = false; 
            };
            Paint += (s, e) => {
                if (!isActiv)
                    Close();
            };
            FormClosing += (s, e) => controller.Stop();
            FormClosed += (s, e) => isActiv = false;
        }


        public static void Main()
        {
            Application.Run(new OpenForm());
        }
    }
}
