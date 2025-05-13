using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
    }
}
