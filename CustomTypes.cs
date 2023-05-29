using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public int FileSaveThreshold;
    }
}
