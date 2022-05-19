 using Domain.Context;
using Domain.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Common.Extensions
{

    public static class IdentityEx
    {
        public static string GetUserID(this ClaimsPrincipal Claim)
        {
            if (Claim == null)
            {
                throw new ArgumentNullException("Argument Null Exception");
            }

            return Claim.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static ApplicationUser GetUserDetails(this ClaimsPrincipal Claim)
        {
            if (Claim == null)
            {
                throw new ArgumentNullException("Argument Null Exception");
            }

            using (DataContext db = new DataContext())
            {
                string UserID = Claim.GetUserID();
                var q = (db.Users.Where(a => a.Id == UserID)
                            .Include(a => a.TblImageProfile)
                            .ThenInclude(a => a.TblServer)).SingleOrDefault();

                return q;
            }
        }

        public static bool IsAccess(this ClaimsPrincipal c,string AccessName)
        {
            DataContext db = new DataContext();

            var Access = db.TblAccess.Where(a => a.Name == AccessName).SingleOrDefault();
            var User = c.GetUserID();

            var q = db.TblUserAccess.Where(a => a.AcccessID == Access.ID && a.UserID == User).SingleOrDefault();
            if (q == null)
                return false;
            else
                return true;
        }

    }


    //public  class ClaimsPrincipal<T>  : IPrincipal
    //{
    //  public IIdentity Identity => throw new NotImplementedException();

    //  public static String GetUserDetails(this ClaimsPrincipal claims)
    //  {
    //    if (claims == null)
    //    {
    //      throw new ArgumentNullException("Argument Null Exception");
    //    }

    //    return claims.FindFirst(ClaimTypes.NameIdentifier).Type;

    //  }

    //  public bool IsInRole(string role)
    //  {
    //    throw new NotImplementedException();
    //  }
    //}



}
