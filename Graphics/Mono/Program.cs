using Gameduino;
using System;

namespace Mono
{
    public class Program
    {
        public static void Main()
        {
            GD2.Init();
            GD2.Load("mono.gd2");

            GD2.ClearColorRGB(0x375e03);
            GD2.Clear();
            GD2.Begin(GD2.Primitive.Bitmaps);
            GD2.ColorRGB(0x68b203);
            GD2.BitmapSize(GD2.Filter.Nearest, GD2.Wrap.Repeat, GD2.Wrap.Repeat, 480, 272);
            GD2.Vertex2ii(0, 0);
            GD2.Swap();
        }
    }
}
