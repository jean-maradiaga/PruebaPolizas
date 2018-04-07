using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    /// <summary>
    /// Poliza POCO(Plain old CLR objects).
    /// </summary>
    public class Poliza
    {

        public int ID { get; set; }
        public int Periodo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Deducible { get; set; }
        public decimal Precio { get; set; }
        public string Riesgo { get; set; }
        public string Cubrimiento { get; set; }
        public DateTime InicioVigencia { get; set; }


        public Poliza(string nombre, string descripcion, int periodo, decimal precio, string riesgo, decimal deducible, string cobertura, DateTime inicioVigencia)
        {

            Nombre = nombre;
            Descripcion = descripcion;
            Periodo = periodo;
            Precio = precio;
            Riesgo = riesgo;
            Deducible = deducible;
            Cubrimiento = cobertura;
            InicioVigencia = inicioVigencia;
        }

        public Poliza(string nombre, string descripcion, int periodo, decimal precio, string riesgo, decimal deducible, string cobertura, DateTime inicioVigencia, int id = 0)
        {
            ID = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Periodo = periodo;
            Precio = precio;
            Riesgo = riesgo;
            Deducible = deducible;
            Cubrimiento = cobertura;
            InicioVigencia = inicioVigencia;
        }


        public override string ToString()
        {
            return "Nombre: " + Nombre + ": " + Descripcion;
        }
    }
}


//Una póliza de seguro se compone de la siguiente información:
//● Nombre y descripción.
//● Tipo de cubrimiento(s) de la póliza(Terremoto, incendio, Robo, Pérdida, etc). La
//cobertura se define en porcentaje.
//● Inicio de vigencia de la póliza.
//● Periodo de cobertura definido en meses
//● Precio de la poliza.
//● Tipo de Riesgo (bajo, medio, medio-alto, alto)