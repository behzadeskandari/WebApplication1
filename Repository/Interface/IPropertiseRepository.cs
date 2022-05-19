using Domain.Db;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;
namespace Repository.Interface
{
    public interface IPropertiseRepository : IDisposable
    {
         List<VmPropertice> GetProductPropertise(int ProductID);
    }
}
