using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace MyGame
{
    public class Animation : ActivElement
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

            EventUpdate += Updated;
        }

        private void Updated()
        {
            _currentIndexSprite = _currentIndexSprite + _speedAnimation * deltaTime;
            _player.Sprite = _sprite[(int)_currentIndexSprite % _sprite.Length];
        }
    }
}
