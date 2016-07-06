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

        private static byte[] size3 = new byte[3];
        private static byte[] size4 = new byte[4];
        private static byte[] size5 = new byte[5];
        private static byte[] size6 = new byte[6];
        private static byte[] size6r = new byte[6];
        private static byte[] size7 = new byte[7];
        private static byte[] size8 = new byte[8];

        private static byte[] cmd_buffer = new byte[2048+3];
        private static int cmd_ptr = 3;

        public static bool FTDI81X = false;

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

        public static void wr8(GPU_Registers_810 addr, byte v)
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
        public static void wr16(GPU_Registers_810 addr, ushort v)
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

        public static void wr32(GPU_Registers addr, uint v)
        {
            wr32((UInt32)addr, v);
        }

        public static void wr32(GPU_Registers_810 addr, uint v)
        {
            wr32((UInt32)addr, v);
        }

        public static void wr32(UInt32 addr, uint v)
        {
            size7[0] = (byte)((addr >> 16) | 0x80);
            size7[1] = (byte)(addr >> 8);
            size7[2] = (byte)addr;
            size7[3] = (byte)v;
            size7[4] = (byte)(v >> 8);
            size7[5] = (byte)(v >> 16);
            size7[6] = (byte)(v >> 24);

            spiDevice.Write(size7);
        }

        public static byte rd(GPU_Registers addr)
        {
            return rd((UInt32)addr);
        }

        public static byte rd(GPU_Registers_810 addr)
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

        public static int rd32(UInt32 addr)
        {
            size3[0] = (byte)(addr >> 16);
            size3[1] = (byte)(addr >> 8);
            size3[2] = (byte)addr;

            spiDevice.WriteRead(size3, size8);

            return size8[4] | (size8[5] << 8) | (size8[6] << 16) | (size8[7] << 24);
        }

        public static byte[] rd_n(GPU_Registers addr, ushort n)
        {
            return rd_n((UInt32)addr, n);
        }

        public static byte[] rd_n(GPU_Registers_810 addr, ushort n)
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

        public static void free(int amount)
        {
            if (amount > cmd_buffer.Length - 3) throw new Exception("Not enough free space.");
            if (cmd_ptr + amount > cmd_buffer.Length - 3) finish();
        }
        
        public static void cmd32(uint cmd)
        {
            // check to make sure we have enough room in the cmd_buffer
            if (cmd_ptr + 4 > cmd_buffer.Length - 3) finish();

            byte[] b = BitConverter.GetBytes(cmd);
            Array.Copy(b, 0, cmd_buffer, cmd_ptr, 4);

            cmd_ptr += 4;
        }

        public static void cmd32(int cmd)
        {
            // check to make sure we have enough room in the cmd_buffer
            if (cmd_ptr + 4 > cmd_buffer.Length - 3) finish();

            byte[] b = BitConverter.GetBytes(cmd);
            Array.Copy(b, 0, cmd_buffer, cmd_ptr, 4);

            cmd_ptr += 4;
        }

        public static void cmd(byte[] data, int size)
        {
            int remaining = size;
            int offset = 0;

            while (remaining > 0)
            {
                int length = (int)System.Math.Min(cmd_buffer.Length - cmd_ptr, remaining);
                Array.Copy(data, offset, cmd_buffer, cmd_ptr, length);

                cmd_ptr += length;
                if (cmd_ptr == cmd_buffer.Length) finish();

                remaining -= length;
                offset += length;
            }

            while ((cmd_ptr - 3) % 4 != 0) cmd_ptr++;
        }

        public static void cmd(byte[] data)
        {
            int remaining = data.Length;
            int offset = 0;

            while (remaining > 0)
            {
                int length = (int)System.Math.Min(cmd_buffer.Length - cmd_ptr, remaining);
                Array.Copy(data, offset, cmd_buffer, cmd_ptr, length);

                cmd_ptr += length;
                if (cmd_ptr == cmd_buffer.Length) finish();

                remaining -= length;
                offset += length;
            }

            while ((cmd_ptr - 3) % 4 != 0) cmd_ptr++;
        }

        public static void align()
        {
            while ((cmd_ptr - 3) % 4 != 0) cmd_ptr++;
        }

        public static void cmd32ffffff(byte d0)
        {
            cmd32(0xffffff00 | d0);
        }

        public static void cmd16(ushort cmd)
        {
            byte[] b = BitConverter.GetBytes(cmd);
            Array.Copy(b, 0, cmd_buffer, cmd_ptr, 2);

            cmd_ptr += 2;
        }

        public static void cmd16(short cmd)
        {
            byte[] b = BitConverter.GetBytes(cmd);
            Array.Copy(b, 0, cmd_buffer, cmd_ptr, 2);

            cmd_ptr += 2;
        }

        public static void finish_unsafe()
        {
            int addr = (0x108000 + (wp & 0xfff));   // #define RAM_CMD               0x108000UL
            if (FTDI81X) addr += 0x200000;

            wp = wp + cmd_ptr - 3;
            if (wp >= 4096) wp -= 4096;

            cmd_buffer[0] = (byte)(0x80 | (addr >> 16));
            cmd_buffer[1] = (byte)(addr >> 8);
            cmd_buffer[2] = (byte)addr;

            spiDevice.Write(cmd_buffer);

            cmd_ptr = 3;

            wp &= 0xffc;
            wr16((FTDI81X ? (uint)GPU_Registers_810.CMD_WRITE : 1058024), (ushort)wp);  // #define REG_CMD_WRITE        1058024UL
        }

        public static void finish()
        {
            /*int addr = (0x108000 + (wp & 0xfff));   // #define RAM_CMD               0x108000UL

            wp = wp + cmd_ptr - 3;
            if (wp >= 4096) wp -= 4096;

            cmd_buffer[0] = (byte)(0x80 | (addr >> 16));
            cmd_buffer[1] = (byte)(addr >> 8);
            cmd_buffer[2] = (byte)addr;

            spiDevice.Write(cmd_buffer);

            cmd_ptr = 3;

            wp &= 0xffc;
            wr16(1058024, (ushort)wp);*/  // #define REG_CMD_WRITE        1058024UL
            finish_unsafe();
            while (rp() != wp) ;
        }

        public static void hostcmd(byte a)
        {
            spiDevice.Write(new byte[] { a, 0, 0 });
            System.Threading.Thread.Sleep(60);
        }

        public static ushort get_wp()
        {
            if (FTDI81X) return __rd16((uint)GPU_Registers_810.CMD_WRITE);
            else return __rd16(0x1024e8);    // #define REG_CMD_WRITE         0x1024e8UL
        }

        public static ushort rp()
        {
            ushort r = __rd16(FTDI81X ? (uint)GPU_Registers_810.CMD_READ : 1058020);    // #define REG_CMD_READ         1058020UL
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

    public enum GPU_Registers_810 : uint
    {
        PCLK = 0x302000 + 0x70,
        PCLK_POL = 0x302000 + 0x6C,
        CSPREAD = 0x302000 + 0x68,
        SWIZZLE = 0x302000 + 0x64,
        DITHER = 0x302000 + 0x60,
        OUTBITS = 0x302000 + 0x5C,
        DLSWAP = 0x302000 + 0x54,
        ROTATE = 0x302000 + 0x58,
        VSYNC1 = 0x302000 + 0x50,
        VSYNC0 = 0x302000 + 0x4C,
        VSIZE = 0x302000 + 0x48,
        VOFFSET = 0x302000 + 0x44,
        VCYCLE = 0x302000 + 0x40,
        HSYNC1 = 0x302000 + 0x3C,
        HSYNC0 = 0x302000 + 0x38,
        HSIZE = 0x302000 + 0x34,
        HOFFSET = 0x302000 + 0x30,
        HCYCLE = 0x302000 + 0x2C,
        TAG = 0x302000 + 0x7C,
        TAGY = 0x302000 + 0x78,
        TAGX = 0x302000 + 0x74,
        PLAY = 0x302000 + 0x8C,
        SOUND = 0x302000 + 0x88,
        VOL_SOUND = 0x302000 + 0x84,
        VOL_PB = 0x302000 + 0x80,
        PLAYBACK_PLAY = 0x302000 + 0xCC,
        PLAYBACK_LOOP = 0x302000 + 0xC8,
        PLAYBACK_FORMAT = 0x302000 + 0xC4,
        PLAYBACK_FREQ = 0x302000 + 0xC0,
        PLAYBACK_READPTR = 0x302000 + 0xBC,
        PLAYBACK_LENGTH = 0x302000 + 0xB8,
        PLAYBACK_START = 0x302000 + 0xB4,
        TOUCH_CONFIG = 0x302000 + 0x168,
        TOUCH_TRANSFORM_F = 0x302000 + 0x164,
        TOUCH_TRANSFORM_E = 0x302000 + 0x160,
        TOUCH_TRANSFORM_D = 0x302000 + 0x15C,
        TOUCH_TRANSFORM_C = 0x302000 + 0x158,
        TOUCH_TRANSFORM_B = 0x302000 + 0x154,
        TOUCH_TRANSFORM_A = 0x302000 + 0x150,
        TOUCH_MODE = 0x302000 + 0x104,
        TOUCH_ADC_MODE = 0x302000 + 0x108,
        TOUCH_CHARGE = 0x302000 + 0x10C,
        TOUCH_SETTLE = 0x302000 + 0x110,
        TOUCH_OVERSAMPLE = 0x302000 + 0x114,
        TOUCH_RZTHRESH = 0x302000 + 0x118,
        TOUCH_RAW_XY = 0x302000 + 0x11C,
        TOUCH_RZ = 0x302000 + 0x120,
        TOUCH_SCREEN_XY = 0x302000 + 0x124,
        TOUCH_TAG_XY = 0x302000 + 0x128,
        TOUCH_TAG = 0x302000 + 0x12C,
        TOUCH_DIRECT_Z1Z2 = 0x302000 + 0x190,
        TOUCH_DIRECT_XY = 0x302000 + 0x18C,
        CMD_DL = 0x302000 + 0x100,
        CMD_WRITE = 0x302000 + 0xFC,
        CMD_READ = 0x302000 + 0xF8,
        CMDB_SPACE = 0x302000 + 0x574,
        CMDB_WRITE = 0x302000 + 0x568,
        TRACKER = 0x302000 + 0x7000,
        TRACKER_1 = 0x302000 + 0x7004,
        TRACKER_2 = 0x302000 + 0x7008,
        TRACKER_3 = 0x302000 + 0x700C,
        TRACKER_4 = 0x302000 + 0x7010,
        MEDIAFIFO_READ = 0x302000 + 0x7014,
        MEDIAFIFO_WRITE = 0x302000 + 0x7018,
        CPURESET = 0x302000 + 0x20,
        PWM_DUTY = 0x302000 + 0xD4,
        PWM_HZ = 0x302000 + 0xD0,
        INT_MASK = 0x302000 + 0xB0,
        INT_EN = 0x302000 + 0xAc,
        INT_FLAGS = 0x302000 + 0xA8,
        GPIO_DIR = 0x302000 + 0x90,
        GPIO = 0x302000 + 0x94,
        GPIOX_DIR = 0x302000 + 0x98,
        GPIOX = 0x302000 + 0x9C,
        FREQUENCY = 0x302000 + 0x0C,
        CLOCK = 0x302000 + 0x08,
        FRAMES = 0x302000 + 0x04,
        ID = 0x302000 + 0x00,
        TRIM = 0x10256C,
        SPI_WIDTH = 0x180
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
