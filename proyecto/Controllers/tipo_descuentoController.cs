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
	[RoutePrefix("api/tipo_descuento")]
	public class tipo_descuentoController: ApiController
	{
		tipo_descuentoDataAccess objtipo_descuento = new tipo_descuentoDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public tipo_descuento Consultar()
		{
			return objtipo_descuento.Consultartipo_descuento();
		}
       [HttpPost]
       [Route("Buscar")]
		public tipo_descuento Buscar([FromBody] tipo_descuento.Data data)
		{
			return objtipo_descuento.Buscartipo_descuento(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public tipo_descuento.State Insertar([FromBody] tipo_descuento.Data data)
		{
			return objtipo_descuento.Insertartipo_descuento(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public tipo_descuento.State Actualizar([FromBody] tipo_descuento.Data data)
		{
			return objtipo_descuento.Actualizartipo_descuento(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public tipo_descuento.State Eliminar([FromBody] tipo_descuento.Data data)
		{
			return objtipo_descuento.Eliminartipo_descuento(data);
		}
	}
}
