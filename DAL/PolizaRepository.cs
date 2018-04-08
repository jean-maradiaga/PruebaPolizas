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


    public class PolizaRepository : IPolizaRepository
    {
        private const string ViewAllProcedure = "PolizaViewAll";
        private const string GetPolizaByIDProcedure = "PolizaById";
        private const string InsertOrUpdateProcedure = "PolizaAddOrEdit";
        private const string DeleteByIDProcedure = "PolizaDeleteById";
        private const string GetClienteByIDProcedure = "ClienteByPolizaId";

        static string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public IEnumerable<Poliza> GetPolizas()
        {
            using (SqlConnection _sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    _sqlCon.Open();
                    return _sqlCon.Query<Poliza>(ViewAllProcedure, commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            
        }

        public Poliza GetPolizaByID(int id)
        {
            using (SqlConnection _sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    _sqlCon.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_poliza", id);

                    Poliza p = _sqlCon.Query<Poliza>(GetPolizaByIDProcedure, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    p.Cliente = _sqlCon.Query<Cliente>(GetClienteByIDProcedure, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return p;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public void InsertOrUpdatePoliza(Poliza p)
        {
            using (SqlConnection _sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    _sqlCon.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_poliza", p.ID_Poliza);
                    param.Add("@nombre", p.Nombre);
                    param.Add("@descripcion", p.Descripcion);
                    param.Add("@periodo", p.Periodo);
                    param.Add("@deducible", p.Deducible);
                    param.Add("@precio", p.Precio);
                    param.Add("@riesgo", p.Riesgo);
                    param.Add("@cubrimiento", p.Cubrimiento);
                    param.Add("@inicio_vigencia", p.Inicio_Vigencia);
                    param.Add("@id_cliente", p.Cliente.ID);

                    _sqlCon.Execute(InsertOrUpdateProcedure, param, commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public void DeletePoliza(int id)
        {
            using (SqlConnection _sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    _sqlCon.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@id_poliza", id);
                    _sqlCon.Query<Cliente>(DeleteByIDProcedure, param, commandType: CommandType.StoredProcedure);

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
