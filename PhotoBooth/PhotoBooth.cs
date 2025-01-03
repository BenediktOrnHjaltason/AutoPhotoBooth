﻿using System.Collections.Generic;
using System.Drawing;
using AutoPhotoBooth.CustomTypes;
using System.Threading.Tasks;
using System;

namespace AutoPhotoBooth
{
    public class PhotoBooth
    {
        private List<IImageHandler> availableImageHandlers = new List<IImageHandler>();
        private static IImageHandler _activeImageHandler;

        public PhotoBooth() { }

        public void Initialize()
        {
            availableImageHandlers.Add(new CanonImageHandler());
            availableImageHandlers.Add(new WebcamImageHandler());
        }

        public void SetActiveImageHandler(string name)
        {
            foreach(var handler in availableImageHandlers)
            {
                if (handler.GetImageHandlerNames().Contains(name))
                {
                    handler.SetActiveHandler(name);

                    if (_activeImageHandler != null)
                        _activeImageHandler.Close();

                    _activeImageHandler = handler;
                    break;
                }
            }
        }

        public void Close()
        {
            if (_activeImageHandler != null)
                _activeImageHandler.Close();
        }

        public void StartLiveView(Action<Bitmap> onLiveViewUpdated)
        {
            _activeImageHandler.StartLiveView(onLiveViewUpdated);
        }

        public static void StopLiveView()
        {
            _activeImageHandler.StopLiveView();
        }

        public List<string> GetImageHandlerNames()
        {
            List<string> handlerNames = new List<string>();

            foreach(var handler in availableImageHandlers) 
            {
                handlerNames.AddRange(handler.GetImageHandlerNames());
            }

            return handlerNames;
        }

        public async Task<Bitmap> TakeReferenceImage()
        {
            return await _activeImageHandler.TakeStillImage(ImagePurpose.REFERENCE);
        }

        public async Task<ComparisonResult> CompareNewImage()
        {
            await _activeImageHandler.TakeStillImage(ImagePurpose.COMPARISON);

            ImageDifference difference = ComputerVision.GetAbsDifference(_activeImageHandler.CapturedReference, _activeImageHandler.CapturedNew);

            var result = new ComparisonResult
            {
                ProcessedImage = (Bitmap)difference.ProcessedImage.Clone(),
                NewImage = (Bitmap)_activeImageHandler.CapturedNew.Clone(),
                DifferencePercentage = difference.Percentage,
            };

            difference.Dispose();

            return result;
        }

        public void SaveToPositiveResults()
        {
            _activeImageHandler.SaveToPositiveResults();
        }

        public void DeleteComparison()
        {
            _activeImageHandler?.DeleteComparison();
        }

        public void Dispose()
        {
            availableImageHandlers.ForEach(x => x.Dispose());
        }
    }
}
