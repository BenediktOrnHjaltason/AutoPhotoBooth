using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using Spirit_Studio.CustomTypes;

namespace Spirit_Studio
{
    class ComputerVision
    {
        public static ImageDifference GetAbsDifference(Image reference, Image newImage)
        {
            if (reference == null)
                Debug.WriteLine("*** GetAbsDifference: reference argument is null");

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

            Debug.WriteLine($"Pixels that changed: {nonZerolements}");
            Debug.WriteLine($"Pixels total in image: {totalPixels} ");

            float percentageChanged = ((float)nonZerolements / (float)totalPixels) * 100;

            Debug.WriteLine($"percentage of pixels that changed: {percentageChanged}");

            if (percentageChanged > 10)
                newImage.Save(Path.Combine("C:/ProgramData/Spirit Lab/PhotoShoot", $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.bmp"), System.Drawing.Imaging.ImageFormat.Bmp);


            return new ImageDifference { 
                ProcessedImage = thresholded.ToBitmap(), 
                Percentage = percentageChanged};
        }
    }
}
