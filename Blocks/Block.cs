using MinecraftClone.Common;
using OpenTK.Graphics.OpenGL4;
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
    public class Block : UpdateMe
    {

        public Vector3 position = new Vector3(0, 0, 0);

        public Texture texture;

        public int blockModel;

        public Shader blockShader;

        private VertexGroup _vertices = new VertexGroup(new List<Vertex>()
        {
            new Vertex(new Vector3( -0.5f, -0.5f, -0.5f),new Vector3( 0.0f,  0.0f, -1.0f), new Vector2(0.0f, 0.0f)),
            new Vertex(new Vector3(0.5f, -0.5f, -0.5f),new Vector3(0.0f,  0.0f, -1.0f), new Vector2(1.0f, 0.0f)),
            new Vertex(new Vector3(0.5f,  0.5f, -0.5f),new Vector3(0.0f,  0.0f, -1.0f), new Vector2(1.0f, 1.0f)),
            new Vertex(new Vector3(0.5f,  0.5f, -0.5f),new Vector3( 0.0f,  0.0f, -1.0f), new Vector2(1.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f,  0.5f, -0.5f),new Vector3(0.0f,  0.0f, -1.0f), new Vector2(0.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f, -0.5f, -0.5f),new Vector3(0.0f,  0.0f, -1.0f), new Vector2( 0.0f, 0.0f)),

            new Vertex(new Vector3(-0.5f, -0.5f,  0.5f),new Vector3(0.0f,  0.0f,  1.0f), new Vector2(0.0f, 0.0f)),
            new Vertex(new Vector3(0.5f, -0.5f,  0.5f),new Vector3(0.0f,  0.0f,  1.0f), new Vector2(1.0f, 0.0f)),
            new Vertex(new Vector3( 0.5f,  0.5f,  0.5f),new Vector3(0.0f,  0.0f,  1.0f) , new Vector2(1.0f, 1.0f)),
            new Vertex(new Vector3(0.5f,  0.5f,  0.5f),new Vector3(0.0f,  0.0f,  1.0f), new Vector2(1.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f,  0.5f,  0.5f),new Vector3(0.0f,  0.0f,  1.0f), new Vector2(0.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f, -0.5f,  0.5f),new Vector3(0.0f,  0.0f,  1.0f), new Vector2(0.0f, 0.0f)),

            new Vertex(new Vector3(-0.5f,  0.5f,  0.5f),new Vector3(-1.0f,  0.0f,  0.0f), new Vector2(1.0f, 0.0f)),
            new Vertex(new Vector3(-0.5f,  0.5f, -0.5f),new Vector3(-1.0f,  0.0f,  0.0f), new Vector2( 1.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f, -0.5f, -0.5f),new Vector3(-1.0f,  0.0f,  0.0f), new Vector2(0.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f, -0.5f, -0.5f),new Vector3(-1.0f,  0.0f,  0.0f), new Vector2(0.0f, 1.0f)),
            new Vertex(new Vector3( -0.5f, -0.5f,  0.5f),new Vector3(-1.0f,  0.0f,  0.0f), new Vector2(0.0f, 0.0f)),
            new Vertex(new Vector3(-0.5f,  0.5f,  0.5f),new Vector3(-1.0f,  0.0f,  0.0f), new Vector2(1.0f, 0.0f)),

            new Vertex(new Vector3(0.5f,  0.5f,  0.5f),new Vector3(1.0f,  0.0f,  0.0f), new Vector2(1.0f, 0.0f)),
            new Vertex(new Vector3( 0.5f,  0.5f, -0.5f),new Vector3(1.0f,  0.0f,  0.0f), new Vector2(1.0f, 1.0f)),
            new Vertex(new Vector3(0.5f, -0.5f, -0.5f),new Vector3(1.0f,  0.0f,  0.0f), new Vector2(0.0f, 1.0f)),
            new Vertex(new Vector3(0.5f, -0.5f, -0.5f),new Vector3(1.0f,  0.0f,  0.0f), new Vector2(0.0f, 1.0f)),
            new Vertex(new Vector3(0.5f, -0.5f,  0.5f),new Vector3(1.0f,  0.0f,  0.0f), new Vector2(0.0f, 0.0f)),
            new Vertex(new Vector3(0.5f,  0.5f,  0.5f),new Vector3(1.0f,  0.0f,  0.0f), new Vector2(1.0f, 0.0f)),

            new Vertex(new Vector3(-0.5f, -0.5f, -0.5f),new Vector3(0.0f, -1.0f,  0.0f), new Vector2(0.0f, 1.0f)),
            new Vertex(new Vector3(0.5f, -0.5f, -0.5f),new Vector3(0.0f, -1.0f,  0.0f), new Vector2(1.0f, 1.0f)),
            new Vertex(new Vector3(0.5f, -0.5f,  0.5f),new Vector3(0.0f, -1.0f,  0.0f), new Vector2(1.0f, 0.0f)),
            new Vertex(new Vector3(0.5f, -0.5f,  0.5f),new Vector3(0.0f, -1.0f,  0.0f), new Vector2(1.0f, 0.0f)),
            new Vertex(new Vector3(-0.5f, -0.5f,  0.5f),new Vector3(0.0f, -1.0f,  0.0f), new Vector2(0.0f, 0.0f)),
            new Vertex(new Vector3(-0.5f, -0.5f, -0.5f),new Vector3(0.0f, -1.0f,  0.0f), new Vector2(0.0f, 1.0f)),

            new Vertex(new Vector3(-0.5f,  0.5f, -0.5f),new Vector3(0.0f,  1.0f,  0.0f), new Vector2(0.0f, 1.0f)),
            new Vertex(new Vector3(0.5f,  0.5f, -0.5f),new Vector3(0.0f,  1.0f,  0.0f), new Vector2(1.0f, 1.0f)),
            new Vertex(new Vector3(0.5f,  0.5f,  0.5f),new Vector3(0.0f,  1.0f,  0.0f), new Vector2(1.0f, 0.0f)),
            new Vertex(new Vector3(0.5f,  0.5f,  0.5f),new Vector3(0.0f,  1.0f,  0.0f), new Vector2(1.0f, 0.0f)),
            new Vertex(new Vector3(-0.5f,  0.5f,  0.5f),new Vector3(0.0f,  1.0f,  0.0f), new Vector2(0.0f, 0.0f)),
            new Vertex(new Vector3(-0.5f,  0.5f, -0.5f),new Vector3(0.0f,  1.0f,  0.0f), new Vector2(0.0f, 1.0f)),
        });

        public bool neighborLeft, neighborRight, neighborTop, neighborBottom, neighborFront, neighborBack;

        string[] neighbors = new string[6];

        public Block()
        {
            //texture = Texture.LoadFromFile("textures/blocks/" + this.GetType().Name.ToLower() + ".png");
            texture = Texture.LoadFromFile("textures/blocks/bedrock.png");

            Main.AddBlock(this);

            blockShader = new Shader("Shaders/shader.vert", "Shaders/lighting.frag");

            blockModel = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, blockModel);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.ToFloat().Length/* BlockShaping.GetBlock(neighbors).Length*/ * sizeof(float), _vertices.ToFloat() /*BlockShaping.GetBlock(neighbors)*/, BufferUsageHint.StaticDraw);

            var positionLocation = blockShader.GetAttribLocation("aPos");
            GL.EnableVertexAttribArray(positionLocation);
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

            var normalLocation = blockShader.GetAttribLocation("aNormal");
            GL.EnableVertexAttribArray(normalLocation);
            GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

            var texCoordLocation = blockShader.GetAttribLocation("aTexCoords");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));

            //texture = Texture.LoadFromFile("Resources/container.png");
            //texture.Use(TextureUnit.Texture0);

            //blockShader.SetInt("texture0", 0);
        }

        public Block(Vector3 position)
        {
            this.position = position;


            Main.AddBlock(this);

            blockShader = new Shader("Shaders/shader.vert", "Shaders/lighting.frag");

            blockModel = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, blockModel);
            GL.BufferData(BufferTarget.ArrayBuffer, /*BlockShaping.GetBlock(neighbors).Length */_vertices.ToFloat().Length * sizeof(float), _vertices.ToFloat()/*BlockShaping.GetBlock(neighbors)*/, BufferUsageHint.StaticDraw);

            var positionLocation = blockShader.GetAttribLocation("aPos");
            GL.EnableVertexAttribArray(positionLocation);
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);

            var normalLocation = blockShader.GetAttribLocation("aNormal");
            GL.EnableVertexAttribArray(normalLocation);
            GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));

            var texCoordLocation = blockShader.GetAttribLocation("aTexCoords");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));
        }


        public override void Draw(FrameEventArgs time)
        {

            { //var _time = 0.0;
              //_time += 4.0 * time.Time;

                //GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                //GL.BindVertexArray(Main._vertexArrayObject);

                //texture.Use(TextureUnit.Texture0);

                //blockShader.Use();

                //var model = Matrix4.Identity * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(_time));
                //blockShader.SetMatrix4("model", model);
                //blockShader.SetMatrix4("view", Main._camera.GetViewMatrix());
                //blockShader.SetMatrix4("projection", Main._camera.GetProjectionMatrix());

                //GL.BindBuffer(BufferTarget.ArrayBuffer, blockModel);
                //GL.BufferData(BufferTarget.ArrayBuffer, _vertices.ToFloat().Length/* BlockShaping.GetBlock(neighbors).Length*/ * sizeof(float), _vertices.ToFloat()/*BlockShaping.GetBlock(neighbors)*/, BufferUsageHint.StaticDraw);

                //GL.BindVertexArray(blockModel);

                //Main._lightingShader.Use();

                //Main._lightingShader.SetMatrix4("model", Matrix4.Identity);
                //Main._lightingShader.SetMatrix4("view", Main._camera.GetViewMatrix());
                //Main._lightingShader.SetMatrix4("projection", Main._camera.GetProjectionMatrix());

                //Main._lightingShader.SetVector3("viewPos", Main._camera.Position);

                //// Here we set the material values of the cube, the material struct is just a container so to access
                //// the underlying values we simply type "material.value" to get the location of the uniform
                ////_lightingShader.SetVector3("material.ambient", new Vector3(1.0f, 0.5f, 0.31f));
                //Main._lightingShader.SetVector3("material.diffuse", new Vector3(1.0f, 0.5f, 0.31f));
                //Main._lightingShader.SetVector3("material.specular", new Vector3(0.5f, 0.5f, 0.5f));
                //Main._lightingShader.SetFloat("material.shininess", 100);


                //Matrix4 model = Matrix4.CreateTranslation(position);
                //// float angle = 0;
                ////model = model * Matrix4.CreateFromAxisAngle(new Vector3(1.0f, 0.3f, 0.5f), angle);
                //Main._lightingShader.SetMatrix4("model", model);

                //GL.DrawArrays(PrimitiveType.Triangles, 0, _vertices.ToFloat().Length);
                //Debug.WriteLine("hi ma 3!!");

                //GL.DrawElements(PrimitiveType.Triangles, _vertices.ToFloat(position).Length, DrawElementsType.UnsignedInt, 36);
            }

            var foo = _vertices.ToFloat();

            BetterDraw.Draw(ref foo, ref Main._lightingShader, ref texture, ref Main._camera, ref blockModel, position);
        }

        public override void Update(FrameEventArgs time)
        {

            //   BlockTools.PositionArray(Main.blocks.ToArray());

            var ran = Main.rand.Next(1, 7);

            for (int i = 0; i < _vertices.vertices.Count; i++)
            {
                _vertices.vertices[i].active = true;
            }

            if (Input.GetKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.D1))
            {
                neighborBack = !neighborBack;
            }
            if (Input.GetKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.D2))
            {
                neighborFront = !neighborFront;
            }
            if (Input.GetKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.D3))
            {
                neighborLeft = !neighborLeft;


            }
            if (Input.GetKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.D4))
            {
                neighborRight = !neighborRight;

            }
            if (Input.GetKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.D5))
            {
                neighborBottom = !neighborBottom;
            }
            if (Input.GetKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.D6))
            {
                neighborTop = !neighborTop;
            }
            //Debug.WriteLine(BlockTools.BlockPositionId(new Vector3(position.X + 1, position.Y, position.Z)));

            //if (BlockTools.BlockPositionId(new Vector3(position.X + 1, position.Y, position.Z)) == -1)
            //{

            //    // neighbors[0] = "Right";
            //    neighborRight = true;
            //}
            //if (BlockTools.BlockPositionId(new Vector3(position.X - 1, position.Y, position.Z)) == -1)
            //{
            //    //neighbors[1] = "Left";
            //    neighborLeft = true;
            //}

            //if (Main.blocks.PositionArray().Contains(new Vector3(position.X + 1, position.Y, position.Z)))
            //{
            //    neighborRight = true;

            //}
            //if (Main.blocks.PositionArray().Contains(new Vector3(position.X - 1, position.Y, position.Z)))
            //{
            //    neighborLeft = true;
            //}

            //if (Main.blocks.PositionArray().Contains(new Vector3(position.X + 1, position.Y, position.Z)))
            //{
            //    neighborRight = true;

            //}
            //if (Main.blocks.PositionArray().Contains(new Vector3(position.X - 1, position.Y, position.Z)))
            //{
            //    neighborLeft = true;
            //}

            //if (Main.blocks.PositionArray().Contains(new Vector3(position.X, position.Y + 1, position.Z)))
            //{
            //    neighborTop = true;

            //}
            //if (Main.blocks.PositionArray().Contains(new Vector3(position.X, position.Y - 1, position.Z)))
            //{
            //    neighborBottom = true;
            //}
            //if (Main.blocks.PositionArray().Contains(new Vector3(position.X, position.Y , position.Z-1)))
            //{
            //    neighborBack = true;

            //}
            //if (Main.blocks.PositionArray().Contains(new Vector3(position.X, position.Y , position.Z+1)))
            //{
            //    neighborFront = true;
            //}

            // Debug.WriteLine(BlockTools.BlockPositionId(position) + " Left: " + neighborLeft + " Right: " + neighborRight);
            Debug.WriteLine(BlockTools.BlockPositionId(position) + " Top: " + neighborTop + " Bottom: " + neighborBottom);

            if (neighborBack)
            {
                _vertices.vertices[0].active = false;
                _vertices.vertices[1].active = false;
                _vertices.vertices[2].active = false;
                _vertices.vertices[3].active = false;
                _vertices.vertices[4].active = false;
                _vertices.vertices[5].active = false;
            }

            if (neighborFront)
            {
                _vertices.vertices[6].active = false;
                _vertices.vertices[7].active = false;
                _vertices.vertices[8].active = false;
                _vertices.vertices[9].active = false;
                _vertices.vertices[10].active = false;
                _vertices.vertices[11].active = false;
            }
            if (neighborLeft)
            {
                _vertices.vertices[12].active = false;
                _vertices.vertices[13].active = false;
                _vertices.vertices[14].active = false;
                _vertices.vertices[15].active = false;
                _vertices.vertices[16].active = false;
                _vertices.vertices[17].active = false;
            }
            if (neighborRight)
            {
                _vertices.vertices[18].active = false;
                _vertices.vertices[19].active = false;
                _vertices.vertices[20].active = false;
                _vertices.vertices[21].active = false;
                _vertices.vertices[22].active = false;
                _vertices.vertices[23].active = false;
            }
            if (neighborBottom)
            {
                _vertices.vertices[24].active = false;
                _vertices.vertices[25].active = false;
                _vertices.vertices[26].active = false;
                _vertices.vertices[27].active = false;
                _vertices.vertices[28].active = false;
                _vertices.vertices[29].active = false;
            }
            if (neighborTop)
            {
                _vertices.vertices[30].active = false;
                _vertices.vertices[31].active = false;
                _vertices.vertices[32].active = false;
                _vertices.vertices[33].active = false;
                _vertices.vertices[34].active = false;
                _vertices.vertices[35].active = false;
            }


            base.Update(time);
        }

        public void RequestModelUpdate()
        {
            //blockModel = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, blockModel);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.ToFloat().Length/* BlockShaping.GetBlock(neighbors).Length*/ * sizeof(float), _vertices.ToFloat()/*BlockShaping.GetBlock(neighbors)*/, BufferUsageHint.StaticDraw);
        }

    }


}
