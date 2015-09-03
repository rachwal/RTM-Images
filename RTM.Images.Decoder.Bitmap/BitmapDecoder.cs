// RTM.Images
// RTM.Images.Decoder.Bitmap
// BitmapDecoder.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 Bartosz Rachwal. The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System;
using System.IO;

namespace RTM.Images.Decoder.Bitmap
{
    public class BitmapDecoder : IImagesDecoder<System.Drawing.Bitmap>
    {
        public System.Drawing.Bitmap Decode(string encodedPicture)
        {
            try
            {
                var bytes = Convert.FromBase64String(encodedPicture);

                System.Drawing.Bitmap decoded;
                using (var stream = new MemoryStream(bytes))
                {
                    decoded = new System.Drawing.Bitmap(stream);
                }
                return decoded;
            }
            catch (Exception)
            {
                return new System.Drawing.Bitmap(1, 1);
            }
        }
    }
}