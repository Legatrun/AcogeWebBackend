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
	[RoutePrefix("api/planilla")]
	public class planillaController: ApiController
	{
		planillaDataAccess objplanilla = new planillaDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public planilla Consultar()
		{
			return objplanilla.Consultarplanilla();
		}
       [HttpPost]
       [Route("Buscar")]
		public planilla Buscar([FromBody] planilla.Data data)
		{
			return objplanilla.Buscarplanilla(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public planilla.State Insertar([FromBody] planilla.Data data)
		{
			return objplanilla.Insertarplanilla(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public planilla.State Actualizar([FromBody] planilla.Data data)
		{
			return objplanilla.Actualizarplanilla(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public planilla.State Eliminar([FromBody] planilla.Data data)
		{
			return objplanilla.Eliminarplanilla(data);
		}
	}
}
