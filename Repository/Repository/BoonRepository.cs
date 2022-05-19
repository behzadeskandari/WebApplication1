using Domain.Context;
using Domain.Db;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilitySpace;

namespace Repository.Repository
{
    public class BoonRepository : IBoonRepository
    {
        private DataContext _db;
        public BoonRepository()
        {
            _db = new DataContext();
        }
        public BoonRepository(DataContext db)
        {
            this._db = db;
        }

     
        //~BoonRepository()
        //{
        //  Dispose();
        //}

        public void Dispose()
        {
            _db.Dispose();
        }
        //public List<TblBoon> GetCountBoon(string UserID)
        //{
        //    int ValidDay = Tools.GetTools().ValidBoonPerDay;
        //    var qBoon = _db.TblBoon.Where(x => x.UserID == UserID).Where(x => x.Status == true)
        //        .Where(x => x.Date.AddDays(ValidDay) <= DateTime.Now).ToList();

        //    return qBoon;
        //}
        public List<TblBoon> GetBoon(string UserID)
        {

            int ValidDay = Tools.GetTools().ValidBoonPerDay;
            var qBoon = _db.TblBoon.Where(x => x.UserID == UserID).Where(x => x.Status == true)
                .Where(x => x.Date.AddDays(ValidDay) <= DateTime.Now).ToList();

            return qBoon;
        }
    }

}
