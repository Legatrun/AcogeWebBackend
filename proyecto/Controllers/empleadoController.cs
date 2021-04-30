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
	[RoutePrefix("api/empleado")]
	public class empleadoController: ApiController
	{
		empleadoDataAccess objempleado = new empleadoDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public empleado Consultar()
		{
			return objempleado.Consultarempleado();
		}
       [HttpPost]
       [Route("Buscar")]
		public empleado Buscar([FromBody] empleado.Data data)
		{
			return objempleado.Buscarempleado(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public empleado.State Insertar([FromBody] empleado.Data data)
		{
			return objempleado.Insertarempleado(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public empleado.State Actualizar([FromBody] empleado.Data data)
		{
			return objempleado.Actualizarempleado(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public empleado.State Eliminar([FromBody] empleado.Data data)
		{
			return objempleado.Eliminarempleado(data);
		}
	}
}
