using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    class Animator: AElement
    {
        private string _currentNameAnimation;
        private Dictionary<string, Animation> _animations = new Dictionary<string, Animation>();

        public void Play(string animation = null)
        {
            if (_currentNameAnimation == null)
                _currentNameAnimation = animation;
            else
            {
                _animations[_currentNameAnimation].Stop();
            }
            _currentNameAnimation = animation;
            _animations[animation].Start();
        }        

        public void AddAnimation(Animation animation)
            => _animations.Add(animation.name, animation);

        internal override void Started()
        {
        }

        internal override void Updated()
        {
            _animations[_currentNameAnimation].Update();
        }

        internal override void Stoped()
        {
        }
    }
    
    class Animation: AElement
    {
        private Player _player;
        private float _currentIndexSprite = 0;
        private Bitmap[] _sprite;
        private int _speedAnimation; // кадров в секунду

        public string name;

        public Animation(Player player, string name, int speedAnimation = 1, params Bitmap[] sprites)
        {
            _sprite = sprites;
            _speedAnimation = speedAnimation;
            _player = player;
            this.name = name; 
        }

        internal override void Updated()
        {
            _currentIndexSprite = _currentIndexSprite + _speedAnimation * deltaTime;
            _player.Sprite = _sprite[(int)_currentIndexSprite % _sprite.Length];
        }
    

        internal override void Started()
        {
        }

        internal override void Stoped()
        {
        }
    }

    class Time
    {
        public float deltaTime
        {
            get => (float)watch.ElapsedMilliseconds / 1000;            
        }

        Stopwatch watch = new Stopwatch();

        public void Restart() => watch.Restart();

        public void Start()
        {
            watch.Start();
        }
    }
}
