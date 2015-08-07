// RTM.Images
// RTM.Images.Factory
// BitmapFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace RTM.Images.Factory
{
    public class BitmapFactory : IBitmapFactory
    {
        public Bitmap Create(Image image)
        {
            try
            {
                var bitmap = new Bitmap(image.Width, image.Height, image.Format);
                var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                var bitmapData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);
                var length = image.Pixels.Length;
                Marshal.Copy(image.Pixels, 0, bitmapData.Scan0, length);
                bitmap.UnlockBits(bitmapData);
                return bitmap;
            }
            catch (Exception)
            {
                return new Bitmap(1, 1);
            }
        }
    }
}