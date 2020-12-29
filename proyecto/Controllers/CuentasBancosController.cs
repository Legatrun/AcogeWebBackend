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
	[RoutePrefix("api/CuentasBancos")]
	public class CuentasBancosController: ApiController
	{
		CuentasBancosDataAccess objCuentasBancos = new CuentasBancosDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public CuentasBancos Consultar()
		{
			return objCuentasBancos.ConsultarCuentasBancos();
		}
       [HttpPost]
       [Route("Buscar")]
		public CuentasBancos Buscar([FromBody] CuentasBancos.Data data)
		{
			return objCuentasBancos.BuscarCuentasBancos(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public CuentasBancos.State Insertar([FromBody] CuentasBancos.Data data)
		{
			return objCuentasBancos.InsertarCuentasBancos(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public CuentasBancos.State Actualizar([FromBody] CuentasBancos.Data data)
		{
			return objCuentasBancos.ActualizarCuentasBancos(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public CuentasBancos.State Eliminar([FromBody] CuentasBancos.Data data)
		{
			return objCuentasBancos.EliminarCuentasBancos(data);
		}
	}
}
