using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    /// <summary>
    /// Una persona que utiliza en sistema del tipo Cliente. Es a quien se le asignan polizas.
    /// </summary>
    public class Cliente : Persona
    {
        public char Genero { get; set; }
        public List<Poliza> Polizas { get; set; }

        /// <summary>
        /// Constructor de Cliente usado para la operacion de creacion de un nuevo cliente.
        /// </summary>
        public Cliente(string nombre, string apellido, string correo, string cedula, char genero)
        {
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Cedula = cedula;
            Genero = genero;
        }

        /// <summary>
        /// Constructor de Cliente usado para las demas operaciones del CRUD.
        /// </summary>
        public Cliente(string nombre, string apellido, string correo, string cedula, char genero, List<Poliza> polizas, int id)
        {
            ID = id;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Cedula = cedula;
            Genero = genero;
            Polizas = polizas;
        }


    }
}
