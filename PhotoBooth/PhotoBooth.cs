using System.Collections.Generic;
using System.Drawing;
using SpiritLab.CustomTypes;
using EDSDK;


namespace SpiritLab
{
    public class PhotoBooth
    {
        
        private WebcamImageSource _webcamImageSource = new WebcamImageSource();
        private CanonImageSource _canonImageSource = new CanonImageSource();

        private List<IImageSource> availableImageSources = new List<IImageSource>();

        private IImageSource _activeImageSource;

        public PhotoBooth() { }

        public void Initialize()
        {
            availableImageSources.Add(new CanonImageSource());
            availableImageSources.Add(new WebcamImageSource());
            
            availableImageSources.ForEach(x => x.Initialize());
        }

        public void CloseVideoContext()
        {
            
        }

        Bitmap capturedStill;
        Bitmap capturedLiveViewFrame;

        Bitmap savedReference;
        Bitmap savedNewImage;


        

        public List<string> GetImageSourceNames()
        {
            List<string> cameraNames = new List<string>();

            foreach(var camera in availableImageSources) 
            {
                cameraNames.AddRange(camera.GetImageSourceNames());
            }



            return cameraNames;
        }

        public Image TakeReferenceImage()
        {
            savedReference = capturedStill;

            return savedReference;
        }

        public PhotoshootResult TakeStillImage()
        {
            savedNewImage = capturedStill;

            ImageDifference difference = ComputerVision.GetAbsDifference(savedReference, savedNewImage);

            return new PhotoshootResult
            {
                ProcessedImage = difference.ProcessedImage,
                NewImage = savedNewImage,
                DifferencePercentage = difference.Percentage,
            };
        }
    }
}
