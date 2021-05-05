using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    public abstract class IController : AElement
    {
        public List<AElement> Elements = new List<AElement>();

        private Dictionary<Keys, bool> isPressKey = new Dictionary<Keys, bool>();

        public bool GetKey(Keys key)
        {
            if (isPressKey.ContainsKey(key))
                return isPressKey[key];
            isPressKey.Add(key, false);
            return false;
        }

        public override void Start()
        {
            base.Start();
            _time.Start();
            new Thread(() => 
            {
                while (isActiv)
                {
                    Update();
                    Thread.Sleep(20);
                }
            }).Start();
        }


        public override void Update()
        {
            base.Update();
            foreach (var e in Elements)
                if(e.isActiv)
                    e.Update();
        }

        public IController(Form form)
        {
            form.KeyDown += (s, e) =>
            {
                if (!isPressKey.ContainsKey(e.KeyCode))
                    isPressKey.Add(e.KeyCode, true);
                else isPressKey[e.KeyCode] = true;
            };
            form.KeyUp += (s, e) =>
            {
                isPressKey[e.KeyCode] = false;
            };
            form.Paint += OnPaint;
            form.FormClosing += (s, e) =>  Stop();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Red);
            foreach (var el in Elements)
                if (el is IObject ob)
                e.Graphics.DrawImage(ob.Sprite, ob.Location);
        }
    }
}
