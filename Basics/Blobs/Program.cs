using Gameduino;
using System.Threading;

namespace Blobs
{
    public class Program
    {
        public struct Point
        {
            public int x, y;

            public Point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }

        private static Point[] blobs = new Point[128];
        private const int OFFSCREEN = -16384;
        private static int blob_i;

        public static void Main()
        {
            GD2.Init();
            GD2.EnableTouch();

            for (int i = 0; i < blobs.Length; i++) blobs[i] = new Point(OFFSCREEN, OFFSCREEN);

            while (true)
            {
                var inputs = GD2.GetInputs();

                if (inputs.x != -32768) blobs[blob_i] = new Point(inputs.x << 4, inputs.y << 4);
                else blobs[blob_i] = new Point(OFFSCREEN, OFFSCREEN);

                blob_i = (blob_i + 1) % blobs.Length;

                GD2.ClearColorRGB(0xe0e0e0);
                GD2.Clear();

                GD2.Begin(GD2.Primitive.Points);

                for (int i = 0; i < blobs.Length; i++)
                {
                    int j = (blob_i + i) % blobs.Length;
                    if (blobs[j].x == OFFSCREEN) continue;

                    GD2.ColorA((byte)(i * 2));
                    GD2.PointSize((ushort)((1024 + 16) - (i << 3)));

                    byte r = (byte)(j * 17);
                    byte g = (byte)(j * 23);
                    byte b = (byte)(j * 147);
                    GD2.ColorRGB(r, g, b);

                    GD2.Vertex2f(blobs[j].x, blobs[j].y);
                }

                GD2.Swap();
            }
        }
    }
}