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
	[RoutePrefix("api/Bancos")]
	public class BancosController: ApiController
	{
		BancosDataAccess objBancos = new BancosDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Bancos Consultar()
		{
			return objBancos.ConsultarBancos();
		}
       [HttpPost]
       [Route("Buscar")]
		public Bancos Buscar([FromBody] Bancos.Data data)
		{
			return objBancos.BuscarBancos(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Bancos.State Insertar([FromBody] Bancos.Data data)
		{
			return objBancos.InsertarBancos(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Bancos.State Actualizar([FromBody] Bancos.Data data)
		{
			return objBancos.ActualizarBancos(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Bancos.State Eliminar([FromBody] Bancos.Data data)
		{
			return objBancos.EliminarBancos(data);
		}
	}
}
