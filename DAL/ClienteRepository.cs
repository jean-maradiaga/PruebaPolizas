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

        static string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

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

    }
}
