// RTM.Images
// RTM.Images.Factory
// IBitmapSourceFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 Bartosz Rachwal. The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Windows.Media.Imaging;

namespace RTM.Images.Factory
{
    public interface IBitmapSourceFactory
    {
        BitmapSource Create(Image image);
    }
}