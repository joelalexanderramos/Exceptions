using Northwind2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Northwind2.Controllers
{
    [HandleError]
    [HandleError(ExceptionType =typeof(Exceptions.CategoryNotFoundException), View ="CategoryNotFound")]
    public class CategoryController : Controller
    {
        private INorthwindContext Context;

        public CategoryController()
        {
            Context = new NorthwindContext();
        }

        public CategoryController(INorthwindContext context)
        {
            this.Context = context;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View("Index");
        }

        public PartialViewResult _CategoryList(int n=0)
        {
            //List<Models.Category> Categories = new List<Models.Category>();
            //return PartialView("_CategoryList", Categories);

            // Desde el repositorio
            List<Category> Categories;
            if (n==0)
            {
                Categories = Context.Categories.ToList();
            }
            else
            {
                Categories = Context.Categories.Take(n).ToList();
            }

            return PartialView("_CategoryList", Categories.ToList());
        }

        public ActionResult GetImage(int id)
        {
            //byte[] Image = new byte[0];
            //return File(Image, "image/jpeg");

            int Offset = 78;
            var Category = Context.FindCategoryById(id);
            byte[] Image = Category == null ? null : Category.Picture.Skip(Offset).ToArray();
            return Image == null ? null : File(Image, "image/jpeg");
        }

        public ActionResult Display(int id)
        {
            Category Category = null;
            ActionResult Result = null;

            if (id<=0)
            {
                throw (new ArgumentException("El ID debe ser mayor que cero"));
            }

            Category = Context.FindCategoryById(id);
            Result = View("Display", Category);
            return Result;
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    if (filterContext.Exception is ArgumentException)
        //    {
        //        var ControllerName = filterContext.RouteData.Values["Controller"].ToString();
        //        var ActionName = filterContext.RouteData.Values["Action"].ToString();
        //        var Model = new HandleErrorInfo(filterContext.Exception, ControllerName, ActionName);

        //        var Result = new ViewResult
        //        {
        //            ViewName = "Error",
        //            ViewData = new ViewDataDictionary<HandleErrorInfo>(Model),
        //            TempData = filterContext.Controller.TempData                    
        //        };

        //        filterContext.Result = Result;
        //        filterContext.ExceptionHandled = true;
        //    }
        //}
    }
}