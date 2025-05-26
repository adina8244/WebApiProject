using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record  OrderDTO( string OrderDate, int? OrderSum, int UserId,  List<OrderItemDTO> OrderItems);

}