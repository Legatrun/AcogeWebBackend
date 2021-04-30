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
	[RoutePrefix("api/planilla_esp")]
	public class planilla_espController: ApiController
	{
		planilla_espDataAccess objplanilla_esp = new planilla_espDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public planilla_esp Consultar()
		{
			return objplanilla_esp.Consultarplanilla_esp();
		}
       [HttpPost]
       [Route("Buscar")]
		public planilla_esp Buscar([FromBody] planilla_esp.Data data)
		{
			return objplanilla_esp.Buscarplanilla_esp(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public planilla_esp.State Insertar([FromBody] planilla_esp.Data data)
		{
			return objplanilla_esp.Insertarplanilla_esp(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public planilla_esp.State Actualizar([FromBody] planilla_esp.Data data)
		{
			return objplanilla_esp.Actualizarplanilla_esp(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public planilla_esp.State Eliminar([FromBody] planilla_esp.Data data)
		{
			return objplanilla_esp.Eliminarplanilla_esp(data);
		}
	}
}
