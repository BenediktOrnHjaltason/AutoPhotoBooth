﻿using System;
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
            //GetMatFromSDImage(reference);
            Mat newImageMat = ((Bitmap)newImage).ToMat();

            Mat output = new Mat();

            CvInvoke.Subtract(referenceMat, newImageMat, output);

            //CvInvoke.AbsDiff(GetMatFromSDImage(reference), GetMatFromSDImage(newImage), output);

            return output.ToBitmap(); //ToImage<Bgra, Int16>().ToBitmap();
        }

        //public static 

    }
}

