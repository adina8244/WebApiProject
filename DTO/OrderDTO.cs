using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record  OrderDTO(int OrderId, DateTime OrderDate, int UserId, string UserName, List<OrderItemDTO> OrderItems);
}
