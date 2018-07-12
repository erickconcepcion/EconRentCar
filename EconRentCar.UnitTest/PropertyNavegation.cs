using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Collections.Generic;

namespace EconRentCar.UnitTest
{
    [TestClass]
    public class PropertyNavegation
    {
        //si tu quiere probar solo un pedazo de codigo
        [TestMethod]
        public void TestPropertyMap()
        {
            Student entity = new Student { Nombre = "looool", Apellido = "sdddsf", Edad = 24 };
            IEnumerable<PropertyInfo> prop = entity.GetType().GetProperties();
            foreach (var item in prop)
            {
                object name = item.GetValue(entity);   
            }
        }
    }
}
