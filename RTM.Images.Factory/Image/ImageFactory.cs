// RTM.Images
// RTM.Images.Factory
// ImageFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 Bartosz Rachwal. The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;
using RTM.Images.Decoder;

namespace RTM.Images.Factory
{
    public class ImageFactory : IImageFactory
    {
        private readonly IImagesDecoder<BitmapImage> decoder;

        public ImageFactory(IImagesDecoder<BitmapImage> imagesDecoder)
        {
            decoder = imagesDecoder;
        }

        public Image Create(string value)
        {
            var bitmap = decoder.Decode(value);
            var cameraImage = Create(bitmap);
            return cameraImage;
        }

        public Image Create(BitmapSource bitmapSource)
        {
            if (bitmapSource == null)
                return Image.Empty;
            try
            {
                var width = bitmapSource.PixelWidth;
                var height = bitmapSource.PixelHeight;
                var format = bitmapSource.Format;

                var bitmap = new WriteableBitmap(bitmapSource);
                var bytesPerPixel = (bitmap.Format.BitsPerPixel + 7)/8;
                var stride = 4*((bitmapSource.PixelWidth*bytesPerPixel + 3)/4);
                var length = stride*bitmapSource.PixelHeight;
                var pixels = new byte[length];
                bitmap.CopyPixels(pixels, stride, 0);

                return new Image(format.BitsPerPixel, width, height, pixels, format.ToString());
            }
            catch (Exception)
            {
                return Image.Empty;
            }
        }

        public Image Create(Bitmap bitmap)
        {
            if (bitmap == null)
                return Image.Empty;

            try
            {
                var bitsPerPixel = ((int) bitmap.PixelFormat >> 8 & 0xFF);
                var width = bitmap.Width;
                var height = bitmap.Height;
                var pixelFormat = bitmap.PixelFormat;

                var rect = new Rectangle(0, 0, width, height);
                var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, pixelFormat);
                var length = bitmapData.Stride*bitmapData.Height;

                var pixels = new byte[length];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, length);
                bitmap.UnlockBits(bitmapData);
                bitmap.Dispose();

                return new Image(bitsPerPixel, width, height, pixels, pixelFormat.ToString());
            }
            catch (Exception)
            {
                return Image.Empty;
            }
        }
    }
}