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
    public class PolizaTests
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        private IPolizaRepository repo = new PolizaRepository();
        SqlConnection sqlCon = new SqlConnection(ConnectionString);
        public static string[] Riesgo = { "Bajo", "Medio", "Medio-Alto", "Alto" };
        public static string[] Cobertura = { "Robo", "Incendio", "Terremoto", "Perdida" };

        [TestMethod]
        public void TestAddPoliza()
        {

            try
            {
                POCO.Poliza p = new POCO.Poliza()
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
                repo.InsertOrUpdatePoliza(p);
            }
            catch(Exception e)
            {
                throw e;
            }
          
        }

        [TestMethod]
        public void TestUpdatePoliza()
        {

            try
            {
                Poliza p1 = repo.GetPolizaByID((int)7);
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

        [TestMethod]
        public void TestGetById()
        {
  

            try
            {
                Poliza p = repo.GetPolizaByID((int)5);
                ManageConnection();
                DynamicParameters param = new DynamicParameters();
                param.Add("@id_poliza", 5);
                p.Cliente = sqlCon.Query<Cliente>("ClienteByPolizaId", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                Console.WriteLine(p.ToString());
                Assert.IsNotNull(p);

            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                ManageConnection();
            }
        }

        [TestMethod]
        public void TestGetAllPolizas()
        {
            IEnumerable<POCO.Poliza> polizas = repo.GetPolizas();
            Console.WriteLine(polizas.First());
            Assert.IsNotNull(polizas);
        }

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

        public static string GetRandom(string[] array)
        {
            var random = new Random();
            return array[random.Next(array.Length)];
        }

        public void ManageConnection()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();

            }
            else
            {
                sqlCon.Close();
            }
        }
    }
}
