using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Entites;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<List<Proudct>> GetProudctAsync();
    }
}
