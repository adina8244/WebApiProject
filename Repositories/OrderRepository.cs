using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository: IOrderRepository
    {
        webApiDB8192Context _webApiDB8192Context;
        public OrderRepository(webApiDB8192Context webApiDB8192Context)
        {
            _webApiDB8192Context = webApiDB8192Context;
        }
        public async Task<Order> AddOrder(Order order)
        {
            await _webApiDB8192Context.Orders.AddAsync(order);
            await _webApiDB8192Context.SaveChangesAsync();
            return await Task.FromResult(order);
        }

    }
}
