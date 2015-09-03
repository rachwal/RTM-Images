// RTM.Images
// RTM.Images.Factory
// IImageFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 Bartosz Rachwal. The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Drawing;
using System.Windows.Media.Imaging;

namespace RTM.Images.Factory
{
    public interface IImageFactory
    {
        Image Create(string value);
        Image Create(Bitmap bitmap);
        Image Create(BitmapSource bitmapSource);
    }
}