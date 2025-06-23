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
    public class CategoriesService : ICategoriesService
    {
        //delete unsed code
        private readonly ICategoriesReposetory repository;//_repository
        private readonly IMapper mapper;//_mapper

        public CategoriesService(ICategoriesReposetory r, IMapper mapper)
        {
            repository = r;
            this.mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetCategoryAsync() // Changed to PascalCase
        {
            List<Category> Category = await repository.getCategoryAsync();
            return mapper.Map<List<CategoryDTO>>(Category); 
            //var categories = await repository.getCategoryAsync();

            //return categories.Select(x => mapper.Map<CategoryDTO>(x)).ToList();
        }
    }
}
    