using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    public partial class OpenForm : Form
    {
        public OpenForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            button1.MouseMove += MouseMove;
            button1.MouseLeave += MouseLeave;
            button2.MouseMove += MouseMove;
            button2.MouseLeave += MouseLeave;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var main = new Program();
            main.ShowDialog();
            Visible = true;
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.Transparent;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            (sender as Button).BackColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
