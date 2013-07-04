﻿using System;
using System.IO;

namespace WorldWideWat.SpriteThumbs
{
    public class RawImage
    {
        public string FullFilePath { get; set; }
        public string Id { get; set; }
        public DateTime LastWriteTime
        {
            get
            {
                return new FileInfo(FullFilePath).LastWriteTime;
            }
        }
    }
}