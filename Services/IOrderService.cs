
using DTO;
using Entites;

namespace Services
{
    public interface IOrderService
    {
        Task<OrderDTO> AddOrder(OrderDTO order);
    }
}
