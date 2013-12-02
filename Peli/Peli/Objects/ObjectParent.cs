using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Peli.Engine;

namespace Peli.Objects
{
    public class ObjectParent
    {

       protected Vector2 _position;
        protected float _speed;
        protected Sprite _sprite;
        public Vector2 Position { get { return _position; } }
        public Rectangle CollisionRect { get; private set; }
        public bool IsDead { get; set; }
        public ObjectParent(Texture2D texture, Vector2 position, float speed)
        {
            _sprite = new Sprite(texture);
            _position = position;
            _speed = speed;
        }
        public void Update(float deltaTime)
        {
            _sprite.Update(deltaTime);
            CollisionRect = new Rectangle((int)_position.X, (int)_position.Y, 
                _sprite.FrameWidth, _sprite.Height);
        }
        public void Draw()
        {
            _sprite.Draw(_position);
        }
    }
}
