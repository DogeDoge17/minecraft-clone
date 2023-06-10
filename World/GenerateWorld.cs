using MinecraftClone.Blocks;
using MinecraftClone.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;

namespace MinecraftClone.World
{
    public class GenerateWorld
    {
        public static void Generate()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 1; y++)
                {
                    for (int z = 0; z < 1; z++)
                    {
                        Main.AddBlock(new Dirt(new Vector3(x , y * -1, z * -1)));
                    }
                }
            }
        }

        public static void Generate(Vector3 amount)
        {
            for (int x = 0; x < amount.X; x++)
            {
                for (int y = 0; y < amount.Y; y++)
                {
                    for (int z = 0; z < amount.Z; z++)
                    {
                        Main.AddBlock(new Dirt(new Vector3(x , y * -1, z * -1)));
                    }
                }
            }
        }

    }
}
