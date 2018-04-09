using POCO;
using System;

namespace WebApi.Validation
{
    public static class Validator
    {
        private static readonly DateTime FechaMin = DateTime.Parse("01-01-1753");
        private static readonly DateTime FechaMax = DateTime.Parse("12-31-9999");
        public static bool PolizaValida(Poliza poliza)
        {
            return (!(poliza.Riesgo.Equals("Alto") && poliza.Deducible > 50)) &&
                poliza.Inicio_Vigencia >= FechaMin && poliza.Inicio_Vigencia <= FechaMax;
        }


    }
}