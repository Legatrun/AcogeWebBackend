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
	[RoutePrefix("api/Personal_departamentos")]
	public class Personal_departamentosController: ApiController
	{
		Personal_departamentosDataAccess objPersonal_departamentos = new Personal_departamentosDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Personal_departamentos Consultar()
		{
			return objPersonal_departamentos.ConsultarPersonal_departamentos();
		}
       [HttpPost]
       [Route("Buscar")]
		public Personal_departamentos Buscar([FromBody] Personal_departamentos.Data data)
		{
			return objPersonal_departamentos.BuscarPersonal_departamentos(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Personal_departamentos.State Insertar([FromBody] Personal_departamentos.Data data)
		{
			return objPersonal_departamentos.InsertarPersonal_departamentos(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Personal_departamentos.State Actualizar([FromBody] Personal_departamentos.Data data)
		{
			return objPersonal_departamentos.ActualizarPersonal_departamentos(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Personal_departamentos.State Eliminar([FromBody] Personal_departamentos.Data data)
		{
			return objPersonal_departamentos.EliminarPersonal_departamentos(data);
		}
	}
}
