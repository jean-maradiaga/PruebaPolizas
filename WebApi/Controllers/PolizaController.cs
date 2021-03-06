﻿using DAL;
using POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Validation;

namespace WebApi.Controllers
{
    public class PolizaController : ApiController
    {
        public IHttpActionResult Get()
        {
            IPolizaRepository repo = new PolizaRepository();
            return Ok(repo.GetPolizas());
        }

        public IHttpActionResult Get(int id)
        {
            IPolizaRepository repo = new PolizaRepository();
            return Ok(repo.GetPolizaByID(id));
        }

        public IHttpActionResult Post(Poliza poliza)
        {
            if (!Validator.PolizaValida(poliza))
            {
                return BadRequest("Combinación de riesgo y deducible invalida");
            }
            IPolizaRepository repo = new PolizaRepository();
            repo.InsertOrUpdatePoliza(poliza);
            return Ok();

        }

        public IHttpActionResult Put([FromBody]Poliza poliza)
        {
            if (!Validator.PolizaValida(poliza))
            {
                return BadRequest("Combinación de riesgo y deducible invalida");
            }
            IPolizaRepository repo = new PolizaRepository();
            repo.InsertOrUpdatePoliza(poliza);
            return Ok();
        }

        public IHttpActionResult Delete(Poliza poliza)
        {
            IPolizaRepository repo = new PolizaRepository();
            repo.DeletePoliza(poliza.ID_Poliza);
            return Ok();
        }

    }
}
