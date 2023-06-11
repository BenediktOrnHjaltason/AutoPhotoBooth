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

            referenceMat.Dispose();
            newImageMat.Dispose();

            Mat thresholded = new Mat();
            CvInvoke.Threshold(absDiffed, thresholded, 50, 255, Emgu.CV.CvEnum.ThresholdType.ToZero);

            absDiffed.Dispose();

            Mat grayScaleConverted = new Mat();
            CvInvoke.CvtColor(thresholded, grayScaleConverted, Emgu.CV.CvEnum.ColorConversion.Rgb2Gray);

            double nonZerolements = CvInvoke.CountNonZero(grayScaleConverted);
            double totalPixels = grayScaleConverted.Height * grayScaleConverted.Width;

            grayScaleConverted.Dispose();

            float percentageChanged = ((float)nonZerolements / (float)totalPixels) * 100;

            var absdiffed = new ImageDifference
            {
                ProcessedImage = (Bitmap)thresholded.ToBitmap().Clone(),
                Percentage = percentageChanged
            };

            thresholded.Dispose();

            return absdiffed;
        }
    }
}
