using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Peli.Engine;
using Peli.Scenes;

namespace Peli.Objects
{
    public class Boss : ObjectParent
    {
        bool goingup = false;
        int hp = 100;
        Timer shoot_timer;
        Random random = new Random();
        public Boss(Texture2D texture, Vector2 position, float speed)
            : base(texture, position, speed)
        {
            shoot_timer = new Timer(400);
        }
        public void Update(float deltaTime)
        {
            if (_position.X > Game1.screen_size.Width - 20)
                _position += new Vector2(-1, 0) * _speed * deltaTime;
            else
            {
                if (goingup)
                {
                    _position.Y-= 3;
                    if (_position.Y < 0)
                        goingup = false;
                }

                else
                {
                    if (_position.Y > Game1.screen_size.Height)
                        goingup = true;
                    else
                        _position.Y += 3;
                }
               
            }
            if (shoot_timer.Update(deltaTime))
            {
                GameScene.boss_bullets.Add(new BossBullet(Resources.GetTexture("boss_bullet"), _position, 200));
                shoot_timer.Delay = random.Next(300) + 100;
            }
            base.Update(deltaTime);
        }
        public void Draw()
        {
            base.Draw();
        }
        public void losehealth()
        {
            if (hp - 20 > 0)
                hp -= 20;
            else
            {
                IsDead = true;
            }
        }
    }
} 
