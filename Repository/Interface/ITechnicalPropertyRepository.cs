using Domain.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ITechnicalPropertyRepository : IDisposable
    {
         List<TblTechnicalProp_Products> GetProductProp(int ProductID);
    }
}
