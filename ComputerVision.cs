using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.Diagnostics;

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

        //Stolen from https://stackoverflow.com/questions/40384487/system-drawing-image-to-emgu-cv-mat
        public static Mat GetMatFromSDImage(Image image)
        {
            int stride;
            Bitmap bmp = new Bitmap(image);

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

            System.Drawing.Imaging.PixelFormat pf = bmp.PixelFormat;
            if (pf == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            {
                stride = bmp.Width * 4;
            }
            else
            {
                stride = bmp.Width * 3;
            }

            Image<Bgra, byte> cvImage = new Image<Bgra, byte>(bmp.Width, bmp.Height, stride, (IntPtr)bmpData.Scan0);

            bmp.UnlockBits(bmpData);

            return cvImage.Mat;
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

            return thresholded.ToBitmap();
        }


    }
}


