using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dapper;
using System;
using POCO;
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
