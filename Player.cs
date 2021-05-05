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
    class Hero: Player
    {
        private MoveState _moveState = MoveState.Right;

        internal override void Started()
        {
            Sprite = new Bitmap(Properties.Resources.Слой_1);

            _animator.AddAnimation(new Animation(this, "Right", 20,
                new Bitmap(Properties.Resources._1),
                new Bitmap(Properties.Resources._2),
                new Bitmap(Properties.Resources._3),
                new Bitmap(Properties.Resources._4)));
            _animator.AddAnimation(new Animation(this, "Left", 5,
                new Bitmap(Properties.Resources._1),
                new Bitmap(Properties.Resources._2),
                new Bitmap(Properties.Resources._3),
                new Bitmap(Properties.Resources._4)));
            _animator.Play("Right");

            Con.Consondeb();
        }

        public void Left()
        {
            if (!(_moveState is MoveState.Left))
            {
                _animator.Play("Left");
                _moveState = MoveState.Left;
            }
               
            _location.X -= 100 * deltaTime;
        }

        public void Right()
        {
            if (!(_moveState is MoveState.Right))
            {
                _animator.Play("Right");
                _moveState = MoveState.Right;
            }
            _location.X += 100 * deltaTime;
        } 

        public void Down()
        {
           _location.Y += 120 * deltaTime ;
        }

        public void Up()
        {
            _location.Y -= 150 * deltaTime;
        }

        internal override void Updated(){}

        internal override void Stoped(){}

        enum MoveState
        {
            Right,
            Left
        }
    }

    public abstract class Player : AElement, IObject
    {
        public Bitmap Sprite { get; set; }

        internal PointF _location = new PointF(0, 0);
        public PointF Location { get => _location; set{ _location = value;   } }

        internal Animator _animator { get; set; } = new Animator();

        public override void Update()
        {
            base.Update();
            _animator.Update();
        }
    }
}
