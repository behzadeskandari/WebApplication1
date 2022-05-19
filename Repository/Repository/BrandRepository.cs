using Domain.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Repository.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private DataContext _db = null;
        public BrandRepository()
        {
            _db = new DataContext();
        }
        public BrandRepository(DataContext db)
        {
            _db = db;
        }
        public List<VmBrand> GetBrandList(int Count = 2)
        {
            var qBrand = _db.TblBrands.Include(a => a.TblImage)
              .ThenInclude(a => a.TblServer)
              .OrderByDescending(a => a.ID)
                .Take(Count)
                  .Select(a => new VmBrand
                  {
                      Title = a.Title,//new char[] { '/' }
                ImageUrl = a.TblImage.TblServer.HttpDomain.Trim() + "/" + a.TblImage.TblServer.Path.Trim() + "/" + a.TblImage.FileName
                  }).ToList();

            return qBrand;

        }

        //~BrandRepository()
        //{
        //  Dispose();
        //}

        public void Dispose()
        {
            _db.Dispose();
        }
    }

}
