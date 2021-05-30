using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    public abstract class IController : ActivElement
    {
        public List<ActivElement> Elements = new List<ActivElement>();

        private Dictionary<Keys, bool> isPressKey = new Dictionary<Keys, bool>();

        public bool GetKey(Keys key)
        {
            if (isPressKey.ContainsKey(key))
                return isPressKey[key];
            isPressKey.Add(key, false);
            return false;
        }

        public IController(Control form)
        {
            form.KeyDown += (s, e) =>
            {
                if (!isPressKey.ContainsKey(e.KeyCode))
                    isPressKey.Add(e.KeyCode, true);
                else isPressKey[e.KeyCode] = true;
            };
            form.KeyUp += (s, e) => isPressKey[e.KeyCode] = false;

            form.Paint += OnPaint;

            EventStart += Started;
            EventUpdate += Updated;
        }

        private void Started()
        {
            new Thread(() => 
            {
                while (isActiv)
                {
                    Thread.Sleep(20);
                    Update();
                }
            }).Start();
        }

        private void Updated()
        {
            foreach (var e in Elements)
                if (e.isActiv)
                    e.Update();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Red);
            foreach (var el in Elements)
                if (el is IOject ob)
                    e.Graphics.DrawImage(ob.Sprite, ob.BoxElement);
        }
    }
}
