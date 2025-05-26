using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //public record CategoryDTO(int CategoryId, string CategoryName, ICollection<ProudctDTO> Products);
    public record CategoryDTO(int CategoryId, string CategoryName, ICollection<ProudctDTO> Products)
    {
        public CategoryDTO() : this(0, string.Empty, new List<ProudctDTO>()) { }
    }

}
