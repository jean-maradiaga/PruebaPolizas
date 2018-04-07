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
                ManageConnection();
                Poliza p = new Poliza()
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
            finally
            {
                ManageConnection();
            }



        }

        [TestMethod]
        public void TestUpdatePoliza()
        {

            try
            {
                ManageConnection();
                Poliza p1 = repo.GetPolizaByID(7);
                string newDes = "Poliza de lujo en primer año";
                p1.Descripcion = newDes;
                repo.InsertOrUpdatePoliza(p1);
                Poliza p2 = repo.GetPolizaByID(7);
                Console.WriteLine(p2.Descripcion);
                Assert.AreEqual(p2.Descripcion, newDes);

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                ManageConnection();
            }



        }

        [TestMethod]
        public void TestGetById()
        {
  

            try
            {
                ManageConnection();
                DynamicParameters param = new DynamicParameters();
                param.Add("@id_poliza", 5);
                Poliza p = sqlCon.Query<Poliza>("PolizaById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
        public void TestGetAll()
        {
            IEnumerable<Poliza> polizas = repo.GetPolizas();
            Console.WriteLine(polizas.First());
            Assert.IsNotNull(polizas);
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
