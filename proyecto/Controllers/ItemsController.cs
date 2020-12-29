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
	[RoutePrefix("api/Items")]
	public class ItemsController: ApiController
	{
		ItemsDataAccess objItems = new ItemsDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Items Consultar()
		{
			return objItems.ConsultarItems();
		}
       [HttpPost]
       [Route("Buscar")]
		public Items Buscar([FromBody] Items.Data data)
		{
			return objItems.BuscarItems(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Items.State Insertar([FromBody] Items.Data data)
		{
			return objItems.InsertarItems(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Items.State Actualizar([FromBody] Items.Data data)
		{
			return objItems.ActualizarItems(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Items.State Eliminar([FromBody] Items.Data data)
		{
			return objItems.EliminarItems(data);
		}
	}
}
