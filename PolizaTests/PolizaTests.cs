using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using POCO;
using System.Linq;
using DAL;
using System.Collections.Generic;
using WebApi.Validation;

namespace PolizaTests
{
    [TestClass]
    public class PolizaTests
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        private IPolizaRepository repo = new PolizaRepository();
        private IClienteRepository crepo = new ClienteRepository();
        SqlConnection sqlCon = new SqlConnection(ConnectionString);
        public static string[] Riesgo = { "Bajo", "Medio", "Medio-Alto", "Alto" };
        public static string[] Cobertura = { "Robo", "Incendio", "Terremoto", "Perdida" };

        /// <summary>
        /// Test de integracion para agregar una poliza.
        /// </summary>
        [TestMethod]
        public void TestAddPoliza()
        {

            try
            {
                Poliza p = GetMockPoliza(true);
                repo.InsertOrUpdatePoliza(p);
            }
            catch(Exception e)
            {
                throw e;
            }
          
        }

        /// <summary>
        /// Test de integracion para modificar una poliza.
        /// </summary>
        [TestMethod]
        public void TestUpdatePoliza()
        {

            try
            {
                Poliza p1 = repo.GetPolizaByID(7);
                string newDes = "Poliza de lujo en primer año";
                p1.Descripcion = newDes;
                repo.InsertOrUpdatePoliza(p1);
                Poliza p2 = repo.GetPolizaByID((int)7);
                Console.WriteLine(p2.Descripcion);
                Assert.AreEqual(p2.Descripcion, newDes);

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        /// <summary>
        /// Test de integracion para conseguir una poliza por su ID.
        /// </summary>
        [TestMethod]
        public void TestGetPolizaById()
        {
                Poliza p = repo.GetPolizaByID(5);
                p.Cliente = crepo.GetClienteByPolizaID(p.ID_Poliza);
                Console.WriteLine(p.ToString());
                Assert.IsNotNull(p);
        }

        /// <summary>
        /// Test de integracion para conseguir todas las polizas.
        /// </summary>
        [TestMethod]
        public void TestGetAllPolizas()
        {
            IEnumerable<Poliza> polizas = repo.GetPolizas();
            Console.WriteLine(polizas.First());
            Assert.IsNotNull(polizas);
        }

        /// <summary>
        /// Test de integracion para borrar una poliza.
        /// </summary>
        [TestMethod]
        public void TestDeletePoliza()
        {
            try
            {
                POCO.Poliza p = repo.GetPolizas().LastOrDefault();
                repo.DeletePoliza(p.ID_Poliza);
                POCO.Poliza p2 = repo.GetPolizas().LastOrDefault();
                Assert.AreNotEqual(p, p2);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Unit Test para validar la regla de negocio: 
        /// Cuando una póliza de seguro, contiene una línea de riesgo alto, 
        /// el porcentaje de cubrimiento no puede ser superior al 50%.
        /// </summary>
        [TestMethod]
        public void TestReglaPoliza()
        {
            Poliza poliza = GetMockPoliza(false);
            
            Assert.IsFalse(Validator.PolizaValida(poliza));
        }

        public Cliente GetTestCliente()
        {
            Cliente c = new Cliente()
            {    

                ID = 4,
                Nombre = "Cesar",
                Apellido = "Mora",
                Correo = "cmora@mail.com",
                Cedula = "127849573",
                Genero = 'M'

            };
            return c;
        }

        public Poliza GetMockPoliza(bool valida)
        {

            if (valida)
            {
                Poliza p_valida = new Poliza()
                {
                    ID_Poliza = 0,
                    Nombre = "Pol-TEST",
                    Descripcion = "Test",
                    Periodo = 5,
                    Deducible = 50,
                    Precio = 10000,
                    Riesgo = GetRandom(Riesgo),
                    Cubrimiento = GetRandom(Cobertura),
                    Inicio_Vigencia = DateTime.Now,
                    Cliente = GetTestCliente()
                };

                return p_valida;
            }
            else
            {
                Poliza p_invalida = new Poliza()
                {
                    ID_Poliza = 0,
                    Nombre = "Pol-TEST",
                    Descripcion = "Test",
                    Periodo = 5,
                    Deducible = 50,
                    Precio = 10000,
                    Riesgo = Riesgo[3],
                    Cubrimiento = GetRandom(Cobertura),
                    Inicio_Vigencia = DateTime.Now,
                    Cliente = GetTestCliente()
                };

                return p_invalida;
            }
        }

        public static string GetRandom(string[] array)
        {
            var random = new Random();
            return array[random.Next(array.Length)];
        }
    }
}
