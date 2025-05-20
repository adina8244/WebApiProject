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


        ICategoriesReposetory repository;
        public CategoriesService(ICategoriesReposetory r)
        {
            repository = r;
        }


        public async Task<List<Category>> getCategory()
        {
            return await repository.getCategory();
        }
    }
}
    