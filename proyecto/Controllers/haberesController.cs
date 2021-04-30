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
	[RoutePrefix("api/haberes")]
	public class haberesController: ApiController
	{
		haberesDataAccess objhaberes = new haberesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public haberes Consultar()
		{
			return objhaberes.Consultarhaberes();
		}
       [HttpPost]
       [Route("Buscar")]
		public haberes Buscar([FromBody] haberes.Data data)
		{
			return objhaberes.Buscarhaberes(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public haberes.State Insertar([FromBody] haberes.Data data)
		{
			return objhaberes.Insertarhaberes(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public haberes.State Actualizar([FromBody] haberes.Data data)
		{
			return objhaberes.Actualizarhaberes(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public haberes.State Eliminar([FromBody] haberes.Data data)
		{
			return objhaberes.Eliminarhaberes(data);
		}
	}
}
