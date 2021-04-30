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
	[RoutePrefix("api/Firmas")]
	public class FirmasController: ApiController
	{
		FirmasDataAccess objFirmas = new FirmasDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Firmas Consultar()
		{
			return objFirmas.ConsultarFirmas();
		}
       [HttpPost]
       [Route("Buscar")]
		public Firmas Buscar([FromBody] Firmas.Data data)
		{
			return objFirmas.BuscarFirmas(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Firmas.State Insertar([FromBody] Firmas.Data data)
		{
			return objFirmas.InsertarFirmas(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Firmas.State Actualizar([FromBody] Firmas.Data data)
		{
			return objFirmas.ActualizarFirmas(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Firmas.State Eliminar([FromBody] Firmas.Data data)
		{
			return objFirmas.EliminarFirmas(data);
		}
	}
}
