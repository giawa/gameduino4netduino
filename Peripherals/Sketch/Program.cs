using Gameduino;
using System;

namespace Sketch
{
    public class Program
    {
        public static void Main()
        {
            GD2.Init();
            GD2.EnableTouch();

            // initialize and draw a black bitmap to use for sketching
            GD2.Memset(0, 0, 480 * 272);
            GD2.Clear();
            GD2.BitmapLayout(GD2.PixelFormat.L8, 480, 272);
            GD2.BitmapSize(GD2.Filter.Nearest, GD2.Wrap.Border, GD2.Wrap.Border, 480, 272);
            GD2.Begin(GD2.Primitive.Bitmaps);
            GD2.Vertex2ii(0, 0);
            GD2.Swap();

            // start sketching
            GD2.Sketch(0, 0, 480, 272, 0, GD2.PixelFormat.L8);
            GDTransport.finish();
        }
    }
}
