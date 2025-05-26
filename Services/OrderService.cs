using Repositories;
using Entites;
using DTO;
using AutoMapper;
namespace Services
{
    public class OrderService: IOrderService
    {
        IOrderRepository repository;
        IMapper mapper;
        public OrderService(IOrderRepository r,IMapper mapper)
        {
            repository = r;
            this.mapper = mapper;
        }

        public async Task<OrderDTO> AddOrder(OrderDTO orderDTO)
        {
            Order orginalOrder = mapper.Map<Order>(orderDTO);
            var sendRepos= await repository.AddOrder(orginalOrder);
            var Dto = mapper.Map<OrderDTO>(orginalOrder);
            return mapper.Map<OrderDTO> (Dto);
        }
    }
}
