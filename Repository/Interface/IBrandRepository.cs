using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repository.Interface
{
    public interface IBrandRepository : IDisposable
    {
         List<VmBrand> GetBrandList(int Count = 2);
    }
}
