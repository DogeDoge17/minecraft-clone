using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone
{
    public class Input
    {
        public static MouseState mouse = Main.mouseState;

        public static bool GetKey(Keys key)
        {
            return Main.keyboardState.IsKeyDown(key);
        }

        public static bool GetKey(MouseButton key)
        {
            return Main.mouseState.IsButtonDown(key);
        }

        public static bool GetKeyDown(Keys key)
        {
            return Main.keyboardState.IsKeyPressed(key);
        }

        public static bool GetKeyDown(MouseButton key)
        {
            return Main.mouseState.IsButtonPressed(key);
        }

        public static bool GetKeyUp(Keys key)
        {
            return Main.keyboardState.IsKeyReleased(key);
        }

        public static bool GetKeyUp(MouseButton key)
        {
            return Main.mouseState.IsButtonReleased(key);
        }
    }
}
