using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICacheSevice
    {
         Task<string> GetCacheValueAsync(string key);


         Task SetCacheValueAsync(string key, string Value);

    }
}
