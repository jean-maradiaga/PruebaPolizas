using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dapper;
using System;
using POCO;
namespace PolizaTests
{
    [TestClass]
    public class PolizaTests
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
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
                    ID = 0,
                    Nombre = "Pol-TEST",
                    Descripcion = "Test",
                    Periodo = 5,
                    Deducible = 50,
                    Precio = 10000,
                    Riesgo = GetRandom(Riesgo),
                    Cubrimiento = GetRandom(Cobertura),
                    InicioVigencia = DateTime.Now,
                    Cliente = GetTestCliente()
            };

                DynamicParameters param = new DynamicParameters();
                param.Add("@id_poliza", p.ID);
                param.Add("@nombre", p.Nombre);
                param.Add("@descripcion", p.Descripcion);
                param.Add("@periodo", p.Periodo);
                param.Add("@deducible", p.Deducible);
                param.Add("@precio", p.Precio);
                param.Add("@riesgo", p.Riesgo);
                param.Add("@cubrimiento", p.Cubrimiento);
                param.Add("@inicio_vigencia", p.InicioVigencia);
                param.Add("@id_cliente", p.Cliente.ID);

                sqlCon.Execute("PolizaAddOrEdit", param, commandType: CommandType.StoredProcedure);
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

        public Cliente GetTestCliente()
        {
            Cliente c = new Cliente("Cesar", "Mora", "cmora@mail.com", "127849573", 'M')
            {
                ID = 4
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
