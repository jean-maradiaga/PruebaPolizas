using System;
using System.Collections.Generic;
using POCO;

namespace DAL
{
    public interface IPolizaRepository
    {
        IEnumerable<Poliza> GetPolizas();
        Poliza GetPolizaByID(int polizaID);
        void InsertOrUpdatePoliza(Poliza poliza);
        void DeletePoliza(int polizaID);
    }
}
