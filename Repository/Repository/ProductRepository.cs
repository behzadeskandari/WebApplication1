using Domain.Context;
using Domain.Db;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilitySpace;
using ViewModel;

namespace Repository.Repository
{
    public class ProductRepository : IProductRepository // IDisposable
    {
        private DataContext db = null;
        public ProductRepository()
        {
            db = new DataContext();
        }

        public List<VmProductList> GetLatestProductList(int Count = 4)
        {
            try
            {
                ImageRepository RepImg = new ImageRepository();
                var qProduct = db.TblProducts
                    .Where(a => a.Status == 1)
                    .Where(a => a.Count > 0)
                    .Where(a => a.Date <= DateTime.Now) // ارسال پست به اینده
                    .OrderByDescending(a => a.ID)
                    .Include(a => a.TblPrices)
                    .Take(Count);

                List<VmProductList> LstVm = new List<VmProductList>();
                foreach (var item in qProduct)
                {
                    VmProductList vm = new VmProductList();
                    vm.ID = item.ID;
                    vm.Link = item.TitleEn;
                    vm.Price = item.TblPrices.OrderByDescending(a => a.ID).Last().Price;
                    vm.TitleEn = item.TitleEn;
                    vm.TitleFa = item.TitleFa;
                    var Image = RepImg.GetImageByProductID(item.ID).FirstOrDefault();
                    vm.ImageUrl = Image.TblServer.HttpDomain.Trim(new char[] { '/' }) + "/" + Image.TblServer.Path.Trim(new char[] { '/' }) + "/" + Image.FileName;

                    LstVm.Add(vm);
                }

                return LstVm;

            }
            catch (Exception e)
            {
                ReportViewModel rvm = new ReportViewModel();
                rvm.Action = "GetLatestProductList";
                rvm.Controller = "ProductRepository";
                rvm.Date = DateTime.Now;
                rvm.Ex = e;
                rvm.UserID = "";
                TblException ex = new TblException();
                ex.Message = "Product Repository Bug GetLatestProductList Action";
                ex.Title = "Bug Report";
                ex.UserName = "aaa";
                ex.Date = DateTime.Now;
                ex.Controller = "ProductRepository";
                ex.Action = "GetLatestProductList";
               // ex.Ex = e.InnerException.Message.ToString();
                ex.UserID = "aaa";
                
                
                new DigitalShopReporter().SendReport(rvm);

                throw;
            }
        }

        ~ProductRepository()
        {
            Dispose();
        }

        public void Dispose()
        {

        }

        public List<VmProductList> GetMostViewedProductList(int Count = 4)
        {
            throw new NotImplementedException();
        }

        public TblProducts ProductDetails(string TitleEn)
        {
            try
            {
                var qProduct = db.TblProducts.Where(a => a.TitleEn == TitleEn)
                    .Include(a => a.TblFavos)
                    .Include(a => a.TblNoti)
                    .Include(a => a.TblTechnicalProp_Products)
                    .ThenInclude(a => a.TblTechnicalProp)
                    .Include(a => a.TblImages)
                    .ThenInclude(x => x.TblServer)
                    .Include(x => x.TblPropertis_Product)
                    .ThenInclude(x => x.TblPropertis)
                    .Include(a => a.TblComments).ThenInclude(a => a.TblUsers)
                    .Include(a => a.TblAsks)
                    .Include(a => a.TblRaiting)
                    .Include(a => a.TblGurunty)
                    .Include(a => a.TblUser)
                    .Include(a => a.TblPrices )
                    .Include(a => a.TblSpical)
                    .Include(x => x.TblCategory)
                    .SingleOrDefault();

                return qProduct;
            }
            catch (Exception e)
            {
                ReportViewModel rvm = new ReportViewModel();
                rvm.Action = "ProductDetails";
                rvm.Controller = "ProductRepository";
                rvm.Date = DateTime.Now;
                rvm.Ex = e;
                rvm.UserID = "";

                new DigitalShopReporter().SendReport(rvm);

                throw;
            }
        }

        public IQueryable<TblProducts> GetProductByCategory(int CateID)
        {
            try
            {
                var qProduct = db.TblProducts.Where(a => a.CateID == CateID).Include(x => x.TblPrices);
                return qProduct;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public bool AddVisit(int ProductID)
        {
            var q = db.TblProducts.Where(x => x.ID == ProductID).SingleOrDefault();

            if(q == null)
            {
                return false;
            }
            q.Visit++;
            db.Update(q);
            if (db.SaveChanges() > 0) 
            {
                return true;
            }else
            {
                return false;
            }
        }

        public List<TblAsks> GetChildAsk(int ID)
        {
            var q = db.TblAsks.Where(a => a.AskID == ID).Include(a => a.TblUser).ToList();
            return q;
        }
    }
}
