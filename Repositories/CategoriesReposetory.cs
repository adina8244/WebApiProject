using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    class CategoriesReposetory : ICategoriesReposetory
    {
        webApiDB8192Context obDB;
        public CategoriesReposetory(webApiDB8192Context w)
        {
            obDB = w;
        }
        public async Task<List<Category>> getCategory()
        {
            return await obDB.Categories.ToListAsync<Category>();
        }
    }
}