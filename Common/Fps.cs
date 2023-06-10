using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.Common
{
    public class Fps : UpdateMe
    {
        int frameCounter = 0;
        float timeCounter = 0.0f;
        float lastFramerate = 0.0f;
        public float refreshTime = 0.5f;



        public override void Update(FrameEventArgs time)
        {
            //        Debug.Log(Time.deltaTime);

            if (timeCounter < refreshTime)
            {
                timeCounter += (float)time.Time;
                frameCounter++;
            }
            else
            {
                //This code will break if you set your m_refreshTime to 0, which makes no sense.
                lastFramerate = (float)frameCounter / timeCounter;
                frameCounter = 0;
                timeCounter = 0.0f;
            }
        }

        public override void LateUpdate(FrameEventArgs time)
        {
//            Debug.WriteLine("Fps: " + Math.Floor(lastFramerate));
        }

    }
}
