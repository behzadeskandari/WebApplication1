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
    public class SliderRepository : ISliderRepository
    {
        private DataContext db = null;
        public SliderRepository()
        {
            db = new DataContext();
        }

        public List<VmSlider> GetSlides()
        {
            List<VmSlider> LstSlides = new List<VmSlider>();

            var qSlide = db.TblSlider
                    .OrderBy(a => a.Sort)
                    .Include(a => a.TblImage)
                    .ThenInclude(a => a.TblServer)
                    .ToList();

            foreach (var item in qSlide)
            {
                VmSlider vm = new VmSlider();
                vm.Id = item.ID;
                vm.Link = item.Link;
                vm.Title = item.Title;
                vm.ImgUrl = item.TblImage.TblServer.HttpDomain.TrimEnd(new char[] { '/' }) + "/" + item.TblImage.TblServer.Path.Trim(new char[] { '/' }) + "/" + item.TblImage.FileName;
                LstSlides.Add(vm);
            }

            return LstSlides;

        }


        ~SliderRepository()
        {
            Dispose(true);
        }

        public void Dispose()
        {
            db.Dispose();
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
