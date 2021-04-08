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
	[RoutePrefix("api/AsientosDetalle")]
	public class AsientosDetalleController: ApiController
	{
		AsientosDetalleDataAccess objAsientosDetalle = new AsientosDetalleDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public AsientosDetalle Consultar()
		{
			return objAsientosDetalle.ConsultarAsientosDetalle();
		}
       [HttpPost]
       [Route("Buscar")]
		public AsientosDetalle Buscar([FromBody] AsientosDetalle.Data data)
		{
			return objAsientosDetalle.BuscarAsientosDetalle(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public AsientosDetalle.State Insertar([FromBody] AsientosDetalle.Data data)
		{
			return objAsientosDetalle.InsertarAsientosDetalle(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public AsientosDetalle.State Actualizar([FromBody] AsientosDetalle.Data data)
		{
			return objAsientosDetalle.ActualizarAsientosDetalle(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public AsientosDetalle.State Eliminar([FromBody] AsientosDetalle.Data data)
		{
			return objAsientosDetalle.EliminarAsientosDetalle(data);
		}
	}
}
