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
	[RoutePrefix("api/TipoDocumentosIdentidad")]
	public class TipoDocumentosIdentidadController: ApiController
	{
		TipoDocumentosIdentidadDataAccess objTipoDocumentosIdentidad = new TipoDocumentosIdentidadDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public TipoDocumentosIdentidad Consultar()
		{
			return objTipoDocumentosIdentidad.ConsultarTipoDocumentosIdentidad();
		}
       [HttpPost]
       [Route("Buscar")]
		public TipoDocumentosIdentidad Buscar([FromBody] TipoDocumentosIdentidad.Data data)
		{
			return objTipoDocumentosIdentidad.BuscarTipoDocumentosIdentidad(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public TipoDocumentosIdentidad.State Insertar([FromBody] TipoDocumentosIdentidad.Data data)
		{
			return objTipoDocumentosIdentidad.InsertarTipoDocumentosIdentidad(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public TipoDocumentosIdentidad.State Actualizar([FromBody] TipoDocumentosIdentidad.Data data)
		{
			return objTipoDocumentosIdentidad.ActualizarTipoDocumentosIdentidad(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public TipoDocumentosIdentidad.State Eliminar([FromBody] TipoDocumentosIdentidad.Data data)
		{
			return objTipoDocumentosIdentidad.EliminarTipoDocumentosIdentidad(data);
		}
	}
}
