using Entites;

using Repositories;

namespace Services
{
    class CategoriesService : ICategoriesService
    {
       

        ICategoriesService repository;
        public CategoriesService(ICategoriesService r)
        {
            repository = r;
        }


        public async Task<List<Category>> getCategory()
        {
            return await repository.getCategory();
        }
    }
}
    