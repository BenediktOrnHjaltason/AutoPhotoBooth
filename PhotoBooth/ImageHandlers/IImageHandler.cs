using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using AutoPhotoBooth.CustomTypes;

namespace AutoPhotoBooth
{
    public interface IImageHandler
    {
        void Initialize();

        void Dispose();

        List<string> GetImageHandlerNames();

        void SetActiveHandler(string name);

        Task<Bitmap> TakeStillImage(ImagePurpose purpose);

        void SaveToPositiveResults();

        void DeleteComparison();

        void StartLiveView(Action<Bitmap> OnLiveViewReceived);

        void StopLiveView();

        void Close();
    }
}
