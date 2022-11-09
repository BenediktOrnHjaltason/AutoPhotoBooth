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

        public static Bitmap GetAbsDifference(Image reference, Image newImage)
        {
            Mat referenceMat = ((Bitmap)reference).ToMat();
            Mat newImageMat = ((Bitmap)newImage).ToMat();

            MCvScalar refSum = CvInvoke.Sum(referenceMat);
            MCvScalar newSum = CvInvoke.Sum(newImageMat);

            Bitmap referenceBitmap = (Bitmap)reference;


            //double totalRefSum = refSum.V0 + refSum.V1 + refSum.V2;
            //double totalNewSum = newSum.V0 + newSum.V1 + newSum.V2;

            //Debug.WriteLine($"SUM of reference image: V0: {refSum.V0}. V1: {refSum.V1}. V2: {refSum.V2}. TotalSum = {totalRefSum}");

            //Debug.WriteLine($"SUM of new image: V0: {newSum.V0}. V1: {newSum.V1}. V2: {newSum.V2}. TotalSum = {totalNewSum}");

            //double similarityPercentage = totalNewSum < totalRefSum ? (totalNewSum / totalRefSum * 100) : (totalRefSum / totalNewSum * 100);

            //Debug.WriteLine($"NEW Image is {similarityPercentage} identical to reference image");

            Mat absDiffed = new Mat();

            CvInvoke.AbsDiff( referenceMat, newImageMat, absDiffed);

            Mat thresholded = new Mat();

            CvInvoke.Threshold(absDiffed, thresholded, 50, 255, Emgu.CV.CvEnum.ThresholdType.ToZero);

            Mat grayScaleConverted = new Mat();

            CvInvoke.CvtColor(absDiffed, grayScaleConverted, Emgu.CV.CvEnum.ColorConversion.Rgb2Gray);

            


            //Image<Gray,byte> grayScale = 

            

            var nonZeroelements = CvInvoke.CountNonZero(grayScaleConverted);

            double percentageDifference = ((double)nonZeroelements / (double)(grayScaleConverted.Height * grayScaleConverted.Width));

            var sumOfAbsDiff = CvInvoke.Sum(grayScaleConverted);

            Debug.WriteLine($"Sum of difference: {sumOfAbsDiff.V0}");

            //double similarityPercentage = ((CvInvoke.CountNonZero(output) / (reference.Width * reference.Height))) * 100;

            //Debug.WriteLine($"NEW Image is {similarityPercentage} identical to reference image");

            //CvInvoke.AbsDiff(GetMatFromSDImage(reference), GetMatFromSDImage(newImage), output);

            return thresholded.ToBitmap(); //ToImage<Bgra, Int16>().ToBitmap();
        }

        //public static 

    }
}

