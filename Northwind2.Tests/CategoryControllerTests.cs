using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind2.Controllers;
using Northwind2.Models;
using Northwind2.Tests.Doubles;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Northwind2.Tests
{
    [TestClass]
    public class CategoryControllerTests
    {
        [TestMethod]
        public void Test_Index_Return_View()
        {
            // Arrange 
            var Context = new FakeNorthwindContext();
            CategoryController controller = new CategoryController(Context);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void Test_CategoryList_Model_Type()
        {
            var Context = new FakeNorthwindContext();
            Context.Categories = new[]
            {
                new Category(), new Category(), new Category(), new Category()
            }.AsQueryable();

            var controller = new CategoryController(Context);
            var result = controller._CategoryList() as PartialViewResult;
            Assert.AreEqual(typeof(List<Category>), result.Model.GetType());
        }

        [TestMethod]
        public void Test_GetImage_Return_Type()
        {
            var Context = new FakeNorthwindContext();
            Context.Categories = new[]
            {
                new Category {CategoryID=1, Picture=new byte[0] },
                new Category {CategoryID=2, Picture=new byte[0] },
                new Category {CategoryID=3, Picture=new byte[0] },
                new Category {CategoryID=4, Picture=new byte[0] }
            }.AsQueryable();

            var controller = new CategoryController(Context);
            var result = controller.GetImage(1) as ActionResult;
            Assert.AreEqual(typeof(FileContentResult), result.GetType());
        }

        [TestMethod]
        public void Test_Display_Model_Type()
        {
            var Context = new FakeNorthwindContext();
            Context.Categories = new[]
            {
                new Category {CategoryID=1 },
                new Category {CategoryID=2 },
                new Category {CategoryID=3},
                new Category {CategoryID=4 }
            }.AsQueryable();

            var controller = new CategoryController(Context);
            var result = controller.Display(1) as ViewResult;
            Assert.AreEqual(typeof(Category), result.Model.GetType());
        }

        [TestMethod]
        public void Test_CategoryList_No_Parameter()
        {
            var Context = new FakeNorthwindContext();
            Context.Categories = new[]
            {
                new Category(),new Category(),new Category(),new Category()
            }.AsQueryable();

            var controller = new CategoryController(Context);
            var result = controller._CategoryList() as PartialViewResult;

            var model = result.Model as IEnumerable<Category>;
            Assert.AreEqual(4, model.Count());
        }

        [TestMethod]
        public void Test_CategoryList_Parameter()
        {
            var Context = new FakeNorthwindContext();
            Context.Categories = new[]
            {
                new Category(),new Category(),new Category(),new Category()
            }.AsQueryable();

            var controller = new CategoryController(Context);
            var result = controller._CategoryList(3) as PartialViewResult;

            var model = result.Model as IEnumerable<Category>;
            Assert.AreEqual(3, model.Count());
        }
    }
}
