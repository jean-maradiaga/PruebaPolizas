using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        public IHttpActionResult Get()
        {
            IClienteRepository repo = new ClienteRepository();
            return Ok(repo.GetClientes());
        }
    }
}
