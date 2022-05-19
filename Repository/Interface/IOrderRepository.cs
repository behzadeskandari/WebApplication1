using Domain.Db;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOrderRepository
    {
        Task<TblOrders> GetOrderAysnc(Guid orderId);
        Task<List<TblOrders>> GetOrderAysnc();
        TblOrders GetOrder();

        Task<TblOrders> CreateOrderAsync(Guid customerId, Guid productId);
    }
}
