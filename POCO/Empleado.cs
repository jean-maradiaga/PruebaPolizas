using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    /// <summary>
    /// Una persona que utiliza el sistema del tipo Empleado. Es quien se encarga de manejar el sistema.
    /// </summary>
    public class Empleado : Persona
    {
        public string Username { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Constructor de Empleado usado para la operacion de creacion de un nuevo empleado.
        /// </summary>
        public Empleado(string nombre, string apellido, string correo, string cedula, string username, string password)
        {
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Cedula = cedula;
            Username = username;
            Password = password;
        }

        /// <summary>
        /// Constructor de Empleado usado para las demas operaciones del CRUD.
        /// </summary>
        public Empleado(string nombre, string apellido, string correo, string cedula, string username, string password, int id)
        {
            ID = id;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Cedula = cedula;
            Username = username;
            Password = password;
        }
    }
}
