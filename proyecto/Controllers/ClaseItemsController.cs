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
	[RoutePrefix("api/ClaseItems")]
	public class ClaseItemsController: ApiController
	{
		ClaseItemsDataAccess objClaseItems = new ClaseItemsDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public ClaseItems Consultar()
		{
			return objClaseItems.ConsultarClaseItems();
		}
       [HttpPost]
       [Route("Buscar")]
		public ClaseItems Buscar([FromBody] ClaseItems.Data data)
		{
			return objClaseItems.BuscarClaseItems(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public ClaseItems.State Insertar([FromBody] ClaseItems.Data data)
		{
			return objClaseItems.InsertarClaseItems(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public ClaseItems.State Actualizar([FromBody] ClaseItems.Data data)
		{
			return objClaseItems.ActualizarClaseItems(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public ClaseItems.State Eliminar([FromBody] ClaseItems.Data data)
		{
			return objClaseItems.EliminarClaseItems(data);
		}
	}
}
