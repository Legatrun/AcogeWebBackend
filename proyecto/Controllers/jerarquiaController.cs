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
	[RoutePrefix("api/jerarquia")]
	public class jerarquiaController: ApiController
	{
		jerarquiaDataAccess objjerarquia = new jerarquiaDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public jerarquia Consultar()
		{
			return objjerarquia.Consultarjerarquia();
		}
       [HttpPost]
       [Route("Buscar")]
		public jerarquia Buscar([FromBody] jerarquia.Data data)
		{
			return objjerarquia.Buscarjerarquia(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public jerarquia.State Insertar([FromBody] jerarquia.Data data)
		{
			return objjerarquia.Insertarjerarquia(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public jerarquia.State Actualizar([FromBody] jerarquia.Data data)
		{
			return objjerarquia.Actualizarjerarquia(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public jerarquia.State Eliminar([FromBody] jerarquia.Data data)
		{
			return objjerarquia.Eliminarjerarquia(data);
		}
	}
}
