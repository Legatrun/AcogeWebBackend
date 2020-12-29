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
	[RoutePrefix("api/TipodePagos")]
	public class TipodePagosController: ApiController
	{
		TipodePagosDataAccess objTipodePagos = new TipodePagosDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public TipodePagos Consultar()
		{
			return objTipodePagos.ConsultarTipodePagos();
		}
       [HttpPost]
       [Route("Buscar")]
		public TipodePagos Buscar([FromBody] TipodePagos.Data data)
		{
			return objTipodePagos.BuscarTipodePagos(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public TipodePagos.State Insertar([FromBody] TipodePagos.Data data)
		{
			return objTipodePagos.InsertarTipodePagos(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public TipodePagos.State Actualizar([FromBody] TipodePagos.Data data)
		{
			return objTipodePagos.ActualizarTipodePagos(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public TipodePagos.State Eliminar([FromBody] TipodePagos.Data data)
		{
			return objTipodePagos.EliminarTipodePagos(data);
		}
	}
}
