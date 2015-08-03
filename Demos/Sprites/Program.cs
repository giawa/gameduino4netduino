﻿using Gameduino;
using System;
using System.Runtime.InteropServices;

namespace Sprites
{
    public class Program
    {
        private static byte[] sprites = new byte[2001 * 4];

        public static unsafe void Main()
        {
            GD2.Init();
            GD2.Load(data);

            // Pre-calculate the sprite placement data
            // This is identical to making individual calls to Vertex2ii
            for (uint i = 0; i < 2001; i++)
            {
                ushort x = GD2.Random(480 - 16);
                ushort y = GD2.Random(272 - 16);

                uint cell = i % 47;
                uint _x = (uint)((x & 511) << 21);
                uint _y = (uint)((y & 511) << 12);
                uint cmd = (uint)(2 << 29) * 2 | _x | _y | cell;

                sprites[i * 4 + 0] = (byte)cmd;
                sprites[i * 4 + 1] = (byte)(cmd >> 8);
                sprites[i * 4 + 2] = (byte)(cmd >> 16);
                sprites[i * 4 + 3] = (byte)(cmd >> 24);
            }

            DateTime now = DateTime.Now;

            while (true)
            {
                TimeSpan diff = DateTime.Now - now;
                int milliseconds = (((diff.Hours * 60) + diff.Minutes) * 60 + diff.Seconds) * 1000 + diff.Milliseconds;
                int nspr = Math.Min(2001, Math.Max(256, milliseconds >> 1));

                GD2.Clear();
                GD2.Begin(GD2.Primitive.Bitmaps);

                // the Netduino is *way* too slow to do the Gameduino 2 sample
                // so we have to improvise!  Let's just rotate the bitmaps
                // around their center to provide some movement frame to frame
                // TODO:  Modify this when we get AOT compilation in the future!
                GD2.LoadIdentity();
                GD2.Translate(65536 * 8, 65536 * 8);
                GD2.Rotate((milliseconds << 6) & 0xffff);
                GD2.Translate(-65536 * 8, -65536 * 8);
                GD2.SetMatrix();
                GDTransport.cmd(sprites, nspr * 4);

                // now lets draw how many sprites we are currently rendering
                GD2.LoadIdentity();
                GD2.ColorRGB(0x000000);
                GD2.ColorA(140);
                GD2.LineWidth(28 * 16);
                GD2.Begin(GD2.Primitive.Lines);
                GD2.Vertex2ii(240 - 110, 136, 0, 0);
                GD2.Vertex2ii(240 + 110, 136, 0, 0);

                GD2.RestoreContext();

                GD2.DisplayText(215, 110, 31, GD2.Options.RightX, nspr.ToString());
                GD2.DisplayText(229, 110, 31, 0, "sprites");

                GD2.Swap();
            }
        }

        private static readonly byte[] data = new byte[] {
            0, 0, 0, 5, 0, 0, 0, 1, 16, 32, 0, 8, 16, 64, 0, 7, 34, 255, 255, 255,
            0, 0, 0, 0, 120, 156, 229, 92, 205, 106, 27, 201, 22, 110, 178, 82,
            32, 144, 187, 202, 120, 17, 152, 44, 102, 21, 152, 133, 152, 23, 16,
            89, 122, 49, 15, 224, 71, 24, 47, 253, 2, 109, 137, 1, 67, 188, 200,
            38, 139, 1, 13, 68, 55, 48, 216, 228, 46, 228, 133, 22, 6, 25, 188,
            50, 54, 52, 186, 12, 228, 10, 219, 224, 160, 196, 118, 6, 217, 198,
            22, 22, 56, 33, 99, 162, 91, 95, 157, 174, 174, 191, 83, 37, 103, 140,
            19, 59, 169, 194, 178, 212, 223, 119, 206, 169, 234, 238, 250, 57, 85,
            167, 59, 73, 46, 144, 154, 73, 150, 244, 234, 195, 228, 60, 25, 36,
            123, 73, 79, 252, 106, 139, 99, 86, 186, 155, 222, 75, 239, 167, 223,
            139, 191, 123, 233, 221, 180, 148, 250, 104, 125, 248, 125, 250, 125,
            128, 161, 164, 67, 56, 24, 115, 91, 253, 253, 233, 211, 254, 254, 220,
            150, 143, 106, 70, 8, 85, 140, 48, 74, 165, 136, 73, 223, 11, 148, 77,
            163, 115, 91, 177, 250, 163, 124, 253, 253, 80, 253, 85, 253, 250,
            251, 161, 250, 79, 159, 6, 234, 127, 129, 235, 115, 177, 116, 178, 82,
            31, 78, 236, 134, 209, 137, 221, 147, 149, 249, 165, 147, 21, 30, 157,
            233, 64, 122, 114, 145, 67, 231, 151, 58, 203, 173, 238, 104, 84, 31,
            158, 172, 112, 140, 201, 197, 206, 242, 76, 7, 12, 216, 224, 112, 104,
            0, 163, 187, 93, 94, 243, 241, 82, 131, 24, 39, 43, 229, 181, 249, 37,
            31, 223, 216, 121, 120, 48, 125, 154, 125, 152, 62, 125, 120, 176,
            177, 227, 227, 11, 2, 47, 143, 8, 95, 96, 112, 104, 32, 121, 78, 154,
            240, 95, 142, 167, 79, 127, 57, 14, 227, 147, 199, 229, 209, 100, 16,
            95, 144, 37, 12, 89, 87, 26, 66, 210, 74, 67, 88, 154, 24, 49, 244,
            98, 169, 151, 234, 207, 0, 99, 86, 253, 241, 172, 94, 154, 214, 122,
            41, 131, 254, 71, 220, 183, 25, 221, 189, 12, 218, 76, 54, 147, 163,
            228, 189, 184, 199, 113, 135, 187, 247, 55, 208, 129, 64, 207, 69,
            126, 207, 48, 218, 192, 101, 27, 81, 248, 170, 193, 176, 165, 143, 60,
            92, 74, 231, 232, 32, 71, 219, 162, 188, 174, 180, 137, 54, 11, 92,
            73, 135, 209, 184, 236, 123, 217, 178, 125, 12, 105, 211, 193, 174,
            40, 45, 236, 160, 103, 162, 236, 222, 69, 115, 91, 11, 121, 235, 66,
            166, 123, 120, 110, 75, 75, 18, 86, 30, 149, 71, 39, 31, 79, 62, 106,
            14, 225, 232, 245, 128, 42, 76, 105, 233, 239, 219, 242, 102, 182,
            219, 9, 236, 207, 109, 153, 217, 180, 175, 89, 200, 253, 215, 161, 54,
            0, 153, 254, 235, 112, 11, 90, 16, 173, 15, 150, 195, 248, 139, 179,
            242, 232, 197, 89, 72, 3, 112, 212, 48, 164, 1, 245, 204, 62, 64, 222,
            47, 187, 102, 140, 107, 225, 87, 153, 208, 106, 199, 50, 242, 182, 31,
            78, 1, 180, 41, 242, 122, 242, 82, 180, 252, 84, 126, 119, 209, 117,
            217, 130, 232, 78, 239, 129, 103, 161, 47, 209, 182, 243, 17, 144,
            218, 233, 75, 171, 117, 247, 114, 84, 231, 129, 96, 168, 180, 46, 52,
            158, 123, 185, 103, 226, 142, 52, 89, 208, 250, 179, 220, 170, 41,
            109, 150, 176, 237, 88, 232, 25, 210, 74, 67, 47, 71, 206, 189, 250,
            169, 51, 208, 99, 107, 127, 29, 82, 83, 246, 219, 77, 235, 155, 141,
            226, 186, 100, 214, 55, 157, 228, 217, 19, 103, 24, 199, 233, 58, 226,
            155, 78, 250, 220, 154, 223, 28, 121, 231, 234, 154, 242, 238, 245,
            113, 237, 219, 12, 31, 53, 25, 60, 170, 25, 33, 84, 49, 226, 87, 238,
            186, 93, 215, 79, 76, 165, 198, 201, 74, 169, 17, 66, 38, 118, 91,
            221, 86, 55, 191, 254, 65, 188, 213, 229, 116, 96, 190, 144, 214, 158,
            85, 159, 85, 43, 213, 103, 204, 188, 226, 91, 199, 175, 67, 130, 135,
            50, 183, 21, 243, 175, 238, 167, 248, 187, 31, 240, 177, 8, 7, 118,
            159, 193, 239, 166, 223, 9, 252, 59, 169, 193, 151, 7, 10, 15, 147,
            24, 190, 247, 244, 157, 225, 95, 250, 12, 37, 125, 25, 252, 178, 250,
            99, 242, 154, 193, 163, 95, 62, 161, 253, 214, 135, 104, 187, 157,
            229, 201, 69, 166, 15, 64, 223, 119, 46, 102, 214, 71, 98, 198, 26,
            234, 95, 37, 222, 221, 238, 110, 51, 30, 98, 142, 119, 183, 71, 163,
            24, 14, 15, 51, 166, 127, 52, 138, 217, 151, 210, 44, 62, 185, 8, 203,
            245, 97, 119, 59, 140, 75, 116, 108, 253, 120, 124, 236, 249, 187,
            230, 73, 206, 218, 196, 200, 47, 124, 187, 170, 63, 195, 203, 189, 61,
            57, 126, 138, 239, 169, 61, 123, 203, 81, 49, 246, 202, 79, 57, 62,
            20, 28, 57, 170, 42, 84, 243, 228, 55, 48, 50, 169, 111, 64, 199, 96,
            27, 12, 42, 5, 122, 201, 252, 168, 98, 164, 202, 130, 252, 214, 54,
            172, 251, 51, 132, 172, 40, 65, 155, 205, 214, 53, 156, 219, 130, 151,
            242, 223, 143, 240, 76, 184, 249, 59, 225, 229, 17, 143, 19, 122, 242,
            17, 94, 80, 72, 195, 141, 72, 222, 184, 110, 165, 118, 178, 23, 97,
            180, 139, 185, 97, 8, 95, 23, 88, 72, 67, 91, 174, 27, 172, 139, 220,
            102, 25, 123, 82, 115, 59, 88, 134, 44, 199, 51, 185, 134, 230, 50,
            50, 41, 191, 151, 51, 218, 242, 206, 177, 173, 15, 242, 178, 241, 22,
            178, 252, 158, 89, 151, 127, 92, 29, 179, 66, 251, 158, 96, 220, 240,
            121, 96, 146, 96, 157, 47, 140, 162, 175, 11, 51, 128, 242, 24, 218,
            9, 214, 239, 248, 22, 182, 177, 19, 66, 73, 14, 216, 134, 92, 41, 224,
            208, 254, 254, 70, 190, 138, 224, 163, 180, 106, 168, 86, 23, 108,
            156, 218, 181, 198, 121, 219, 208, 128, 181, 219, 79, 173, 213, 87,
            149, 154, 211, 167, 210, 183, 247, 253, 123, 145, 208, 55, 162, 245,
            201, 255, 174, 31, 213, 204, 253, 202, 129, 228, 100, 57, 163, 64,
            105, 101, 93, 156, 191, 38, 176, 28, 29, 40, 13, 132, 106, 70, 222,
            187, 231, 22, 148, 172, 197, 48, 60, 57, 218, 85, 192, 29, 233, 104,
            176, 180, 91, 242, 78, 233, 61, 251, 94, 253, 139, 59, 139, 69, 191,
            138, 148, 89, 217, 67, 229, 172, 45, 207, 253, 125, 231, 12, 200, 163,
            245, 97, 121, 36, 16, 66, 205, 115, 132, 187, 1, 242, 205, 34, 103,
            142, 167, 157, 25, 247, 157, 102, 88, 22, 104, 108, 166, 171, 196,
            206, 223, 50, 75, 158, 175, 97, 12, 213, 140, 88, 250, 26, 175, 188,
            76, 98, 142, 101, 100, 31, 173, 15, 53, 234, 174, 51, 210, 209, 250,
            112, 234, 240, 89, 149, 80, 57, 123, 43, 80, 172, 58, 10, 249, 180,
            200, 179, 246, 238, 130, 150, 49, 25, 182, 133, 180, 86, 31, 194, 187,
            70, 230, 246, 45, 164, 206, 34, 7, 106, 24, 65, 53, 35, 132, 74, 70,
            20, 189, 201, 233, 100, 197, 204, 62, 138, 254, 85, 229, 250, 208,
            246, 127, 212, 209, 238, 54, 252, 35, 160, 200, 182, 172, 58, 138,
            140, 245, 35, 115, 13, 201, 70, 21, 195, 181, 79, 218, 187, 219, 176,
            229, 251, 95, 56, 166, 51, 95, 195, 24, 170, 25, 177, 179, 116, 243,
            252, 190, 79, 79, 88, 37, 138, 161, 24, 37, 67, 12, 160, 24, 125, 121,
            6, 80, 244, 226, 189, 89, 78, 135, 148, 29, 208, 252, 128, 246, 209,
            77, 134, 41, 75, 243, 12, 115, 182, 166, 100, 177, 87, 165, 70, 9, 27,
            213, 199, 129, 152, 51, 57, 53, 63, 224, 230, 134, 215, 34, 113, 43,
            246, 54, 234, 175, 216, 155, 248, 32, 223, 119, 225, 25, 122, 101,
            125, 28, 99, 220, 202, 250, 69, 24, 227, 234, 49, 158, 49, 110, 253,
            254, 34, 140, 216, 40, 126, 125, 24, 30, 202, 238, 201, 91, 104, 50,
            8, 51, 138, 145, 55, 136, 99, 20, 14, 239, 33, 250, 227, 54, 163, 123,
            150, 179, 161, 214, 198, 105, 244, 125, 86, 197, 124, 192, 24, 253,
            83, 154, 33, 152, 26, 76, 134, 44, 147, 26, 187, 139, 255, 186, 156,
            249, 175, 154, 46, 127, 175, 230, 91, 144, 214, 115, 253, 254, 12,
            194, 153, 125, 48, 229, 151, 165, 150, 136, 172, 137, 167, 93, 151, 0,
            214, 77, 134, 137, 163, 20, 105, 45, 168, 33, 47, 161, 87, 190, 166,
            24, 119, 172, 249, 177, 252, 93, 160, 201, 166, 24, 177, 55, 205, 44,
            127, 43, 70, 150, 28, 137, 30, 224, 200, 204, 242, 119, 86, 224, 189,
            238, 182, 220, 187, 44, 178, 252, 157, 21, 250, 215, 133, 190, 117,
            51, 203, 223, 205, 11, 150, 175, 72, 52, 118, 248, 199, 53, 142, 253,
            137, 24, 94, 30, 93, 78, 254, 178, 246, 175, 90, 62, 54, 6, 97, 21, 2,
            235, 24, 33, 198, 198, 142, 90, 7, 225, 101, 49, 2, 34, 186, 1, 217,
            214, 65, 35, 173, 90, 71, 1, 230, 51, 72, 30, 35, 112, 124, 5, 53, 84,
            62, 66, 41, 50, 36, 180, 190, 138, 248, 46, 142, 97, 162, 62, 195, 69,
            93, 6, 226, 194, 176, 110, 235, 70, 168, 168, 243, 180, 177, 243, 248,
            204, 150, 70, 126, 124, 166, 113, 58, 115, 33, 121, 85, 179, 144, 125,
            159, 113, 53, 43, 200, 104, 29, 49, 205, 177, 251, 67, 51, 194, 40,
            102, 229, 83, 135, 161, 253, 227, 68, 197, 72, 196, 102, 0, 189, 60,
            250, 145, 221, 125, 153, 58, 20, 232, 251, 100, 79, 252, 231, 118,
            255, 133, 108, 171, 139, 29, 24, 79, 135, 210, 60, 40, 53, 164, 103,
            50, 112, 24, 171, 10, 47, 175, 181, 186, 229, 181, 2, 95, 181, 229,
            133, 93, 196, 136, 13, 100, 57, 2, 22, 100, 230, 234, 208, 44, 172,
            184, 145, 105, 95, 40, 141, 243, 100, 115, 111, 151, 141, 245, 153,
            219, 186, 253, 118, 110, 43, 140, 78, 30, 139, 185, 244, 107, 201,
            240, 108, 96, 149, 55, 182, 143, 2, 89, 48, 184, 245, 84, 83, 214, 95,
            7, 86, 178, 106, 45, 214, 69, 55, 118, 76, 73, 78, 22, 177, 159, 252,
            10, 242, 237, 183, 229, 209, 47, 199, 161, 245, 97, 200, 134, 122,
            230, 185, 173, 236, 3, 36, 57, 236, 115, 165, 201, 197, 216, 142, 228,
            228, 226, 76, 7, 94, 115, 136, 65, 145, 189, 97, 70, 169, 129, 168,
            221, 139, 50, 248, 178, 40, 198, 252, 82, 119, 123, 234, 16, 17, 192,
            46, 7, 140, 249, 165, 153, 14, 180, 240, 12, 148, 179, 188, 6, 70,
            103, 25, 123, 176, 110, 20, 177, 194, 59, 203, 212, 207, 185, 123,
            208, 176, 80, 94, 35, 20, 119, 138, 191, 71, 13, 13, 243, 75, 106,
            148, 242, 113, 42, 35, 105, 231, 98, 152, 21, 3, 153, 67, 175, 46,
            209, 29, 172, 70, 23, 180, 94, 31, 215, 241, 159, 62, 62, 185, 136,
            190, 29, 43, 44, 173, 238, 76, 199, 143, 0, 191, 172, 126, 205, 224,
            81, 98, 44, 236, 220, 126, 203, 69, 134, 106, 70, 246, 33, 214, 210,
            22, 118, 194, 209, 159, 132, 103, 31, 98, 56, 245, 123, 49, 52, 84,
            122, 85, 59, 138, 80, 143, 105, 249, 210, 169, 50, 251, 108, 182, 194,
            245, 235, 114, 239, 179, 130, 117, 218, 234, 131, 170, 199, 104, 11,
            143, 97, 47, 201, 30, 84, 123, 240, 83, 252, 8, 130, 30, 141, 140,
            149, 89, 48, 24, 121, 26, 27, 165, 133, 160, 253, 54, 157, 181, 216,
            185, 195, 60, 53, 182, 58, 69, 115, 173, 24, 30, 215, 143, 52, 110,
            110, 6, 244, 250, 94, 223, 80, 42, 53, 202, 107, 19, 187, 120, 254,
            163, 188, 198, 245, 207, 132, 34, 130, 134, 99, 148, 26, 243, 75, 229,
            53, 194, 253, 190, 25, 210, 120, 46, 4, 12, 232, 25, 141, 108, 13, 52,
            47, 83, 235, 186, 200, 246, 10, 50, 228, 205, 117, 97, 250, 109, 90,
            152, 95, 66, 233, 148, 236, 196, 174, 219, 191, 66, 130, 44, 163, 20,
            182, 52, 141, 90, 100, 83, 253, 209, 108, 86, 149, 141, 214, 159, 81,
            67, 148, 28, 181, 83, 199, 180, 60, 216, 224, 232, 239, 177, 253, 243,
            235, 154, 122, 105, 172, 127, 195, 58, 74, 138, 253, 157, 89, 110,
            143, 29, 199, 49, 242, 165, 146, 101, 51, 104, 76, 165, 222, 79, 106,
            168, 217, 254, 143, 66, 105, 124, 0, 3, 154, 76, 105, 219, 131, 74,
            61, 220, 245, 208, 76, 156, 247, 192, 204, 18, 186, 184, 41, 109, 107,
            8, 249, 168, 202, 3, 142, 249, 184, 55, 61, 97, 246, 29, 243, 14, 105,
            222, 20, 98, 196, 253, 127, 204, 49, 208, 63, 240, 79, 151, 41, 28,
            173, 55, 134, 227, 217, 178, 171, 194, 209, 203, 224, 233, 185, 16,
            58, 94, 254, 166, 167, 169, 67, 204, 210, 133, 255, 27, 72, 157, 229,
            169, 67, 172, 0, 4, 21, 172, 138, 49, 126, 175, 240, 171, 189, 84, 31,
            222, 73, 133, 246, 77, 62, 194, 171, 213, 189, 155, 222, 73, 37, 131,
            213, 48, 117, 120, 39, 93, 121, 55, 117, 88, 74, 185, 18, 180, 186,
            43, 239, 238, 228, 242, 216, 39, 244, 113, 72, 163, 4, 43, 239, 184,
            39, 24, 225, 117, 196, 228, 193, 128, 133, 16, 122, 179, 211, 194,
            206, 70, 254, 252, 24, 34, 229, 232, 155, 246, 207, 23, 118, 104, 213,
            80, 204, 188, 218, 216, 121, 67, 47, 128, 62, 93, 49, 30, 30, 60, 62,
            67, 150, 145, 152, 25, 190, 209, 74, 40, 124, 114, 146, 135, 207, 158,
            100, 226, 175, 141, 79, 100, 244, 22, 36, 111, 219, 6, 195, 180, 127,
            81, 219, 194, 186, 180, 77, 168, 107, 91, 90, 102, 108, 171, 186, 11,
            110, 38, 254, 218, 248, 164, 252, 117, 246, 240, 255, 36, 169, 168,
            11, 55, 43, 31, 64, 238, 86, 32, 87, 225, 23, 228, 159, 114, 22, 225,
            225, 179, 60, 30, 183, 144, 71, 124, 92, 202, 66, 92, 30, 223, 248,
            252, 185, 206, 113, 60, 253, 154, 242, 89, 161, 152, 149, 35, 250,
            102, 98, 215, 204, 229, 53, 98, 252, 154, 214, 135, 71, 79, 126, 124,
            250, 243, 211, 39, 191, 81, 254, 249, 233, 143, 79, 143, 158, 180,
            186, 10, 159, 58, 4, 254, 228, 183, 211, 198, 79, 127, 252, 244, 199,
            105, 227, 201, 111, 159, 134, 79, 236, 30, 61, 129, 246, 63, 127, 63,
            109, 156, 54, 254, 252, 29, 22, 254, 9, 14, 6, 80, 14, 143, 149, 191,
            213, 125, 49, 79, 12, 202, 64, 95, 204, 43, 220, 100, 80, 182, 81,
            147, 65, 217, 69, 53, 131, 178, 143, 42, 6, 101, 14, 53, 175, 227, 5,
            46, 249, 63, 74, 232, 215, 98, 79, 158, 160, 103, 12, 224, 3, 244,
            141, 144, 23, 253, 94, 150, 12, 120, 86, 68, 254, 178, 246, 101, 146,
            222, 223, 37, 228, 47, 99, 159, 234, 78, 35, 71, 168, 246, 196, 9, 91,
            184, 108, 253, 46, 158, 226, 113, 74, 165, 198, 76, 103, 98, 55, 196,
            32, 52, 188, 150, 75, 40, 63, 203, 5, 74, 171, 188, 156, 180, 150,
            141, 161, 254, 202, 46, 161, 240, 241, 9, 245, 203, 110, 162, 202, 35,
            231, 53, 115, 79, 56, 150, 26, 40, 51, 80, 172, 205, 113, 171, 31,
            132, 34, 74, 168, 60, 2, 195, 215, 64, 121, 156, 15, 4, 6, 158, 191,
            15, 95, 29, 172, 16, 127, 153, 40, 50, 21, 99, 31, 123, 250, 133, 223,
            223, 165, 157, 231, 233, 211, 23, 103, 200, 46, 67, 161, 253, 125,
            210, 223, 223, 7, 71, 51, 240, 204, 62, 161, 120, 250, 158, 226, 236,
            167, 79, 31, 159, 245, 95, 19, 254, 240, 160, 243, 17, 79, 213, 3,
            197, 243, 245, 96, 208, 167, 194, 97, 153, 62, 57, 188, 255, 186, 243,
            145, 244, 131, 225, 235, 167, 186, 189, 56, 11, 149, 79, 251, 246,
            124, 253, 244, 185, 163, 121, 104, 236, 28, 134, 176, 47, 144, 154,
            214, 19, 216, 70, 194, 190, 30, 90, 68, 120, 143, 18, 104, 184, 247,
            64, 12, 102, 169, 193, 239, 13, 18, 10, 255, 136, 219, 125, 84, 40,
            255, 244, 225, 21, 161, 182, 93, 246, 217, 36, 3, 101, 207, 73, 222,
            167, 92, 239, 103, 195, 105, 7, 122, 51, 176, 251, 44, 227, 205, 254,
            53, 10, 198, 249, 173, 58, 79, 215, 173, 58, 248, 121, 30, 89, 71, 17,
            122, 153, 119, 111, 13, 138, 168, 126, 245, 22, 1, 199, 190, 232, 49,
            233, 233, 146, 77, 62, 198, 96, 35, 127, 191, 15, 230, 33, 124, 4, 11,
            189, 135, 196, 142, 251, 116, 53, 100, 31, 194, 17, 12, 100, 33, 220,
            62, 245, 251, 171, 120, 124, 92, 124, 196, 248, 248, 158, 171, 221,
            55, 80, 179, 151, 240, 238, 19, 69, 136, 68, 202, 224, 61, 25, 227,
            225, 148, 217, 200, 69, 88, 22, 215, 175, 89, 220, 11, 14, 138, 179,
            143, 17, 152, 67, 233, 220, 210, 24, 203, 239, 47, 162, 247, 45, 53,
            112, 253, 75, 141, 219, 111, 93, 255, 156, 174, 173, 150, 183, 113,
            91, 250, 225, 1, 112, 115, 159, 81, 173, 254, 146, 124, 24, 183, 165,
            125, 11, 232, 253, 57, 244, 115, 166, 248, 29, 72, 239, 236, 81, 111,
            238, 113, 82, 51, 121, 41, 100, 131, 239, 46, 193, 44, 171, 62, 156,
            233, 196, 230, 149, 83, 135, 97, 60, 145, 111, 129, 137, 188, 27, 5,
            248, 251, 104, 252, 47, 240, 184, 252, 120, 253, 95, 78, 254, 170,
            211, 170, 124, 139, 213, 102, 96, 253, 117, 53, 127, 199, 85, 128, 33,
            174, 124, 33, 207, 221, 65, 152, 197, 73, 198, 170, 152, 65, 189, 246,
            165, 209, 254, 160, 131, 90, 130, 31, 95, 104, 183, 22, 243, 55, 183,
            171, 159, 123, 162, 185, 229, 242, 200, 47, 15, 34, 144, 20, 46, 122,
            157, 8, 110, 234, 226, 244, 143, 43, 159, 58, 130, 122, 211, 27, 168,
            248, 200, 38, 154, 231, 18, 203, 47, 207, 101, 211, 173, 87, 63, 252,
            253, 195, 223, 207, 143, 159, 31, 215, 14, 110, 189, 114, 81, 28, 125,
            243, 63, 202, 183, 94, 213, 14, 108, 14, 161, 181, 131, 31, 254, 222,
            61, 219, 61, 195, 247, 71, 111, 52, 67, 163, 144, 171, 29, 0, 51, 25,
            132, 214, 14, 192, 51, 25, 248, 3, 250, 232, 141, 41, 173, 112, 250,
            188, 245, 234, 249, 177, 43, 173, 112, 42, 9, 56, 116, 20, 191, 129,
            17, 234, 227, 100, 65, 161, 164, 17, 245, 53, 237, 233, 255, 132, 254,
            251, 79, 148, 80, 29, 131, 6, 147, 139, 242, 39, 9, 149, 239, 209, 27,
            93, 3, 133, 66, 90, 51, 80, 162, 221, 179, 231, 199, 46, 74, 12, 85,
            74, 194, 108, 84, 113, 84, 246, 177, 207, 153, 240, 38, 70, 238, 249,
            28, 28, 135, 231, 222, 89, 158, 219, 194, 12, 222, 28, 37, 128, 33,
            234, 10, 113, 87, 254, 60, 27, 222, 57, 189, 251, 17, 241, 85, 164,
            229, 175, 186, 139, 82, 124, 17, 24, 243, 75, 38, 131, 226, 178, 38,
            118, 241, 94, 17, 224, 120, 195, 6, 49, 76, 156, 80, 30, 135, 126,
            196, 118, 2, 245, 113, 98, 224, 189, 147, 60, 170, 117, 32, 3, 227,
            214, 47, 254, 170, 171, 243, 99, 214, 237, 91, 73, 52, 55, 86, 241,
            217, 238, 28, 195, 68, 145, 225, 107, 187, 79, 88, 217, 239, 31, 180,
            113, 68, 37, 40, 239, 156, 60, 116, 196, 150, 26, 6, 154, 249, 83,
            167, 197, 159, 240, 62, 173, 231, 183, 141, 167, 152, 114, 255, 198,
            159, 157, 133, 226, 199, 53, 227, 42, 163, 179, 175, 107, 170, 84, 91,
            93, 231, 217, 239, 60, 183, 186, 149, 170, 184, 54, 85, 249, 228, 119,
            254, 220, 72, 41, 45, 62, 51, 68, 138, 1, 31, 141, 4, 126, 94, 74,
            157, 55, 188, 101, 163, 17, 240, 52, 199, 85, 46, 120, 2, 79, 171,
            244, 100, 49, 93, 59, 75, 195, 64, 234, 159, 165, 213, 138, 188, 4,
            26, 37, 235, 179, 234, 77, 167, 146, 241, 82, 190, 125, 244, 92, 190,
            191, 231, 165, 70, 21, 3, 245, 24, 201, 132, 114, 51, 207, 255, 224,
            45, 52, 50, 182, 45, 245, 208, 111, 33, 85, 170, 149, 106, 120, 191,
            11, 119, 2, 82, 124, 71, 12, 251, 104, 149, 106, 47, 176, 111, 86, 49,
            162, 2, 125, 134, 137, 202, 119, 170, 218, 111, 112, 49, 143, 180,
            243, 231, 25, 53, 195, 62, 210, 206, 231, 177, 109, 75, 218, 60, 18,
            215, 255, 205, 38, 122, 191, 85, 108, 237, 154, 162, 243, 90, 93, 142,
            67, 173, 12, 109, 7, 12, 30, 173, 212, 136, 193, 224, 179, 178, 245,
            213, 40, 186, 212, 143, 176, 168, 84, 31, 212, 8, 127, 80, 171, 84,
            253, 40, 29, 27, 103, 222, 79, 104, 233, 15, 149, 94, 149, 47, 84,
            251, 248, 249, 185, 138, 244, 127, 68, 156, 132, 103 };
    }
}
