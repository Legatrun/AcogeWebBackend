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
	[RoutePrefix("api/Pais")]
	public class PaisController: ApiController
	{
		PaisDataAccess objPais = new PaisDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Pais Consultar()
		{
			return objPais.ConsultarPais();
		}
       [HttpPost]
       [Route("Buscar")]
		public Pais Buscar([FromBody] Pais.Data data)
		{
			return objPais.BuscarPais(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Pais.State Insertar([FromBody] Pais.Data data)
		{
			return objPais.InsertarPais(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Pais.State Actualizar([FromBody] Pais.Data data)
		{
			return objPais.ActualizarPais(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Pais.State Eliminar([FromBody] Pais.Data data)
		{
			return objPais.EliminarPais(data);
		}
	}
}
