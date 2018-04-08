using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CubrimientoRepository : ICubrimientoRepository
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public IEnumerable<string> GetCubrimientos()
        {

            using (SqlConnection _sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    _sqlCon.Open();
                    return _sqlCon.Query<String>("CubrimientoViewAll", commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
    }
}
