using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritLab
{
    public interface IImageSource
    {
        Bitmap capturedStill { get; set; }
        Bitmap capturedLiveViewFrame { get; set; }

        void Initialize();

        List<string> GetImageSourceNames();

        void SetActiveSource(string name);

        Task<Bitmap> TakeStillImage();

        Bitmap GetLiveViewFrame();

        void StartLiveView(Action<Bitmap> OnLiveViewReceived);

        void Close();

    }
}
