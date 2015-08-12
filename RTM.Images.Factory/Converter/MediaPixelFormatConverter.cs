// RTM.Images
// RTM.Images.Factory
// MediaPixelFormatConverter.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Globalization;
using System.Windows.Media;

namespace RTM.Images.Factory.Converter
{
    public class MediaPixelFormatConverter : IPixelFormatConverter<PixelFormat?>
    {
        public PixelFormat? Convert(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return PixelFormats.Default;
            }

            switch (format.ToUpper(CultureInfo.InvariantCulture))
            {
                case "DEFAULT":
                    return PixelFormats.Default;

                case "EXTENDED":
                    return PixelFormats.Default;

                case "INDEXED1":
                    return PixelFormats.Indexed1;

                case "INDEXED2":
                    return PixelFormats.Indexed2;

                case "INDEXED4":
                    return PixelFormats.Indexed4;

                case "INDEXED8":
                    return PixelFormats.Indexed8;

                case "BLACKWHITE":
                    return PixelFormats.BlackWhite;

                case "GRAY2":
                    return PixelFormats.Gray2;

                case "GRAY4":
                    return PixelFormats.Gray4;

                case "GRAY8":
                    return PixelFormats.Gray8;

                case "BGR555":
                    return PixelFormats.Bgr555;

                case "BGR565":
                    return PixelFormats.Bgr565;

                case "BGR24":
                    return PixelFormats.Bgr24;

                case "RGB24":
                    return PixelFormats.Rgb24;

                case "BGR101010":
                    return PixelFormats.Bgr101010;

                case "BGR32":
                    return PixelFormats.Bgr32;

                case "BGRA32":
                    return PixelFormats.Bgra32;

                case "PBGRA32":
                    return PixelFormats.Pbgra32;

                case "RGB48":
                    return PixelFormats.Rgb48;

                case "RGBA64":
                    return PixelFormats.Rgba64;

                case "PRGBA64":
                    return PixelFormats.Prgba64;

                case "GRAY16":
                    return PixelFormats.Gray16;

                case "GRAY32FLOAT":
                    return PixelFormats.Gray32Float;

                case "RGB128FLOAT":
                    return PixelFormats.Rgb128Float;

                case "RGBA128FLOAT":
                    return PixelFormats.Rgba128Float;

                case "PRGBA128FLOAT":
                    return PixelFormats.Prgba128Float;

                case "CMYK32":
                    return PixelFormats.Cmyk32;

                default:
                    return null;
            }
        }
    }
}