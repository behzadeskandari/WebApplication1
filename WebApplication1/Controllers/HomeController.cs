using Common.Extensions;
using Domain.Context;
using Domain.Db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Security.Application;
using Newtonsoft.Json;
using Repository.Interface;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UtilitySpace;
using ViewModel;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        List<VmSiteMap> vmMap = null;
        public HomeController()
        {
            vmMap = new List<VmSiteMap>();
        }
        // GET: /<controller>/
        //[Authorize(Roles = "Admin, Programmer")] 
        public IActionResult Index()
        {

            

            vmMap.Add(new VmSiteMap() { Title = "صفحه ی اصلی", Link = "/" });
            ViewBag.SiteMap = vmMap;

            return View();
        }

        [HttpPost]
        public IActionResult ProductProp(string Property, int ProductID)
        {
            if (!Property.Contains(','))
            {
                return View(new VmProductProp() { TotalPrice = "-2", SavePrive = "-2" });
            }

            string[] Prop = Property.Split(new char[] { ',' }).Where(a => a != "" && a != null).ToArray();

            DataContext db = new DataContext();
            int TotalPrice = 0;
            int TotalSavePrice = 0;
            var ProductPriceList = db.TblPrices.Where(a => a.ProductID == ProductID).OrderByDescending(a => a.ID).FirstOrDefault();
            if (ProductPriceList == null)
            {
                return View(new VmProductProp() { TotalPrice = "-1", SavePrive = "-1" });
            }



            int ProductPrice = int.Parse(ProductPriceList.Price);

            foreach (var item in Prop)
            {
                int ID = int.Parse(item);
                var p = db.TblPropertis_Product.Where(a => a.ID == ID && a.ProductID == ProductID).SingleOrDefault();
                if (p != null)
                {
                    TotalPrice += (int)p.Price;
                }
            }

            ProductPrice += TotalPrice;
             
            if (User.Identity.IsAuthenticated)
            {
                int BoonValue = Tools.GetTools().BoonValue;
                int CountBoon = new BoonRepository().GetBoon(User.GetUserID()).Count();
                int SavePrice = CountBoon * BoonValue;
                if (ProductPrice < SavePrice)
                {
                    TotalSavePrice = ProductPrice;
                    //vmp.CountBoonUsed = (int.Parse(vmp.Price) / BoonValue) + " بن از " + CountBoon;
                }
                else
                {
                    TotalSavePrice = ProductPrice - SavePrice;
                    //vmp.CountBoonUsed = (int.Parse(vmp.Price) / BoonValue) + " بن ";
                }
            }
            else
            {
                TotalSavePrice = ProductPrice;
            }

            return View(new VmProductProp() { TotalPrice = ProductPrice.ToString(), SavePrive = TotalSavePrice.ToString() });
        }

        public IActionResult Product(string id, int[] Property, int AskPage = 1, int CommentPage = 1)
        {
            string Urll = null;

            string Proper = "";

            foreach (var item in Property)
            {
                Proper += "&&Property=" + item;
            }

            Urll = "/" + Url.Action("Product").Trim('/') + "?id=" + id + "&&AskPage=" + AskPage + "&&CommentPage=" + CommentPage + Proper;
            ViewBag.CurrentUrl = Urll;

            ProductRepository RepProduct = new ProductRepository();
            var q = RepProduct.ProductDetails(id);

            VmProductDetails vmp = new VmProductDetails();
            vmp.Author = q.TblUser.Name;
            vmp.Evaluation = new Utility().GetSafeHtml(q.Evaluation);  // Sanitizer.GetSafeHtml(q.Evaluation);
            vmp.Favo = User.Identity.IsAuthenticated ? (q.TblFavos.Where(a => a.UserID == User.GetUserID()).SingleOrDefault() != null ? true : false) : false;
            vmp.GuruntyName = q.TblGurunty.Title;
            vmp.ID = q.ID;
            vmp.Noti = User.Identity.IsAuthenticated ? (q.TblNoti.Where(a => a.UserID == User.GetUserID()).SingleOrDefault() != null ? true : false) : false;
            vmp.Price = q.TblPrices.OrderByDescending(a => a.ID).FirstOrDefault().Price;

            // Proccess Property
            DataContext db = new DataContext();
            int TotalPrice = 0;
            //int ProductPrice = int.Parse(db.TblPrices.Where(a => a.ProductID == q.ID).OrderByDescending(a => a.ID).FirstOrDefault().Price);

            if (Property.Count() > 0 && Property != null)
            {
                foreach (var item in Property)
                {
                    int ID = item;
                    var p = db.TblPropertis_Product.Where(a => a.ID == ID && a.ProductID == q.ID).SingleOrDefault();
                    if (p != null)
                    {
                        TotalPrice += (int)p.Price;
                    }
                }
                vmp.Price = (int.Parse(vmp.Price) + TotalPrice).ToString();
            }

            vmp.RatingAvg = q.TblRaiting.Count == 0 ? "0" : (q.TblRaiting.Sum(a => a.Star) / q.TblRaiting.Count()).ToString() + " از " + q.TblRaiting.Count();
            if (User.Identity.IsAuthenticated)
            {
                int BoonValue = Tools.GetTools().BoonValue;
                int CountBoon = new BoonRepository().GetBoon(User.GetUserID()).Count();
                int SavePrice = CountBoon * BoonValue;
                if (int.Parse(vmp.Price) < SavePrice)
                {
                    vmp.SavePrice = vmp.Price;
                    vmp.CountBoonUsed = (int.Parse(vmp.Price) / BoonValue) + " بن از " + CountBoon;
                }
                else
                {
                    vmp.SavePrice = (int.Parse(vmp.Price) - SavePrice).ToString();
                    vmp.CountBoonUsed = (int.Parse(vmp.Price) / BoonValue) + " بن ";
                }
            }
            else
            {
                vmp.SavePrice = vmp.Price;
            }

            vmp.Star = q.TblRaiting.Count() <= 0 ? 0 : q.TblRaiting.Sum(a => a.Star) / 5; ;
            vmp.StatusTitle = q.TblSpical.Title;
            vmp.StatusImgUrl = q.TblSpical.ImageUrl;
            vmp.Text = new Utility().RemoveHtmlTag(Sanitizer.GetSafeHtml(q.Text));
            vmp.TitleEn = q.TitleEn;
            vmp.TitleFa = q.TitleFa;

            vmp.ListAsks = new LstAsks();
            vmp.ListAsks.Asks = new List<Asks>();

            AskPage = AskPage <= 0 ? 1 : AskPage;

            int TakeAsk = Tools.GetTools().CountAskPerPage;
            int CountAll = q.TblAsks.Where(a => a.AskID == 0).Count();
            int CountAllPage = (int)Math.Ceiling((decimal)CountAll / TakeAsk);

            AskPage = AskPage >= CountAllPage ? CountAllPage : AskPage;

            int Skip = (TakeAsk * AskPage) - TakeAsk; // (r * x) - r

            vmp.ListAsks.Take = TakeAsk;
            vmp.ListAsks.CurrentPage = AskPage;
            vmp.ListAsks.CountAllPage = CountAllPage;

            foreach (var item in q.TblAsks
                .Where(a => a.AskID == 0)
                .OrderByDescending(a => a.ID)
                .Skip(Skip)
                .Take(TakeAsk))
            {
                Asks ask = new Asks();
                ask.ID = item.ID;
                ask.Name = item.TblUser.Name;
                ask.Text = item.Text;
                ask.Like = item.Like;
                ask.DisLike = item.DisLike;
                ask.AskID = 0;
                ask.Date = new TimeUtility().GetTimeName(item.Date);
                vmp.ListAsks.Asks.Add(ask);

                foreach (var itemAns in q.TblAsks.Where(a => a.AskID == item.ID))
                {
                    Asks Ans = new Asks();
                    Ans.ID = itemAns.ID;
                    Ans.Name = itemAns.TblUser.Name;
                    Ans.Text = itemAns.Text;
                    Ans.Like = itemAns.Like;
                    Ans.DisLike = itemAns.DisLike;
                    Ans.AskID = itemAns.ID;
                    Ans.Date = new TimeUtility().GetTimeName(itemAns.Date);
                    vmp.ListAsks.Asks.Add(Ans);
                }
            }

            //vmp.ListAsks.Clear();
            //vmp.ListAsks.AddRange(vmp.ListAsks.Skip(Skip).Take(Take).ToList());
            vmp.ListComment = new LstComment();
            vmp.ListComment.Comments = new List<Comment>();

            int TakeComment = Tools.GetTools().CountCommentPerPage;
            CommentPage = CommentPage <= 0 ? 1 : CommentPage;
            bool OnlyShowConfirmed = Tools.GetTools().OnlyShowConfirmedComment;
            int CountComment = q.TblComments.Where(a => OnlyShowConfirmed == true ? a.Confirm == true : true).Count();
            CommentPage = CommentPage > (int)Math.Ceiling((decimal)CountComment / TakeComment) ? (int)Math.Ceiling((decimal)CountComment / TakeComment) : CommentPage;
            int SkipComment = (TakeComment * CommentPage) - TakeComment; // (r * x) - r

            vmp.ListComment.Take = TakeComment;
            vmp.ListComment.CurrentPage = CommentPage;
            vmp.ListComment.CountAllPage = (int)Math.Ceiling((decimal)CountComment / TakeComment);
            vmp.ListComment.Comments = new List<Comment>();

            vmp.ListComment.AvgItem1 = (q.TblComments.Sum(a => a.Item1) / q.TblComments.Where(a => a.Item1 > 0).Count()) * 20;
            vmp.ListComment.AvgItem2 = (q.TblComments.Sum(a => a.Item2) / q.TblComments.Where(a => a.Item2 > 0).Count()) * 20;
            vmp.ListComment.AvgItem3 = (q.TblComments.Sum(a => a.Item3) / q.TblComments.Where(a => a.Item3 > 0).Count()) * 20;
            vmp.ListComment.AvgItem4 = (q.TblComments.Sum(a => a.Item4) / q.TblComments.Where(a => a.Item4 > 0).Count()) * 20;
            vmp.ListComment.AvgItem5 = (q.TblComments.Sum(a => a.Item5) / q.TblComments.Where(a => a.Item5 > 0).Count()) * 20;
            vmp.ListComment.AvgItem6 = (q.TblComments.Sum(a => a.Item6) / q.TblComments.Where(a => a.Item6 > 0).Count()) * 20;


            foreach (var item in q.TblComments
                .Where(a => OnlyShowConfirmed == true ? a.Confirm == true : true)
                .OrderByDescending(a => a.ID)
                .Skip(SkipComment)
                .Take(TakeComment))
            {
                Comment c = new Comment();
                c.ID = item.ID;
                c.Bad = item.Bad;
                c.Best = item.Best;
                c.Date = new TimeUtility().GetDateName(item.Date.ToShamsi());
                c.DisLike = item.DisLike;
                c.Item1 = item.Item1;
                c.Item2 = item.Item2;
                c.Item3 = item.Item3;
                c.Item4 = item.Item4;
                c.Item5 = item.Item5;
                c.Item6 = item.Item6;
                c.Like = item.Like;
                c.Name = item.TblUsers.Name;
                c.Text = new Utility().RemoveHtmlTag(Sanitizer.GetSafeHtml(item.Text));
                c.Title = item.Title;
                vmp.ListComment.Comments.Add(c);
            }

            vmp.ListOtherProduct = new List<OtherProduct>();
            foreach (var item in RepProduct.GetProductByCategory(q.CateID)
                .Where(a => a.ID != q.ID)
                .OrderByDescending(a => a.ID)
                .Skip(0)
                .Take(3)
                .ToList())
            {
                OtherProduct o = new OtherProduct();
                o.Title = item.TitleFa;
                o.TitleEn = item.TitleEn;
                o.Price = item.TblPrices.OrderByDescending(a => a.ID).FirstOrDefault().Price;

                var Image = new ImageRepository().GetImageByProductID(item.ID).FirstOrDefault();
                o.ImageUrl = Image.TblServer.HttpDomain.Trim('/') + "/" + Image.TblServer.Path.Trim('/') + "/" + Image.FileName;
                vmp.ListOtherProduct.Add(o);
            }

            vmp.ListProductImg = new List<ProductImage>();
            foreach (var item in new ImageRepository().GetImageByProductID(q.ID))
            {
                ProductImage p = new ProductImage();
                p.ImageUrl = item.TblServer.HttpDomain.Trim('/') + "/" + item.TblServer.Path.Trim('/') + "/" + item.FileName;
                vmp.ListProductImg.Add(p);
            }

            vmp.ListProperty = new List<ProductProperty>();
            foreach (var item in new PropertiseRepository().GetProductPropertise(q.ID).GroupBy(a => a.Title))
            {
                ProductProperty p = new ProductProperty();
                p.ID = item.FirstOrDefault().ID;
                p.Title = item.Key;
                p.ProductPropertyDetails = new List<ProductPropertyDetails>();
                foreach (var itemp in item)
                {
                    ProductPropertyDetails pr = new ProductPropertyDetails();
                    pr.ID = itemp.IDProduct_Property;
                    pr.PropName = itemp.PropTitle;
                    pr.Price = itemp.Price.ToString();

                    p.ProductPropertyDetails.Add(pr);
                }
                vmp.ListProperty.Add(p);
            }


            vmp.ListTechnicalProperty = new List<TechnicalProperty>();

            foreach (var item in new TechnicalPropertyRepository().GetProductProp(q.ID))
            {
                TechnicalProperty t = new TechnicalProperty();
                t.Title = item.TblTechnicalProp.Title;
                t.Value = item.Value;

                vmp.ListTechnicalProperty.Add(t);
            }

            RepProduct.AddVisit(q.ID);



            vmMap.Add(new VmSiteMap() { Title = "صفحه ی اصلی", Link = "/" });
            vmMap.Add(new VmSiteMap() { Title = "محصولات", Link = "" });
            vmMap.Add(new VmSiteMap() { Title = q.TblCategory.Title, Link = "/Home/Category/" + q.TblCategory.Title });
            vmMap.Add(new VmSiteMap() { Title = q.TitleFa, Link = "" });
            ViewBag.SiteMap = vmMap;
            if (Property.Count() <= 0 || Property == null)
            {
                var qProp = db.TblPropertis_Product
                    .Where(a => a.ProductID == q.ID)
                    .Where(a => a.Price.ToString() == "0/00")
                    .Select(a => a.ID).ToArray();
                ViewBag.PropertyList = qProp;
            }
            else
            {
                ViewBag.PropertyList = Property;
            }


            return View(vmp);
        }

        [HttpPost]
        public string AddComment(TblComments t)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return "لطفا ابتدا وارد سایت شوید";
            }

            if (!ModelState.IsValid)
            {
                return ModelState.GetErrors();
            }

            t.Confirm = false;
            t.Date = DateTime.Now;
            t.DisLike = 0;
            t.Like = 0;
            t.Read = false;
            t.UserID = "aaa";// User.GetUserID();
            t.Ip = "127.0.0.1";
            var r = Request;

            using (DataContext db = new DataContext())
            {
                db.TblComments.Add(t);
                db.SaveChanges();
            }

            return "نظر با موفقیت ثبت شد";
        }


        public string CommLike(int ID)
        {
            if (Request.Cookies["CommentLike"] == null)
            {
                Response.Cookies.Append("CommentLike", ID.ToString());

            }
            else
            {
                string CookieValue = Request.Cookies["CommentLike"].ToString();

                if (CookieValue.Contains(ID.ToString()))
                {
                    return "-1";
                }
                else
                {
                    CookieValue += "," + ID.ToString();
                    Response.Cookies.Delete("CommentLike");
                    Response.Cookies.Append("CommentLike", CookieValue);
                }
            }

            DataContext db = new DataContext();
            var qComment = db.TblComments.Where(a => a.ID == ID).SingleOrDefault();
            if (qComment == null)
            {

                return "-1";
            }
            else
            {
                qComment.Like++;
                db.Update(qComment);
                db.SaveChanges();
                return qComment.Like.ToString();
            }

        }

        public string CommDisLike(int ID)
        {
            if (Request.Cookies["CommentDisLike"] == null)
            {
                Response.Cookies.Append("CommentDisLike", ID.ToString());

            }
            else
            {
                string CookieValue = Request.Cookies["CommentDisLike"].ToString();

                if (CookieValue.Contains(ID.ToString()))
                {
                    return "-1";
                }
                else
                {
                    CookieValue += "," + ID.ToString();
                    Response.Cookies.Delete("CommentDisLike");
                    Response.Cookies.Append("CommentDisLike", CookieValue);
                }
            }

            DataContext db = new DataContext();
            var qComment = db.TblComments.Where(a => a.ID == ID).SingleOrDefault();
            if (qComment == null)
            {

                return "-1";
            }
            else
            {
                qComment.DisLike++;
                db.Update(qComment);
                db.SaveChanges();
                return qComment.DisLike.ToString();
            }

        }

        [HttpPost]
        public string AddAsk(TblAsks t)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return "لطفا ابتدا وارد سایت شوید";
            }

            if (!ModelState.IsValid)
            {
                return ModelState.GetErrors();
            }


            t.Date = DateTime.Now;
            t.DisLike = 0;
            t.Like = 0;
            t.UserID = "aaa";// User.GetUserID();
            t.Ip = "127.0.0.1";


            using (DataContext db = new DataContext())
            {
                db.TblAsks.Add(t);
                db.SaveChanges();
                if (t.AskID != 0)
                {
                    var q = db.TblAsks.Where(a => a.ID == t.AskID)
                        .Include(a => a.TblUser).SingleOrDefault();
                    if (q  != null)
                    {
                        EmailService mail = new EmailService();
                        mail.Send(q.TblUser.Email,"اطلاع رسانی پاسخ به پرسش شما" ,"سلام پاسخ به پرسش شما با شماره");
                    }
                }
            }

            if (t.AskID == 0)
            {
                return "پرسش با موفقیت ثبت شد";
            }
            else
            {
                return "پاسخ با موفقیت ثبت شد";
            }
        }

        public IActionResult PriceChart(string TitleEn = "")
        {
            if (TitleEn == "")
            {
                return RedirectToAction("Index", "Home");
            }
            vmMap.Add(new VmSiteMap() { Title = "صفحه ی اصلی", Link = "/" });
            vmMap.Add(new VmSiteMap() { Title = "نمودار قیمت", Link = "" });

            ViewBag.SiteMap = vmMap;

            var q = new DataContext()
                .TblProducts.Where(a => a.TitleEn == TitleEn)
                .Include(a => a.TblPrices)
                .SingleOrDefault();

            if (q == null)
                return RedirectToAction("Index", "Home");

            string DateStr = "";
            string PriceStr = "";

            foreach (var item in q.TblPrices.OrderBy(a => a.Date))
            {
                DateStr += "\"" + item.Date.ToShamsi().ToString("yy/MM/dd") + "\","; // "1395/4/6",
                PriceStr += "" + item.Price + ","; // 25000,
            }

            DateStr = DateStr.Trim(',');
            PriceStr = PriceStr.Trim(',');

            ViewBag.Date = DateStr;
            ViewBag.PriceStr = PriceStr;

            return View();

        }

        public IActionResult Compree(string[] TitleEn, int Brand = 0)
        {
            if (TitleEn.Count() <= 0)
                return RedirectToAction("Index");

            int TopicID = 0;
            DataContext db = new DataContext();
            List<CompreeViewModel> LstCompree = new List<CompreeViewModel>();

            foreach (var item in TitleEn)
            {
                var q = db.TblProducts
                    .Where(a => a.TitleEn == item)
                    .Include(a => a.TblImages)
                    .ThenInclude(a => a.TblServer)
                    .Include(a => a.TblTechnicalProp_Products)
                    .ThenInclude(a => a.TblTechnicalProp)
                    .SingleOrDefault();
                if (q == null)
                    return RedirectToAction("Index");

                if (TopicID <= 0)
                {
                    TopicID = q.TblTechnicalProp_Products.FirstOrDefault().TblTechnicalProp.TopicID;
                }
                else
                {
                    if (q.TblTechnicalProp_Products.FirstOrDefault().TblTechnicalProp.TopicID != TopicID)
                    {
                        // انتقال به صفحه ی ارور
                        return RedirectToAction("Index");
                    }
                }

                CompreeViewModel vm = new CompreeViewModel();
                vm.ID = q.ID;
                vm.TitleEn = q.TitleEn;
                vm.Title = q.TitleFa;
                var Img = q.TblImages.FirstOrDefault();
                vm.ImageUrl = Img.TblServer.HttpDomain.Trim('/') + "/" + Img.TblServer.Path.Trim('/') + "/" + Img.FileName;
                vm.LstProp = new List<CompreeTecnicalViewModel>();

                foreach (var itemProp in q.TblTechnicalProp_Products)
                {
                    CompreeTecnicalViewModel cVm = new CompreeTecnicalViewModel();
                    cVm.Title = itemProp.TblTechnicalProp.Title;
                    cVm.Value = itemProp.Value;

                    vm.LstProp.Add(cVm);
                }

                LstCompree.Add(vm);
            }


            vmMap.Add(new VmSiteMap() { Title = "صفحه ی اصلی", Link = "/" });
            vmMap.Add(new VmSiteMap() { Title = "مقایسه ی محصول", Link = "" });

            ViewBag.SiteMap = vmMap;

            List<ListProduct> LstProduct = new List<ListProduct>();

            foreach (var item in new DataContext().TblProducts.Where(a => a.BrandID == Brand).ToList())
            {
                ListProduct lst = new ListProduct();
                lst.ID = item.ID;
                lst.Title = item.TitleFa;
                lst.TitleEn = item.TitleEn;
                lst.BrandID = item.BrandID.Value;
                LstProduct.Add(lst);
            }
            ViewBag.TopicID = TopicID;
            ViewBag.LstProduct = LstProduct;
            return View(LstCompree);
        }



        public IActionResult About()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        public string AddtoCart(int ProductID, string Prop)
        {
            DataContext db = new DataContext();
            var qProduct = db.TblProducts.Where(a => a.ID == ProductID).SingleOrDefault();
            if (qProduct != null)
            {
                string UserID = User.GetUserID();
                var Exist = db.TblShopingCart
                    .Where(a => a.UserID == UserID)
                    .Where(a => a.ProductID == ProductID)
                    .Where(a => a.Date.AddDays(7) >= DateTime.Now)
                    .SingleOrDefault();

                if (Exist != null)
                {
                    goto RefreshCart;
                }
                else
                {
                    TblShopingCart t = new TblShopingCart();
                    t.Count = 1;
                    t.Date = DateTime.Now;
                    t.ProductID = ProductID;
                    t.UserID = UserID;
                    t.TblPropertiseProduct_ShopingCart = new List<TblPropertiseProduct_ShopingCart>();
                    foreach (var item in Prop.Trim(',').Split(',')) // 17,1,22
                    {
                        if (item != null && item.Trim() != "")
                            t.TblPropertiseProduct_ShopingCart.Add(new TblPropertiseProduct_ShopingCart() { PropertiseProductID = int.Parse(item) });
                    }

                    db.TblShopingCart.Add(t);
                    db.SaveChanges();
                    goto RefreshCart;
                }

            }
            else
            {
                //return Json("");
                return "";
            }

        RefreshCart:
            {
                var q = db.TblShopingCart
                    .Include(a => a.TblProducts)
                    .ThenInclude(a => a.TblPrices)
                    .Include(a => a.TblPropertiseProduct_ShopingCart)
                    .ThenInclude(a => a.TblPropertis_Product)
                    .Where(a => a.UserID == User.GetUserID())
                    .Where(a => a.Date.AddDays(7) >= DateTime.Now).ToList();
                CartVm cv = new CartVm();
                cv.Count = q.Count().ToString();
                cv.TotalPrice = "0"; /*q.Sum(a => Convert.ToInt32(a.TblProducts.TblPrices.OrderByDescending(b => b.Date).FirstOrDefault().Price));*/

                cv.ProductInCartVM = new List<ProductInCartVM>();
                foreach (var item in q)
                {
                    ProductInCartVM p = new ProductInCartVM();
                    p.ID = item.ProductID.ToString();
                    p.Price = (int.Parse(item.TblProducts.TblPrices.OrderByDescending(a => a.Date).FirstOrDefault().Price) +
                        ((int)item.TblPropertiseProduct_ShopingCart.Sum(b => b.TblPropertis_Product.Price))).ToString();
                    p.Title = item.TblProducts.TitleFa;
                    p.Count = item.Count.ToString();
                    cv.TotalPrice = (int.Parse(cv.TotalPrice) + int.Parse(p.Price)).ToString();

                    cv.ProductInCartVM.Add(p);
                }
                string datas = JsonConvert.SerializeObject(cv);

                return datas;
            }

        }

    }

}
