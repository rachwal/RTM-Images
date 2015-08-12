// RTM.Images
// RTM.Images.Factory
// IImageConverter.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Drawing;
using System.Windows.Media.Imaging;

namespace RTM.Images.Factory
{
    public interface IImageConverter
    {
        Bitmap ToBitmap(Image image);
        BitmapSource ToBitmapSource(Image image);
    }
}