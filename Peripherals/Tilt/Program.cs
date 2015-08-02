using Gameduino;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using System;

namespace Tilt
{
    public class Program
    {
        public static void Main()
        {
            GD2.Init();

            int x = 0, y = 0, z = 0;

            while (true)
            {
                GD2.GetAccelerometer(ref x, ref y, ref z);

                GD2.Clear();
                GD2.LineWidth(16 * 3);
                int xp = 240 + x;
                int yp = 136 + y;
                GD2.Begin(GD2.Primitive.Lines);
                GD2.Vertex2f(16 * 240, 16 * 136);
                GD2.Vertex2f(16 * xp, 16 * yp);

                GD2.PointSize(16 * 40);
                GD2.Begin(GD2.Primitive.Points);
                GD2.Vertex2f(16 * xp, 16 * yp);

                GD2.Swap();
            }
        }
    }
}
