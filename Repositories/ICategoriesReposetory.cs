using Entites;

namespace Repositories
{
    internal interface ICategoriesReposetory
    {
        Task<List<Category>> getCategory();
    }
}