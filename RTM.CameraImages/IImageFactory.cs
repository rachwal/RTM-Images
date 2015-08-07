// RTM.Images
// RTM.CameraImages
// IImageFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Drawing;

namespace RTM.CameraImages
{
    public interface IImageFactory
    {
        Image Create(string value);
        Image Create(Bitmap bitmap);
    }
}