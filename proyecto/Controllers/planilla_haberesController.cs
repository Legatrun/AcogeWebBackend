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
	[RoutePrefix("api/planilla_haberes")]
	public class planilla_haberesController: ApiController
	{
		planilla_haberesDataAccess objplanilla_haberes = new planilla_haberesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public planilla_haberes Consultar()
		{
			return objplanilla_haberes.Consultarplanilla_haberes();
		}
       [HttpPost]
       [Route("Buscar")]
		public planilla_haberes Buscar([FromBody] planilla_haberes.Data data)
		{
			return objplanilla_haberes.Buscarplanilla_haberes(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public planilla_haberes.State Insertar([FromBody] planilla_haberes.Data data)
		{
			return objplanilla_haberes.Insertarplanilla_haberes(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public planilla_haberes.State Actualizar([FromBody] planilla_haberes.Data data)
		{
			return objplanilla_haberes.Actualizarplanilla_haberes(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public planilla_haberes.State Eliminar([FromBody] planilla_haberes.Data data)
		{
			return objplanilla_haberes.Eliminarplanilla_haberes(data);
		}
	}
}
