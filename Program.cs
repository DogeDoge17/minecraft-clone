using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace MinecraftClone
{
    public static class Program
    {
        private static void Main()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(1360, 720),
                Title = "Minecraft Clone",
                // This is needed to run on macos
                Flags = ContextFlags.ForwardCompatible,
            };

            using (var window = new Main(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }
}