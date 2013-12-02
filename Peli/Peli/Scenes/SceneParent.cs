using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Peli.Scenes
{
    class SceneParent
    {
        public bool Paused = false;
        public SceneParent()
        {
        }


        virtual public void Update(float dT)
        {
        }
        virtual public void Draw(float deltaTime)
        {
        }
    }
}
