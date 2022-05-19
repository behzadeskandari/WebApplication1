using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Authentication;


namespace ViewModel
{
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    //
    // Summary:
    //     Represents a linked login for a user (i.e. a facebook/google account)
    public sealed class UserLoginInfo
    {
        //
        // Summary:
        //     Constructor
        //
        // Parameters:
        //   loginProvider:
        //
        //   providerKey:
        public UserLoginInfo(string loginProvider, string providerKey) 
        { 
        }

        //
        // Summary:
        //     Provider for the linked login, i.e. Facebook, Google, etc.
        public string LoginProvider { get; set; }
        //
        // Summary:
        //     User specific key for the login provider
        public string ProviderKey { get; set; }
    }
}
