using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static MyGame.ICollider;

namespace MyGame
{
    public interface ICollider : IOject
    {
        public Dictionary<Sect, bool> CanMove { get; set; }

        public enum Sect
        {
            Left,
            Rigth,
            Top,
            Bottom
        }
    }

    class Collider
    {
        private static List<ICollider> _listCollider = new List<ICollider>();
        public static void Add(ICollider collider) => _listCollider.Add(collider);

        public static bool OnTriger(ICollider box)
        {
            var myBox = box.BoxElement;

            bool Intersection = false;
            var CanMove = new Dictionary<Sect, bool>
            {
                { Sect.Left, true },
                { Sect.Bottom, true },
                { Sect.Rigth, true },
                { Sect.Top, true }
            };

            foreach (var colider in _listCollider.Select(s=> s.BoxElement).Where(c => c != myBox))
                if (colider.IntersectsWith(myBox))
                {
                    if (CanMove[Sect.Top] && myBox.Top - colider.Bottom > -10)
                    {
                        CanMove[Sect.Top] = myBox.Top - colider.Bottom > 10
                               || colider.Right < myBox.Left || colider.Left > myBox.Right;
                        //if (!CanMove[Sect.Top])
                        //    box.Location = new PointF(box.Location.X, colider.Bottom);
                    }
                    if (CanMove[Sect.Bottom] && colider.Top - myBox.Bottom  > -10)
                    {
                        CanMove[Sect.Bottom] = colider.Top - myBox.Bottom > 10
                                || colider.Right < myBox.Left || colider.Left > myBox.Right;
                    }
                    if (CanMove[Sect.Rigth] && colider.Left - myBox.Right > -10)
                    {
                        CanMove[Sect.Rigth] = colider.Left - myBox.Right > 10
                                || colider.Bottom < myBox.Top || colider.Top > myBox.Bottom;
                    }
                    if (CanMove[Sect.Left] && myBox.Left - colider.Right > -10)
                    {
                        CanMove[Sect.Left] = myBox.Left - colider.Right > 10
                                || colider.Bottom < myBox.Top || colider.Top > myBox.Bottom;
                    }
                    Intersection = true;
                }
            box.CanMove = CanMove;
            return Intersection;
        }
    }
}
