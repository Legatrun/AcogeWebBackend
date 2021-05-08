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
	[RoutePrefix("api/empleado_depto")]
	public class empleado_deptoController: ApiController
	{
		empleado_deptoDataAccess objempleado_depto = new empleado_deptoDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public empleado_depto Consultar()
		{
			return objempleado_depto.Consultarempleado_depto();
		}
       [HttpPost]
       [Route("Buscar")]
		public empleado_depto Buscar([FromBody] empleado_depto.Data data)
		{
			return objempleado_depto.Buscarempleado_depto(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public empleado_depto.State Insertar([FromBody] empleado_depto.Data data)
		{
			return objempleado_depto.Insertarempleado_depto(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public empleado_depto.State Actualizar([FromBody] empleado_depto.Data data)
		{
			return objempleado_depto.Actualizarempleado_depto(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public empleado_depto.State Eliminar([FromBody] empleado_depto.Data data)
		{
			return objempleado_depto.Eliminarempleado_depto(data);
		}
	}
}
