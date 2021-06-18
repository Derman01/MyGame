using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    public class Animator: ActivElement
    {
        private string _currentNameAnimation;

        private Dictionary<string, Animation> _animations = new Dictionary<string, Animation>();

        public void Play(string animation = null)
        {
            if (isActiv == false)
                isActiv = true;

            if (_currentNameAnimation == null)
                _currentNameAnimation = animation;
            else
                _animations[_currentNameAnimation].Stop();

            _currentNameAnimation = animation;
            _animations[animation].Start();
        }        

        public void AddAnimation(Animation animation)
            => _animations.Add(animation.name, animation);

        public Animator()
        {
            EventUpdate += Updated;
        }


        private void Updated()
        {
            _animations[_currentNameAnimation].Update();
        }
    }
}
