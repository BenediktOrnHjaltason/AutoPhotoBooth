using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace Spirit_Studio.Utilities
{
    public class Utils
    {
        public static Image ResizeImage(Image imgToResize, Size size)
        {
            if (imgToResize == null)
                Debug.WriteLine("imgToResize is NULL");

            if (size == null)
                Debug.WriteLine("size is NULL");

            return new Bitmap(imgToResize, size);
        }
    }
}
