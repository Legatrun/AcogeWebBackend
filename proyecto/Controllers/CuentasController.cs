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
	[RoutePrefix("api/Cuentas")]
	public class CuentasController: ApiController
	{
		CuentasDataAccess objCuentas = new CuentasDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Cuentas Consultar()
		{
			return objCuentas.ConsultarCuentas();
		}
       [HttpPost]
       [Route("Buscar")]
		public Cuentas Buscar([FromBody] Cuentas.Data data)
		{
			return objCuentas.BuscarCuentas(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Cuentas.State Insertar([FromBody] Cuentas.Data data)
		{
			return objCuentas.InsertarCuentas(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Cuentas.State Actualizar([FromBody] Cuentas.Data data)
		{
			return objCuentas.ActualizarCuentas(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Cuentas.State Eliminar([FromBody] Cuentas.Data data)
		{
			return objCuentas.EliminarCuentas(data);
		}
	}
}
