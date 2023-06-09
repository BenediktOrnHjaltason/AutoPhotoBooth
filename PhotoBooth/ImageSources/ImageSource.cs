using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace SpiritLab
{
    public interface IImageSource
    {
        void Initialize();

        void Dispose();

        List<string> GetImageSourceNames();

        void SetActiveSource(string name);

        Task<Bitmap> TakeStillImage(ImagePurpose purpose);

        void SaveToPositiveResults();

        void DeleteComparison();

        Bitmap GetLiveViewFrame();

        void StartLiveView(Action<Bitmap> OnLiveViewReceived);

        void Close();
    }
}
