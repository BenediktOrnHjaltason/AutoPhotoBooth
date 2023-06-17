using System;
using System.Drawing;

namespace SpiritLab.CustomTypes
{
    public struct ComparisonResult : IDisposable
    {
        public Image ProcessedImage;
        public Image NewImage;
        public float DifferencePercentage;

        public void Dispose() 
        {
            ProcessedImage?.Dispose();
            NewImage?.Dispose();
        }
    }

    public struct ImageDifference
    {
        public Image ProcessedImage;
        public float Percentage;

        public void Dispose()
        {
            ProcessedImage?.Dispose();
        }
    }

    public class Config
    {
        public PhotoBoothConfig PhotoBoothConfig = new PhotoBoothConfig();
    }

    public class PhotoBoothConfig
    {
        public int FileSaveThresholdMultiplier = 1;
        public int ShootInterval = 10;
        public int SlideshowInterval = 10;
    }
}
