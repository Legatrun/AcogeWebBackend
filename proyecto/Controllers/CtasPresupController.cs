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
	[RoutePrefix("api/CtasPresup")]
	public class CtasPresupController: ApiController
	{
		CtasPresupDataAccess objCtasPresup = new CtasPresupDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public CtasPresup Consultar()
		{
			return objCtasPresup.ConsultarCtasPresup();
		}
       [HttpPost]
       [Route("Buscar")]
		public CtasPresup Buscar([FromBody] CtasPresup.Data data)
		{
			return objCtasPresup.BuscarCtasPresup(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public CtasPresup.State Insertar([FromBody] CtasPresup.Data data)
		{
			return objCtasPresup.InsertarCtasPresup(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public CtasPresup.State Actualizar([FromBody] CtasPresup.Data data)
		{
			return objCtasPresup.ActualizarCtasPresup(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public CtasPresup.State Eliminar([FromBody] CtasPresup.Data data)
		{
			return objCtasPresup.EliminarCtasPresup(data);
		}
	}
}
