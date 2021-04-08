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
	[RoutePrefix("api/TiposdeCambio")]
	public class TiposdeCambioController: ApiController
	{
		TiposdeCambioDataAccess objTiposdeCambio = new TiposdeCambioDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public TiposdeCambio Consultar()
		{
			return objTiposdeCambio.ConsultarTiposdeCambio();
		}
       [HttpPost]
       [Route("Buscar")]
		public TiposdeCambio Buscar([FromBody] TiposdeCambio.Data data)
		{
			return objTiposdeCambio.BuscarTiposdeCambio(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public TiposdeCambio.State Insertar([FromBody] TiposdeCambio.Data data)
		{
			return objTiposdeCambio.InsertarTiposdeCambio(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public TiposdeCambio.State Actualizar([FromBody] TiposdeCambio.Data data)
		{
			return objTiposdeCambio.ActualizarTiposdeCambio(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public TiposdeCambio.State Eliminar([FromBody] TiposdeCambio.Data data)
		{
			return objTiposdeCambio.EliminarTiposdeCambio(data);
		}
	}
}
