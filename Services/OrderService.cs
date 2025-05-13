using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;

namespace Services
{
    class OrderService: IOrderService
    {
        IOrderRepository repository;
        public OrderService(IOrderRepository r)
        {
            repository = r;
        }

        public async Task<Order> AddOrder(Order order)
        {
            return await repository.AddOrder(order);
        }
    }
}
