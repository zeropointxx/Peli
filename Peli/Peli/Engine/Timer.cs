using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Peli.Engine
{
    class Timer
    {
        float currentTime, delay;
        public float Delay
        {
            get{
                return delay * 1000f;
            }
            set{
                delay = value*0.001f;
            }
        }
        public Timer(float delayMilliseconds)
        {
            delay = delayMilliseconds * 0.001f;
            currentTime = delay;
        }
        public bool Update(float deltatime)
        {
            currentTime -= deltatime;
            if (currentTime < 0)
            {
                currentTime = delay;
                return true;
            }

            return false;
        }
    }
}
