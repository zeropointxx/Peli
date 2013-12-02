using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Peli.Engine;

namespace Peli.Objects
{
    public class Enemy:ObjectParent
    {
               public Enemy(Texture2D texture, Vector2 position, float speed)
            : base(texture, position, speed)
        {
            _sprite = new Sprite(Resources.GetTexture("enemy"),32,32,4,200);
        }
        public void Update(float deltaTime)
        {
            _position += new Vector2(-1,0) * _speed * deltaTime;
            base.Update(deltaTime);
        }
        public void Draw()
        {
            base.Draw();
        }
    }
}
