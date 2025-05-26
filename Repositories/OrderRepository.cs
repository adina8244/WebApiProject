using Entites;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                await _webApiDB8192Context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("שגיאת DB:");
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return await Task.FromResult(order);
        }

    }
}
