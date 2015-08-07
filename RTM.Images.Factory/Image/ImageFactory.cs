// RTM.Images
// RTM.Images.Factory
// ImageFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using RTM.Images.Decoder;

namespace RTM.Images.Factory
{
    public class ImageFactory : IImageFactory
    {
        private readonly IImagesDecoder<Bitmap> decoder;

        public ImageFactory(IImagesDecoder<Bitmap> imagesDecoder)
        {
            decoder = imagesDecoder;
        }

        public Image Create(string value)
        {
            var bitmap = decoder.Decode(value);
            var cameraImage = Create(bitmap);
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
            var outputPixels = new byte[length];
            Marshal.Copy(bitmapData.Scan0, outputPixels, 0, length);
            bitmap.UnlockBits(bitmapData);

            var bitsPerPixel = ((int) bitmap.PixelFormat >> 8 & 0xFF);

            cameraImage.Bpp = bitsPerPixel;
            cameraImage.Width = bitmap.Width;
            cameraImage.Height = bitmap.Height;
            cameraImage.Pixels = outputPixels;
            cameraImage.Format = bitmap.PixelFormat;
            return cameraImage;
        }
    }
}