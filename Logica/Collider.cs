using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyGame
{
    public class Collider
    {
        private static List<IObject> _listCollider = new List<IObject>();

        public static void Update()
        {
            _listCollider = new List<IObject>();
        }

        public static void Add(IObject collider) 
        {
            lock(_listCollider)
                _listCollider.Add(collider);
        }
        public static void Delete(IObject collider) 
        {
            lock(_listCollider)
                _listCollider.Remove(collider);
        } 

        public static bool OnTrigger<T>(IObject obj, out T item) where T : IObject, new()
        {
            item = default;
            var a = new T();
            lock (_listCollider)
            {
                foreach (var i in _listCollider)
                    if (a.GetType() == i.GetType())
                        if (obj.BoxElement.IntersectsWith(i.BoxElement))
                        {
                            item = (T)i;
                            return true;
                        }
            }
            return false;
        }
    }
}
