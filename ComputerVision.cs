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

namespace Spirit_Studio
{
    class ComputerVision
    {
        public static Image resizeImage(Image imgToResize, Size size)
        {
            if (imgToResize == null)
                Debug.WriteLine("imgToResize is NULL");

            if (size == null)
                Debug.WriteLine("size is NULL");

            return new Bitmap(imgToResize, size);
        }

        public static Bitmap GetAbsDifference(Image reference, Image newImage, out double? differencePercentage)
        {
            Mat referenceMat = ((Bitmap)reference).ToMat();
            Mat newImageMat = ((Bitmap)newImage).ToMat();

            Mat absDiffed = new Mat();
            CvInvoke.AbsDiff( referenceMat, newImageMat, absDiffed);

            Mat thresholded = new Mat();
            CvInvoke.Threshold(absDiffed, thresholded, 50, 255, Emgu.CV.CvEnum.ThresholdType.ToZero);

            Mat grayScaleConverted = new Mat();
            CvInvoke.CvtColor(thresholded, grayScaleConverted, Emgu.CV.CvEnum.ColorConversion.Rgb2Gray);

            double nonZeroelements = CvInvoke.CountNonZero(grayScaleConverted);
            double totalPixels = grayScaleConverted.Height * grayScaleConverted.Width;

            Debug.WriteLine($"Pixels that changed: {nonZeroelements}");
            Debug.WriteLine($"Pixels total in image: {totalPixels} ");

            double percentageChanged = (nonZeroelements / totalPixels) * 100;

            differencePercentage = percentageChanged;

            Debug.WriteLine($"percentage of pixels that changed: {percentageChanged}");

            if (differencePercentage > 10)
                newImage.Save(Path.Combine("C:/ProgramData/Spirit Lab/PhotoShoot", $"{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.bmp"), System.Drawing.Imaging.ImageFormat.Bmp);
            

            return thresholded.ToBitmap();
        }


    }
}


