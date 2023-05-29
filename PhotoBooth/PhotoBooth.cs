using System.Collections.Generic;
using System.Drawing;
using SpiritLab.CustomTypes;
using EDSDK;
using System.Diagnostics;
using System.Threading.Tasks;
using System;

namespace SpiritLab
{
    public class PhotoBooth
    {
        private List<IImageSource> availableImageSources = new List<IImageSource>();
        private IImageSource _activeImageSource;

        public Bitmap _savedReference { get; set; }
        public Bitmap _savedNewImage { get; set; }

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
                    _activeImageSource = source;
                    break;
                }
            }
        }

        public void Close()
        {
            _activeImageSource.Close();
        }

        
        public void StartLiveView(Action<Bitmap> onLiveViewUpdated)
        {
            _activeImageSource.StartLiveView(onLiveViewUpdated);
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

        public async Task<Image> TakeReferenceImage()
        {
            _savedReference = await _activeImageSource.TakeStillImage();

            return _savedReference;
        }

        public async Task<ComparisonResult> CompareNewImage()
        {
            _savedNewImage = await _activeImageSource.TakeStillImage();

            ImageDifference difference = ComputerVision.GetAbsDifference(_savedReference, _savedNewImage);

            return new ComparisonResult
            {
                ProcessedImage = difference.ProcessedImage,
                NewImage = _savedNewImage,
                DifferencePercentage = difference.Percentage,
            };
        }
    }
}
