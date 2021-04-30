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
	[RoutePrefix("api/CreditoFiscal")]
	public class CreditoFiscalController: ApiController
	{
		CreditoFiscalDataAccess objCreditoFiscal = new CreditoFiscalDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public CreditoFiscal Consultar()
		{
			return objCreditoFiscal.ConsultarCreditoFiscal();
		}
       [HttpPost]
       [Route("Buscar")]
		public CreditoFiscal Buscar([FromBody] CreditoFiscal.Data data)
		{
			return objCreditoFiscal.BuscarCreditoFiscal(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public CreditoFiscal.State Insertar([FromBody] CreditoFiscal.Data data)
		{
			return objCreditoFiscal.InsertarCreditoFiscal(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public CreditoFiscal.State Actualizar([FromBody] CreditoFiscal.Data data)
		{
			return objCreditoFiscal.ActualizarCreditoFiscal(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public CreditoFiscal.State Eliminar([FromBody] CreditoFiscal.Data data)
		{
			return objCreditoFiscal.EliminarCreditoFiscal(data);
		}
	}
}
