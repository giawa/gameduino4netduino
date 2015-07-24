using Gameduino;
using System;
using System.Threading;

namespace Simon
{
    public class Program
    {
        private enum Color : uint
        {
            DARK_GREEN = 0x007000,
            LIGHT_GREEN = 0x33ff33,
            DARK_RED = 0x700000,
            LIGHT_RED = 0xff3333,
            DARK_YELLOW = 0x707000,
            LIGHT_YELLOW = 0xffff33,
            DARK_BLUE = 0x007070,
            LIGHT_BLUE = 0x33ffff
        }

        public static void Main()
        {
            GD2.Init();
            GD2.EnableTouch();
            GDTransport.wr8(GPU_Registers.VOL_SOUND, 255);

            int[] sequence = new int[100];
            int length = 0;

            while (true)
            {
                Thread.Sleep(500);

                sequence[length++] = RandomNote();

                for (int i = 0; i < length; i++) Play(sequence[i]);

                for (int i = 0; i < length; i++)
                {
                    int pressed = GetNote();

                    if (pressed != sequence[i])
                    {
                        for (byte j = 69; j > 49; j--)
                        {
                            GD2.Play(GD2.Instrument.Bell, j);
                            Thread.Sleep(50);
                        }
                        return;
                    }
                }
            }
        }

        private static void DrawScreen(int pressed)
        {
            GD2.Clear();

            GD2.PointSize(16 * 60);
            GD2.Begin(GD2.Primitive.Points);
            GD2.Tag(1);

            if (pressed == 1) GD2.ColorRGB((uint)Color.LIGHT_GREEN);
            else GD2.ColorRGB((uint)Color.DARK_GREEN);
            GD2.Vertex2ii(240 - 70, 136 - 70);

            GD2.Tag(2);
            if (pressed == 2) GD2.ColorRGB((uint)Color.LIGHT_RED);
            else GD2.ColorRGB((uint)Color.DARK_RED);
            GD2.Vertex2ii(240 + 70, 136 - 70);

            GD2.Tag(3);
            if (pressed == 3) GD2.ColorRGB((uint)Color.LIGHT_YELLOW);
            else GD2.ColorRGB((uint)Color.DARK_YELLOW);
            GD2.Vertex2ii(240 - 70, 136 + 70);

            GD2.Tag(4);
            if (pressed == 4) GD2.ColorRGB((uint)Color.LIGHT_BLUE);
            else GD2.ColorRGB((uint)Color.DARK_BLUE);
            GD2.Vertex2ii(240 + 70, 136 + 70);

            GD2.Swap();
        }

        private static readonly byte[] note = new byte[] { 0, 52, 69, 61, 64 };

        private static void Play(int pressed)
        {
            GD2.Play(GD2.Instrument.Bell, note[pressed]);
            for (int i = 0; i < 15; i++)
                DrawScreen(pressed);
            for (int i = 0; i < 7; i++)
                DrawScreen(0);
        }

        private static int GetNote()
        {
            byte pressed = 0;

            while (pressed == 0)
            {
                GD2.Random();
                DrawScreen(0);

                var inputs = GD2.GetTouch();

                if ((1 <= inputs.tag) && (inputs.tag <= 4)) pressed = inputs.tag;
            }

            Play(pressed);
            return pressed;
        }

        private static int RandomNote()
        {
            return 1 + GD2.Random(4);
        }
    }
}
