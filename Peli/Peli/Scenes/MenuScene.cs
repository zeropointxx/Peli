using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uppercut.Components;
using Microsoft.Xna.Framework;
using Peli.Engine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Peli.Menu;

namespace Peli.Scenes
{
    class MenuScene:SceneParent
    {
        Button button1;
        public MenuScene()
            :base()
        {
            button1 = new Button(Resources.GetTexture("boss_bullet"), new Vector2(400, 200));
            button1.onButtonPressed += onButtonPress;
        }


        public override void Update(float dT)
        {
            base.Update(dT);
            if (Input.IsKeyPressed(Keys.M))
            {
                SceneSys.CloseCurrentScene();
                SceneSys.PauseCurrentScene(false);
            }
            button1.Update(dT);
        }
        public override void Draw(float deltaTime)
        {
            DrawSys.DrawText("menu",Resources.GetFont("font"), new Vector2(100, 100), Color.White);
            button1.Draw();
        }
        void onButtonPress()
        {
            Console.WriteLine("Toimii nappula");
        }
    }
}
