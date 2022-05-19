using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repository.Interface
{
    public interface ISliderRepository : IDisposable
    {
         List<VmSlider> GetSlides();
    }
}
