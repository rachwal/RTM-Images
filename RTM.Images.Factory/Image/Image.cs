// RTM.Images
// RTM.Images.Factory
// Image.cs
// 
// Created by Bartosz Rachwal. 
// Copyright (c) 2015 The National Institute of Advanced Industrial Science and Technology, Japan. All rights reserved. 

namespace RTM.Images.Factory
{
    public struct Image
    {
        public int Bpp { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public byte[] Pixels { get; set; }
        public string Format { get; set; }
    }
}