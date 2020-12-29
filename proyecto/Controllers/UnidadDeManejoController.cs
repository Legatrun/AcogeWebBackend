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
	[RoutePrefix("api/UnidadDeManejo")]
	public class UnidadDeManejoController: ApiController
	{
		UnidadDeManejoDataAccess objUnidadDeManejo = new UnidadDeManejoDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public UnidadDeManejo Consultar()
		{
			return objUnidadDeManejo.ConsultarUnidadDeManejo();
		}
       [HttpPost]
       [Route("Buscar")]
		public UnidadDeManejo Buscar([FromBody] UnidadDeManejo.Data data)
		{
			return objUnidadDeManejo.BuscarUnidadDeManejo(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public UnidadDeManejo.State Insertar([FromBody] UnidadDeManejo.Data data)
		{
			return objUnidadDeManejo.InsertarUnidadDeManejo(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public UnidadDeManejo.State Actualizar([FromBody] UnidadDeManejo.Data data)
		{
			return objUnidadDeManejo.ActualizarUnidadDeManejo(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public UnidadDeManejo.State Eliminar([FromBody] UnidadDeManejo.Data data)
		{
			return objUnidadDeManejo.EliminarUnidadDeManejo(data);
		}
	}
}
