using Entites;


namespace Services
{
    public interface ICategoriesService
    {
        Task<List<Category>> getCategory();
    }
}
