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
	[RoutePrefix("api/descuentos")]
	public class descuentosController: ApiController
	{
		descuentosDataAccess objdescuentos = new descuentosDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public descuentos Consultar()
		{
			return objdescuentos.Consultardescuentos();
		}
       [HttpPost]
       [Route("Buscar")]
		public descuentos Buscar([FromBody] descuentos.Data data)
		{
			return objdescuentos.Buscardescuentos(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public descuentos.State Insertar([FromBody] descuentos.Data data)
		{
			return objdescuentos.Insertardescuentos(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public descuentos.State Actualizar([FromBody] descuentos.Data data)
		{
			return objdescuentos.Actualizardescuentos(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public descuentos.State Eliminar([FromBody] descuentos.Data data)
		{
			return objdescuentos.Eliminardescuentos(data);
		}
	}
}
