using System.Collections.Generic;
using System.Drawing;
using SpiritLab.CustomTypes;
using System.Threading.Tasks;
using System;
using SpiritLab.Configuration;
using System.IO;

namespace SpiritLab
{
    public class PhotoBooth
    {
        private List<IImageSource> availableImageSources = new List<IImageSource>();
        private static IImageSource _activeImageSource;

        public static Bitmap CapturedReference { get; set; }
        public static Bitmap CapturedComparison { get; set; }

        public PhotoBooth() { }

        public void Initialize()
        {
            availableImageSources.Add(new CanonImageSource());
            availableImageSources.Add(new WebcamImageSource());
            
            availableImageSources.ForEach(x => x.Initialize());
        }

        public void SetActiveImageSource(string name)
        {
            foreach(var source in availableImageSources)
            {
                if (source.GetImageSourceNames().Contains(name))
                {
                    source.SetActiveSource(name);

                    if (_activeImageSource != null)
                        _activeImageSource.Close();

                    _activeImageSource = source;
                    break;
                }
            }
        }

        public void Close()
        {
            if (_activeImageSource != null)
                _activeImageSource.Close();
        }

        public void StartLiveView(Action<Bitmap> onLiveViewUpdated)
        {
            _activeImageSource.StartLiveView(onLiveViewUpdated);
        }

        public static void StopLiveView()
        {
            _activeImageSource.StopLiveView();
        }

        public List<string> GetImageSourceNames()
        {
            List<string> cameraNames = new List<string>();

            foreach(var camera in availableImageSources) 
            {
                cameraNames.AddRange(camera.GetImageSourceNames());
            }

            return cameraNames;
        }

        public async Task<Bitmap> TakeReferenceImage()
        {
            return await _activeImageSource.TakeStillImage(ImagePurpose.REFERENCE);
        }

        public async Task<ComparisonResult> CompareNewImage()
        {
            var newImage = await _activeImageSource.TakeStillImage(ImagePurpose.COMPARISON);

            ImageDifference difference = ComputerVision.GetAbsDifference(CapturedReference, newImage);

            return new ComparisonResult
            {
                ProcessedImage = difference.ProcessedImage,
                NewImage = newImage,
                DifferencePercentage = difference.Percentage,
            };
        }

        public void SaveToPositiveResults()
        {
            _activeImageSource.SaveToPositiveResults();
        }

        public void DeleteComparison()
        {
            _activeImageSource?.DeleteComparison();
        }

        public void Dispose()
        {
            availableImageSources.ForEach(x => x.Dispose());
        }
    }

    public enum ImagePurpose
    {
        REFERENCE = 0,
        COMPARISON = 1
    }
}
