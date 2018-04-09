using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using DAL;
using System.Collections.Generic;

namespace PolizaTests
{
    [TestClass]
    public class CubrimientoTest
    {

        private ICubrimientoRepository repo = new CubrimientoRepository();

        [TestMethod]
        public void TestGetAllCubrimientos()
        {
            IEnumerable<string> cubrimiento = repo.GetCubrimientos();
            Console.WriteLine(cubrimiento.FirstOrDefault());
            Assert.IsNotNull(cubrimiento);
        }
    }
}
