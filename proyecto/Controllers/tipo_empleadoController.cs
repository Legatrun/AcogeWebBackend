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
	[RoutePrefix("api/tipo_empleado")]
	public class tipo_empleadoController: ApiController
	{
		tipo_empleadoDataAccess objtipo_empleado = new tipo_empleadoDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public tipo_empleado Consultar()
		{
			return objtipo_empleado.Consultartipo_empleado();
		}
       [HttpPost]
       [Route("Buscar")]
		public tipo_empleado Buscar([FromBody] tipo_empleado.Data data)
		{
			return objtipo_empleado.Buscartipo_empleado(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public tipo_empleado.State Insertar([FromBody] tipo_empleado.Data data)
		{
			return objtipo_empleado.Insertartipo_empleado(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public tipo_empleado.State Actualizar([FromBody] tipo_empleado.Data data)
		{
			return objtipo_empleado.Actualizartipo_empleado(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public tipo_empleado.State Eliminar([FromBody] tipo_empleado.Data data)
		{
			return objtipo_empleado.Eliminartipo_empleado(data);
		}
	}
}
