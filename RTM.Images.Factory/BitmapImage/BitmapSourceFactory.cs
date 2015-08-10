// RTM.Images
// RTM.Images.Factory
// BitmapSourceFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using RTM.Images.Factory.Converter;

namespace RTM.Images.Factory
{
    public class BitmapSourceFactory : IBitmapSourceFactory
    {
        private readonly IPixelFormatConverter<PixelFormat> converter = new MediaPixelFormatConverter();

        public BitmapSource Create(Image image)
        {
            try
            {
                var pixelFormat = converter.Convert(image.Format);
                var bytesPerPixel = (pixelFormat.BitsPerPixel + 7)/8;
                var stride = 4*((image.Width*bytesPerPixel + 3)/4);
                var writeableBitmap = new WriteableBitmap(image.Width, image.Height, 96.0, 96.0, pixelFormat, null);
                writeableBitmap.WritePixels(new Int32Rect(0, 0, image.Width, image.Height), image.Pixels, stride, 0);
                writeableBitmap.Freeze();
                return writeableBitmap;
            }
            catch (Exception)
            {
                return new BitmapImage();
            }
        }
    }
}