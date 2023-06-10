using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.Common
{
    public class UpdateMe
    {
        public static float deltaTime;

        public UpdateMe()
        {
            Main.AddUpdate(this);
        }


        public virtual void Update(FrameEventArgs time)
        {
            deltaTime = (float)time.Time;
        }

        public virtual void Draw(FrameEventArgs time)
        {

        }

        public virtual void LateUpdate(FrameEventArgs time)
        {

        }
    }
}