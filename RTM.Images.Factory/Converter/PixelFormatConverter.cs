// RTM.Images
// RTM.Images.Factory
// PixelFormatConverter.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

namespace RTM.Images.Factory.Converter
{
    public class PixelFormatConverter
    {
        public static System.Drawing.Imaging.PixelFormat Convert(System.Windows.Media.PixelFormat pixelFormat)
        {
            if (pixelFormat == System.Windows.Media.PixelFormats.Indexed1)
            {
                return System.Drawing.Imaging.PixelFormat.Format1bppIndexed;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Indexed4)
            {
                return System.Drawing.Imaging.PixelFormat.Format4bppIndexed;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Indexed8)
            {
                return System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.BlackWhite)
            {
                return System.Drawing.Imaging.PixelFormat.Format1bppIndexed;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Gray4)
            {
                return System.Drawing.Imaging.PixelFormat.Format4bppIndexed;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Gray8)
            {
                return System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Rgb24)
            {
                return System.Drawing.Imaging.PixelFormat.Format24bppRgb;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Rgb48)
            {
                return System.Drawing.Imaging.PixelFormat.Format48bppRgb;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Rgba64)
            {
                return System.Drawing.Imaging.PixelFormat.Format64bppArgb;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Prgba64)
            {
                return System.Drawing.Imaging.PixelFormat.Format64bppPArgb;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Gray16)
            {
                return System.Drawing.Imaging.PixelFormat.Format16bppGrayScale;
            }
            if (pixelFormat.BitsPerPixel == System.Windows.Media.PixelFormats.Gray8.BitsPerPixel)
            {
                return System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
            }
            if (pixelFormat.BitsPerPixel == System.Windows.Media.PixelFormats.Gray16.BitsPerPixel)
            {
                return System.Drawing.Imaging.PixelFormat.Format16bppGrayScale;
            }
            if (pixelFormat.BitsPerPixel == System.Windows.Media.PixelFormats.Rgb24.BitsPerPixel)
            {
                return System.Drawing.Imaging.PixelFormat.Format24bppRgb;
            }
            if (pixelFormat.BitsPerPixel == System.Windows.Media.PixelFormats.Rgb48.BitsPerPixel)
            {
                return System.Drawing.Imaging.PixelFormat.Format48bppRgb;
            }
            if (pixelFormat.BitsPerPixel == System.Windows.Media.PixelFormats.Rgba64.BitsPerPixel)
            {
                return System.Drawing.Imaging.PixelFormat.Format64bppArgb;
            }
            return System.Drawing.Imaging.PixelFormat.DontCare;
        }

        public static System.Windows.Media.PixelFormat Convert(System.Drawing.Imaging.PixelFormat pixelFormat)
        {
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format1bppIndexed)
            {
                return System.Windows.Media.PixelFormats.Indexed1;
            }
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format4bppIndexed)
            {
                return System.Windows.Media.PixelFormats.Indexed4;
            }
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
            {
                return System.Windows.Media.PixelFormats.Indexed8;
            }
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format1bppIndexed)
            {
                return System.Windows.Media.PixelFormats.BlackWhite;
            }
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format4bppIndexed)
            {
                return System.Windows.Media.PixelFormats.Gray4;
            }
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
            {
                return System.Windows.Media.PixelFormats.Gray8;
            }
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
            {
                return System.Windows.Media.PixelFormats.Rgb24;
            }
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format48bppRgb)
            {
                return System.Windows.Media.PixelFormats.Rgb48;
            }
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format64bppArgb)
            {
                return System.Windows.Media.PixelFormats.Rgba64;
            }
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format64bppPArgb)
            {
                return System.Windows.Media.PixelFormats.Prgba64;
            }
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format16bppGrayScale)
            {
                return System.Windows.Media.PixelFormats.Gray16;
            }

            return System.Windows.Media.PixelFormats.Default;
        }
    }
}