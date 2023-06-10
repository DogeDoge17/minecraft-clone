using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.Common
{
    public class Vertex
    {
        public Vector3 position = new Vector3(0, 0, 0);
        public Vector3 normal = new Vector3();
        public Vector2 texture = new Vector2();

        public bool active = true;

        public Vertex(Vector3 position, Vector3 normal, Vector2 texture)
        {
            this.position = position;
            this.normal = normal;
            this.texture = texture;
        }


        public float[] ToFloat()
        {
            float[] num = { position.X, position.Y, position.Z, normal.X, normal.Y, normal.Z };

            return num;
        }
    }

    public class VertexGroup
    {
        public List<Vertex> vertices = new List<Vertex>();

        public VertexGroup(List<Vertex> vertices)
        {
            this.vertices = vertices;
        }

        public float[] ToFloat()
        {
            List<float> num = new List<float>();

            foreach (Vertex vert in vertices)
            {
                if (vert.active)
                {
                    num.Add(vert.position.X);
                    num.Add(vert.position.Y);
                    num.Add(vert.position.Z);

                    num.Add(vert.normal.X);
                    num.Add(vert.normal.Y);
                    num.Add(vert.normal.Z);

                    num.Add(vert.texture.X);
                    num.Add(vert.texture.Y);
                }
                
            }
            // position.X, position.Y, position.Z, uv.X, uv.Y, uv.Z

            return num.ToArray();
        }

        public float[] ToFloat(Vector3 positionOffset)
        {
            List<float> num = new List<float>();

            foreach (Vertex vert in vertices)
            {
                if (vert.active)
                {
                    num.Add(vert.position.X + positionOffset.X);
                    num.Add(vert.position.Y + positionOffset.Y);
                    num.Add(vert.position.Z + positionOffset.Z);

                    num.Add(vert.normal.X);
                    num.Add(vert.normal.Y);
                    num.Add(vert.normal.Z);

                    num.Add(vert.texture.X);
                    num.Add(vert.texture.Y);
                }
                
            }
            // position.X, position.Y, position.Z, uv.X, uv.Y, uv.Z

            return num.ToArray();
        }
    }
}
