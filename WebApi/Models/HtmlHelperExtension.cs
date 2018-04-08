using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Models
{
    public static class HtmlHelperExtension
    {
        const string Option = "<option value=@Value>@Text</option>";
        const string Placeholder = "<option selected disabled style=\"display:none;\" value=\"\">@Placeholder</option>";

        public static HtmlString GetRiesgos(this HtmlHelper helper)
        {
            return new HtmlString(BuildOptions(new RiesgoRepository().GetRiesgos(), "Seleccione un nivel de riesgo"));
        }

        public static HtmlString GetCubrimientos(this HtmlHelper helper)
        {
            return new HtmlString(BuildOptions(new CubrimientoRepository().GetCubrimientos(), "Seleccione un cubrimiento"));
        }

        private static string BuildOptions(IEnumerable<string> list, string placeholder)
        {
            var sb = new StringBuilder();
            foreach(string s in list)
            {
                sb.Append(Option);
                sb.Replace("@Value", s);
                sb.Replace("@Text", s);
            }

            sb.Append(Placeholder);
            sb.Replace("@Placeholder", placeholder);


            return sb.ToString();
        }
    }
}