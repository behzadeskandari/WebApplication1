using Domain.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Seed
{
    public class Seed : IDisposable
    {
        DataContext db = null;
        public Seed()
        {
            db = new DataContext();
        }
        public void ApplySeed()
        {
            #region RoleSeed
            List<IdentityRole> LstIdentityRole = new List<IdentityRole>(){
            new IdentityRole("Admin"),
            new IdentityRole("Hesabdar"),
            new IdentityRole("Programmer")
        };

            foreach (var item in LstIdentityRole)
            {
                if (db.Roles.Where(a => a.Name == item.Name).SingleOrDefault() == null)
                {
                    db.Roles.Add(item);
                }
            }
            #endregion

            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
        ~Seed()
        {
            Dispose();
        }
    }

}
