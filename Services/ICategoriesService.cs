using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;

namespace Services
{
    public interface ICategoriesService
    {
        Task<List<Category>> getCategory();
    }
}
