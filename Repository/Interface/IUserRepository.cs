using Domain.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IUserRepository : IDisposable
    {
         ApplicationUser GetUserByID(string UserID);
    }
}
