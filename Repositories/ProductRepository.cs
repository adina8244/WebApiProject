using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository: IProductRepository
    {
        webApiDB8192Context _webApiDB8192Context;
        public ProductRepository(webApiDB8192Context webApiDB8192Context)
        {
            _webApiDB8192Context = webApiDB8192Context;
        }
        
        public async Task<List<Proudct>> GetProudctAsync()
        {
            return await _webApiDB8192Context.Proudcts.Include(c=>c.Category).ToListAsync<Proudct>();
        }
    }
}
