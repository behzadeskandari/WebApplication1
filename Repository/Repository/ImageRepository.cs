using Domain.Context;
using Domain.Db;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Repository.Repository
{
    public class ImageRepository : IImageRepository
    {
        private DataContext db = null;
        public ImageRepository()
        {
            db = new DataContext();
        }

        public TblImage GetImageByID(int id)
        {
            var qImg = db.TblImage.Where(a => a.ID == id)
                 .Include(a => a.TblServer)
                 .SingleOrDefault();

            return qImg ?? null;

            //if (qImg == null)
            //{

            //    return null;
            //}
            //else
            //{
            //    return qImg;
            //}
        }
        public List<TblImage> GetImageByProductID(int ProductID)
        {
            var qImg = db.TblImage.Where(a => a.ProductID == ProductID)
                .Include(a => a.TblServer)
                .OrderByDescending(a => a.ID)
                .ToList();
            //.FirstOrDefault();
            return qImg ?? null;
        }
        //public TblImage GetImageByProductID(int ProductID)
        //{
        //    var qImg = db.TblImage.Where(a => a.ProductID == ProductID)
        //         .Include(a => a.TblServer)
        //         .FirstOrDefault();

        //    return qImg ?? null;
        //}

        ~ImageRepository()
        {
            Dispose(true);
        }

        public void Dispose()
        {

        }

        public void Dispose(bool Dis)
        {
            if (Dis)
            {
                Dispose();
            }
        }

       
    }
}
