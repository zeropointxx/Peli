using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Peli.Engine;

namespace Peli.Menu
{
    public class Button
    {

       protected Vector2 _position;
        protected Sprite _sprite;
        public Action onButtonPressed;
        public Vector2 Position { get { return _position; } }
        public Rectangle CollisionRect { get; private set; }
        public Button(Texture2D texture, Vector2 position)
        {
            _sprite = new Sprite(texture);
            _position = position;
        }
        public void Update(float deltaTime)
        {
            _sprite.Update(deltaTime);
            CollisionRect = new Rectangle((int)(_position.X - _sprite.FrameWidth *0.5), (int)(_position.Y - _sprite.FrameHeight * 0.5), 
                _sprite.FrameWidth, _sprite.FrameHeight);
            if (Input.IsButtonPressed())
            {
                if (CollisionRect.Contains((int)Input.MousePosition.X,
                    (int)Input.MousePosition.Y))
                {
                    if (onButtonPressed != null)
                    {
                        onButtonPressed();
                    }
                }
            }
        }
        public void Draw()
        {
            _sprite.Draw(_position);
        }
    }
}
