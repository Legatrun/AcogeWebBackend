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
	[RoutePrefix("api/Zonas")]
	public class ZonasController: ApiController
	{
		ZonasDataAccess objZonas = new ZonasDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Zonas Consultar()
		{
			return objZonas.ConsultarZonas();
		}
       [HttpPost]
       [Route("Buscar")]
		public Zonas Buscar([FromBody] Zonas.Data data)
		{
			return objZonas.BuscarZonas(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Zonas.State Insertar([FromBody] Zonas.Data data)
		{
			return objZonas.InsertarZonas(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Zonas.State Actualizar([FromBody] Zonas.Data data)
		{
			return objZonas.ActualizarZonas(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Zonas.State Eliminar([FromBody] Zonas.Data data)
		{
			return objZonas.EliminarZonas(data);
		}
	}
}
