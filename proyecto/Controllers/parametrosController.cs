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
	[RoutePrefix("api/parametros")]
	public class parametrosController: ApiController
	{
		parametrosDataAccess objparametros = new parametrosDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public parametros Consultar()
		{
			return objparametros.Consultarparametros();
		}
       [HttpPost]
       [Route("Buscar")]
		public parametros Buscar([FromBody] parametros.Data data)
		{
			return objparametros.Buscarparametros(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public parametros.State Insertar([FromBody] parametros.Data data)
		{
			return objparametros.Insertarparametros(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public parametros.State Actualizar([FromBody] parametros.Data data)
		{
			return objparametros.Actualizarparametros(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public parametros.State Eliminar([FromBody] parametros.Data data)
		{
			return objparametros.Eliminarparametros(data);
		}
	}
}
