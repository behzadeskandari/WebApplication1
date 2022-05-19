using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repository.Interface
{
    public interface IMenuRepositry : IDisposable
    {
         bool HasChildMenu(int id);
         List<VmMenu> GetMenu(int id = 0);
    }
}
