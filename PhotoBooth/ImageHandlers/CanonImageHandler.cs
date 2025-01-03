﻿using EDSDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using AutoPhotoBooth.Configuration;
using AutoPhotoBooth.CustomTypes;

namespace AutoPhotoBooth
{
    public class CanonImageHandler : IImageHandler
    {
        private SDKHandler _sdkHandler;

        public Bitmap capturedLiveViewFrame = null;

        private string _lastCapturedImagePath = "";

        private uint _transferProgress = 0;

        public Bitmap CapturedReference { get; private set; }
        public Bitmap CapturedNew { get; private set; }

        public CanonImageHandler() 
        {
            Initialize();
        }

        private void Initialize()
        {
            Debug.WriteLine("CannonImageSource: Initializing!");

            _sdkHandler = new SDKHandler();
            _sdkHandler.LiveViewUpdated += ReceiveLiveViewStream;
            _sdkHandler.SDKProgressCallbackEvent += SDKProgressCallbackEvent;
        }

        public List<string> GetImageHandlerNames()
        {
            return _sdkHandler.GetCameraList().Select(x => x.Info.szDeviceDescription).ToList();
        }

        public void SetActiveHandler(string name)
        {
            var cameraList = _sdkHandler.GetCameraList();

            foreach (var camera in cameraList)
            {
                if (camera.Info.szDeviceDescription == name)
                {
                    Debug.WriteLine("Set active camera: " + name);
                    _sdkHandler.OpenSession(camera);

                    _sdkHandler.SetSetting(EDSDKLib.PropID_SaveTo, (uint)EDSDKLib.EdsSaveTo.Host);
                    _sdkHandler.SetCapacity();

                    break;
                }
            }
        }

        ImagePurpose LastImagePurpose;
        public async Task<Bitmap> TakeStillImage(ImagePurpose purpose)
        {
            try
            {
                LastImagePurpose = purpose;
                _transferProgress = 0;

                _sdkHandler.TakePhoto();


                if (purpose == ImagePurpose.REFERENCE)
                {
                    CapturedReference?.Dispose();
                    CapturedReference = null;

                    while (CapturedReference == null)
                    {
                        await Task.Delay(100);
                    }

                    return CapturedReference;
                }
                else
                {
                    CapturedNew?.Dispose();
                    CapturedNew = null;

                    while (CapturedNew == null)
                    {
                        await Task.Delay(100);
                    }

                    return CapturedNew;
                }
            }
            catch (Exception e)
            {
                _sdkHandler.CloseSession();
                Debug.WriteLine(e);

                return null;
            }
        }

        private uint SDKProgressCallbackEvent(uint inPercent, IntPtr inContext, ref bool outCancel)
        {
            _transferProgress = inPercent;

            if (_transferProgress == 100)
            {
                LoadCapturedImage(LastImagePurpose);
            }

            return 0;
        }

        //The Canon SDK stores the images it takes to disk and they need to be loaded
        private async void LoadCapturedImage(ImagePurpose purpose)
        {
            try
            {
                var files = Directory.EnumerateFiles(ConfigurationHandler.TempImagePath);

                Debug.WriteLine($"Files count: {files.Count()}");

                if (files.Count() == 1)
                {
                    _lastCapturedImagePath = files.ElementAt(0);

                    Debug.WriteLine("Image Path: " + _lastCapturedImagePath);

                    await Task.Delay(100);

                    Bitmap bmp = null;

                    using (var stream = File.OpenRead(_lastCapturedImagePath))
                    {
                        bmp = (Bitmap)Bitmap.FromStream(stream);
                    }

                    if (purpose == ImagePurpose.REFERENCE)
                    {
                        CapturedReference?.Dispose();
                        CapturedReference = bmp;

                        File.Delete(_lastCapturedImagePath);
                        _lastCapturedImagePath = "";
                    }
                    else
                    {
                        CapturedNew?.Dispose();
                        CapturedNew = bmp;
                    }
                }
                else throw new Exception("More than one file in temp directory");
            }
            catch (Exception e)
            {
                _sdkHandler.CloseSession();
                Debug.WriteLine(e);
            }
        }

        Action<Bitmap> OnLiveViewReceived;
        public void StartLiveView(Action<Bitmap> onLiveViewReceived)
        {
            OnLiveViewReceived += onLiveViewReceived;
            _sdkHandler.StartLiveView();
        }

        public void StopLiveView()
        {
            _sdkHandler?.StopLiveView();
        }

        public void SaveToPositiveResults()
        {
            File.Move(_lastCapturedImagePath, $"{ConfigurationHandler.PositiveResultSavePath}/{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.jpg");
        }

        public void DeleteComparison()
        {
            File.Delete(_lastCapturedImagePath);
        }

        public void ReceiveLiveViewStream(Stream str)
        {
            if (str != null)
            {
                capturedLiveViewFrame = (Bitmap)Image.FromStream(str);
                OnLiveViewReceived?.Invoke(capturedLiveViewFrame);
            }
        }

        public void Close()
        {
            Debug.WriteLine("CLOSING SESSION");

            if(File.Exists(_lastCapturedImagePath)) 
            {
                File.Delete(_lastCapturedImagePath);
            }

            _sdkHandler.CloseSession();
        }

        public void Dispose()
        {
            _sdkHandler.Dispose();
        }
    }
}
