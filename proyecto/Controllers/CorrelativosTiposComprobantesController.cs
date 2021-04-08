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
	[RoutePrefix("api/CorrelativosTiposComprobantes")]
	public class CorrelativosTiposComprobantesController: ApiController
	{
		CorrelativosTiposComprobantesDataAccess objCorrelativosTiposComprobantes = new CorrelativosTiposComprobantesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public CorrelativosTiposComprobantes Consultar()
		{
			return objCorrelativosTiposComprobantes.ConsultarCorrelativosTiposComprobantes();
		}
       [HttpPost]
       [Route("Buscar")]
		public CorrelativosTiposComprobantes Buscar([FromBody] CorrelativosTiposComprobantes.Data data)
		{
			return objCorrelativosTiposComprobantes.BuscarCorrelativosTiposComprobantes(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public CorrelativosTiposComprobantes.State Insertar([FromBody] CorrelativosTiposComprobantes.Data data)
		{
			return objCorrelativosTiposComprobantes.InsertarCorrelativosTiposComprobantes(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public CorrelativosTiposComprobantes.State Actualizar([FromBody] CorrelativosTiposComprobantes.Data data)
		{
			return objCorrelativosTiposComprobantes.ActualizarCorrelativosTiposComprobantes(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public CorrelativosTiposComprobantes.State Eliminar([FromBody] CorrelativosTiposComprobantes.Data data)
		{
			return objCorrelativosTiposComprobantes.EliminarCorrelativosTiposComprobantes(data);
		}
	}
}
