using Entites;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService: IProductService
    {
        IProductRepository repository;
        public ProductService(IProductRepository r)
        {
            repository = r;
        }

        public async Task<List<Proudct>> GetProudct()
        {
            return await repository.GetProudct();
        }

    }
}
