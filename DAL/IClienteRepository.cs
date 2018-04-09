using System;
using System.Collections.Generic;
using POCO;

namespace DAL
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetClientes();
        Cliente GetClienteByID(int clienteID);
        Cliente GetClienteByPolizaID(int polizaID);
    }
}
