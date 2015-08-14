// RTM.Images
// RTM.Images.Factory
// ImageConverter.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using RTM.Images.Factory.Converter;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

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
            var preprocessed = Preprocess(image);
            var pixelFormat = drawingConverter.Convert(preprocessed.Format);
            if (pixelFormat != PixelFormat.Undefined)
            {
                return bitmapFactory.Create(preprocessed);
            }
            var bitmapSource = bitmapSourceFactory.Create(preprocessed);
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
            var preprocessed = Preprocess(image);
            var pixelFormat = mediaConverter.Convert(preprocessed.Format);
            if (pixelFormat != null)
            {
                return bitmapSourceFactory.Create(preprocessed);
            }
            var bitmap = bitmapFactory.Create(preprocessed);
            return Convert(bitmap);
        }

        private Image Preprocess(Image image)
        {
            return !string.IsNullOrEmpty(image.Format) ? image : TryGuessPixelFormat(image);
        }

        private Image TryGuessPixelFormat(Image image)
        {
            var ratio = image.Pixels.Length/(image.Width*image.Height);

            switch (ratio)
            {
                case 1:
                    image.Format = PixelFormats.Gray8.ToString();
                    break;
                case 2:
                    image.Format = PixelFormats.Gray16.ToString();
                    break;
                case 3:
                    image.Format = PixelFormats.Rgb24.ToString();
                    break;
                case 4:
                    image.Format = PixelFormat.Format32bppRgb.ToString();
                    break;
                case 6:
                    image.Format = PixelFormats.Rgb48.ToString();
                    break;
            }
            return image;
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        private BitmapSource Convert(Bitmap bitmap)
        {
            var hBitmap = bitmap.GetHbitmap();

            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }
        }
    }
}