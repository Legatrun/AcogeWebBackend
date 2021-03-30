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
	[RoutePrefix("api/TiposItems")]
	public class TiposItemsController: ApiController
	{
		TiposItemsDataAccess objTiposItems = new TiposItemsDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public TiposItems Consultar()
		{
			return objTiposItems.ConsultarTiposItems();
		}
       [HttpPost]
       [Route("Buscar")]
		public TiposItems Buscar([FromBody] TiposItems.Data data)
		{
			return objTiposItems.BuscarTiposItems(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public TiposItems.State Insertar([FromBody] TiposItems.Data data)
		{
			return objTiposItems.InsertarTiposItems(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public TiposItems.State Actualizar([FromBody] TiposItems.Data data)
		{
			return objTiposItems.ActualizarTiposItems(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public TiposItems.State Eliminar([FromBody] TiposItems.Data data)
		{
			return objTiposItems.EliminarTiposItems(data);
		}
	}
}
