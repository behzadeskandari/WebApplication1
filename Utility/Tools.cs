using Domain.Context;
using Domain.Db;
using System;
using System.Linq;

namespace UtilitySpace
{
    public static class Tools
    {
        static Tools()
        {

        }
        public static TblSettings GetTools()
        {
            DataContext db = new DataContext();
            var q = db.TblSettings.FirstOrDefault();
            return q;
        }
    }
}
