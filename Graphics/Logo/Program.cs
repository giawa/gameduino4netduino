using Gameduino;
using System;

namespace Logo
{
    public class Program
    {
        private struct Point
        {
            public int x, y;

            public Point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }

        private static byte clamp(int x)
        {
            if (x < 0) return 0;
            else if (x > 255) return 255;
            else return (byte)x;
        }

        private const byte GAMEDUINO_HANDLE = 0;
        private const int GAMEDUINO_WIDTH = 395;
        private const int GAMEDUINO_HEIGHT = 113;
        private const int GAMEDUINO_CELLS = 1;
        private const byte OSHW_HANDLE = 1;
        private const int OSHW_WIDTH = 46;
        private const int OSHW_HEIGHT = 50;
        private const int OSHW_CELLS = 1;
        private const int TWO_HANDLE = 2;
        private const int TWO_WIDTH = 128;
        private const int TWO_HEIGHT = 143;
        private const int TWO_CELLS = 2;
        private const byte PERSONAL_HANDLE = 3;
        private const int PERSONAL_WIDTH = 480;
        private const int PERSONAL_HEIGHT = 272;
        private const int PERSONAL_CELLS = 1;

        public static void Main()
        {
            GD2.Init();
            GD2.Load("logo.gd2");

            byte fade;
            int t = 0;
            Point[] stars = new Point[256];
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Point(GD2.Random(16 * 480), GD2.Random(16 * 272));
            }

            while (true)
            {
                if (t == 464) continue;
                else t++;

                GD2.Gradient(0, 0, 0x120000, 0, 272, 0x480000);
                GD2.BlendFunc(GD2.Blend.SrcAlpha, GD2.Blend.One);
                GD2.Begin(GD2.Primitive.Points);

                for (int i = 0; i < stars.Length; i++)
                {
                    GD2.ColorA((byte)(64 + (i >> 2)));
                    GD2.PointSize((ushort)(8 + (i >> 5)));
                    GD2.Vertex2f(stars[i].x, stars[i].y);

                    // stars drift left, then wrap around
                    stars[i].x -= 1 + (i >> 5);
                    if (stars[i].x < -256)
                    {
                        stars[i].x += 16 * 500;
                        stars[i].y = GD2.Random(16 * 272);
                    }
                }

                GD2.RestoreContext();
                GD2.Begin(GD2.Primitive.Bitmaps);

                // Main logo fades up from black
                fade = clamp(5 * (t - 15));
                GD2.ColorRGB(fade, fade, fade);
                GD2.Vertex2ii(240 - GAMEDUINO_WIDTH / 2, 65, GAMEDUINO_HANDLE, 0);
                GD2.RestoreContext();

                // The '2' and its glow
                fade = clamp(8 * (t - 120));
                GD2.ColorA(fade);
                GD2.Vertex2ii(270, 115, TWO_HANDLE, 0);
                fade = clamp(5 * (t - 144));

                GD2.BlendFunc(GD2.Blend.SrcAlpha, GD2.Blend.One);
                GD2.ColorA(fade);
                GD2.ColorRGB(85, 85, 85);
                GD2.Vertex2ii(270, 115, TWO_HANDLE, 1);

                // The text fades up. Its glow is a full-screen bitmap
                fade = clamp(8 * (t - 160));
                GD2.ColorA(fade);
                GD2.DisplayText(140, 200, 29, GD2.Options.Center, "This time");
                GD2.DisplayText(140, 225, 29, GD2.Options.Center, "it's personal");
                fade = clamp(5 * (t - 184));
                GD2.BlendFunc(GD2.Blend.SrcAlpha, GD2.Blend.One);
                GD2.ColorA(fade);
                GD2.ColorRGB(85, 85, 85);
                GD2.Vertex2ii(0, 0, PERSONAL_HANDLE, 0);

                // OSHW logo fades in
                GD2.ColorRGB(0, 153 * 160 / 255, 176 * 160 / 255);
                GD2.Vertex2ii(2, 2, OSHW_HANDLE, 0);
                GD2.RestoreContext();

                // Fade to white at the end by drawing a white rectangle on top
                fade = clamp(5 * (t - 400));
                GD2.ColorA(fade);
                GD2.Begin(GD2.Primitive.Rects);
                GD2.Vertex2ii(0, 0, 0, 0);
                GD2.Vertex2ii(480, 272, 0, 0);

                GD2.Swap();
            }
        }
    }
}
