using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Spirit_Studio.CustomTypes
{
    public struct PhotoshootResult
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
}
