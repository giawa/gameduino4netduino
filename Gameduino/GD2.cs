using Microsoft.SPOT;
using System;
using System.Runtime.InteropServices;

namespace Gameduino
{
    public static class GD2
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Inputs
        {
            public ushort track_tag;
            public ushort track_val;
            public ushort rz;
            public ushort dummy;
            public short y;
            public short x;
            public short tag_y;
            public short tag_x;
            public byte tag;
            public byte ptag;

            public Inputs(byte[] tracker, byte[] touchrz, byte[] btag)
            {
                track_tag = (ushort)((tracker[1] << 8) | (tracker[0]));
                track_val = (ushort)((tracker[3] << 8) | (tracker[2]));

                rz = (ushort)((touchrz[1] << 8) | (touchrz[0]));
                dummy = 0;
                y = (short)((touchrz[5] << 8) | (touchrz[4]));
                x = (short)((touchrz[7] << 8) | (touchrz[6]));
                tag_y = (short)((touchrz[9] << 8) | (touchrz[8]));
                tag_x = (short)((touchrz[11] << 8) | (touchrz[10]));

                tag = touchrz[12];
                ptag = btag[0];
            }

            public Inputs(byte[] touchrz)
            {
                track_tag = 0;
                track_val = 0;

                rz = (ushort)((touchrz[1] << 8) | (touchrz[0]));
                dummy = 0;
                y = (short)((touchrz[5] << 8) | (touchrz[4]));
                x = (short)((touchrz[7] << 8) | (touchrz[6]));
                tag_y = (short)((touchrz[9] << 8) | (touchrz[8]));
                tag_x = (short)((touchrz[11] << 8) | (touchrz[10]));

                tag = touchrz[12];
                ptag = 0;
            }
        }

        public static Inputs GetInputs()
        {
            byte[] tracker = GDTransport.rd_n(GPU_Registers.TRACKER, 4);
            byte[] touchrz = GDTransport.rd_n(GPU_Registers.TOUCH_RZ, 13);
            byte[] tag = GDTransport.rd_n(GPU_Registers.TAG, 1);

            return new Inputs(tracker, touchrz, tag);
        }

        public static Inputs GetTouch()
        {
            byte[] touchrz = GDTransport.rd_n(GPU_Registers.TOUCH_RZ, 13);

            return new Inputs(touchrz);
        }

        public static void ClearColorRGB(uint rgb)
        {
            GDTransport.cmd32(0x02000000 | (rgb & 0xffffff));
        }

        public static void ClearColorRGB(byte red, byte green, byte blue)
        {
            GDTransport.cmd32(blue, green, red, 2);
        }

        public static void Clear()
        {
            GDTransport.cmd32(0x26000007);
        }

        public static void Display()
        {
            GDTransport.cmd32(0x00000000);
        }

        public static void End()
        {
            GDTransport.cmd32(0x21000000);
        }

        public enum Primitive : uint
        {
            Bitmaps = 1,
            Points = 2,
            Lines = 3,
            LineStrip = 4,
            EdgeStripR = 5,
            EdgeStripL = 6,
            EdgeStripA = 7,
            EdgeStripB = 8,
            Rects = 9
        }

        public enum Instrument : byte
        {
            Silence = 0x00,
            Squarewave = 0x01,
            Sinewave = 0x02,
            Sawtooth = 0x03,
            Triangle = 0x04,
            Beeping = 0x05,
            Alarm = 0x06,
            Warble = 0x07,
            Carousel = 0x08,
            Pips = 0x0F,
            Harp = 0x40,
            Xylophone = 0x41,
            Tuba = 0x42,
            Glockenspiel = 0x43,
            Organ = 0x44,
            Trumpet = 0x45,
            Piano = 0x46,
            Chimes = 0x47,
            MusicBox = 0x48,
            Bell = 0x49,
            Click = 0x50,
            Switch = 0x51,
            Cowbell = 0x52,
            Notch = 0x53,
            Hihat = 0x54,
            Kickdrum = 0x55,
            Pop = 0x56,
            Clack = 0x57,
            Chack = 0x58,
            Mute = 0x60,
            Unmute = 0x61
        }

        private static Random generator = new Random((int)DateTime.Now.Ticks);

        public static ushort Random()
        {
            return (ushort)generator.Next(ushort.MaxValue);
        }

        public static ushort Random(ushort n)
        {
            return (ushort)generator.Next(n);
        }

        public static byte RandomByte()
        {
            return (byte)generator.Next(byte.MaxValue);
        }

        public static void Begin(Primitive primitive)
        {
            GDTransport.cmd32((uint)0x1F000000 | (uint)primitive);
        }

        public static void ColorA(byte alpha)
        {
            GDTransport.cmd32((uint)0x10000000 | alpha);
        }

        public static void PointSize(ushort size)
        {
            GDTransport.cmd32((uint)0x0D000000 | size);
        }

        public static void TagMask(byte mask)
        {
            GDTransport.cmd32((uint)0x14000000 | mask);
        }

        public static void Tag(byte s)
        {
            GDTransport.cmd32((uint)0x03000000 | s);
        }

        public static void ColorRGB(byte r, byte g, byte b)
        {
            GDTransport.cmd32((uint)0x04000000 | (uint)(r << 16) | (uint)(g << 8) | b);
        }

        public static void ColorRGB(uint color)
        {
            color &= 0xffffff;
            GDTransport.cmd32((uint)0x04000000 | color);
        }

        public static void Vertex2f(int x, int y)
        {
            uint _x = (uint)((x & 32767) << 15);
            uint _y = (uint)(y & 32767);
            GDTransport.cmd32((uint)0x40000000 | _x | _y);
        }

        public static void Vertex2f(short x, short y)
        {
            uint _x = (uint)((x & 32767) << 15);
            uint _y = (uint)(y & 32767);
            GDTransport.cmd32((uint)0x40000000 | _x | _y);
        }


        public static void Vertex2ii(ushort x, ushort y)
        {
            uint _x = (uint)((x & 511) << 21);
            uint _y = (uint)((y & 511) << 12);
            uint cmd = (uint)(2 << 29) * 2;
            GDTransport.cmd32(cmd | _x | _y);
        }

        public static void Swap()
        {
            GDTransport.cmd32(0x00000000);//DL_DISPLAY
            GDTransport.cmd32(0xffffff01);//CMD_SWAP
            
            GDTransport.finish();

            GDTransport.cmd32(0xffffff00);//CMD_DLSTART
            //GDTransport.cmd32(0xffffff26);//CMD_LOADIDENTITY
        }

        private static ushort lcdWidth = 480;				// Active width of LCD display
        private static ushort lcdHeight = 272;				// Active height of LCD display
        private static ushort lcdHcycle = 548;				// Total number of clocks per line
        private static ushort lcdHoffset = 43;				// Start of active line
        private static ushort lcdHsync0 = 0;				// Start of horizontal sync pulse
        private static ushort lcdHsync1 = 41;				// End of horizontal sync pulse
        private static ushort lcdVcycle = 292;				// Total number of lines per screen
        private static ushort lcdVoffset = 12;				// Start of active screen
        private static ushort lcdVsync0 = 0;				// Start of vertical sync pulse
        private static ushort lcdVsync1 = 10;				// End of vertical sync pulse
        private static byte lcdPclk = 5;				// Pixel Clock
        private static byte lcdSwizzle = 3;				// Define RGB output pins
        private static byte lcdPclkpol = 1;				// Define active edge of PCLK

        public static void Init()
        {
            GDTransport.Init();

            Debug.Print("ID Register: " + GDTransport.rd(GPU_Registers.ID));

            // wake up the FT800
            GDTransport.hostcmd(0x00);

            GDTransport.wr8(GPU_Registers.PCLK, 0);
            GDTransport.wr8(GPU_Registers.PWM_DUTY, 0);

            // initialize the display
            GDTransport.wr16(GPU_Registers.HSIZE, lcdWidth);	// active display width
            GDTransport.wr16(GPU_Registers.HCYCLE, lcdHcycle);	// total number of clocks per line, incl front/back porch
            GDTransport.wr16(GPU_Registers.HOFFSET, lcdHoffset);// start of active line
            GDTransport.wr16(GPU_Registers.HSYNC0, lcdHsync0);	// start of horizontal sync pulse
            GDTransport.wr16(GPU_Registers.HSYNC1, lcdHsync1);	// end of horizontal sync pulse
            GDTransport.wr16(GPU_Registers.VSIZE, lcdHeight);	// active display height
            GDTransport.wr16(GPU_Registers.VCYCLE, lcdVcycle);	// total number of lines per screen, incl pre/post
            GDTransport.wr16(GPU_Registers.VOFFSET, lcdVoffset);// start of active screen
            GDTransport.wr16(GPU_Registers.VSYNC0, lcdVsync0);	// start of vertical sync pulse
            GDTransport.wr16(GPU_Registers.VSYNC1, lcdVsync1);	// end of vertical sync pulse
            GDTransport.wr8(GPU_Registers.SWIZZLE, lcdSwizzle);	// FT800 output to LCD - pin order
            GDTransport.wr8(GPU_Registers.PCLK_POL, lcdPclkpol);// LCD data is clocked in on this PCLK edge

            // configure Touch and Audio - not used in this example, so disable both
            GDTransport.wr16(GPU_Registers.TOUCH_MODE, 0);		// Disable touch
            GDTransport.wr16(GPU_Registers.TOUCH_RZTHRESH, 0);	// Eliminate any false touches

            GDTransport.wr8(GPU_Registers.VOL_PB, 0);		    // turn recorded audio volume down
            GDTransport.wr8(GPU_Registers.VOL_SOUND, 0);		// turn synthesizer volume down
            GDTransport.wr16(GPU_Registers.SOUND, 0x6000);		// set synthesizer to mute

            // enable display
            GDTransport.wr8(GPU_Registers.PCLK, lcdPclk);		// Now start clocking data to the LCD panel
            GDTransport.wr8(GPU_Registers.PWM_DUTY, 127);       // Backlight to full power

            GDTransport.wr8(GPU_Registers.GPIO_DIR, 0x83);
            GDTransport.wr8(GPU_Registers.GPIO, 0x80);

            // start a display list
            GDTransport.cmd32(0xffffff00);//CMD_DLSTART
            //GDTransport.cmd32(0xffffff26);//CMD_LOADIDENTITY
        }

        public static void EnableTouch()
        {
            GDTransport.wr16(GPU_Registers.TOUCH_MODE, 3);
            GDTransport.wr16(GPU_Registers.TOUCH_RZTHRESH, 3000);
            SelfCalibrate();
        }

        public static void DisableTouch()
        {
            GDTransport.wr16(GPU_Registers.TOUCH_MODE, 0);
            GDTransport.wr16(GPU_Registers.TOUCH_RZTHRESH, 0);
        }

        [Flags]
        public enum Options : ushort
        {
            Mono = 1,
            Nodl = 2,
            Flag = 256,
            CenterX = 512,
            CenterY = 1024,
            Center = CenterX | CenterY,
            NoBack = 4096,
            NoTicks = 8192,
            NoPointer = 16384,
            NoSecs = 32768,
            RightX = 2048,
            Signed = 256
        }

        public static void DisplayText(ushort x, ushort y, byte font, Options options, string s)
        {
            byte align = 0;
            byte n = (byte)(s.Length + 1);
            
            while (((n++) & 3) != 0) align++;

            byte[] data = new byte[4 + 2 + 2 + 2 + 2 + s.Length + 1 + align];

            data[0] = 0x0c;
            data[1] = 0xff;
            data[2] = 0xff;
            data[3] = 0xff;
            data[4] = (byte)x;
            data[5] = (byte)(x >> 8);
            data[6] = (byte)y;
            data[7] = (byte)(y >> 8);
            data[8] = font;
            //data[9] = 0;
            data[10] = (byte)options;
            data[11] = (byte)((ushort)options >> 8);
            for (int i = 0; i < s.Length; i++) data[12 + i] = (byte)s[i];

            GDTransport.cmd(data);
        }

        private static void cmd_swap()
        {
            GDTransport.cmd32ffffff(1);
        }

        private static void cmd_loadidentity()
        {
            GDTransport.cmd32ffffff(0x26);
        }

        private static void cmd_dlstart()
        {
            GDTransport.cmd32ffffff(0);
        }

        private static void cmd_calibrate()
        {
            GDTransport.cmd32ffffff(0x15);
            GDTransport.cmd32ffffff(0xff);
        }

        public static void Play(Instrument instrument, byte note)
        {
            GDTransport.wr16(GPU_Registers.SOUND, (ushort)(((int)note << 8) | (int)instrument));
            GDTransport.wr8(GPU_Registers.PLAY, 1);
        }

        public static void SelfCalibrate()
        {
            cmd_dlstart();
            Clear();
            DisplayText(240, 100, 30, Options.CenterX, "Please tap on the dot");
            cmd_calibrate();
            GDTransport.finish();
            //cmd_loadidentity();
            cmd_dlstart();
        }
    }
}
