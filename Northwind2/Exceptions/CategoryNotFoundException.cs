using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind2.Exceptions
{
    public class CategoryNotFoundException:System.Exception
    {
        public CategoryNotFoundException(int ID) :
            base($"La categoría '{ID}' no ha sido encontrada.")
        {

        }
    }
}