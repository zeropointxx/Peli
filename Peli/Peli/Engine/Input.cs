using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Peli.Engine
{
    class Input
    {
        static public string lastkeys = "";
        static KeyboardState k_state, k_state_old;
        static MouseState m_state, m_state_old;

        public static void UpdateState()
        {
            checkCheat();
            k_state_old = k_state;
            k_state = Keyboard.GetState();
            m_state_old = m_state;
            m_state = Mouse.GetState();
        }
        public static void checkCheat()
        {
            if (lastkeys.Count() > 30)
                Console.WriteLine("sad");
            Keys[] cheats = { Keys.T, Keys.H, Keys.E, Keys.R, Keys.I, Keys.S, Keys.N, Keys.O, Keys.Space, Keys.U, Keys.F, Keys.L, Keys.V };
            string[] strings = { "T", "H", "E", "R", "I", "S", "N", "O", " ", "U", "F", "L", "V" };
            for (int i = 0; i < cheats.Count(); i++)
            {
                if (IsKeyPressed(cheats[i]))
                    lastkeys += strings[i];
            }
        }
        public static Boolean IsKeyDown(Keys key)
        {
            return k_state.IsKeyDown(key);
        }
        public static Boolean IsKeyUp(Keys key)
        {
            return k_state.IsKeyUp(key);
        }
        public static bool IsKeyPressed(Keys key)
        {
            return k_state.IsKeyDown(key) && k_state_old.IsKeyUp(key);
        }
        public static bool IsKeyRealeased(Keys key)
        {
            return k_state.IsKeyUp(key) && k_state_old.IsKeyDown(key);
        }

        //mouse buttons
        public static Boolean IsButtonDown()
        {
            return m_state.LeftButton == ButtonState.Pressed;
        }
        public static Boolean IsButtonUp()
        {
            return m_state.LeftButton == ButtonState.Released;
        }
        public static bool IsButtonPressed()
        {
            return IsButtonDown() && m_state_old.LeftButton == ButtonState.Released;
        }
        public static bool IsButtonRealeased()
        {
            return IsButtonUp() && m_state_old.LeftButton == ButtonState.Pressed;
        }
        public static Vector2 MousePosition 
        {
            get
            {
                return new Vector2(m_state.X, m_state.Y);
            }
        }
    }
}
