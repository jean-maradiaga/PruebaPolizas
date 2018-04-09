using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using POCO;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace DAL
{
    public class ClienteRepository : IClienteRepository
    {
        private const string ViewAllProcedure = "ClienteViewAll";
        private const string GetByIDProcedure = "ClienteById";
        private const string GetByPolizaIDProcedure = "ClienteByPolizaId";

        static string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        /// <summary>
        /// Metodo que retorna una lista de todos los clientes de la BD.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        public IEnumerable<Cliente> GetClientes()
        {
            using (SqlConnection _sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    _sqlCon.Open();
                    return _sqlCon.Query<Cliente>(ViewAllProcedure, commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }

        /// <summary>
        /// Metodo que retorna un Cliente por su ID unico.
        /// </summary>
        /// <param name="id">ID del cliente.</param>
        /// <returns>Cliente</returns>
        public Cliente GetClienteByID(int id)
        {
            using (SqlConnection _sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    _sqlCon.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_cliente", id);

                    Cliente c = _sqlCon.Query<Cliente>(GetByIDProcedure, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return c;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Metodo que retorna un Cliente asociado a una poliza.
        /// </summary>
        /// <param name="polizaID">ID de la poliza.</param>
        /// <returns>Cliente</returns>
        public Cliente GetClienteByPolizaID(int polizaID)
        {
            using (SqlConnection _sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    _sqlCon.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_poliza", polizaID);

                    Cliente c = _sqlCon.Query<Cliente>(GetByPolizaIDProcedure, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return c;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

    }
}
