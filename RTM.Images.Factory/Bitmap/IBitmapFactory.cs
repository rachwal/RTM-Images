// RTM.Images
// RTM.Images.Factory
// IBitmapFactory.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

using System.Drawing;

namespace RTM.Images.Factory
{
    public interface IBitmapFactory
    {
        Bitmap Create(Image image);
    }
}