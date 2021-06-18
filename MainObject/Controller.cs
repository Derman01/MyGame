using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    class Controller : IController
    {
        private Random rnd = new Random();
        private Hero _player  = new Hero() { Location = new PointF(600, 600)};
        private List<Enemy> enemies = new List<Enemy>();

        public int score = 0;
        private int limitCountEnemy => 1 + (score / 2);

        private float timeSpanEnemies = 2000;
        private float timeNow = 2000;

        public Controller(Form form) : base(form)
        {
            EventStart += Started;
            EventUpdate += Updated;
            EventUpdate += Updater;
            EventStop += Stoped;
            _player.EventDeleted += Stop;
            form.Paint += Form_Paint;
        }

        private void Stoped()
        {
            var str = "YOU  LOSE";
            Font drawFont = new Font("Roboto", 30);
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            var e = control.CreateGraphics();
            e.DrawString(str, drawFont, drawBrush, control.Width / 2 - 200, 200);
            e.DrawString($"Ваш Счет: {score}", new Font("Roboto", 20), drawBrush,control.Width / 2 - 100, 300);
            Thread.Sleep(2000);
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.White);

            e.Graphics.DrawString($"Счет: {score}", drawFont, drawBrush, 10, 10);
        }

        private void Updater()
        {
            timeNow += deltaTime * 1000;
            if (enemies.Count < limitCountEnemy)
            {
                if (timeNow >= timeSpanEnemies)
                {
                    CreateEnemy();
                    timeNow = 0;
                }
            }
        }

        private void CreateEnemy()
        {
            var enemy = new Enemy(new Random().Next(0, control.Width), -30);
            enemy.EventDeleted += () =>
            {
                enemies.Remove(enemy);
                CreateEnemy();
                score++;
                if (score % 3 == 0)
                   new Bonus(new Random().Next(0, control.Width), -30).Start();
            };
            enemy.Start();
            enemies.Add(enemy);
        }

        private void Started()
        {
            _player.Start();

            new Thread(()=> {
            for(var i = 0; i < limitCountEnemy; i++)
                {
                    Thread.Sleep(1000);
                    CreateEnemy();
                }               
            }).Start();
        }

        private void Updated()
        {
            if (GetKey(Keys.Space))
                _player.CreateBullet();
            if (GetKey(Keys.Right))
                _player.Right();
            if (GetKey(Keys.Down))
                _player.Down();
            if (GetKey(Keys.Left))
                _player.Left();
            if (GetKey(Keys.Up))
                _player.Up();
        }
    }
}

