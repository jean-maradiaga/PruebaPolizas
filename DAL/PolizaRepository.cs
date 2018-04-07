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

        static string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        private SqlConnection _sqlCon = new SqlConnection(ConnectionString);

        public IEnumerable<Poliza> GetPolizas()
        {
            return this._sqlCon.Query<Poliza>("PolizaViewAll", commandType: CommandType.StoredProcedure);
        }

        public Poliza GetPolizaByID(int id)
        {
            try
            {
                ManageConnection();
                DynamicParameters param = new DynamicParameters();
                param.Add("@id_poliza", id);

                Poliza p = _sqlCon.Query<Poliza>("PolizaById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                p.Cliente = _sqlCon.Query<Cliente>("ClienteByPolizaId", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return p;


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

        public void InsertOrUpdatePoliza(Poliza p)
        {
            try
            {
                ManageConnection();
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

                _sqlCon.Execute("PolizaAddOrEdit", param, commandType: CommandType.StoredProcedure);
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

        public void DeletePoliza(int PolizaID)
        {
            throw new NotImplementedException();
        }

        public void ManageConnection()
        {
            if (_sqlCon.State == ConnectionState.Closed)
            {
                _sqlCon.Open();

            }
            else
            {
                _sqlCon.Close();
            }
        }

    }
}
