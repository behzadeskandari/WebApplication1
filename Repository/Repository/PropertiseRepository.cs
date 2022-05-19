using Domain.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Domain.Db;

namespace Repository.Repository
{
    public class PropertiseRepository : IPropertiseRepository//IDisposable
    {
        private DataContext db = null;
        public PropertiseRepository()
        {
            db = new DataContext();
        }


        public List<VmPropertice> GetProductPropertise(int ProductID)
        {
            var q = (from a in db.TblPropertiseTitle
                     join b in db.TblPropertis on a.ID equals b.TitleID
                     join c in db.TblPropertis_Product on b.ID equals c.PropertiseID
                     where c.ProductID == ProductID
                     select new VmPropertice
                     {
                         ID = a.ID,
                         IDProduct_Property = c.ID,
                         Title = a.Title,
                         PropTitle  = b.Title,
                         Price = c.Price
                     }).ToList();

            //var qPropertice = db.TblPropertis_Product
            //    .Where(a => a.ProductID == ProductID)
            //    .Include(x => x.TblPropertis)
            //    .ThenInclude(a => a.PropertiseTitle)
            //    .ToList();
            return q;
        }
        //~PropertiseRepository()
        //{
        //  Dispose();
        //}

        public void Dispose()
        {
            db.Dispose();
        }

     
    }

}
