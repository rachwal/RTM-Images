// RTM.Images
// RTM.Images.Factory
// DrawingPixelFormatConverter.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 Bartosz Rachwal. The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.Drawing.Imaging;

namespace RTM.Images.Factory.Converter
{
    public class DrawingPixelFormatConverter : IPixelFormatConverter<PixelFormat>
    {
        public PixelFormat Convert(string format)
        {
            try
            {
                return (PixelFormat) Enum.Parse(typeof (PixelFormat), format, true);
            }
            catch (Exception)
            {
                return PixelFormat.Undefined;
            }
        }
    }
}