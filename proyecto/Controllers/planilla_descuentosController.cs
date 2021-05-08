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
	[RoutePrefix("api/planilla_descuentos")]
	public class planilla_descuentosController: ApiController
	{
		planilla_descuentosDataAccess objplanilla_descuentos = new planilla_descuentosDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public planilla_descuentos Consultar()
		{
			return objplanilla_descuentos.Consultarplanilla_descuentos();
		}
       [HttpPost]
       [Route("Buscar")]
		public planilla_descuentos Buscar([FromBody] planilla_descuentos.Data data)
		{
			return objplanilla_descuentos.Buscarplanilla_descuentos(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public planilla_descuentos.State Insertar([FromBody] planilla_descuentos.Data data)
		{
			return objplanilla_descuentos.Insertarplanilla_descuentos(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public planilla_descuentos.State Actualizar([FromBody] planilla_descuentos.Data data)
		{
			return objplanilla_descuentos.Actualizarplanilla_descuentos(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public planilla_descuentos.State Eliminar([FromBody] planilla_descuentos.Data data)
		{
			return objplanilla_descuentos.Eliminarplanilla_descuentos(data);
		}
	}
}
