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
	[RoutePrefix("api/TipoMovimientoInventario")]
	public class TipoMovimientoInventarioController: ApiController
	{
		TipoMovimientoInventarioDataAccess objTipoMovimientoInventario = new TipoMovimientoInventarioDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public TipoMovimientoInventario Consultar()
		{
			return objTipoMovimientoInventario.ConsultarTipoMovimientoInventario();
		}
       [HttpPost]
       [Route("Buscar")]
		public TipoMovimientoInventario Buscar([FromBody] TipoMovimientoInventario.Data data)
		{
			return objTipoMovimientoInventario.BuscarTipoMovimientoInventario(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public TipoMovimientoInventario.State Insertar([FromBody] TipoMovimientoInventario.Data data)
		{
			return objTipoMovimientoInventario.InsertarTipoMovimientoInventario(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public TipoMovimientoInventario.State Actualizar([FromBody] TipoMovimientoInventario.Data data)
		{
			return objTipoMovimientoInventario.ActualizarTipoMovimientoInventario(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public TipoMovimientoInventario.State Eliminar([FromBody] TipoMovimientoInventario.Data data)
		{
			return objTipoMovimientoInventario.EliminarTipoMovimientoInventario(data);
		}
	}
}
