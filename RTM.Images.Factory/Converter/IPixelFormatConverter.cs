// RTM.Images
// RTM.Images.Factory
// IPixelFormatConverter.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

namespace RTM.Images.Factory.Converter
{
    public interface IPixelFormatConverter<out T>
    {
        T Convert(string format);
    }
}