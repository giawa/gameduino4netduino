using System;
using Gameduino;

namespace Fizz
{
    public class Program
    {
        public static void Main()
        {
            GD2.Init();

            while (true)
            {
                GD2.Clear();
                GD2.Begin(GD2.Primitive.Points);

                for (int i = 0; i < 100; i++)
                {
                    GD2.PointSize(GD2.Random(50 * 16));
                    GD2.ColorRGB(GD2.RandomByte(), GD2.RandomByte(), GD2.RandomByte());
                    GD2.ColorA(GD2.RandomByte());
                    GD2.Vertex2ii(GD2.Random(480), GD2.Random(272));
                }

                GD2.Swap();
            }
        }
    }
}
