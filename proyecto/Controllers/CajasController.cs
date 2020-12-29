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
	[RoutePrefix("api/Cajas")]
	public class CajasController: ApiController
	{
		CajasDataAccess objCajas = new CajasDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Cajas Consultar()
		{
			return objCajas.ConsultarCajas();
		}
       [HttpPost]
       [Route("Buscar")]
		public Cajas Buscar([FromBody] Cajas.Data data)
		{
			return objCajas.BuscarCajas(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Cajas.State Insertar([FromBody] Cajas.Data data)
		{
			return objCajas.InsertarCajas(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Cajas.State Actualizar([FromBody] Cajas.Data data)
		{
			return objCajas.ActualizarCajas(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Cajas.State Eliminar([FromBody] Cajas.Data data)
		{
			return objCajas.EliminarCajas(data);
		}
	}
}
