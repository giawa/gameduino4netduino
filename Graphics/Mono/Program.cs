﻿using Gameduino;
using System;

namespace Mono
{
    public class Program
    {
        public static void Main()
        {
            GD2.Init();
            GD2.Load(mono);

            // clear the screen
            GD2.ClearColorRGB(0x375e03);
            GD2.Clear();

            // draw the bitmap itself
            GD2.Begin(GD2.Primitive.Bitmaps);
            GD2.ColorRGB(0x68b203);
            GD2.BitmapSize(GD2.Filter.Nearest, GD2.Wrap.Repeat, GD2.Wrap.Repeat, 480, 272);
            GD2.Vertex2ii(0, 0);

            GD2.Swap();
        }

        // replace with a file on the SD card eventually
        private static readonly byte[] mono = new byte[] { 0x0, 0x0, 0x0, 0x5, 0x0, 0x0, 0x0, 0x1, 0x80, 0x0, 0x1, 0x8, 0x80, 0x80, 0x10, 0x7, 0x22, 0xff, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0, 0x78, 0x9c, 0x55, 0x59, 0x5d, 0x8c, 0x15, 0xe7, 0x79, 0x9e, 0x1, 0x6c, 0xa7, 0x77, 0xf3, 0xcd, 0xf2, 0xef, 0x5e, 0x30, 0x73, 0x30, 0x6, 0xc3, 0x5, 0xbb, 0x6b, 0xab, 0x8d, 0xbd, 0x48, 0x5e, 0x6c, 0x59, 0x6a, 0xd, 0x95, 0xb1, 0x53, 0x37, 0x8a, 0xd, 0x32, 0x56, 0x9a, 0x5e, 0xd4, 0x26, 0x36, 0xaa, 0x65, 0xb5, 0x9, 0xb4, 0x9b, 0xb6, 0x69, 0x13, 0x19, 0x5c, 0x50, 0xaa, 0x54, 0x95, 0xbd, 0x29, 0x24, 0xb2, 0x52, 0x2b, 0x80, 0x42, 0x7e, 0x14, 0x79, 0x77, 0x5d, 0xc9, 0x60, 0x1c, 0xfb, 0xcc, 0xac, 0xa5, 0x6, 0x82, 0x81, 0x99, 0xe1, 0xa2, 0xe2, 0xd7, 0xcc, 0x9c, 0xbb, 0xd8, 0x31, 0xe6, 0x9c, 0x3e, 0xcf, 0xf3, 0x7e, 0xb3, 0xc6, 0x7, 0xd8, 0x65, 0xf7, 0xcc, 0xfb, 0xf7, 0xbc, 0xff, 0xef, 0x71, 0xce, 0xb9, 0xc3, 0x75, 0x89, 0x57, 0x5e, 0x64, 0x78, 0xe5, 0x4f, 0x45, 0x41, 0x10, 0x8d, 0x65, 0x79, 0x59, 0x36, 0x55, 0xd3, 0x1f, 0xcc, 0xbd, 0x4e, 0xa4, 0x69, 0x92, 0xb8, 0x34, 0x71, 0xb1, 0xb, 0xa2, 0xe8, 0xf, 0xca, 0xa6, 0x6e, 0x9a, 0xf3, 0xcf, 0x25, 0xa1, 0xb, 0xa3, 0xcd, 0xa0, 0xce, 0xca, 0x22, 0x27, 0x7d, 0x76, 0x34, 0x88, 0x2, 0xf7, 0x4a, 0x9e, 0x95, 0x55, 0x51, 0x35, 0xcd, 0x1c, 0xf9, 0xe5, 0x91, 0x34, 0x76, 0xf8, 0xb, 0x1e, 0xe, 0x24, 0x5b, 0xc1, 0xbc, 0x2e, 0xaf, 0x25, 0x11, 0x7e, 0x72, 0x5f, 0x80, 0x7c, 0x4f, 0x9d, 0x75, 0x3f, 0x70, 0xa1, 0xbb, 0xad, 0xc8, 0xca, 0xfc, 0xc4, 0xe8, 0x43, 0x6f, 0xf6, 0x7b, 0x9e, 0xfc, 0x93, 0xf1, 0x34, 0x4e, 0xe2, 0x94, 0x3a, 0x40, 0xbe, 0x8b, 0x67, 0xcb, 0xba, 0xac, 0xea, 0xb, 0x4e, 0x2f, 0xfc, 0x4, 0x5, 0xa, 0x19, 0xd0, 0x9d, 0xde, 0x92, 0xb8, 0x4d, 0xb0, 0xe3, 0xdc, 0x70, 0x1c, 0xdf, 0xf1, 0x7e, 0x4b, 0xff, 0x8f, 0x23, 0x20, 0x26, 0x3, 0xe7, 0xd2, 0xc8, 0x85, 0x4b, 0x9a, 0xba, 0xaa, 0xaa, 0x66, 0x9f, 0x8b, 0xa4, 0xcd, 0xe, 0xc8, 0x2f, 0x8a, 0x52, 0x0, 0x4c, 0xff, 0xdc, 0xd, 0x4d, 0x43, 0xfe, 0xb1, 0xd8, 0xc5, 0xc9, 0x6a, 0x4f, 0xff, 0xfb, 0x51, 0xa8, 0x8f, 0x17, 0xc4, 0x83, 0x43, 0xe8, 0x36, 0xc0, 0xb4, 0xa6, 0xb9, 0x36, 0x6c, 0xf2, 0xc3, 0x65, 0x75, 0x99, 0xe7, 0x65, 0x96, 0x89, 0x41, 0xf7, 0x85, 0x6f, 0x64, 0x60, 0xf6, 0x8, 0xa0, 0x71, 0xc9, 0xe, 0xa3, 0xbf, 0x30, 0x9a, 0xb8, 0x24, 0xd5, 0xb, 0xcf, 0x7, 0xee, 0x70, 0x59, 0xd7, 0x4d, 0xf5, 0xbb, 0x30, 0x8c, 0x89, 0xa8, 0x1b, 0x22, 0xfe, 0x85, 0x91, 0x67, 0xd3, 0xfc, 0x5e, 0x7c, 0x10, 0x42, 0xb7, 0x24, 0x5e, 0x78, 0xde, 0xe8, 0x47, 0x52, 0x4f, 0x4d, 0xfa, 0xf0, 0xb6, 0xba, 0x2e, 0xeb, 0xaa, 0x77, 0x0, 0xbe, 0x48, 0x48, 0x1f, 0xed, 0x26, 0x80, 0x79, 0x96, 0x7b, 0x6, 0x30, 0xff, 0xa8, 0xa9, 0x96, 0x8c, 0x79, 0xfd, 0x9, 0x1d, 0x19, 0x10, 0x7e, 0xb7, 0xa1, 0x84, 0xf1, 0x55, 0x33, 0x4e, 0x9d, 0x62, 0x72, 0x5c, 0xb, 0x3, 0xa0, 0x40, 0x2e, 0x6, 0xfc, 0x5e, 0xde, 0x1f, 0x88, 0x3c, 0x8d, 0x8f, 0x88, 0xc1, 0xa3, 0xc0, 0x2f, 0x49, 0xbd, 0xf9, 0xd1, 0x24, 0x62, 0xa3, 0x6e, 0x2e, 0xf3, 0x9, 0x45, 0x85, 0xbb, 0xa5, 0x6, 0x7e, 0xd9, 0x4d, 0xaf, 0xf, 0x60, 0xa4, 0x3, 0xeb, 0x38, 0x5d, 0x6d, 0x6, 0x48, 0x77, 0x3e, 0x9c, 0xb8, 0x68, 0x11, 0xa4, 0x23, 0x7a, 0x8e, 0x3a, 0x8f, 0x49, 0xe4, 0xa2, 0x49, 0xd0, 0x4b, 0x7a, 0x61, 0x1a, 0xbc, 0x15, 0x86, 0x62, 0x0, 0xa2, 0x97, 0xc5, 0x60, 0xfb, 0x4d, 0xfa, 0xaf, 0x6d, 0x44, 0xbf, 0xc5, 0xd1, 0x23, 0xfc, 0x55, 0xe0, 0x36, 0x50, 0xbe, 0x69, 0x0, 0x2e, 0x79, 0xfe, 0x1c, 0x1c, 0x1b, 0xc7, 0x10, 0x10, 0xa7, 0x8b, 0xe5, 0xc3, 0x8f, 0x62, 0x9a, 0x4a, 0xf8, 0x83, 0x68, 0xaf, 0xbc, 0xf7, 0xfb, 0x38, 0x4e, 0x28, 0x21, 0x66, 0x44, 0x2f, 0x29, 0x18, 0x41, 0xa4, 0x35, 0x5, 0x86, 0xc3, 0x20, 0x4, 0x83, 0x94, 0x2e, 0xdf, 0x2a, 0x5, 0xf6, 0xe1, 0x7, 0x22, 0xe0, 0xc2, 0x85, 0x8a, 0xfd, 0xe6, 0x2d, 0x1a, 0x9f, 0xb6, 0x3a, 0x1d, 0x2e, 0x10, 0x0, 0x66, 0x0, 0xd, 0x19, 0x76, 0x61, 0x48, 0xe1, 0x44, 0x6d, 0xa5, 0x7c, 0xf8, 0x9, 0x33, 0x7, 0xc2, 0x9c, 0xbb, 0x9d, 0xd4, 0x4d, 0x6f, 0x7b, 0x42, 0x86, 0x1d, 0xa3, 0xf, 0x37, 0x97, 0x45, 0x49, 0x7, 0x16, 0xa6, 0xc5, 0x38, 0xf1, 0x4b, 0xa5, 0xb3, 0x4b, 0xee, 0x93, 0x2, 0x3f, 0xf3, 0xde, 0x8f, 0x76, 0x48, 0xfd, 0x4f, 0xc8, 0x6e, 0x2e, 0xa4, 0x90, 0x43, 0x79, 0x5e, 0xc8, 0x85, 0x5, 0xbf, 0x4c, 0xc0, 0x4c, 0xbe, 0x6f, 0x71, 0x73, 0x4, 0x79, 0xdc, 0xbf, 0x31, 0x8e, 0x4, 0xc0, 0x93, 0x43, 0x55, 
            0x49, 0xfa, 0xff, 0x73, 0x73, 0xfa, 0xa7, 0x2e, 0x8, 0xc3, 0x19, 0x38, 0x80, 0x49, 0x58, 0x48, 0x91, 0xdf, 0x3a, 0x1a, 0x10, 0x93, 0x1e, 0x46, 0x9b, 0xf, 0x4f, 0xc5, 0xa, 0xa9, 0xe5, 0x88, 0xbd, 0xa6, 0xea, 0x4d, 0xcc, 0xc9, 0xb7, 0x10, 0x7c, 0x16, 0x0, 0x94, 0x84, 0x9e, 0x99, 0x58, 0x16, 0xcf, 0x33, 0x4d, 0x52, 0x99, 0x87, 0x27, 0x76, 0x93, 0xbe, 0xff, 0x3c, 0xcd, 0x8f, 0x9e, 0x45, 0xe8, 0x54, 0xcd, 0xa7, 0x89, 0xc0, 0xf7, 0xa, 0x26, 0x51, 0xb0, 0xac, 0x30, 0x62, 0xda, 0xf, 0x67, 0x9c, 0x61, 0x69, 0xf0, 0xea, 0xc5, 0xf1, 0x22, 0x42, 0xd8, 0xbb, 0x4c, 0x87, 0xd, 0xcd, 0x2a, 0xf8, 0x2e, 0x20, 0x76, 0xe6, 0xf8, 0x13, 0x81, 0xf9, 0x39, 0x6b, 0x8, 0x12, 0x8f, 0x1c, 0xca, 0x72, 0xf6, 0xe7, 0x48, 0x3f, 0x85, 0xc, 0x43, 0x3f, 0xdd, 0xd4, 0x1f, 0xf4, 0x9b, 0xc1, 0x7e, 0x48, 0x5c, 0x53, 0x37, 0xd0, 0xff, 0xfc, 0xbe, 0xa4, 0xe5, 0xde, 0x91, 0xfe, 0x61, 0xb0, 0xbb, 0x24, 0x31, 0xf1, 0x23, 0x90, 0x45, 0xbd, 0x9d, 0x95, 0x5, 0x2, 0x46, 0xa0, 0x62, 0x3c, 0xf4, 0x3f, 0x34, 0xe0, 0x3a, 0xfe, 0xbb, 0x3, 0x75, 0xab, 0xa9, 0xeb, 0x61, 0x17, 0x9b, 0xfa, 0x1d, 0x89, 0x87, 0xb2, 0xb7, 0x17, 0xc2, 0x8e, 0x7f, 0xf9, 0xaa, 0xae, 0x24, 0x42, 0xd8, 0x3f, 0x71, 0xef, 0x60, 0xd0, 0xf4, 0x9b, 0xdf, 0x76, 0xfe, 0xa8, 0x42, 0xe5, 0x2a, 0x9b, 0xb, 0xf3, 0x64, 0xdd, 0x48, 0xc7, 0xf2, 0x92, 0xa, 0x2c, 0x20, 0x0, 0xa8, 0xa3, 0x39, 0x53, 0x11, 0x4c, 0xaa, 0xb7, 0x63, 0xd1, 0x8f, 0x1a, 0x44, 0x3f, 0x18, 0xf4, 0xc1, 0xe1, 0xbd, 0xd9, 0xa6, 0x29, 0xab, 0xa6, 0x77, 0x40, 0xe0, 0x77, 0xa4, 0x1, 0xe3, 0x88, 0x68, 0xef, 0xc9, 0x24, 0x1a, 0xee, 0x33, 0xd, 0xea, 0x9d, 0x88, 0xc0, 0x38, 0x1d, 0x1d, 0xa5, 0x88, 0x78, 0xc9, 0xa0, 0x37, 0x80, 0xdb, 0xfb, 0xc0, 0xe, 0x95, 0x73, 0xd8, 0x29, 0x1d, 0xc9, 0x9a, 0x21, 0x1a, 0x33, 0xab, 0xc7, 0x58, 0x2, 0xe9, 0x3e, 0xa3, 0xae, 0xaa, 0x4f, 0x86, 0x19, 0xc1, 0x9d, 0x8e, 0x1e, 0x4b, 0xb6, 0x41, 0x3e, 0xca, 0x26, 0xd0, 0xab, 0xab, 0x4b, 0xf3, 0x9c, 0xd9, 0x9f, 0x1a, 0x3, 0x24, 0x75, 0xe0, 0x16, 0x4b, 0x36, 0x85, 0xf3, 0x5f, 0x5, 0x41, 0x6f, 0xa3, 0xdc, 0xa7, 0x26, 0x26, 0x46, 0x29, 0xeb, 0x37, 0x4c, 0x1c, 0xbe, 0x75, 0x74, 0xe, 0xfd, 0x84, 0xda, 0xc7, 0xaa, 0x4a, 0x43, 0x33, 0x39, 0x23, 0xa7, 0xf4, 0x10, 0x32, 0xca, 0x27, 0x58, 0x41, 0x64, 0x1, 0x84, 0xdc, 0xd7, 0xef, 0x3, 0x7b, 0xe0, 0x57, 0x35, 0xa8, 0xf1, 0xe6, 0x5c, 0x14, 0x40, 0x2b, 0xc1, 0xc8, 0x97, 0x74, 0x8f, 0xca, 0x38, 0xf0, 0x23, 0x7d, 0xc3, 0x28, 0xbf, 0x3e, 0xcc, 0x82, 0x6f, 0x6, 0xa0, 0x94, 0x35, 0x4, 0xf, 0x9c, 0x3f, 0x36, 0xd7, 0xf8, 0x72, 0x4e, 0x6a, 0xf6, 0x81, 0x78, 0x2b, 0x23, 0xb7, 0xf4, 0xfa, 0x23, 0xca, 0x80, 0xf3, 0xc5, 0x38, 0x6d, 0x83, 0x2c, 0x4e, 0xd7, 0xf4, 0xc9, 0x0, 0xc0, 0x1c, 0x23, 0x60, 0x90, 0x4f, 0x7c, 0x4d, 0x77, 0x95, 0xc2, 0x5d, 0x2d, 0xa9, 0xf0, 0x6b, 0x10, 0xe5, 0x3, 0x85, 0x9c, 0xd2, 0x8, 0x82, 0x92, 0xdd, 0x20, 0x87, 0x6, 0xd5, 0x7e, 0x25, 0x22, 0x5d, 0xc0, 0x1a, 0x25, 0x13, 0x22, 0x17, 0xaf, 0x9c, 0x29, 0xe5, 0x7c, 0x83, 0xcf, 0x0, 0x18, 0x5c, 0x1f, 0x4f, 0xac, 0xf0, 0x11, 0xe4, 0xc5, 0xbd, 0x4a, 0xf8, 0xed, 0x1c, 0x41, 0xd1, 0x52, 0xf5, 0xf2, 0xa2, 0x9, 0xd2, 0x43, 0x2f, 0x95, 0x45, 0xeb, 0x79, 0xd2, 0xb3, 0xc6, 0xf4, 0xfb, 0x83, 0x8b, 0xa2, 0xb7, 0x28, 0x75, 0x5b, 0x6b, 0x2, 0x58, 0xed, 0xef, 0xa4, 0xd2, 0x1e, 0xbf, 0xfa, 0xab, 0x17, 0xbf, 0xf3, 0x9f, 0xaf, 0x4f, 0x4d, 0x4d, 0x67, 0xd4, 0x3d, 0x37, 0xd7, 0x57, 0xfa, 0xb, 0x37, 0xa3, 0xff, 0x23, 0x69, 0x5a, 0x5, 0x10, 0xa5, 0xb, 0xdf, 0xc7, 0x6f, 0xeb, 0xea, 0x9d, 0x51, 0xf6, 0xd2, 0xd1, 0xd1, 0x7, 0xff, 0xfc, 0x6b, 0x88, 0xca, 0x41, 0xaf, 0xd1, 0x0, 0x91, 0xdd, 0x64, 0x3e, 0x84, 0x54, 0xd2, 0x7f, 0xd0, 0xfb, 0x74, 0x3c, 0x8d, 0xe7, 0xca, 0xe4, 0x86, 0x5a, 0xa1, 0xf5, 0xde, 0xeb, 0xaf, 0x43, 0x22, 0xa2, 0x71, 0x40, 0x48, 0x1b, 0xa3, 0x9f, 0x83, 0xae, 0x51, 0xf8, 0x90, 0xbc, 0x47, 0xe, 0x97, 0xe4, 0x68, 0x1a, 0x80, 0x42, 0xc0, 0xb1, 0xc1, 0xcf, 0x15, 0xbd, 0x3e, 0xdf, 0x6f, 0xe6, 0x18, 0x14, 0x73, 0xd0, 0x9b, 0xd, 0x9a, 0x5f, 0x68, 0xc1, 0xf, 0x63, 0x33, 0x80, 0x88, 0x4d, 0x56, 0x15, 0x25, 0x10, 0x9b, 0x5e, 0xaf, 0xd7, 0x30, 0x27, 0xd0, 0xa, 0xf9, 0xf8, 0x9c, 0xfc, 0x9a, 0xa6, 0x9b, 0xfd, 0x10, 0x1, 0x41, 0xb0, 0x20, 0x31, 0x7, 0xb8, 0x78, 0x1b, 0x3d, 0xb, 0xdf, 0xf6, 0x28, 0x1e, 0xca, 0xf7, 0x69, 0x40, 0x55, 0xdf, 0x2c, 0xba, 0x5, 0xa0, 
            0x96, 0xfd, 0x1c, 0x61, 0x2e, 0x6a, 0x76, 0x51, 0xd0, 0x6d, 0x92, 0x72, 0x90, 0xd9, 0xb0, 0x2d, 0x79, 0xfb, 0x6b, 0xc9, 0x87, 0xf7, 0x1a, 0xcb, 0xbc, 0x9a, 0xa, 0xf1, 0x11, 0x88, 0x18, 0xf0, 0xb9, 0x83, 0xb1, 0x46, 0x2f, 0xd0, 0x8f, 0x31, 0x7d, 0x55, 0xc0, 0x39, 0x9c, 0x41, 0x3, 0x3c, 0x83, 0x7a, 0x6a, 0x42, 0xf3, 0x9a, 0xd4, 0x64, 0x40, 0xe, 0x64, 0xe0, 0xe7, 0x17, 0x5a, 0xc0, 0xd6, 0xeb, 0xd2, 0x6d, 0xe4, 0x5c, 0xda, 0x3b, 0x3d, 0x60, 0x40, 0xe9, 0x30, 0x68, 0xce, 0x2, 0xc6, 0x97, 0xc2, 0xa7, 0x56, 0x97, 0xc1, 0x3, 0xd0, 0xb2, 0xe9, 0x5d, 0xf2, 0xa1, 0x96, 0x4e, 0xa, 0x2d, 0xbc, 0x7, 0x64, 0x68, 0x3c, 0xd, 0x4, 0x49, 0x36, 0x35, 0x65, 0x3a, 0xbc, 0x3b, 0x83, 0x10, 0xaf, 0xd, 0x7f, 0x62, 0x6c, 0x13, 0x24, 0xa2, 0x88, 0xf4, 0x69, 0xbc, 0x8, 0x59, 0x55, 0x9a, 0x7, 0x6d, 0xb6, 0xfb, 0x8f, 0x7f, 0xf9, 0xda, 0xe3, 0x5f, 0x7a, 0x60, 0x24, 0x75, 0x9d, 0xaf, 0xd0, 0xf4, 0x6b, 0x8f, 0xdd, 0x73, 0xa8, 0xa6, 0x88, 0x52, 0x4d, 0xb2, 0xf1, 0xf4, 0x83, 0x3e, 0x2d, 0x0, 0x87, 0xb1, 0xba, 0x66, 0xf9, 0xac, 0x7b, 0x4c, 0xc4, 0x3c, 0x9b, 0xfa, 0xef, 0x28, 0xc, 0xd0, 0xbc, 0x34, 0x2c, 0xec, 0x81, 0x3, 0xcf, 0x74, 0xd2, 0x3b, 0xd1, 0x20, 0xe8, 0x3c, 0xd3, 0x1f, 0x82, 0x4, 0x42, 0xef, 0x92, 0xa, 0xed, 0x61, 0x69, 0x59, 0x55, 0x67, 0xfe, 0xf2, 0xc1, 0x7, 0x46, 0xd5, 0xf, 0x99, 0x80, 0x51, 0xa0, 0x51, 0x9, 0x8a, 0x5d, 0xc1, 0x53, 0xf, 0x43, 0xbc, 0x45, 0x19, 0xc, 0x94, 0x8f, 0xa4, 0xc2, 0xf, 0x51, 0x46, 0xd6, 0xc8, 0x7b, 0x55, 0x79, 0x6d, 0x23, 0xb4, 0x21, 0x9c, 0x96, 0xbb, 0xa1, 0xea, 0xcf, 0x52, 0xbc, 0x77, 0x85, 0xe3, 0xc4, 0x64, 0xed, 0xa1, 0x6c, 0x5a, 0x2f, 0xe3, 0x5b, 0xff, 0xc6, 0xd3, 0x69, 0xe7, 0xb0, 0xf, 0x95, 0x4b, 0x9d, 0x11, 0xa6, 0xbd, 0x4a, 0x87, 0x6, 0xe2, 0x20, 0x8, 0xdc, 0x2d, 0x78, 0xe3, 0x2a, 0xf9, 0x2e, 0x26, 0x78, 0x35, 0xe3, 0x57, 0x11, 0xd4, 0x30, 0x4, 0x10, 0xad, 0xd7, 0x5f, 0xdc, 0x83, 0x5f, 0x29, 0x42, 0x4e, 0x51, 0x70, 0xac, 0x22, 0xd6, 0x56, 0x9f, 0x80, 0x53, 0x64, 0xf5, 0x61, 0xc2, 0xbe, 0x7d, 0x1f, 0x22, 0xa2, 0x36, 0x0, 0x91, 0x22, 0x52, 0x1f, 0x81, 0xe, 0x77, 0x2b, 0xb0, 0xf1, 0x3a, 0xcd, 0xaa, 0x15, 0xfb, 0x12, 0xe0, 0xb, 0x58, 0xa0, 0x31, 0x7a, 0x18, 0x95, 0x28, 0x94, 0x5, 0xec, 0xd2, 0xcc, 0x91, 0x1e, 0x43, 0x10, 0xff, 0x18, 0xe7, 0xd0, 0x4a, 0xbe, 0xbd, 0xca, 0xba, 0xcc, 0xd9, 0x35, 0xe1, 0x40, 0x2e, 0xc, 0x80, 0xe1, 0x24, 0xd4, 0xde, 0x12, 0xf1, 0xbf, 0x8b, 0xe9, 0x64, 0xcb, 0x5f, 0xf, 0x80, 0x75, 0x9f, 0xc6, 0xf2, 0xbc, 0xaa, 0xc7, 0x13, 0xd, 0x7f, 0x3e, 0xb3, 0x81, 0x23, 0xba, 0x35, 0xc6, 0xca, 0xb2, 0x7a, 0xc4, 0x94, 0x79, 0xb8, 0x61, 0x1a, 0x92, 0xc1, 0x0, 0x3e, 0xa0, 0x7, 0x1b, 0x66, 0xaa, 0x4f, 0x30, 0x4e, 0xee, 0x2a, 0x7a, 0xd6, 0xfc, 0xd9, 0xa5, 0xb8, 0x94, 0x60, 0xa, 0x6e, 0x26, 0xe4, 0x4b, 0x17, 0xef, 0x55, 0x0, 0xf5, 0x14, 0xbf, 0x60, 0xc1, 0x38, 0x6a, 0x9a, 0x36, 0x4f, 0xaa, 0xea, 0xa4, 0x9f, 0x7e, 0xc4, 0x23, 0xe1, 0x8, 0xe8, 0x82, 0x60, 0x33, 0xde, 0xe0, 0x4a, 0x0, 0x4, 0xdd, 0xe2, 0x59, 0x26, 0x40, 0xaf, 0x31, 0xfa, 0x9e, 0x6c, 0x30, 0xfd, 0xd9, 0x9a, 0xcb, 0x2b, 0x9f, 0xc9, 0x8f, 0x35, 0xd4, 0x12, 0x82, 0xd, 0x78, 0xe7, 0x28, 0xf8, 0x44, 0x1c, 0x5d, 0x9e, 0x94, 0x7c, 0xc0, 0xc6, 0x18, 0xea, 0xd1, 0x85, 0xbd, 0xd6, 0x7c, 0x46, 0xd0, 0xb0, 0xb3, 0xe, 0x4c, 0x8, 0x7c, 0xb, 0x9, 0xfe, 0x10, 0xde, 0xf9, 0x4d, 0x28, 0x56, 0x2e, 0x5d, 0xc5, 0xfa, 0xc1, 0xfc, 0x52, 0xa1, 0xf2, 0xd5, 0xa6, 0x61, 0xf4, 0xe7, 0x39, 0x32, 0x70, 0xdf, 0x67, 0xf6, 0x27, 0xb1, 0xd, 0x66, 0x21, 0x26, 0xb3, 0xf2, 0xa4, 0xba, 0x19, 0x36, 0xa4, 0xd1, 0x49, 0x5, 0x30, 0x55, 0x10, 0x7e, 0x2a, 0x54, 0xe5, 0x6b, 0xdf, 0xa8, 0xad, 0x50, 0x9e, 0x84, 0x97, 0x5, 0x1e, 0x4a, 0x93, 0x93, 0xb, 0x23, 0x4, 0x70, 0x5d, 0x5e, 0x84, 0xf1, 0x88, 0x67, 0xd7, 0x19, 0x99, 0xf4, 0xe4, 0x2c, 0x13, 0x74, 0x2, 0xe9, 0x2f, 0xa6, 0x9d, 0x19, 0x3, 0xf0, 0x32, 0xe7, 0x5b, 0xeb, 0xdf, 0x88, 0x58, 0x29, 0x80, 0xb5, 0x4, 0x9, 0xa8, 0x76, 0xa, 0xe3, 0x56, 0xe5, 0xd, 0xeb, 0x27, 0x28, 0xfb, 0x16, 0x41, 0xa0, 0xaf, 0x76, 0x62, 0x12, 0xd3, 0x84, 0x50, 0x62, 0x2, 0xb1, 0xe9, 0x9f, 0xbe, 0xc3, 0x28, 0x1, 0xa2, 0xf0, 0x16, 0x16, 0xdd, 0x91, 0x44, 0xb1, 0x78, 0xcf, 0xab, 0x16, 0xc0, 0x74, 0xbc, 0x0, 0x20, 0xfd, 0x15, 0x88, 0x5b, 0x6a, 0xb9, 0x55, 0x4d, 0x44, 0x2d, 0x0, 0x4e, 0x3a, 0x60, 0x60, 0x1f, 0xa2, 0x7b, 0xf, 
            0x42, 0x7e, 0xe7, 0x2f, 0xbe, 0x9b, 0xd7, 0x2a, 0x60, 0xaa, 0xa0, 0xc4, 0x90, 0x45, 0xa8, 0xc1, 0x4e, 0xe7, 0x86, 0x32, 0x93, 0x7f, 0x4c, 0xf3, 0xa1, 0xd, 0x0, 0xb1, 0x25, 0xd0, 0x3c, 0xda, 0x76, 0xf5, 0x85, 0xc7, 0xff, 0x76, 0x9a, 0xe9, 0xa7, 0xe8, 0x33, 0x17, 0xb0, 0xc6, 0x81, 0xbc, 0x37, 0xc1, 0xa1, 0x74, 0x2f, 0x87, 0xb4, 0xba, 0xbc, 0x1c, 0x2a, 0x83, 0x38, 0xc8, 0x58, 0x15, 0x9, 0x23, 0x37, 0xa3, 0xd8, 0x2c, 0x6b, 0xb5, 0x12, 0x54, 0x20, 0x34, 0x98, 0xbe, 0xd0, 0x27, 0xe, 0xc8, 0xbe, 0x2d, 0x9, 0xa0, 0x1d, 0xc3, 0x98, 0xca, 0x10, 0x5a, 0xaf, 0xed, 0x44, 0x39, 0x68, 0xb9, 0x1c, 0x4, 0x7b, 0x6f, 0x6a, 0x20, 0x28, 0x74, 0x96, 0xc1, 0x3, 0x75, 0x0, 0x2a, 0xf2, 0xe9, 0xb0, 0x53, 0x99, 0xc9, 0xd5, 0xde, 0x27, 0x2c, 0x2, 0x34, 0x1, 0xd9, 0x4, 0x11, 0xed, 0x6a, 0x5b, 0x18, 0x53, 0xac, 0x6a, 0xda, 0x6, 0x2a, 0x3, 0xa0, 0xb, 0xf6, 0x55, 0x14, 0x9a, 0xf9, 0x19, 0x23, 0xa0, 0xa9, 0x8, 0x40, 0xc2, 0xce, 0xe8, 0x2b, 0x40, 0x14, 0x45, 0xdb, 0x34, 0xbc, 0xd9, 0x4, 0x52, 0x5b, 0xfd, 0x93, 0x6, 0x7d, 0xc2, 0xdf, 0xef, 0x83, 0x1e, 0xc5, 0x96, 0x0, 0x50, 0xcf, 0x8f, 0x43, 0xcd, 0x80, 0x5c, 0xf2, 0x7c, 0x9, 0x8a, 0x36, 0xdb, 0x0, 0x92, 0x71, 0x88, 0x2d, 0x59, 0x2e, 0x7a, 0x3d, 0x23, 0x96, 0x1, 0x4d, 0xfd, 0xa8, 0xac, 0x1c, 0x2b, 0xe5, 0x82, 0x7a, 0xbd, 0xed, 0x8f, 0x76, 0x12, 0xe0, 0x3b, 0xe1, 0x3a, 0xd3, 0xdd, 0xb8, 0x78, 0xed, 0x19, 0xbf, 0xec, 0x72, 0xc0, 0xaf, 0xb7, 0x13, 0xcf, 0xb8, 0x70, 0x29, 0x67, 0xbc, 0xaa, 0x3e, 0x3f, 0xe1, 0xab, 0xa7, 0xa1, 0x87, 0xac, 0xd, 0xd7, 0x6a, 0xa, 0xe1, 0x2a, 0x9f, 0xab, 0x7c, 0x59, 0x93, 0x1c, 0x68, 0xc, 0x18, 0x68, 0x65, 0x63, 0xb3, 0x98, 0x9f, 0x59, 0xab, 0xff, 0x5f, 0x15, 0x8a, 0xa4, 0x15, 0xf, 0xde, 0xcb, 0x39, 0x3a, 0x72, 0x4, 0xcd, 0xcc, 0x5, 0x8d, 0xe4, 0xeb, 0xc5, 0x4a, 0xd0, 0x5c, 0x41, 0x6a, 0x84, 0x61, 0xb4, 0x87, 0x10, 0xd5, 0xe5, 0x25, 0x1e, 0x22, 0xdc, 0xdc, 0x2b, 0x8c, 0x82, 0xe5, 0xd7, 0x4c, 0x1, 0xe1, 0xc7, 0x2d, 0xb1, 0xcf, 0xcc, 0xbb, 0xf1, 0xc6, 0xbf, 0x7e, 0xe7, 0x3c, 0x2b, 0x58, 0x53, 0x4f, 0x84, 0xcc, 0xad, 0xcd, 0x99, 0xc6, 0xbc, 0x42, 0xd7, 0x8f, 0xb9, 0xf9, 0x11, 0x49, 0x7b, 0x57, 0xa1, 0xe1, 0x3f, 0xcf, 0xac, 0xc8, 0xd0, 0x77, 0x37, 0xba, 0xdf, 0x7e, 0x60, 0xa4, 0x73, 0xf7, 0x6e, 0x95, 0xcf, 0xf2, 0xea, 0x38, 0x5b, 0xcd, 0xb2, 0x42, 0xfa, 0x55, 0x4f, 0x29, 0xd3, 0x5a, 0x15, 0xa0, 0xd8, 0x5a, 0xae, 0x90, 0xda, 0x21, 0x69, 0x20, 0xa0, 0x3f, 0xf7, 0xfd, 0xc7, 0x30, 0xc3, 0x77, 0x46, 0x1f, 0xdc, 0x31, 0x50, 0xfe, 0x56, 0xbf, 0xa6, 0xb4, 0x45, 0xdc, 0xf0, 0xc0, 0xff, 0x2d, 0x77, 0xb3, 0xf6, 0x2c, 0x60, 0x44, 0xae, 0xd0, 0xe, 0xb, 0xe1, 0xdd, 0xef, 0x7f, 0x69, 0xc4, 0x72, 0xac, 0xf3, 0xe0, 0xcb, 0xcc, 0x24, 0x4e, 0xcf, 0x27, 0x56, 0xc4, 0x71, 0x87, 0x52, 0xd8, 0xc5, 0xc2, 0xa8, 0x6d, 0x60, 0x4c, 0xdf, 0x28, 0x78, 0x36, 0xe3, 0xf2, 0x9b, 0x73, 0x83, 0x38, 0xf7, 0xe3, 0xaf, 0xf2, 0xf7, 0x89, 0x6e, 0x0, 0xa3, 0xf7, 0x9c, 0xb7, 0x49, 0xd, 0x76, 0xfd, 0x12, 0x3b, 0xef, 0xc, 0x9f, 0xa8, 0xaa, 0x6b, 0x2b, 0x22, 0x17, 0xb4, 0xa, 0x80, 0x55, 0x70, 0x8, 0xde, 0x47, 0xf0, 0x94, 0xdd, 0x1f, 0x7f, 0x75, 0x24, 0xa, 0x64, 0x1c, 0x2f, 0x1c, 0xe9, 0x8, 0xd7, 0x37, 0x8e, 0x99, 0xcc, 0x8e, 0xd7, 0x46, 0x56, 0xce, 0x98, 0x7f, 0x3c, 0x0, 0xad, 0xfb, 0x82, 0xf9, 0x5a, 0xfd, 0x8b, 0x37, 0xfe, 0x79, 0x23, 0x9b, 0x0, 0x94, 0xb3, 0xc2, 0x88, 0x25, 0xee, 0x48, 0x4f, 0xc1, 0x4, 0x72, 0x40, 0xff, 0xab, 0xef, 0xb6, 0x41, 0x76, 0x34, 0xa, 0xa2, 0x96, 0x3, 0xba, 0xd6, 0x6d, 0x84, 0xff, 0x57, 0x8f, 0x45, 0xe8, 0xc5, 0x41, 0xe0, 0xa1, 0x95, 0xfc, 0xbb, 0x6, 0x56, 0x7d, 0x1b, 0x9d, 0x88, 0x98, 0x22, 0xb9, 0x42, 0xf8, 0x22, 0xda, 0x76, 0x64, 0xf0, 0xc1, 0x90, 0x68, 0x39, 0xe8, 0xdf, 0x5d, 0xf, 0xc5, 0x43, 0xb4, 0x0, 0x15, 0x41, 0x2, 0x80, 0x10, 0x3f, 0xc2, 0x22, 0xd6, 0xe7, 0xc8, 0x52, 0xfa, 0x2b, 0x91, 0xed, 0x49, 0x1f, 0xae, 0x40, 0x42, 0x7a, 0x1b, 0x20, 0x75, 0xc, 0xab, 0xef, 0x4, 0xe7, 0x99, 0x20, 0xb0, 0x2a, 0xca, 0xe5, 0x5, 0x19, 0x7a, 0x97, 0xb5, 0x50, 0x35, 0x7f, 0xae, 0xa8, 0xb4, 0x5e, 0x1e, 0xa8, 0x9e, 0x8a, 0x6c, 0x76, 0x31, 0xfb, 0xf7, 0x64, 0xd9, 0x59, 0xf2, 0x9, 0x68, 0x41, 0xd4, 0x5e, 0x57, 0xd2, 0xe4, 0x7, 0x8d, 0xd5, 0x5f, 0xc1, 0xa7, 0x2b, 0x99, 0x56, 0x4d, 0xbc, 0x7e, 0x1a, 0x49, 0xd1, 0x48, 0xe2, 0x43, 0xc0, 0x7a, 0x2a, 0xe0, 0x2b, 0xc, 0x25, 
            0x3d, 0x55, 0x71, 0x48, 0x97, 0x49, 0xbc, 0x19, 0xa0, 0xf0, 0xa6, 0x6, 0x56, 0x69, 0x2e, 0x6, 0xcc, 0x48, 0xf6, 0x3b, 0x7c, 0x5f, 0x80, 0xbc, 0xfc, 0x69, 0xe0, 0x19, 0x44, 0x31, 0x8b, 0xa3, 0x2e, 0x86, 0x76, 0xc0, 0x69, 0xfa, 0xff, 0xfe, 0xf8, 0xa1, 0xda, 0x4e, 0x14, 0x19, 0xe1, 0xe3, 0xb2, 0x7c, 0xe, 0xa4, 0xb6, 0x7c, 0x39, 0xc2, 0x9f, 0xe5, 0xcf, 0xd1, 0xfa, 0x30, 0x34, 0xb7, 0x71, 0xb4, 0x48, 0xe2, 0xa5, 0x3e, 0x1, 0x8f, 0xa7, 0xc9, 0xca, 0xc9, 0x5a, 0x47, 0x22, 0x38, 0x39, 0xb7, 0x22, 0xf1, 0x88, 0x85, 0x9, 0xad, 0xf, 0xb0, 0x80, 0x67, 0xf7, 0x47, 0xb2, 0x9f, 0x87, 0x35, 0xb6, 0x5, 0xa6, 0xf7, 0xcb, 0x3d, 0x1b, 0x20, 0x31, 0x63, 0x26, 0x43, 0xaf, 0xd6, 0xb9, 0x5d, 0x79, 0x8a, 0xdc, 0x3, 0x20, 0x71, 0x1a, 0x5a, 0x36, 0x17, 0xd9, 0x59, 0x73, 0x28, 0xd, 0x22, 0x35, 0x97, 0xd3, 0xa5, 0xbe, 0x7e, 0x1e, 0xd3, 0xa4, 0xb5, 0x60, 0xa6, 0xb0, 0x33, 0x59, 0x6e, 0x29, 0x7c, 0xa, 0xf4, 0x91, 0xb4, 0x47, 0x59, 0xc8, 0x8a, 0xd3, 0xf8, 0x41, 0x31, 0x8d, 0xd8, 0x73, 0xb6, 0x9b, 0xfe, 0xbd, 0x9f, 0x5f, 0x47, 0xec, 0xf0, 0xb9, 0xf8, 0x50, 0xd1, 0x1e, 0x89, 0xb8, 0xe4, 0x9f, 0x7d, 0xc4, 0xc8, 0x43, 0xc1, 0x9f, 0x1d, 0xd3, 0x20, 0xc8, 0x7, 0xb5, 0x60, 0x22, 0x76, 0x96, 0xd8, 0xf0, 0x9, 0xf1, 0xf8, 0x9, 0x60, 0x45, 0xab, 0xec, 0xc8, 0x57, 0xfa, 0x45, 0xf7, 0x0, 0xf0, 0xa2, 0xf2, 0x80, 0x1f, 0x4a, 0xfd, 0x17, 0xd4, 0x8, 0x4c, 0x23, 0x3f, 0x15, 0x7c, 0xdd, 0x2f, 0x0, 0xc3, 0x76, 0xf9, 0xc3, 0xa3, 0x77, 0xa, 0x41, 0x5, 0x20, 0x34, 0x38, 0x15, 0x6, 0xfe, 0xf5, 0x5, 0xa4, 0xc4, 0x53, 0x84, 0x5f, 0xa7, 0x1f, 0xa6, 0x35, 0x7a, 0x8b, 0x1d, 0xcf, 0x6, 0xbd, 0xdf, 0x38, 0x2d, 0x20, 0xb0, 0x2d, 0xc, 0x56, 0xd3, 0xfc, 0xc2, 0x8f, 0x32, 0x67, 0x89, 0x37, 0x3, 0x2e, 0x58, 0x7, 0xb6, 0xeb, 0xa9, 0x7e, 0xc0, 0xb2, 0x10, 0x5b, 0x69, 0xfe, 0xba, 0xf6, 0x97, 0xfe, 0x8d, 0x71, 0x2e, 0xab, 0x28, 0x75, 0x21, 0x35, 0xbd, 0xb7, 0x60, 0x10, 0x65, 0x3c, 0xb8, 0x65, 0xe5, 0xfd, 0xce, 0xc8, 0xa3, 0x67, 0xb2, 0xec, 0x4c, 0x24, 0xf3, 0x6d, 0x1c, 0x27, 0x8, 0x8b, 0xfc, 0x1, 0xf9, 0x94, 0x86, 0x2c, 0x9d, 0x8f, 0xf0, 0xc8, 0xbc, 0x97, 0xb2, 0x42, 0x75, 0x82, 0x10, 0x1c, 0x60, 0xe7, 0xe7, 0x1f, 0xc0, 0x77, 0x82, 0x99, 0x63, 0xe, 0xa5, 0x4f, 0x43, 0xb7, 0xcd, 0x6f, 0xf, 0x1b, 0x53, 0xbb, 0x56, 0x68, 0x4c, 0xc, 0xdc, 0x9a, 0x42, 0xd7, 0x62, 0x24, 0x51, 0x91, 0x9f, 0x32, 0xe9, 0x21, 0xa2, 0x2f, 0x3b, 0x4e, 0xf3, 0x23, 0x5b, 0x27, 0x8, 0xc1, 0xc2, 0x9e, 0xc6, 0xbf, 0xde, 0x85, 0xb8, 0x3d, 0x56, 0x48, 0xb9, 0xf8, 0xe, 0xfa, 0xdf, 0x4a, 0x40, 0xd6, 0x4d, 0xf0, 0x1b, 0x94, 0xf5, 0x6f, 0xc2, 0x1a, 0xb9, 0xcf, 0x96, 0x1, 0x45, 0xe5, 0x9f, 0xd, 0xa4, 0x7f, 0xff, 0xd1, 0xd4, 0x6e, 0x65, 0xa0, 0x7, 0x38, 0x51, 0xbc, 0x84, 0x0, 0xe6, 0xd2, 0xbf, 0xc8, 0xf, 0x52, 0xe3, 0x79, 0x5f, 0xa1, 0x53, 0x8f, 0x1b, 0x98, 0xac, 0xa5, 0xf8, 0x13, 0x2e, 0x3c, 0x6f, 0xed, 0xfb, 0x42, 0xbb, 0xc1, 0x23, 0x1d, 0x19, 0xaf, 0xf1, 0xbd, 0xba, 0xf5, 0xa9, 0xce, 0x16, 0x59, 0xf7, 0x6f, 0xd2, 0xbb, 0xbf, 0xfc, 0xa, 0x33, 0x3a, 0x3b, 0x6d, 0xce, 0x34, 0x94, 0x22, 0xb7, 0xd9, 0xf7, 0xfe, 0xa7, 0xdb, 0x23, 0x8c, 0xee, 0x34, 0x91, 0x5b, 0xf8, 0x13, 0x82, 0x5f, 0xfa, 0x14, 0xca, 0x8b, 0xa9, 0x19, 0x3b, 0x7d, 0x67, 0x5d, 0xfa, 0x4f, 0x21, 0x8, 0x8, 0xc2, 0xf9, 0xb3, 0x3d, 0x4d, 0xef, 0x17, 0xdb, 0x41, 0x53, 0x21, 0x4, 0xe5, 0xbe, 0x99, 0xd9, 0xa5, 0x8a, 0xc3, 0x30, 0xeb, 0x7d, 0x69, 0x57, 0x57, 0x7c, 0x39, 0xa8, 0xe4, 0x27, 0xc6, 0x0, 0x65, 0x5d, 0x5f, 0xed, 0x6f, 0xf0, 0xb4, 0x68, 0x47, 0x39, 0x6b, 0x42, 0xb1, 0x30, 0x7c, 0xa2, 0xf4, 0xc4, 0xa5, 0x6a, 0x40, 0xae, 0x93, 0xa5, 0xbd, 0xce, 0xae, 0x6f, 0xa3, 0x31, 0xc, 0xe7, 0xcd, 0x56, 0x1a, 0xbe, 0x7e, 0xa7, 0x13, 0x8c, 0x2e, 0x55, 0x4c, 0xcc, 0xe8, 0x4f, 0xed, 0x50, 0xdb, 0x5e, 0x9a, 0x74, 0xaf, 0x53, 0x4e, 0xf1, 0xcb, 0x9, 0xa3, 0x66, 0x3a, 0xae, 0xb5, 0xf6, 0xdf, 0xdf, 0x29, 0xf1, 0x23, 0x23, 0xba, 0x9d, 0xba, 0xe0, 0x8b, 0x65, 0x61, 0x5, 0x24, 0xf3, 0x93, 0x52, 0xa6, 0x82, 0x54, 0x74, 0x5f, 0xf8, 0x3b, 0x6a, 0x30, 0xe1, 0xf3, 0x21, 0x72, 0x6f, 0x96, 0xda, 0x3e, 0x3f, 0xe2, 0x8e, 0x30, 0x2, 0xf9, 0x36, 0x27, 0xac, 0xe6, 0xb3, 0x94, 0x95, 0xd3, 0xf2, 0x42, 0xe5, 0x50, 0x27, 0xcb, 0x13, 0x69, 0xfa, 0x4, 0x21, 0xbc, 0xdf, 0x1b, 0xb0, 0x5c, 0xd3, 0x43, 0x33, 0x78, 0x9e, 0xda, 0x77, 0xec, 0xfa, 0xe0, 0xa2, 0xc5, 0xb3, 
            0x45, 0xe1, 0xaf, 0xc4, 0x2a, 0xa1, 0x60, 0xc0, 0xab, 0x23, 0x78, 0xbc, 0x9d, 0xa6, 0x43, 0xaf, 0x64, 0xd9, 0xf4, 0x3b, 0x91, 0x99, 0x7f, 0x88, 0xf3, 0x7f, 0xaf, 0xf7, 0x11, 0x1a, 0x28, 0x95, 0x97, 0xfa, 0x6e, 0xd1, 0x9b, 0x7a, 0x98, 0xa1, 0x6b, 0xe1, 0x5f, 0x16, 0xd2, 0x1, 0x2c, 0x4f, 0x33, 0x5b, 0xb3, 0x6c, 0x2a, 0xdb, 0x2f, 0xf1, 0xcb, 0xfc, 0x4, 0x35, 0x81, 0xba, 0xd1, 0x51, 0xf4, 0x40, 0xff, 0x85, 0x93, 0xa5, 0x8e, 0x63, 0x52, 0xdc, 0x2a, 0x30, 0xf, 0x7e, 0xb4, 0xa1, 0x78, 0xf, 0x9b, 0x5f, 0x70, 0x6f, 0x77, 0xaa, 0xdb, 0x7d, 0x84, 0x19, 0xf4, 0xaa, 0xe, 0x78, 0xfd, 0x8f, 0x75, 0xf6, 0x87, 0x7c, 0x5e, 0x12, 0x51, 0x3d, 0xd9, 0xc1, 0xd8, 0xfd, 0xb, 0x4d, 0x4a, 0x85, 0x3f, 0x38, 0x2a, 0x91, 0xb7, 0xb0, 0x69, 0xbe, 0x34, 0xd5, 0x9d, 0xfa, 0x35, 0x82, 0x77, 0x19, 0x7e, 0xc1, 0xfb, 0xd7, 0xc4, 0xdc, 0x99, 0x11, 0x5, 0x69, 0x97, 0x9d, 0x19, 0xfc, 0x85, 0xd8, 0xc6, 0x34, 0xb5, 0x12, 0xfe, 0x3f, 0x3b, 0xc8, 0x42, 0x70, 0xcb, 0x74, 0x36, 0x3d, 0xfd, 0x8b, 0xe4, 0x8e, 0x43, 0x74, 0xf, 0x6f, 0xf4, 0x68, 0x0, 0xfe, 0x0, 0xea, 0x9e, 0xe9, 0x73, 0xab, 0x25, 0x45, 0xa6, 0x1, 0x27, 0x37, 0x4, 0x55, 0xd0, 0xa1, 0xc0, 0x69, 0x55, 0xd1, 0x35, 0xdd, 0xa9, 0xa9, 0xe9, 0x37, 0xa6, 0xa1, 0x22, 0xcf, 0x77, 0x13, 0xf6, 0x9, 0x81, 0x1a, 0xd9, 0x13, 0xda, 0x9f, 0xf8, 0x39, 0x9, 0x43, 0x8e, 0xe3, 0x9d, 0x2e, 0x9d, 0x16, 0xbf, 0xec, 0xaa, 0xeb, 0x85, 0xfc, 0x33, 0xd3, 0x53, 0xd3, 0xfa, 0x4, 0x5, 0xe3, 0x1f, 0xc4, 0x6b, 0x43, 0xe4, 0xf1, 0xe6, 0x4f, 0x10, 0xc, 0xdc, 0xde, 0x15, 0xb2, 0xa, 0xda, 0x6f, 0x3f, 0x34, 0x63, 0xe6, 0x97, 0xb9, 0x82, 0x6f, 0x1f, 0x9b, 0x50, 0xb0, 0xe0, 0x27, 0x59, 0x77, 0x4a, 0xed, 0xb5, 0x3a, 0xbf, 0xcf, 0x19, 0x3d, 0x4a, 0xf7, 0x1f, 0xfb, 0xd, 0x88, 0x8f, 0x67, 0x4a, 0xdc, 0x7f, 0x4a, 0x47, 0x27, 0xfd, 0xb8, 0x4e, 0x8b, 0xe6, 0x62, 0x77, 0xf5, 0xd4, 0x54, 0x36, 0xad, 0xda, 0xc2, 0x25, 0xd3, 0xdf, 0xfe, 0x56, 0x9d, 0xd7, 0xfe, 0x59, 0x37, 0xad, 0xb0, 0xf2, 0x7b, 0x49, 0xe7, 0xee, 0x99, 0xaa, 0x65, 0xc0, 0xa0, 0xea, 0x26, 0xc6, 0xe0, 0xaf, 0xa7, 0x79, 0xce, 0x2b, 0xb0, 0x23, 0xc6, 0xed, 0x86, 0xbb, 0xea, 0xfd, 0x81, 0x6, 0xc0, 0x4a, 0xee, 0xa3, 0xc0, 0x1f, 0xb9, 0xb4, 0x73, 0x87, 0xa7, 0xf6, 0x1f, 0x9d, 0xe4, 0xff, 0x60, 0xf4, 0xb, 0xac, 0xc1, 0x94, 0x57, 0x92, 0xc4, 0x7f, 0xe4, 0xb5, 0xf0, 0x88, 0xaa, 0xb8, 0xf6, 0x4f, 0x79, 0x7b, 0xf6, 0x97, 0x9c, 0x6e, 0xee, 0xe2, 0xa7, 0x50, 0x95, 0x21, 0x40, 0x5, 0x8e, 0xf9, 0xd0, 0xdf, 0x34, 0x4d, 0xfc, 0x67, 0xf, 0xb0, 0x5, 0x12, 0xfa, 0xa1, 0x49, 0x95, 0xa1, 0x56, 0x7e, 0x59, 0xcc, 0xbe, 0xa3, 0xe, 0xb9, 0xd5, 0xaf, 0x3b, 0xc, 0x49, 0x66, 0xd5, 0x7b, 0x9e, 0x7e, 0x41, 0xb7, 0xb, 0x88, 0x3e, 0x1c, 0xe6, 0x66, 0xca, 0x13, 0xe9, 0x2e, 0x1b, 0x20, 0x1a, 0x7f, 0xbe, 0x2d, 0xca, 0x33, 0xeb, 0x39, 0x6f, 0xc, 0xcd, 0x94, 0x75, 0xbb, 0x2f, 0xf9, 0xcf, 0x2e, 0x3d, 0x83, 0x27, 0x59, 0x5f, 0x4f, 0xda, 0x10, 0x91, 0xa6, 0x4f, 0x5a, 0x13, 0x18, 0x60, 0x2, 0xac, 0x14, 0x80, 0x67, 0xc7, 0xd9, 0x33, 0xe7, 0x2d, 0xe5, 0x8a, 0x38, 0x87, 0x0, 0x4b, 0xd8, 0x51, 0x9f, 0xfc, 0xb7, 0x12, 0xe0, 0x7d, 0xca, 0xb8, 0x34, 0x79, 0xd8, 0x93, 0xdb, 0x6, 0xc, 0xf9, 0xe7, 0xb6, 0xe8, 0x5a, 0xe1, 0x36, 0x55, 0x75, 0x7b, 0x2b, 0xb5, 0xa1, 0x22, 0xfb, 0xa0, 0xad, 0x5e, 0xbb, 0xe0, 0xbf, 0xed, 0xfc, 0x84, 0x23, 0x4e, 0xbe, 0x38, 0x77, 0xc2, 0xe2, 0x0, 0xca, 0xf, 0x3d, 0x77, 0xa2, 0x3f, 0xb2, 0xc8, 0x1f, 0xc6, 0x12, 0xa3, 0xc3, 0x9f, 0x3e, 0x3d, 0x54, 0x59, 0x68, 0x8b, 0xc7, 0x32, 0x64, 0xc5, 0xd3, 0x9c, 0x9c, 0xdd, 0x9d, 0x2d, 0x39, 0x17, 0x48, 0x4d, 0x60, 0xfb, 0x59, 0x5b, 0x51, 0xe0, 0x6e, 0xd5, 0x99, 0x94, 0x69, 0x5e, 0x17, 0xa, 0x2a, 0x30, 0x38, 0xe0, 0x8b, 0xe7, 0xfc, 0x2c, 0xab, 0xbe, 0x35, 0x2, 0xdf, 0x2f, 0x7e, 0x7f, 0xd0, 0xbe, 0xec, 0x0, 0xd0, 0xfc, 0x88, 0xed, 0x6, 0x63, 0x5f, 0xb4, 0x4e, 0x6b, 0x74, 0xbb, 0x71, 0x2a, 0x82, 0xda, 0x10, 0xa4, 0x1, 0xe5, 0x71, 0x84, 0xdd, 0xca, 0x23, 0x73, 0xe4, 0x3, 0xbb, 0x34, 0xbe, 0x8d, 0xa, 0x1e, 0x68, 0x40, 0xda, 0xcb, 0xd, 0xa5, 0x6c, 0x2f, 0x87, 0xaa, 0x82, 0xdd, 0xee, 0xa, 0x4f, 0x3f, 0x56, 0x94, 0x57, 0x37, 0xa6, 0x2b, 0x27, 0xdb, 0xf5, 0xa9, 0x35, 0xe1, 0xf4, 0xa, 0x9b, 0x37, 0x3, 0xb7, 0xb0, 0x94, 0xf9, 0xaf, 0x3d, 0xe4, 0x4f, 0xee, 0xa, 0xba, 0x99, 0x7f, 0x6b, 0xab, 0x27, 0x36, 0xbc, 0x77, 0x5f, 0x3c, 0x74, 0x33, 
            0x31, 0x8f, 0x9d, 0x57, 0xd6, 0x6b, 0xba, 0x60, 0x83, 0x5d, 0x67, 0x47, 0xee, 0x8d, 0xe9, 0xe6, 0xfa, 0xb3, 0x8, 0xe8, 0x9e, 0x6a, 0xe9, 0xb9, 0x2, 0xf3, 0xfa, 0xf2, 0x39, 0xe, 0xd7, 0xc7, 0x9d, 0xcd, 0xb6, 0x11, 0x3f, 0x32, 0x85, 0xf8, 0xfa, 0x43, 0xe4, 0x6, 0x92, 0x4a, 0x9f, 0x5e, 0xea, 0xe3, 0xe3, 0xc8, 0xaa, 0xff, 0x98, 0x6d, 0xa0, 0xfd, 0xcf, 0x91, 0xdf, 0xd8, 0xae, 0x11, 0x4c, 0x7d, 0x64, 0x41, 0xa5, 0xb, 0x21, 0x86, 0xd2, 0x84, 0xc7, 0xb2, 0x42, 0x1f, 0x3c, 0xc1, 0x80, 0xe7, 0x8c, 0x7e, 0x2b, 0xcb, 0x57, 0xd5, 0xeb, 0xdf, 0x6c, 0x7e, 0xff, 0x5b, 0x9a, 0x2a, 0x6c, 0x5e, 0xbd, 0xbd, 0x16, 0xfd, 0xf3, 0x8, 0xd1, 0x31, 0x7f, 0x3e, 0x17, 0x4, 0xc7, 0xcd, 0x81, 0x33, 0x56, 0xff, 0x3e, 0x87, 0xde, 0xf7, 0xec, 0x6, 0x1b, 0x6b, 0x8e, 0xdc, 0xad, 0x2b, 0xec, 0x55, 0x2a, 0xb4, 0xd8, 0x8f, 0xf5, 0xd4, 0x7f, 0x5a, 0x23, 0x54, 0x70, 0x6b, 0x96, 0xe9, 0x82, 0x3c, 0xb8, 0xc9, 0xfe, 0x5f, 0x90, 0xd4, 0x9f, 0xb, 0xa3, 0xf9, 0xb9, 0x3c, 0x77, 0xd2, 0xfd, 0x3f, 0x75, 0x8a, 0xdf, 0x81 };
    }
}
