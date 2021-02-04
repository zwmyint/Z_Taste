using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taste.DataAccess.Data.Repository.IRepository;
using Taste.Models;
using Taste.Utility;

namespace Taste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        //
        [HttpGet]
        public IActionResult Get()
        {   
            // *** "Category,FoodType"
            return Json(new { data = _unitOfWork.MenuItem.GetAll(null,null,"Category,FoodType") });

            /* SELECT [m].[Id], [m].[CategoryId], [m].[Description], [m].[FoodTypeId], [m].[Image], [m].[Name], [m].[Price], [c].[Id], [c].[DisplayOrder], [c].[Name], [f].[Id], [f].[Name]
            FROM [MenuItem] AS [m]
            INNER JOIN [Category] AS [c] ON [m].[CategoryId] = [c].[Id]
            INNER JOIN [FoodType] AS [f] ON [m].[FoodTypeId] = [f].[Id] */

        }

        //
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id);
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Error while deleting." });
                }

                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                _unitOfWork.MenuItem.Remove(objFromDb);
                _unitOfWork.Save();
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = "Error while deleting." + ex});
            }
            return Json(new { success = true, message = "Delete success." });
        }


        //
    }
}