using Domain.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Repository.Interface
{
    public interface IProductRepository : IDisposable
    {
         List<VmProductList> GetLatestProductList(int Count = 4);

         List<VmProductList> GetMostViewedProductList(int Count = 4);
         TblProducts ProductDetails(string TitleEn);
         IQueryable<TblProducts> GetProductByCategory(int CateID);

         bool AddVisit(int ProductID);

         List<TblAsks> GetChildAsk(int ID);
    }

}
