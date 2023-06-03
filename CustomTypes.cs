using System.Drawing;

namespace SpiritLab.CustomTypes
{
    public struct ComparisonResult
    {
        public Image ProcessedImage;
        public Image NewImage;
        public float DifferencePercentage;
    }

    public struct ImageDifference
    {
        public Image ProcessedImage;
        public float Percentage;
    }

    public class Config
    {
        public PhotoBoothConfig PhotoBoothConfig = new PhotoBoothConfig();
    }

    public class PhotoBoothConfig
    {
        public int FileSaveThreshold = 3;
        public int ShootInterval = 30;
        public int SlideshowInterval = 10;
    }
}
