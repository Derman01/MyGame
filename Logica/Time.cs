using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MyGame
{
    class Time
    {
        public float deltaTime
        {
            get => (float)watch.ElapsedMilliseconds / 1000;
        }

        Stopwatch watch = new Stopwatch();

        public void Restart() => watch.Restart();

        public void Start() => watch.Start();

        public void Stop() => watch.Stop();
    }
}
