using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind2.Models;
using System.Collections.Generic;

namespace Northwind2.Tests
{
    [TestClass]
    public class CategoryModelTests
    {
        [TestMethod]
        public void Test_Category_Products()
        {
            // Fase Preparar
            Category TestCategory = new Models.Category();
            TestCategory.CategoryID = 1;

            // Fase Actual
            var result = TestCategory.GetProducts();

            // Fase Asegurar
            Assert.AreEqual(typeof(List<Product>), result.GetType());
        }
    }
}
