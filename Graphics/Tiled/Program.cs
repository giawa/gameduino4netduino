using Gameduino;
using System;

namespace Tiled
{
    public class Program
    {
        public static void Main()
        {
            GD2.Init();
            GD2.Load("tiled.gd2");

            GD2.Clear();
            GD2.Begin(GD2.Primitive.Bitmaps);
            GD2.BitmapSize(GD2.Filter.Bilinear, GD2.Wrap.Repeat, GD2.Wrap.Repeat, 480, 272);
            GD2.Rotate(3333);
            GD2.SetMatrix();
            GD2.Vertex2ii(0, 0);
            GD2.Swap();
        }
    }
}
