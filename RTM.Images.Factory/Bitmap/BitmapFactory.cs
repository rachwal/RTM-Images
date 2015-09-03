// RTM.Images
// RTM.Images.Factory
// BitmapFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 Bartosz Rachwal. The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using RTM.Images.Factory.Converter;

namespace RTM.Images.Factory
{
    public class BitmapFactory : IBitmapFactory
    {
        private readonly IPixelFormatConverter<PixelFormat> converter = new DrawingPixelFormatConverter();

        public Bitmap Create(Image image)
        {
            var pixelFormat = converter.Convert(image.Format);
            try
            {
                var bitmap = new Bitmap(image.Width, image.Height, pixelFormat);
                var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                var bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
                var length = image.Pixels.Length;
                Marshal.Copy(image.Pixels, 0, bitmapData.Scan0, length);
                bitmap.UnlockBits(bitmapData);
                image.Pixels = new byte[1];
                return bitmap;
            }
            catch (Exception)
            {
                image.Pixels = new byte[1];
                return new Bitmap(1, 1);
            }
        }
    }
}