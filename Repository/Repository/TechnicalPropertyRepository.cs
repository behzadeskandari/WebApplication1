using Domain.Context;
using Domain.Db;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class TechnicalPropertyRepository : ITechnicalPropertyRepository//: IDisposable
    {
        private DataContext db = null;
        public TechnicalPropertyRepository()
        {
            db = new DataContext();
        }

        public List<TblTechnicalProp_Products> GetProductProp(int ProductID)
        {
            var q = db.TblTechnicalProp_Products
                .Where(a => a.ProductID == ProductID)
                .Include(a => a.TblTechnicalProp)
                .ToList();

            return q;
        }

        //~TechnicalPropertyRepository()
        //{
        //  Dispose();
        //}


        public void Dispose()
        {
            db.Dispose();
        }
    }

}
