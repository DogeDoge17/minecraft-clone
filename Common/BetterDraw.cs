using MinecraftClone.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;

namespace MinecraftClone.Common
{
    public class BetterDraw
    {
        public static void Draw(float[] vertices, ref Shader shader, ref Texture texture, ref Camera camera, ref int model, Vector3 position = new Vector3(), float scale = 1f, float angle = 0)
        {
            Draw(ref vertices, ref shader, ref texture, ref camera, ref model, position, scale = 1f, angle = 0);
        }

        public static void Draw(float[] vertices, ref Shader shader, Texture texture, ref Camera camera, ref int model, Vector3 position = new Vector3(), float scale = 1f, float angle = 0)
        {
            Draw(ref vertices, ref shader, ref texture, ref camera, ref model, position, scale = 1f, angle = 0);
        }


        public static void Draw(ref float[] vertices, ref Shader shader, ref Texture texture, ref Camera camera, ref int model, Vector3 position = new Vector3(), float scale = 1f, float angle = 0)
        {
            

            shader.Use();

            GL.BindVertexArray(model);

            GL.BindBuffer(BufferTarget.ArrayBuffer, model);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.DynamicDraw);

            GL.BindVertexArray(model);

            
            shader.SetMatrix4("view", camera.GetViewMatrix());
            shader.SetMatrix4("projection", camera.GetProjectionMatrix());

            
            if (texture != null)
            {
                shader.SetMatrix4("model", Matrix4.Identity);
                shader.SetVector3("viewPos", camera.Position);
                texture.Use(TextureUnit.Texture0);
                shader.SetVector3("material.diffuse", new Vector3(1.0f, 0.5f, 0.31f));
                shader.SetVector3("material.specular", new Vector3(0.5f, 0.5f, 0.5f));
                shader.SetFloat("material.shininess", 100);
            }

            Matrix4 modelOffset = Matrix4.CreateTranslation(position);

            modelOffset = modelOffset * Matrix4.CreateFromAxisAngle(new Vector3(1.0f, 0.3f, 0.5f), angle);
            shader.SetMatrix4("model", modelOffset);

            GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Length);

        }
    }
}