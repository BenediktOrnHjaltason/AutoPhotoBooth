using Emgu.CV;
using System.Drawing;
using SpiritLab.CustomTypes;

namespace SpiritLab
{
    class ComputerVision
    {
        public static ImageDifference GetAbsDifference(Image reference, Image newImage)
        {
            Mat referenceMat = ((Bitmap)reference).ToMat();
            Mat newImageMat = ((Bitmap)newImage).ToMat();

            Mat absDiffed = new Mat();
            CvInvoke.AbsDiff( referenceMat, newImageMat, absDiffed);

            Mat thresholded = new Mat();
            CvInvoke.Threshold(absDiffed, thresholded, 50, 255, Emgu.CV.CvEnum.ThresholdType.ToZero);

            Mat grayScaleConverted = new Mat();
            CvInvoke.CvtColor(thresholded, grayScaleConverted, Emgu.CV.CvEnum.ColorConversion.Rgb2Gray);

            double nonZerolements = CvInvoke.CountNonZero(grayScaleConverted);
            double totalPixels = grayScaleConverted.Height * grayScaleConverted.Width;

            float percentageChanged = ((float)nonZerolements / (float)totalPixels) * 100;

            return new ImageDifference { 
                ProcessedImage = thresholded.ToBitmap(), 
                Percentage = percentageChanged};
        }
    }
}
