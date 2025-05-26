using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public record ProudctDTO(int ProductId, string ProductName, int? Price, string Description, string Imgpath);


}
