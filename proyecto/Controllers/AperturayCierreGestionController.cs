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
	[RoutePrefix("api/AperturayCierreGestion")]
	public class AperturayCierreGestionController: ApiController
	{
		AperturayCierreGestionDataAccess objAperturayCierreGestion = new AperturayCierreGestionDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public AperturayCierreGestion Consultar()
		{
			return objAperturayCierreGestion.ConsultarAperturayCierreGestion();
		}
       [HttpPost]
       [Route("Buscar")]
		public AperturayCierreGestion Buscar([FromBody] AperturayCierreGestion.Data data)
		{
			return objAperturayCierreGestion.BuscarAperturayCierreGestion(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public AperturayCierreGestion.State Insertar([FromBody] AperturayCierreGestion.Data data)
		{
			return objAperturayCierreGestion.InsertarAperturayCierreGestion(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public AperturayCierreGestion.State Actualizar([FromBody] AperturayCierreGestion.Data data)
		{
			return objAperturayCierreGestion.ActualizarAperturayCierreGestion(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public AperturayCierreGestion.State Eliminar([FromBody] AperturayCierreGestion.Data data)
		{
			return objAperturayCierreGestion.EliminarAperturayCierreGestion(data);
		}
	}
}
