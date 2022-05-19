using Domain.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IBoonRepository : IDisposable
    {
         List<TblBoon> GetBoon(string UserID);

    }
}
