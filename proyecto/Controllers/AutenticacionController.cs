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
    [RoutePrefix("api/Autenticacion")]
    public class AutenticacionController : ApiController
    {
        AutenticacionDataAccess objAutenticacion = new AutenticacionDataAccess();

        [HttpPost]
        [Route("Login")]
        public Autenticacion Login([FromBody] Autenticacion.Data data)
        {
            return objAutenticacion.Login(data);
        }

        [HttpPost]
        [Route("LoginAD")]
        public Autenticacion.State LoginAD([FromBody] Autenticacion.Data data)
        {
            return objAutenticacion.LoginAD(data);
        }

        [HttpPost]
        [Route("Logout")]
        public Autenticacion.State Logout([FromBody] Autenticacion.Data data)
        {
            return objAutenticacion.Logout(data);
        }
    }
}
