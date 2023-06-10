using MinecraftClone.Blocks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Diagnostics;

namespace MinecraftClone.Common
{
    internal class CameraMove : UpdateMe
    {
        private bool _firstMove = true;

        private Vector2 _lastPos;
        
        float cameraSpeed = 1.5f;
        public CameraMove()
        {
        }

        public override void Update(FrameEventArgs time)
        { 

            const float sensitivity = 0.2f;

            if (Input.GetKeyDown(Keys.LeftControl))
            {
                cameraSpeed *= 2;
            }else if (Input.GetKeyUp(Keys.LeftControl))
            {
                cameraSpeed /= 2;
            }

            if (Input.GetKey(Keys.W))
            {
                Main._camera.Position += Main._camera.Front * cameraSpeed * (float)time.Time; // Forward
            }

            if (Input.GetKey(Keys.S))
            {
                Main._camera.Position -= Main._camera.Front * cameraSpeed * (float)time.Time; // Backwards
            }
            if (Input.GetKey(Keys.A))
            {
                Main._camera.Position -= Main._camera.Right * cameraSpeed * (float)time.Time; // Left
            }
            if (Input.GetKey(Keys.D))
            {
                Main._camera.Position += Main._camera.Right * cameraSpeed * (float)time.Time; // Right
            }
            if (Input.GetKey(Keys.Space))
            {
                Main._camera.Position += Main._camera.Up * cameraSpeed * (float)time.Time; // Up
            }
            if (Input.GetKey(Keys.LeftShift))
            {
                Main._camera.Position -= Main._camera.Up * cameraSpeed * (float)time.Time; // Down
            }

            // Get the mouse state

            if (_firstMove) // This bool variable is initially set to true.
            {
                _lastPos = new Vector2(Input.mouse.X, Input.mouse.Y);
                _firstMove = false;
            }
            else
            {
                // Calculate the offset of the mouse position
                var deltaX = Input.mouse.X - _lastPos.X;
                var deltaY = Input.mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(Input.mouse.X, Input.mouse.Y);

                // Apply the camera pitch and yaw (we clamp the pitch in the camera class)
                Main._camera.Yaw += deltaX * sensitivity;
                Main._camera.Pitch -= deltaY * sensitivity; // Reversed since y-coordinates range from bottom to top
            }

            base.Update(time);
        }
    }
}
