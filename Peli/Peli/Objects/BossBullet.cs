using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Peli.Objects
{
    public class BossBullet:ObjectParent
    {
            public BossBullet(Texture2D texture, Vector2 position, float speed)
            : base(texture, position, speed)
        {
        }
        public void Update(float deltaTime)
        {
            _position += new Vector2(-3,0) * _speed * deltaTime;
            base.Update(deltaTime);
        }
        public void Draw()
        {
            base.Draw();
        }
    }
}
