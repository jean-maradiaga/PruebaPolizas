using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using POCO;
using System.Linq;
using DAL;
using System.Collections.Generic;

namespace PolizaTests
{
    [TestClass]
    public class ClienteTests
    {

        private IClienteRepository repo = new ClienteRepository();

        [TestMethod]
        public void TestGetAllClientes()
        {
            IEnumerable<Cliente> clientes = repo.GetClientes();
            Console.WriteLine(clientes.FirstOrDefault());
            Assert.IsNotNull(clientes);
        }

        [TestMethod]
        public void TestGetClienteById()
        {
            Cliente c = repo.GetClienteByID(1);
            Console.WriteLine(c.ToString());
            Assert.IsNotNull(c);
        }
    }
}
