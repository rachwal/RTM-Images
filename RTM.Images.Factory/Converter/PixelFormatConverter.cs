// RTM.Images
// RTM.Images.Factory
// PixelFormatConverter.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.Drawing.Imaging;

namespace RTM.Images.Factory.Converter
{
    public class PixelFormatConverter : IPixelFormatConverter
    {
        public PixelFormat Convert(System.Windows.Media.PixelFormat pixelFormat)
        {
            if (pixelFormat == System.Windows.Media.PixelFormats.Indexed1)
            {
                return PixelFormat.Format1bppIndexed;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Indexed4)
            {
                return PixelFormat.Format4bppIndexed;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Indexed8)
            {
                return PixelFormat.Format8bppIndexed;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.BlackWhite)
            {
                return PixelFormat.Format1bppIndexed;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Gray4)
            {
                return PixelFormat.Format4bppIndexed;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Gray8)
            {
                return PixelFormat.Format8bppIndexed;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Rgb24)
            {
                return PixelFormat.Format24bppRgb;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Rgb48)
            {
                return PixelFormat.Format48bppRgb;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Rgba64)
            {
                return PixelFormat.Format64bppArgb;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Prgba64)
            {
                return PixelFormat.Format64bppPArgb;
            }
            if (pixelFormat == System.Windows.Media.PixelFormats.Gray16)
            {
                return PixelFormat.Format16bppGrayScale;
            }
            if (pixelFormat.BitsPerPixel == System.Windows.Media.PixelFormats.Gray8.BitsPerPixel)
            {
                return PixelFormat.Format8bppIndexed;
            }
            if (pixelFormat.BitsPerPixel == System.Windows.Media.PixelFormats.Gray16.BitsPerPixel)
            {
                return PixelFormat.Format16bppGrayScale;
            }
            if (pixelFormat.BitsPerPixel == System.Windows.Media.PixelFormats.Rgb24.BitsPerPixel)
            {
                return PixelFormat.Format24bppRgb;
            }
            if (pixelFormat.BitsPerPixel == System.Windows.Media.PixelFormats.Rgb48.BitsPerPixel)
            {
                return PixelFormat.Format48bppRgb;
            }
            if (pixelFormat.BitsPerPixel == System.Windows.Media.PixelFormats.Rgba64.BitsPerPixel)
            {
                return PixelFormat.Format64bppArgb;
            }
            return PixelFormat.DontCare;
        }

        public System.Windows.Media.PixelFormat Convert(PixelFormat pixelFormat)
        {
            if (pixelFormat == PixelFormat.Format1bppIndexed)
            {
                return System.Windows.Media.PixelFormats.Indexed1;
            }
            if (pixelFormat == PixelFormat.Format4bppIndexed)
            {
                return System.Windows.Media.PixelFormats.Indexed4;
            }
            if (pixelFormat == PixelFormat.Format8bppIndexed)
            {
                return System.Windows.Media.PixelFormats.Indexed8;
            }
            if (pixelFormat == PixelFormat.Format1bppIndexed)
            {
                return System.Windows.Media.PixelFormats.BlackWhite;
            }
            if (pixelFormat == PixelFormat.Format4bppIndexed)
            {
                return System.Windows.Media.PixelFormats.Gray4;
            }
            if (pixelFormat == PixelFormat.Format8bppIndexed)
            {
                return System.Windows.Media.PixelFormats.Gray8;
            }
            if (pixelFormat == PixelFormat.Format24bppRgb)
            {
                return System.Windows.Media.PixelFormats.Rgb24;
            }
            if (pixelFormat == PixelFormat.Format48bppRgb)
            {
                return System.Windows.Media.PixelFormats.Rgb48;
            }
            if (pixelFormat == PixelFormat.Format64bppArgb)
            {
                return System.Windows.Media.PixelFormats.Rgba64;
            }
            if (pixelFormat == PixelFormat.Format64bppPArgb)
            {
                return System.Windows.Media.PixelFormats.Prgba64;
            }
            if (pixelFormat == PixelFormat.Format16bppGrayScale)
            {
                return System.Windows.Media.PixelFormats.Gray16;
            }

            return System.Windows.Media.PixelFormats.Default;
        }

        public PixelFormat Convert(string pixelFormat)
        {
            return TryParse(pixelFormat);
        }

        private PixelFormat TryParse(string pixelFormat)
        {
            try
            {
                var format = (PixelFormat) Enum.Parse(typeof (PixelFormat), pixelFormat, true);
                return format;
            }
            catch (Exception)
            {
            }

            try
            {
                var format =
                    (System.Windows.Media.PixelFormat)
                        Enum.Parse(typeof (System.Windows.Media.PixelFormat), pixelFormat, true);
                return Convert(format);
            }
            catch (Exception)
            {
                return Convert(System.Windows.Media.PixelFormats.Default);
            }
        }
    }
}