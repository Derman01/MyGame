using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    class Animator
    {
        private string _currentNameAnimation;

        private Dictionary<string, Animation> _animations;

        public void Play(string animation)
        {
            _animations[_currentNameAnimation]?.Start();
            _currentNameAnimation = animation;
            _animations[animation].Start();
        }
    }
    
    class Animation
    {
        private bool _isActiv = false;

        private Time _time = new Time();

        public int speedAnimation;
        private Player _player;

        private int _currentIndexSprite = 0;
        private Bitmap[] _sprite;

        public Animation(Player player,int speedAnimation = 1000, params Bitmap[] sprites)
        {
            _sprite = sprites;
            this.speedAnimation = speedAnimation;
            this._player = player;
        }

        public void Start()
        {
            _time.Start();
            _isActiv = true;
            Parallel.Invoke(Update);
        }

        private void Update()
        {
            while (_isActiv)
            {
                if (_time.deltaTime > speedAnimation)
                {
                    Next();
                }
            }
        }

        private void Next()
        {
            _currentIndexSprite = (_currentIndexSprite + 1) % _sprite.Length;
            _player.Sprite = _sprite[_currentIndexSprite];
        }

        private void Stop()
        {

        }
    }

    class Time
    {
        public long deltaTime
        {
            get
            {
                var res = watch.ElapsedMilliseconds;
                watch.Stop();
                watch.Start();
                return res;
            }
        }

        Stopwatch watch = new Stopwatch();

        public Time()
        {

        }

        public void Start()
        {
            watch.Start();
        }
    }

    public static class Input
    {
        public static void Activ()
        {
            Keypad.KeyUp += (s, key) =>
            {
                if (activKeys.ContainsKey(key.KeyCode))
                    activKeys[key.KeyCode] = false;
            };
        }

        public static void AddEvent(Keys key, Action metod)
        {
            if (!activKeys.ContainsKey(key))
            {
                activKeys.Add(key, false);
                Keypad.KeyDown += (s, key) =>
                {
                    if (activKeys.ContainsKey(key.KeyCode) && !activKeys[key.KeyCode])
                         MakeMetod(key.KeyCode, metod);
                 };           
            }                        
        }

        private static void MakeMetod(Keys key, Action metod)
        {
            new Thread(new ThreadStart(
                   () => {
                       activKeys[key] = true;
                       while (activKeys[key])
                           metod();
                   }
                   )).Start();
        }

        public static Control Keypad = new  Control();
        
        private static Dictionary<Keys, bool> activKeys = new Dictionary<Keys, bool>();
    }
}
