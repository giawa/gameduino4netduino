using Gameduino;
using System;

namespace SlotGag
{
    public class Program
    {
        private const byte BACKGROUND_HANDLE = 0;
        private const ushort BACKGROUND_WIDTH = 256;
        private const ushort BACKGROUND_HEIGHT = 256;
        private const ushort BACKGROUND_CELLS = 1;
        private const byte GAMEDUINO_HANDLE = 1;
        private const ushort GAMEDUINO_WIDTH = 395;
        private const ushort GAMEDUINO_HEIGHT = 113;
        private const ushort GAMEDUINO_CELLS = 1;

        public static void Main()
        {
            GD2.Init();
            GD2.Load("slotgag.gd2");

            ushort x = 0;

            while (true)
            {
                GD2.Clear();
                GD2.ColorMask(1, 1, 1, 0);
                GD2.Begin(GD2.Primitive.Bitmaps);
                GD2.BitmapHandle(BACKGROUND_HANDLE);
                GD2.BitmapSize(GD2.Filter.Nearest, GD2.Wrap.Repeat, GD2.Wrap.Repeat, 480, 272);
                GD2.Vertex2ii(0, 0, BACKGROUND_HANDLE, 0);

                GD2.ColorMask(1, 1, 1, 1);
                GD2.ColorRGB(0xa0a0a0);
                GD2.Vertex2ii(240 - GAMEDUINO_WIDTH / 2, 136 - GAMEDUINO_HEIGHT / 2, GAMEDUINO_HANDLE, 0);

                GD2.LineWidth(20 * 16);
                GD2.BlendFunc(GD2.Blend.DstAlpha, GD2.Blend.One);
                GD2.Begin(GD2.Primitive.Lines);
                GD2.Vertex2ii(x, 0);
                GD2.Vertex2ii((ushort)(x + 100), 272);
                x = (ushort)((x + 20) % 480);

                GD2.Swap();
            }
        }
    }
}
