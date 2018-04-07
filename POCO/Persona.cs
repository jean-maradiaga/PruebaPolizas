using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{

    /// <summary>
    /// Clase Abstracta Persona. Clase base que define los atributos y comportamientos compartidos de los empelados y clientes
    /// que utilizan/estan en el sistema.
    /// </summary>
    public abstract class Persona
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Cedula { get; set; }

    }
}
