using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CategoriesReposetory : ICategoriesReposetory
    {
        webApiDB8192Context _webApiDB8192Context;
        public CategoriesReposetory(webApiDB8192Context webApiDB8192Context)
        {
            _webApiDB8192Context = webApiDB8192Context;
        }
        public async Task<List<Category>> getCategory()
        {
            return await _webApiDB8192Context.Categories.ToListAsync<Category>();
        }
    }
}