using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    public class IController : IItem
    {
        private bool _isActiv = false;
        public bool isPressLeft = false;
        public bool isPressRight = false;
        public bool isPressDown = false;
        public bool isPressUp = false;

        public List<IElement> Elements = new List<IElement>();

        public bool isActiv { get; set; }

        public IController(Form form)
        {
            form.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Left && !isPressLeft)
                    isPressLeft = true;
                if (e.KeyCode == Keys.Right && !isPressRight)
                    isPressRight = true;
                if (e.KeyCode == Keys.Up && !isPressUp)
                    isPressUp = true;
                if (e.KeyCode == Keys.Down && !isPressDown)
                    isPressDown = true;
            };
            form.KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Left)
                    isPressLeft = false;
                if (e.KeyCode == Keys.Right)
                    isPressRight = false;
                if (e.KeyCode == Keys.Up)
                    isPressUp = false;
                if (e.KeyCode == Keys.Down)
                    isPressDown = false;
            };
            form.Paint += OnPaint;
            form.FormClosing += (s, e) =>  Stop();
        }

        public virtual void Start()
        {
            this._isActiv = true;
            new Thread(() => { while (_isActiv) Update(); }).Start();
        }

        public void Stop()
        { 
            _isActiv = false;
            foreach (var e in Elements)
                e.Stop();
        }

        public virtual void Update()
        {
            foreach (var e in Elements)
                if (e.isActiv)
                    e.Update();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Red);
            foreach (var el in Elements)
                e.Graphics.DrawImage(el.Sprite, el.Location);
        }
    }
}
