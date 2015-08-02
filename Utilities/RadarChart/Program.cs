using Gameduino;
using System;

namespace RadarChart
{
    public class Program
    {
        public static void Main()
        {
            GD2.Init();

            string[] labels = new string[] { "Eating", "Drinking", "Sleeping", "Designing", "Coding", "Partying", "Running" };
            GD2.Options[] align = new GD2.Options[] { GD2.Options.CenterX, GD2.Options.RightX, GD2.Options.RightX, GD2.Options.CenterX, GD2.Options.CenterX, 0, 0 };
            ushort[] data = new ushort[7];
            ushort[] speed = new ushort[] { 5, 7, 6, 3, 4, 8, 2 };
            DateTime now = DateTime.Now;
            Polygon poly = new Polygon();

            while (true)
            {
                TimeSpan diff = DateTime.Now - now;
                int milliseconds = (((diff.Hours * 60) + diff.Minutes) * 60 + diff.Seconds) * 1000 + diff.Milliseconds;

                GD2.ClearColorRGB(0xffffff);
                GD2.Clear();
                int x = 0, y = 0;

                GD2.Begin(GD2.Primitive.Points);
                GD2.ColorRGB(0x000000);

                for (ushort i = 0; i < 7; i++)
                {
                    Ray(ref x, ref y, 16 * 128, i);
                    GD2.DisplayText((ushort)(x >> 4), (ushort)(y >> 4), 26, GD2.Options.CenterY | align[i], labels[i]);
                }

                GD2.ColorRGB(220, 220, 200);
                GD2.LineWidth(8);
                GD2.Begin(GD2.Primitive.Lines);
                for (ushort i = 0; i < 7; i++)
                {
                    GD2.Vertex2ii(240, 136);
                    Ray(ref x, ref y, 16 * 114, i);
                    GD2.Vertex2f(x, y);
                }
                for (ushort r = 19; r <= 114; r += 19)
                {
                    GD2.Begin(GD2.Primitive.LineStrip);
                    for (ushort i = 0; i < 8; i++)
                    {
                        Ray(ref x, ref y, (ushort)(16 * r), i);
                        GD2.Vertex2f(x, y);
                    }
                }

                for (ushort i = 0; i < 7; i++)
                {
                    data[i] = (ushort)(900 + 700 * Math.Sin(2 * Math.PI * 2 * speed[i] * milliseconds / 1024 / 256));
                }

                GD2.ColorRGB(151, 187, 205);

                GD2.SaveContext();
                GD2.ColorA(128);

                poly.Begin();
                for (ushort i = 0; i < 7; i++)
                {
                    Ray(ref x, ref y, data[i], i);
                    poly.V(x, y);
                }
                poly.Draw();
                GD2.RestoreContext();

                GD2.LineWidth(1 * 16);
                GD2.Begin(GD2.Primitive.LineStrip);
                DrawData(data);
                Ray(ref x, ref y, data[0], 0);
                GD2.Vertex2f(x, y);

                GD2.Begin(GD2.Primitive.Points);
                GD2.ColorRGB(0xffffff);
                GD2.PointSize(56);
                DrawData(data);
                GD2.ColorRGB(151, 187, 205);
                GD2.PointSize(40);
                DrawData(data);

                GD2.Swap();
            }
        }

        private static void Ray(ref int x, ref int y, ushort r, ushort i)
        {
            ushort th = (ushort)(0x8000 + 65536 * i / 7);
            //GD2.Polar(x, y, r, th);
            x = -(int)(r * Math.Sin(2 * Math.PI * th / 1024));
            y = (int)(r * Math.Cos(2 * Math.PI * th / 1024));
            x += 16 * 240;
            y += 16 * 136;
        }

        private static void DrawData(ushort[] data)
        {
            int x = 0, y = 0;

            for (ushort i = 0; i < 7; i++)
            {
                Ray(ref x, ref y, data[i], i);
                GD2.Vertex2f(x, y);
            }
        }
    }
}
