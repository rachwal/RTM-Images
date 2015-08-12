// RTM.Images
// RTM.Images.Factory
// ImageConverter.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using RTM.Images.Factory.Converter;

namespace RTM.Images.Factory
{
    public class ImageConverter : IImageConverter
    {
        private readonly IBitmapFactory bitmapFactory = new BitmapFactory();
        private readonly IPixelFormatConverter<PixelFormat> drawingConverter = new DrawingPixelFormatConverter();

        private readonly IBitmapSourceFactory bitmapSourceFactory = new BitmapSourceFactory();

        private readonly IPixelFormatConverter<System.Windows.Media.PixelFormat?> mediaConverter =
            new MediaPixelFormatConverter();

        public Bitmap ToBitmap(Image image)
        {
            var pixelFormat = drawingConverter.Convert(image.Format);
            if (pixelFormat != PixelFormat.Undefined)
            {
                return bitmapFactory.Create(image);
            }
            var bitmapSource = bitmapSourceFactory.Create(image);
            return Convert(bitmapSource);
        }

        private Bitmap Convert(BitmapSource bitmapSource)
        {
            try
            {
                using (var outStream = new MemoryStream())
                {
                    var bitmapEncoder = new BmpBitmapEncoder();
                    bitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                    bitmapEncoder.Save(outStream);
                    return new Bitmap(outStream);
                }
            }
            catch (Exception)
            {
                return new Bitmap(1, 1);
            }
        }

        public BitmapSource ToBitmapSource(Image image)
        {
            var pixelFormat = mediaConverter.Convert(image.Format);
            if (pixelFormat != null)
            {
                return bitmapSourceFactory.Create(image);
            }
            var bitmap = bitmapFactory.Create(image);
            return Convert(bitmap);
        }

        private BitmapSource Convert(Bitmap bitmap)
        {
            try
            {
                var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero,
                    Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                bitmapSource.Freeze();
                return bitmapSource;
            }
            catch (Exception)
            {
                return new BitmapImage();
            }
        }
    }
}