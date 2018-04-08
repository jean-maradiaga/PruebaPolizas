using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class PolizasController : Controller
    {
        // GET: Polizas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Poliza by ID
        public ActionResult Show(int id)
        {
            return View();
        }

    }
}