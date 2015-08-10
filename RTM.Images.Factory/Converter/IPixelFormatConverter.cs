// RTM.Images
// RTM.Images.Factory
// IPixelFormatConverter.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Drawing.Imaging;

namespace RTM.Images.Factory.Converter
{
    public interface IPixelFormatConverter
    {
        PixelFormat Convert(System.Windows.Media.PixelFormat pixelFormat);
        PixelFormat Convert(string pixelFormat);
        System.Windows.Media.PixelFormat Convert(PixelFormat pixelFormat);
    }
}