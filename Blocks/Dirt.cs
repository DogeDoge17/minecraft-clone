using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.Blocks
{
    public class Dirt : Block
    {
        public Dirt(Vector3 position)
        {
            this.position = position;
        }

        public Dirt()
        {
        }

        public override void Draw(FrameEventArgs time)
        {
            base.Draw(time);
        }

        public override void Update(FrameEventArgs time)
        {
      
            
            base.Update(time);
        }

    }
}
