using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using proyecto.Models;

namespace proyecto.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : ApiController
    {
        EmpresaDataAccess objEmpresa = new EmpresaDataAccess();

        [HttpPost]
        [Route("Consultar")]
        public Empresa Consultar()
        {
            return objEmpresa.ConsultarEmpresa();
        }
      
    }
}
