using Domain.Db;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Task<TblOrders> CreateOrderAsync(Guid customerId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public TblOrders GetOrder()
        {
            throw new NotImplementedException();
        }

        public Task<TblOrders> GetOrderAysnc(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TblOrders>> GetOrderAysnc()
        {
            throw new NotImplementedException();
        }
    }

}
