using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System;

namespace Gameduino
{
    public static class GDTransport
    {
        private static SPI spiDevice;

        private static int wp;

        private static byte[] size1 = new byte[1];
        private static byte[] size2 = new byte[2];
        private static byte[] size3 = new byte[3];
        private static byte[] size4 = new byte[4];
        private static byte[] size5 = new byte[5];
        private static byte[] size6 = new byte[6];
        private static byte[] size7 = new byte[7];
        private static byte[] size8 = new byte[8];

        private static byte[] size1r = new byte[1];
        private static byte[] size6r = new byte[6];
        private static byte[] size7r = new byte[7];

        public static void Init()
        {
            if (spiDevice != null) return;

            spiDevice = new SPI(new SPI.Configuration(Pins.GPIO_PIN_D8, false, 0, 0, false, true, 8000, SPI.SPI_module.SPI1));

            wp = get_wp();
            Debug.Print("Write pointer initialized at: " + wp);
        }

        public static void wr8(GPU_Registers addr, byte v)
        {
            wr8((UInt32)addr, v);
        }

        public static void wr8(UInt32 addr, byte v)
        {
            size4[0] = (byte)((addr >> 16) | 0x80);
            size4[1] = (byte)(addr >> 8);
            size4[2] = (byte)addr;
            size4[3] = v;

            spiDevice.Write(size4);
        }

        public static void wr16(GPU_Registers addr, ushort v)
        {
            wr16((UInt32)addr, v);
        }

        public static void wr16(UInt32 addr, ushort v)
        {
            size5[0] = (byte)((addr >> 16) | 0x80);
            size5[1] = (byte)(addr >> 8);
            size5[2] = (byte)addr;
            size5[3] = (byte)v;
            size5[4] = (byte)(v >> 8);

            spiDevice.Write(size5);
        }

        public static byte rd(GPU_Registers addr)
        {
            return rd((UInt32)addr);
        }

        public static byte rd(UInt32 addr)
        {
            size3[0] = (byte)(addr >> 16);
            size3[1] = (byte)(addr >> 8);
            size3[2] = (byte)addr;

            spiDevice.WriteRead(size3, size5);

            return size5[4];
        }

        public static byte[] rd_n(GPU_Registers addr, ushort n)
        {
            return rd_n((UInt32)addr, n);
        }

        public static byte[] rd_n(UInt32 addr, ushort n)
        {
            byte[] read = new byte[n];
            byte[] temp = new byte[n + 4];

            size3[0] = (byte)(addr >> 16);
            size3[1] = (byte)(addr >> 8);
            size3[2] = (byte)(addr);

            spiDevice.WriteRead(size3, temp);

            for (int i = 0; i < n; i++) read[i] = temp[i + 4];

            return read;
        }
        
        public static void cmd32(uint cmd)
        {
            int addr = (0x108000 + wp);   // #define RAM_CMD               0x108000UL

            wp = wp + 4;
            if (wp >= 4096) wp -= 4096;

            size7[0] = (byte)(0x80 | (addr >> 16));
            size7[1] = (byte)(addr >> 8);
            size7[2] = (byte)addr;
            size7[3] = (byte)cmd;
            size7[4] = (byte)(cmd >> 8);
            size7[5] = (byte)(cmd >> 16);
            size7[6] = (byte)(cmd >> 24);

            spiDevice.Write(size7);
        }

        public static void cmd(byte[] data)
        {
            int addr = (0x108000 + wp);   // #define RAM_CMD               0x108000UL

            wp = wp + data.Length;
            if (wp >= 4096) wp -= 4096;

            byte[] temp = new byte[data.Length + 3];
            temp[0] = (byte)(0x80 | (addr >> 16));
            temp[1] = (byte)(addr >> 8);
            temp[2] = (byte)addr;

            for (int i = 0; i < data.Length; i++) temp[i + 3] = data[i];

            spiDevice.Write(temp);
        }

        public static void cmd32(byte d0, byte d1, byte d2, byte d3)
        {
            //stream();
            int addr = (0x108000 + (wp & 0xfff));   // #define RAM_CMD               0x108000UL

            wp = wp + 4;
            if (wp >= 4096) wp -= 4096;

            size7[0] = (byte)(0x80 | (addr >> 16));
            size7[1] = (byte)(addr >> 8);
            size7[2] = (byte)addr;
            size7[3] = d0;
            size7[4] = d1;
            size7[5] = d2;
            size7[6] = d3;

            spiDevice.Write(size7);
        }

        public static void cmd32ffffff(byte d0)
        {
            cmd32(0xffffff00 | d0);
        }

        public static void finish()
        {
            wp &= 0xffc;
            wr16(1058024, (ushort)wp);  // #define REG_CMD_WRITE        1058024UL
            while (rp() != wp) ;
        }

        public static void hostcmd(byte a)
        {
            spiDevice.Write(new byte[] { a, 0, 0 });
            System.Threading.Thread.Sleep(60);
        }

        public static ushort get_wp()
        {
            return __rd16(0x1024e8);    // #define REG_CMD_WRITE         0x1024e8UL
        }

        public static ushort rp()
        {
            ushort r = __rd16(1058020);    // #define REG_CMD_READ         1058020UL
            if (r == 0xfff)
            {
                Debug.Print("Read pointer overflow!");
                for (; ; ) ;
            }
            return r;
        }

        private static ushort __rd16(uint addr)
        {
            ushort r;

            size6[0] = (byte)(addr >> 16);
            size6[1] = (byte)(addr >> 8);
            size6[2] = (byte)addr;

            for (int i = 3; i < 6; i++) size6[i] = 0;

            //spiDevice.WriteRead(size7, size7r);
            spiDevice.WriteRead(size6, size6r);

            r = (ushort)((size6r[5] << 8) | size6r[4]);
            //Debug.Print("rd16 = " + r);

            return r;
        }
    }

    public enum GPU_Registers : uint
    {
        CLOCK = 1057800,
        CMD_DL = 1058028,
        CMD_READ = 1058020,
        CMD_WRITE = 1058024,
        CPURESET = 1057820,
        CSPREAD = 1057892,
        DITHER = 1057884,
        DLSWAP = 1057872,
        FRAMES = 1057796,
        FREQUENCY = 1057804,
        GPIO = 1057936,
        GPIO_DIR = 1057932,
        HCYCLE = 1057832,
        HOFFSET = 1057836,
        HSIZE = 1057840,
        HSYNC0 = 1057844,
        HSYNC1 = 1057848,
        ID = 1057792,
        INT_EN = 1057948,
        INT_FLAGS = 1057944,
        INT_MASK = 1057952,
        MACRO_0 = 1057992,
        MACRO_1 = 1057996,
        OUTBITS = 1057880,
        PCLK = 1057900,
        PCLK_POL = 1057896,
        PLAY = 1057928,
        PLAYBACK_FORMAT = 1057972,
        PLAYBACK_FREQ = 1057968,
        PLAYBACK_LENGTH = 1057960,
        PLAYBACK_LOOP = 1057976,
        PLAYBACK_PLAY = 1057980,
        PLAYBACK_READPTR = 1057964,
        PLAYBACK_START = 1057956,
        PWM_DUTY = 1057988,
        PWM_HZ = 1057984,
        ROTATE = 1057876,
        SOUND = 1057924,
        SWIZZLE = 1057888,
        TAG = 1057912,
        TAG_X = 1057904,
        TAG_Y = 1057908,
        TOUCH_ADC_MODE = 1058036,
        TOUCH_CHARGE = 1058040,
        TOUCH_DIRECT_XY = 1058164,
        TOUCH_DIRECT_Z1Z2 = 1058168,
        TOUCH_MODE = 1058032,
        TOUCH_OVERSAMPLE = 1058048,
        TOUCH_RAW_XY = 1058056,
        TOUCH_RZ = 1058060,
        TOUCH_RZTHRESH = 1058052,
        TOUCH_SCREEN_XY = 1058064,
        TOUCH_SETTLE = 1058044,
        TOUCH_TAG = 1058072,
        TOUCH_TAG_XY = 1058068,
        TOUCH_TRANSFORM_A = 1058076,
        TOUCH_TRANSFORM_B = 1058080,
        TOUCH_TRANSFORM_C = 1058084,
        TOUCH_TRANSFORM_D = 1058088,
        TOUCH_TRANSFORM_E = 1058092,
        TOUCH_TRANSFORM_F = 1058096,
        TRACKER = 1085440,
        VCYCLE = 1057852,
        VOFFSET = 1057856,
        VOL_PB = 1057916,
        VOL_SOUND = 1057920,
        VSIZE = 1057860,
        VSYNC0 = 1057864,
        VSYNC1 = 1057868
    }
}
