using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using System.Drawing;

namespace Spirit_Studio
{
    class ComputerVision
    {
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }
    }
}
