using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    public abstract class IController : ActivElement
    {
        public static void AddElement(ActivElement a)
            => queueActivElement.Enqueue(a);

        protected Form control;
        private List<ActivElement> Elements = new List<ActivElement>();
        private static Dictionary<Keys, bool> isPressKey;
        private static Queue<ActivElement> queueActivElement ;
        private static Queue<ActivElement> queueDeleteObject ; 

        public static void DeleteElement(IObject a)
        {
            if (a is ActivElement activ)
                queueDeleteObject.Enqueue(activ);
        }

        public static bool GetKey(Keys key)
        {
            if (isPressKey.ContainsKey(key))
                return isPressKey[key];
            isPressKey.Add(key, false);
            return false;
        }

        public IController(Form form)
        {
            queueActivElement = new Queue<ActivElement>();
            queueDeleteObject = new Queue<ActivElement>();
            isPressKey = new Dictionary<Keys, bool>();
            Collider.Update();

            control = form;
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
                    Thread.Sleep(5);
                    Update();
                }
            }).Start();
        }

        private void Updated()
        { 
            lock (Elements)
            {
                foreach (var e in Elements)
                    if (e.isActiv)
                        e.Update();
            }
            control.Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            //e.Graphics.DrawImage(Properties.Resources.fon, 0, 0);
            lock (Elements)
            {
                while (queueActivElement.Count != 0)
                    Elements.Add(queueActivElement.Dequeue());
                while (queueDeleteObject.Count != 0)
                    Elements.Remove(queueDeleteObject.Dequeue());

                foreach (var el in Elements)
                    if (el is IObject ob && !queueDeleteObject.Contains(el))
                    {
                        e.Graphics.DrawImage(ob.Sprite, ob.BoxElement);
                    }
            }
        }
    }
}
