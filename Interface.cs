using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public abstract class AElement
    {
        public bool isActiv = false;
        internal float deltaTime = 0;
        internal Time _time = new Time();

        internal abstract void Started();
        public virtual void Start()
        {
            isActiv = true;
            _time.Start();
            Started();
            //new Thread(() => { while (isActiv) Update(); }).Start();
        }

        internal abstract void Updated();
        public virtual void Update()
        {
            deltaTime = _time.deltaTime;
            _time.Restart();
            Updated();
        }


        internal abstract void Stoped();
        public virtual void Stop()
        {
            isActiv = false;
            Stoped();
        }
    }

    public interface IObject
    {
        public Bitmap Sprite { get; }
        public PointF Location { get; set; }
    }    
}
