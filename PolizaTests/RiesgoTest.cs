﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using DAL;
using System.Collections.Generic;

namespace PolizaTests
{
    [TestClass]
    public class RiesgoTest
    {

        private IRiesgoRepository repo = new RiesgoRepository();

        [TestMethod]
        public void TestGetAllRiesgos()
        {
            IEnumerable<string> riesgos = repo.GetRiesgos();
            Console.WriteLine(riesgos.FirstOrDefault());
            Assert.IsNotNull(riesgos);
        }
    }
}
