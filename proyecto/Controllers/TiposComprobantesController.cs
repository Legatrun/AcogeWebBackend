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
	[RoutePrefix("api/TiposComprobantes")]
	public class TiposComprobantesController: ApiController
	{
		TiposComprobantesDataAccess objTiposComprobantes = new TiposComprobantesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public TiposComprobantes Consultar()
		{
			return objTiposComprobantes.ConsultarTiposComprobantes();
		}
       [HttpPost]
       [Route("Buscar")]
		public TiposComprobantes Buscar([FromBody] TiposComprobantes.Data data)
		{
			return objTiposComprobantes.BuscarTiposComprobantes(data);
		}

       [HttpPost]
       [Route("Insertar")]
        //public TiposComprobantes.State Insertar([FromBody] TiposComprobantes.Data data)
        //{
        //	return objTiposComprobantes.InsertarTiposComprobantes(data);
        //}
        public TiposComprobantes.State Insertar([FromBody] TiposComprobantes.Data data)
        {
            return objTiposComprobantes.InsertarTiposComprobantes(data);
        }

        [HttpPut]
       [Route("Actualizar")]
		public TiposComprobantes.State Actualizar([FromBody] TiposComprobantes.Data data)
		{
			return objTiposComprobantes.ActualizarTiposComprobantes(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public TiposComprobantes.State Eliminar([FromBody] TiposComprobantes.Data data)
		{
			return objTiposComprobantes.EliminarTiposComprobantes(data);
		}
	}
}
