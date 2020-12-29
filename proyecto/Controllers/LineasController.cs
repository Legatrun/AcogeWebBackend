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
	[RoutePrefix("api/Lineas")]
	public class LineasController: ApiController
	{
		LineasDataAccess objLineas = new LineasDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Lineas Consultar()
		{
			return objLineas.ConsultarLineas();
		}
       [HttpPost]
       [Route("Buscar")]
		public Lineas Buscar([FromBody] Lineas.Data data)
		{
			return objLineas.BuscarLineas(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Lineas.State Insertar([FromBody] Lineas.Data data)
		{
			return objLineas.InsertarLineas(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Lineas.State Actualizar([FromBody] Lineas.Data data)
		{
			return objLineas.ActualizarLineas(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Lineas.State Eliminar([FromBody] Lineas.Data data)
		{
			return objLineas.EliminarLineas(data);
		}
	}
}
