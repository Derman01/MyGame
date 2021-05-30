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
    public abstract class ActivElement
    {
        public bool isActiv = false;
        internal float deltaTime = 0;
        internal Time _time = new Time();

        internal event Action EventStart;
        internal event Action EventUpdate;
        internal event Action EventStop;

        public void Start()
        {
            isActiv = true;
            _time.Start();
            EventStart?.Invoke();
        }

        public void Update()
        {
            deltaTime = _time.deltaTime;
            _time.Restart();
            EventUpdate?.Invoke();
        }

        public void Stop()
        {
            isActiv = false;
            _time.Stop();
            EventStop?.Invoke();
        }
    }   
}
