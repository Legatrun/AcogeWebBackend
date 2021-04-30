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
	[RoutePrefix("api/tipo_haber")]
	public class tipo_haberController: ApiController
	{
		tipo_haberDataAccess objtipo_haber = new tipo_haberDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public tipo_haber Consultar()
		{
			return objtipo_haber.Consultartipo_haber();
		}
       [HttpPost]
       [Route("Buscar")]
		public tipo_haber Buscar([FromBody] tipo_haber.Data data)
		{
			return objtipo_haber.Buscartipo_haber(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public tipo_haber.State Insertar([FromBody] tipo_haber.Data data)
		{
			return objtipo_haber.Insertartipo_haber(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public tipo_haber.State Actualizar([FromBody] tipo_haber.Data data)
		{
			return objtipo_haber.Actualizartipo_haber(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public tipo_haber.State Eliminar([FromBody] tipo_haber.Data data)
		{
			return objtipo_haber.Eliminartipo_haber(data);
		}
	}
}
