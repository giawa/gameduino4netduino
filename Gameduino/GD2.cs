using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using System;
using System.Runtime.InteropServices;

namespace Gameduino
{
    public class Polygon
    {
        private int x0, y0, x1, y1;
        private int[] x = new int[8];
        private int[] y = new int[8];
        private byte n;

        private void Restart()
        {
            n = 0;
            x0 = 16 * 480;
            x1 = 0;
            y0 = 16 * 272;
            y1 = 0;
        }

        private void Perimeter()
        {
            for (byte i = 0; i < n; i++)
                GD2.Vertex2f(x[i], y[i]);
            GD2.Vertex2f(x[0], y[0]);
        }

        public void Begin()
        {
            Restart();

            GD2.ColorMask(0, 0, 0, 0);
            GD2.StencilOp(GD2.StencilOperation.Keep, GD2.StencilOperation.Invert);
            GD2.StencilFunc(GD2.CompareFunc.Always, 255, 255);
        }

        public void V(int _x, int _y)
        {
            x0 = System.Math.Min(x0, _x >> 4);
            x1 = System.Math.Max(x1, _x >> 4);
            y0 = System.Math.Min(y0, _y >> 4);
            y1 = System.Math.Max(y1, _y >> 4);
            x[n] = _x;
            y[n] = _y;
            n++;
        }

        public void Paint()
        {
            x0 = System.Math.Max(0, x0);
            y0 = System.Math.Max(0, y0);
            x1 = System.Math.Min(16 * 480, x1);
            y1 = System.Math.Min(16 * 272, y1);
            GD2.ScissorXY((ushort)x0, (ushort)y0);
            GD2.ScissorSize((ushort)(x1 - x0 + 1), (ushort)(y1 - y0 + 1));
            GD2.Begin(GD2.Primitive.EdgeStripB);
            Perimeter();
        }

        public void Finish()
        {
            GD2.ColorMask(1, 1, 1, 1);
            GD2.StencilFunc(GD2.CompareFunc.Equal, 255, 255);

            GD2.Begin(GD2.Primitive.EdgeStripB);
            GD2.Vertex2ii(0, 0);
            GD2.Vertex2ii(511, 0);
        }

        public void Draw()
        {
            Paint();
            Finish();
        }

        public void Outline()
        {
            GD2.Begin(GD2.Primitive.LineStrip);
            Perimeter();
        }
    }

    public static class GD2
    {
        #region Enumerations
        public enum Filter
        {
            Nearest = 0,
            Bilinear = 1
        }

        public enum Wrap
        {
            Border = 0,
            Repeat = 1
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

        public enum Blend : byte
        {
            Zero = 0,
            One = 1,
            SrcAlpha = 2,
            DstAlpha = 3,
            OneMinusSrcAlpha = 4,
            OneMinusDstAlpha = 5
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

        public enum PixelFormat : byte
        {
            ARGB1555 = 0,
            L1 = 1,
            L4 = 2,
            L8 = 3,
            RGB332 = 4,
            ARGB2 = 5,
            ARGB4 = 6,
            RGB565 = 7,
            PALETTED = 8,
            TEXT8X8 = 9,
            TEXTVGA = 10,
            BARGRAPH = 11
        }

        public enum StencilOperation : byte
        {
            Keep = 1,
            Replace = 2,
            Increment = 3,
            Decrement = 4,
            Invert = 5
        }

        public enum CompareFunc : byte
        {
            Never = 0,
            Less = 1,
            Lequal = 2,
            Greater = 3,
            Gequal = 4,
            Equal = 5,
            NotEqual = 6,
            Always = 7
        }
        #endregion

        #region Initialization
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
            GDTransport.wr8(GPU_Registers.ROTATE, 1);           // The lcd viewing angle seem to be much better this way

            // start a display list
            GDTransport.cmd32(0xffffff00);//CMD_DLSTART
            //GDTransport.cmd32(0xffffff26);//CMD_LOADIDENTITY
        }
        #endregion

        #region Touch Input
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

        private static AnalogInput pinA0 = new AnalogInput(AnalogChannels.ANALOG_PIN_A0);
        private static AnalogInput pinA1 = new AnalogInput(AnalogChannels.ANALOG_PIN_A1);
        private static AnalogInput pinA2 = new AnalogInput(AnalogChannels.ANALOG_PIN_A2);

        public static void GetAccelerometer(ref int x, ref int y, ref int z)
        {
            int zf = (-160 * (pinA0.ReadRaw() / 4 - 440)) >> 6;
            int yf = (-160 * (pinA1.ReadRaw() / 4 - 440)) >> 6;
            int xf = (-160 * (pinA2.ReadRaw() / 4 - 440)) >> 6;

            z = ((3 * z) >> 2) + (zf >> 2);
            y = ((3 * y) >> 2) + (yf >> 2);
            x = ((3 * x) >> 2) + (xf >> 2);
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
        #endregion

        private static Random generator = new Random((int)DateTime.Now.Ticks);

        public static void Begin(Primitive primitive)
        {
            GDTransport.cmd32((uint)0x1F000000 | (uint)primitive);
        }

        public static void BitmapLayout(PixelFormat format, ushort lineStride, ushort height)
        {
            uint cmd = (0x07 << 24) | ((uint)format << 19) | ((uint)(lineStride & 1023) << 9) | (uint)(height & 511);
            GDTransport.cmd32(cmd);
        }

        public static void BitmapHandle(byte handle)
        {
            GDTransport.cmd32((uint)0x05000000 | handle);
        }

        public static void BitmapSize(Filter filter, Wrap wrapx, Wrap wrapy, ushort width, ushort height)
        {
            uint fxy = ((uint)filter << 2) | ((uint)wrapx << 1) | ((uint)wrapy);
            uint cmd = (0x08 << 24) | (uint)height | ((uint)width << 9) | (fxy << 18);
            GDTransport.cmd32(cmd);
        }

        public static void BlendFunc(Blend source, Blend destination)
        {
            uint cmd = (11 << 24) | ((uint)source << 3) | (uint)destination;
        }

        public static void Clear()
        {
            GDTransport.cmd32(0x26000007);
        }

        public static void ClearColorRGB(uint rgb)
        {
            GDTransport.cmd32(0x02000000 | (rgb & 0xffffff));
        }

        public static void ClearColorRGB(byte red, byte green, byte blue)
        {
            GDTransport.cmd32(blue, green, red, 2);
        }

        public static void ColorA(byte alpha)
        {
            GDTransport.cmd32((uint)0x10000000 | alpha);
        }

        public static void ColorMask(byte r, byte g, byte b, byte a)
        {
            uint cmd = (uint)((32 << 24) | ((r & 1) << 3) | ((g & 1) << 2) | ((b & 1) << 1) | ((a & 1) << 0));
            GDTransport.cmd32(cmd);
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

        public static void Display()
        {
            GDTransport.cmd32(0x00000000);
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

        public static void End()
        {
            GDTransport.cmd32(0x21000000);
        }

        public static void Gradient(ushort x0, ushort y0, uint rgb0, ushort x1, ushort y1, uint rgb1)
        {
            byte[] data = new byte[20];

            data[0] = 0x0b;
            data[1] = 0xff;
            data[2] = 0xff;
            data[3] = 0xff;
            data[4] = (byte)x0;
            data[5] = (byte)(x0 >> 8);
            data[6] = (byte)y0;
            data[7] = (byte)(y0 >> 8);
            data[8] = (byte)rgb0;
            data[9] = (byte)(rgb0 >> 8);
            data[10] = (byte)(rgb0 >> 16);
            data[11] = (byte)(rgb0 >> 24);
            data[12] = (byte)x1;
            data[13] = (byte)(x1 >> 8);
            data[14] = (byte)y1;
            data[15] = (byte)(y1 >> 8);
            data[16] = (byte)rgb1;
            data[17] = (byte)(rgb1 >> 8);
            data[18] = (byte)(rgb1 >> 16);
            data[19] = (byte)(rgb1 >> 24);

            GDTransport.cmd(data);
        }

        public static void LineWidth(ushort width)
        {
            GDTransport.cmd32((14 << 24) | width);
        }

        public static void Load(string path)
        {

        }

        public static void Load(byte[] data)
        {
            GDTransport.cmd(data);
        }

        public static void LoadImage(uint ptr, uint options)
        {
            byte[] data = new byte[12];

            data[0] = 0x24;
            data[1] = 0xff;
            data[2] = 0xff;
            data[3] = 0xff;
            data[4] = (byte)ptr;
            data[5] = (byte)(ptr >> 8);
            data[6] = (byte)(ptr >> 16);
            data[7] = (byte)(ptr >> 24);
            data[8] = (byte)options;
            data[9] = (byte)(options >> 8);
            data[10] = (byte)(options >> 16);
            data[11] = (byte)(options >> 24);

            GDTransport.cmd(data);
        }

        public static void Memset(uint ptr, byte value, uint num)
        {
            byte[] data = new byte[16];

            data[0] = 0x1b;
            data[1] = 0xff;
            data[2] = 0xff;
            data[3] = 0xff;
            data[4] = (byte)ptr;
            data[5] = (byte)(ptr >> 8);
            data[6] = (byte)(ptr >> 16);
            data[7] = (byte)(ptr >> 24);
            data[8] = value;
            //data[9] = 0;
            //data[10] = 0;
            //data[11] = 0;
            data[12] = (byte)num;
            data[13] = (byte)(num >> 8);
            data[14] = (byte)(num >> 16);
            data[15] = (byte)(num >> 24);

            GDTransport.cmd(data);
        }

        public static void Rotate(int angle)
        {
            GDTransport.free(8);
            GDTransport.cmd32(0xffffff29);
            GDTransport.cmd32(angle);
        }

        public static void SaveContext()
        {
            GDTransport.cmd32((uint)(34 << 24));
        }

        public static void SetMatrix()
        {
            GDTransport.cmd32(0xffffff2a);
        }

        public static void Scale(int sx, int sy)
        {
            GDTransport.free(12);
            GDTransport.cmd32(0xffffff28);
            GDTransport.cmd32(sx);
            GDTransport.cmd32(sy);
        }

        public static void ScissorSize(ushort width, ushort height)
        {
            uint cmd = (uint)((28 << 24) | (width << 10) | height);
            GDTransport.cmd32(cmd);
        }

        public static void ScissorXY(ushort x, ushort y)
        {
            GDTransport.cmd32((27 << 24) | ((x & 511) << 9) | (y & 511));
        }

        public static void StencilFunc(CompareFunc func, byte reference, byte mask)
        {
            GDTransport.cmd32((10 << 24) | ((byte)func << 16) | ((reference & 255) << 8) | (mask & 255));
        }

        public static void StencilMask(byte mask)
        {
            GDTransport.cmd32((19 << 24) | (mask & 255));
        }

        public static void StencilOp(StencilOperation sfail, StencilOperation spass)
        {
            GDTransport.cmd32((12 << 24) | ((byte)sfail << 3) | (byte)spass);
        }

        public static void Translate(int tx, int ty)
        {
            GDTransport.free(12);
            GDTransport.cmd32(0xffffff27);
            GDTransport.cmd32(tx);
            GDTransport.cmd32(ty);
        }

        public static void Play(Instrument instrument, byte note)
        {
            GDTransport.wr16(GPU_Registers.SOUND, (ushort)(((int)note << 8) | (int)instrument));
            GDTransport.wr8(GPU_Registers.PLAY, 1);
        }

        public static void PointSize(ushort size)
        {
            GDTransport.cmd32((uint)0x0D000000 | size);
        }

        public static void RestoreContext()
        {
            GDTransport.cmd32(0x23000000);
        }

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

        public static void SelfCalibrate()
        {
            GDTransport.cmd32(0xffffff00);//CMD_DLSTART
            Clear();
            DisplayText(240, 100, 30, Options.CenterX, "Please tap on the dot");

            GDTransport.cmd32ffffff(0x15);
            GDTransport.cmd32ffffff(0xff);

            GDTransport.finish();
            //GDTransport.cmd32(0xffffff26);//CMD_LOADIDENTITY
            GDTransport.cmd32(0xffffff00);//CMD_DLSTART
        }

        public static void Sketch(ushort x, ushort y, ushort w, ushort h, uint ptr, PixelFormat format)
        {
            byte[] data = new byte[20];

            data[0] = 0x30;
            data[1] = 0xff;
            data[2] = 0xff;
            data[3] = 0xff;
            data[4] = (byte)x;
            data[5] = (byte)(x >> 8);
            data[6] = (byte)y;
            data[7] = (byte)(y >> 8);
            data[8] = (byte)w;
            data[9] = (byte)(w >> 8);
            data[10] = (byte)h;
            data[11] = (byte)(h >> 8);
            data[12] = (byte)ptr;
            data[13] = (byte)(ptr >> 8);
            data[14] = (byte)(ptr >> 16);
            data[15] = (byte)(ptr >> 24);
            data[16] = (byte)format;
            //data[17] = 0;
            //data[18] = 0;
            //data[19] = 0;

            GDTransport.cmd(data);
        }

        public static void Swap()
        {
            GDTransport.cmd32(0x00000000);//DL_DISPLAY
            GDTransport.cmd32(0xffffff01);//CMD_SWAP

            GDTransport.finish();

            GDTransport.cmd32(0xffffff00);//CMD_DLSTART
            //GDTransport.cmd32(0xffffff26);//CMD_LOADIDENTITY
        }

        public static void TagMask(byte mask)
        {
            GDTransport.cmd32((uint)0x14000000 | mask);
        }

        public static void Tag(byte s)
        {
            GDTransport.cmd32((uint)0x03000000 | s);
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

        public static void Vertex2ii(ushort x, ushort y, byte handle, byte cell)
        {
            uint _x = (uint)((x & 511) << 21);
            uint _y = (uint)((y & 511) << 12);
            uint cmd = (uint)(2 << 29) * 2;
            GDTransport.cmd32(cmd | _x | _y | cell | ((uint)handle << 7));
        }
    }
}
