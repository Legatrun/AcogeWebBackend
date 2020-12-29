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
	[RoutePrefix("api/Monedas")]
	public class MonedasController: ApiController
	{
		MonedasDataAccess objMonedas = new MonedasDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Monedas Consultar()
		{
			return objMonedas.ConsultarMonedas();
		}
       [HttpPost]
       [Route("Buscar")]
		public Monedas Buscar([FromBody] Monedas.Data data)
		{
			return objMonedas.BuscarMonedas(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Monedas.State Insertar([FromBody] Monedas.Data data)
		{
			return objMonedas.InsertarMonedas(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Monedas.State Actualizar([FromBody] Monedas.Data data)
		{
			return objMonedas.ActualizarMonedas(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Monedas.State Eliminar([FromBody] Monedas.Data data)
		{
			return objMonedas.EliminarMonedas(data);
		}
	}
}
