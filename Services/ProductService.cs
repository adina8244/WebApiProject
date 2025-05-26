using AutoMapper;
using DTO;
using Entites;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository repository;
        IMapper mapper;
        public ProductService(IProductRepository r, IMapper mapper)
        {
            repository = r;
            this.mapper = mapper;
        }

        public async Task<List<ProudctDTO>> GetProudctAsync()
        {
            List<Proudct> products = await repository.GetProudctAsync();
            return mapper.Map<List<ProudctDTO>>(products); // Fixed the mapping type
        }
    }
}
