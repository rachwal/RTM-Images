// RTM.Images
// RTM.Images.Decoder.ImageSource
// BitmapImageDecoder.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 Bartosz Rachwal. The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace RTM.Images.Decoder.ImageSource
{
    public class BitmapImageDecoder : IImagesDecoder<BitmapImage>
    {
        public BitmapImage Decode(string encodedPicture)
        {
            try
            {
                return DecodeToBitmapImage(encodedPicture);
            }
            catch (Exception)
            {
                return new BitmapImage();
            }
        }

        private BitmapImage DecodeToBitmapImage(string encodedPicture)
        {
            var bytes = Convert.FromBase64String(encodedPicture);
            var bitmapImage = new BitmapImage();
            using (var stream = new MemoryStream(bytes))
            {
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
    }
}