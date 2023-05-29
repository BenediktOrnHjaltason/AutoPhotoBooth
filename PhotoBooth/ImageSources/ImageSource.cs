using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritLab
{
    public interface IImageSource
    {
        void Initialize();

        List<string> GetImageSourceNames();

        void Close();

    }
}
