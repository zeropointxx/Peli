using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Peli.Engine;
using Microsoft.Xna.Framework.Input;

namespace Peli.Objects
{
    public class Player:ObjectParent
    {
       public float _hp
       {
           get;
           private set;
       }
        public Player(Texture2D texture, Vector2 position, float speed)
            : base(texture, position, speed)
        {
            _hp = 28;
        }
        public void Update(float deltaTime)
        {
            base.Update(deltaTime);
            if(!this.IsDead){
            if (Input.IsKeyDown(Keys.D1))
            _speed = 1;
            if (Input.IsKeyDown(Keys.D2))
                _speed = 3;
            if (Input.IsKeyDown(Keys.D3))
                _speed = 5;

            if (Input.IsKeyDown(Keys.D))
                _position += Vector2.UnitX * _speed;
            if (Input.IsKeyDown(Keys.S))
                _position += Vector2.UnitY * _speed;
             if (Input.IsKeyDown(Keys.A))
                 _position -= Vector2.UnitX * _speed;
             if (Input.IsKeyDown(Keys.W))
                 _position -= Vector2.UnitY * _speed;


             if (_position.X < 0)
             {
                 _position.X = 0;
             }
             if (_position.Y < 0)
             {
                 _position.Y = 0;
             }}

             if (_position.X > Game1.screen_size.Width - _sprite.texture.Bounds.Width/2)
                 _position.X = Game1.screen_size.Width - _sprite.texture.Bounds.Width/2;
             if (_position.Y > Game1.screen_size.Height - _sprite.texture.Bounds.Height/2)
                 _position.Y = Game1.screen_size.Height - _sprite.texture.Bounds.Height/2;
            
        }
        public void Draw()
        {
            DrawSys.Draw(Resources.GetTexture("hp"), new Rectangle((int)_position.X - 15, (int)_position.Y - 20, (int)_hp, 4), Color.White);
            base.Draw();
        }
        public void decHp()
        {
            if (_hp - 7 > 0)
                _hp -= 7;
            else
            {
                IsDead = true;
            }
        }
    }
}
