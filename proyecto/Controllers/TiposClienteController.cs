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
	[RoutePrefix("api/TiposCliente")]
	public class TiposClienteController: ApiController
	{
		TiposClienteDataAccess objTiposCliente = new TiposClienteDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public TiposCliente Consultar()
		{
			return objTiposCliente.ConsultarTiposCliente();
		}
       [HttpPost]
       [Route("Buscar")]
		public TiposCliente Buscar([FromBody] TiposCliente.Data data)
		{
			return objTiposCliente.BuscarTiposCliente(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public TiposCliente.State Insertar([FromBody] TiposCliente.Data data)
		{
			return objTiposCliente.InsertarTiposCliente(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public TiposCliente.State Actualizar([FromBody] TiposCliente.Data data)
		{
			return objTiposCliente.ActualizarTiposCliente(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public TiposCliente.State Eliminar([FromBody] TiposCliente.Data data)
		{
			return objTiposCliente.EliminarTiposCliente(data);
		}
	}
}
