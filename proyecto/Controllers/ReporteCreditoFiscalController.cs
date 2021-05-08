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
	[RoutePrefix("api/ReporteCreditoFiscal")]
	public class ReporteCreditoFiscalController: ApiController
	{
		ReporteCreditoFiscalDataAccess objReporteCreditoFiscal = new ReporteCreditoFiscalDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public ReporteCreditoFiscal Consultar()
		{
			return objReporteCreditoFiscal.ConsultarReporteCreditoFiscal();
		}
       [HttpPost]
       [Route("Buscar")]
		public ReporteCreditoFiscal Buscar([FromBody] ReporteCreditoFiscal.Data data)
		{
			return objReporteCreditoFiscal.BuscarReporteCreditoFiscal(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public ReporteCreditoFiscal.State Insertar([FromBody] ReporteCreditoFiscal.Data data)
		{
			return objReporteCreditoFiscal.InsertarReporteCreditoFiscal(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public ReporteCreditoFiscal.State Actualizar([FromBody] ReporteCreditoFiscal.Data data)
		{
			return objReporteCreditoFiscal.ActualizarReporteCreditoFiscal(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public ReporteCreditoFiscal.State Eliminar([FromBody] ReporteCreditoFiscal.Data data)
		{
			return objReporteCreditoFiscal.EliminarReporteCreditoFiscal(data);
		}
	}
}
