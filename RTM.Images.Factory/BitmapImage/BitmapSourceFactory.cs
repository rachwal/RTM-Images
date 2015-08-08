// RTM.Images
// RTM.Images.Factory
// BitmapSourceFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.Windows.Media.Imaging;
using RTM.Images.Factory.Converter;

namespace RTM.Images.Factory
{
    public class BitmapSourceFactory : IBitmapSourceFactory
    {
        private readonly IPixelFormatConverter converter = new PixelFormatConverter();

        public BitmapSource Create(Image image)
        {
            try
            {
                var bitsPerPixel = ((int) image.Format >> 8 & 0xFF);
                var stride = bitsPerPixel*image.Width;
                var bitmap = BitmapSource.Create(image.Width, image.Height, 96.0, 96.0,
                    converter.Convert(image.Format), null, image.Pixels, stride);
                return bitmap;
            }
            catch (Exception)
            {
                return new BitmapImage();
            }
        }
    }
}