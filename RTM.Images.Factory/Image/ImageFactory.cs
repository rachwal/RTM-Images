// RTM.Images
// RTM.Images.Factory
// ImageFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

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
            var cameraImage = new Image();
            if (bitmapSource == null)
                return cameraImage;

            var bitmap = new WriteableBitmap(bitmapSource);
            var bytesPerPixel = (bitmap.Format.BitsPerPixel + 7)/8;
            var stride = 4*((bitmapSource.PixelWidth*bytesPerPixel + 3)/4);
            var length = stride*bitmapSource.PixelHeight;
            var pixels = new byte[length];
            bitmap.CopyPixels(pixels, stride, 0);
            bitmap.Freeze();

            cameraImage.Bpp = bitmapSource.Format.BitsPerPixel;
            cameraImage.Width = bitmapSource.PixelWidth;
            cameraImage.Height = bitmapSource.PixelHeight;
            cameraImage.Pixels = pixels;
            cameraImage.Format = bitmapSource.Format.ToString();
            return cameraImage;
        }

        public Image Create(Bitmap bitmap)
        {
            var cameraImage = new Image();
            if (bitmap == null)
                return cameraImage;

            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
            var length = bitmapData.Stride*bitmapData.Height;
            var pixels = new byte[length];
            Marshal.Copy(bitmapData.Scan0, pixels, 0, length);
            bitmap.UnlockBits(bitmapData);

            var bitsPerPixel = ((int) bitmap.PixelFormat >> 8 & 0xFF);

            cameraImage.Bpp = bitsPerPixel;
            cameraImage.Width = bitmap.Width;
            cameraImage.Height = bitmap.Height;
            cameraImage.Pixels = pixels;
            cameraImage.Format = bitmap.PixelFormat.ToString();
            return cameraImage;
        }
    }
}