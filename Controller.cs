using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    class Controller
    {
        public Controller(Form form)
        {
            form.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Left && !_isPressLeft)
                    new Thread(() => { _isPressLeft = true; while (_isPressLeft) Left(); }).Start();
                if (e.KeyCode == Keys.Right && !_isPressRight)
                    new Thread(() => { _isPressRight = true; while (_isPressRight) Right(); }).Start();
                if (e.KeyCode == Keys.Up && !_isPressUp)
                    new Thread(() => { _isPressUp = true; while (_isPressUp) Up(); }).Start();
                if (e.KeyCode == Keys.Down && !_isPressDown)
                    new Thread(() => { _isPressDown = true; while (_isPressDown) Down(); }).Start();
            };
            form.KeyUp += (s, e) =>
            {
                if (e.KeyCode == Keys.Left)
                    _isPressLeft = false;
                if (e.KeyCode == Keys.Right)
                    _isPressRight = false;
                if (e.KeyCode == Keys.Up)
                    _isPressUp = false;
                if (e.KeyCode == Keys.Down)
                    _isPressDown = false;
            };
        }

        private bool _isPressLeft = false;
        private bool _isPressRight = false;
        private bool _isPressDown = false;
        private bool _isPressUp = false;

        public virtual void Left() => throw new NotImplementedException();
        public virtual void Right() => throw new NotImplementedException();
        public virtual void Up() => throw new NotImplementedException();
        public virtual void Down() => throw new NotImplementedException();
    }    
 }

