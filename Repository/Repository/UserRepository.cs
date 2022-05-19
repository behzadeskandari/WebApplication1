using Domain.Context;
using Domain.Db;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class UserRepository : IUserRepository//: IDisposable
    {
        private DataContext db = null;
        public UserRepository()
        {
            db = new DataContext();
        }

        public ApplicationUser GetUserByID(string UserID)
        {
            if (UserID == null)
                return null;

            var qUser = db.Users.Where(a => a.Id == UserID).SingleOrDefault();

            return qUser ?? null;
        }

        //~UserRepository()
        //{
        //  Dispose();
        //}

        public void Dispose()
        {

        }


    }

}
