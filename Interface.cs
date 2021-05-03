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
    public interface IItem
    {
        public bool isActiv { get; set; }
        public void Update();
        public void Start();
        public void Stop();
    }

    public interface IElement: IItem
    {
        public Bitmap Sprite { get; }
        public PointF Location { get; }
    }    
}
