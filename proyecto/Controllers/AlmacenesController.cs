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
	[RoutePrefix("api/Almacenes")]
	public class AlmacenesController: ApiController
	{
		AlmacenesDataAccess objAlmacenes = new AlmacenesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Almacenes Consultar()
		{
			return objAlmacenes.ConsultarAlmacenes();
		}
       [HttpPost]
       [Route("Buscar")]
		public Almacenes Buscar([FromBody] Almacenes.Data data)
		{
			return objAlmacenes.BuscarAlmacenes(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Almacenes.State Insertar([FromBody] Almacenes.Data data)
		{
			return objAlmacenes.InsertarAlmacenes(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Almacenes.State Actualizar([FromBody] Almacenes.Data data)
		{
			return objAlmacenes.ActualizarAlmacenes(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Almacenes.State Eliminar([FromBody] Almacenes.Data data)
		{
			return objAlmacenes.EliminarAlmacenes(data);
		}
	}
}
