using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Taste.Models.ViewModels
{
    public class MenuItemVM
    {
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }
    }
}