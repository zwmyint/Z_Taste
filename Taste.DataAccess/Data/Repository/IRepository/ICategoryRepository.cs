using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taste.Models;

namespace Taste.DataAccess.Data.Repository.IRepository
{
    // inh: from IRepository
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(Category category);

        //
    }
}
