using Domain.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IImageRepository : IDisposable
    {
         TblImage GetImageByID(int id);
         List<TblImage> GetImageByProductID(int ProductID);
    }
}
