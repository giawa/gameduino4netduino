using Gameduino;
using System;

namespace Widgets
{
    public class Program
    {
        private static ushort value = 15000;
        private static char[] message = new char[41];
        private static GD2.Options options = GD2.Options.Flat;
        private static char prevkey;

        private enum Tag : int
        {
            TAG_DIAL = 200,
            TAG_SLIDER = 201,
            TAG_TOGGLE = 202,
            TAG_BUTTON1 = 203,
            TAG_BUTTON2 = 204
        }

        public static void Main()
        {
            GD2.Init();
            GD2.EnableTouch();

            for (int i = 0; i < message.Length; i++) message[i] = ' ';

            while (true)
            {
                var inputs = GD2.GetInputs();

                Tag track_tag = (Tag)(inputs.track_tag & 0xff);
                if (track_tag == Tag.TAG_DIAL || track_tag == Tag.TAG_SLIDER || track_tag == Tag.TAG_TOGGLE)
                    value = inputs.track_val;

                if ((Tag)inputs.tag == Tag.TAG_BUTTON1) options = GD2.Options.Flat;
                else if ((Tag)inputs.tag == Tag.TAG_BUTTON2) options = GD2.Options.None;

                char key = (char)inputs.tag;
                if ((prevkey == 0x00) && (' ' <= key) && (key < 0x7f))
                {
                    /*memmove(message, message + 1, 39);
                    message[39] = key;*/
                    Array.Copy(message, 1, message, 0, 39);
                    message[39] = key;
                }
                prevkey = key;

                GD2.Gradient(0, 0, 0x404044, 480, 480, 0x606068);
                GD2.ColorRGB(0x707070);

                GD2.LineWidth(4 * 16);
                GD2.Begin(GD2.Primitive.Rects);

                GD2.Vertex2ii(8, 8);
                GD2.Vertex2ii(128, 128);

                GD2.Vertex2ii(8, 136 + 8);
                GD2.Vertex2ii(128, 136 + 128);

                GD2.Vertex2ii(144, 136 + 8);
                GD2.Vertex2ii(472, 136 + 128);
                GD2.ColorRGB(0xffffff);

                GD2.Tag((byte)Tag.TAG_DIAL);
                GD2.Dial(68, 68, 50, options, value);
                GD2.Track(68, 68, 1, 1, (byte)Tag.TAG_DIAL);

                GD2.Tag((byte)Tag.TAG_SLIDER);
                GD2.Slider(16, 199, 104, 10, options, value, 65535);
                GD2.Track(16, 199, 104, 10, (byte)Tag.TAG_SLIDER);

                GD2.Tag((byte)Tag.TAG_TOGGLE);
                GD2.Toggle(360, 62, 80, 29, options, value, "that\xffthis");
                GD2.Track(360, 62, 80, 20, (byte)Tag.TAG_TOGGLE);

                GD2.Tag(255);
                GD2.Number(68, 136, 30, GD2.Options.Center | (GD2.Options)5, value);

                GD2.Clock(184, 48, 40, options | GD2.Options.NoSecs, 0, 0, value, 0);
                GD2.Gauge(280, 48, 40, options, 4, 3, value, 65535);

                GD2.Tag((byte)Tag.TAG_BUTTON1);
                GD2.Button(352, 12, 40, 30, 28, options, "2D");
                GD2.Tag((byte)Tag.TAG_BUTTON2);
                GD2.Button(400, 12, 40, 30, 28, options, "3D");

                GD2.Tag(255);
                GD2.Progress(144, 100, 320, 10, options, value, 65535);
                GD2.Scrollbar(144, 120, 320, 10, options, (ushort)(value / 2), 32768, 65535);

                GD2.Keys(144, 168, 320, 24, 28, options | GD2.Options.Center | (GD2.Options)key, "qwertyuiop");
                GD2.Keys(144, 168 + 26, 320, 24, 28, options | GD2.Options.Center | (GD2.Options)key, "asdfghjkl");
                GD2.Keys(144, 168 + 52, 320, 24, 28, options | GD2.Options.Center | (GD2.Options)key, "zxcvbnm,.");
                GD2.Tag((byte)' ');
                GD2.Button(308 - 60, 172 + 74, 120, 20, 28, options, "");

                GD2.BlendFunc(GD2.Blend.SrcAlpha, GD2.Blend.Zero);
                GD2.DisplayText(149, 146, 18, GD2.Options.None, new string(message));

                GD2.Swap();
            }
        }
    }
}
