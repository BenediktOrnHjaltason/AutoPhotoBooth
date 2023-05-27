using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDSDK;
using Emgu.CV.CvEnum;

namespace Spirit_Studio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            EDSDKLib.EdsInitializeSDK();

            IntPtr cameraList = IntPtr.Zero;
            var error1 = EDSDKLib.EdsGetCameraList(out cameraList);

            int cameraCount = 0;
            var error2 = EDSDKLib.EdsGetChildCount(cameraList, out cameraCount);

            IntPtr cameraRef = IntPtr.Zero;

            EDSDKLib.EdsGetChildAtIndex(cameraList, 0, out cameraRef);

            Debug.WriteLine("Camera count: " + cameraCount);

            EDSDKLib.EdsDeviceInfo cameraInfo = new EDSDKLib.EdsDeviceInfo();

            var error3 =  EDSDKLib.EdsGetDeviceInfo(cameraRef, out cameraInfo);

            Debug.WriteLine($"Camera info:{cameraInfo.szDeviceDescription}");

            var error4 = EDSDKLib.EdsOpenSession(cameraRef);

            Debug.WriteLine("OpenSession error: " + error4);
            */

            SDKHandler sdkHandler = new SDKHandler();

            var cameraList = sdkHandler.GetCameraList();

            Debug.WriteLine("number of cameras:" +  cameraList.Count);

            sdkHandler.OpenSession(cameraList.First());

            sdkHandler.TakePhoto();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
