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
	[RoutePrefix("api/AsientosEncabezado")]
	public class AsientosEncabezadoController: ApiController
	{
		AsientosEncabezadoDataAccess objAsientosEncabezado = new AsientosEncabezadoDataAccess();
        
       [HttpPost]
       [Route("Consultar")]
		public AsientosEncabezado Consultar()
		{
			return objAsientosEncabezado.ConsultarAsientosEncabezado();
		}
       [HttpPost]
       [Route("Buscar")]
		public AsientosEncabezado Buscar([FromBody] AsientosEncabezado.Data data)
		{
			return objAsientosEncabezado.BuscarAsientosEncabezado(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public AsientosEncabezado.State Insertar([FromBody] AsientosEncabezado.Data data)
		{
			return objAsientosEncabezado.InsertarAsientosEncabezado(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public AsientosEncabezado.State Actualizar([FromBody] AsientosEncabezado.Data data)
		{
			return objAsientosEncabezado.ActualizarAsientosEncabezado(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public AsientosEncabezado.State Eliminar([FromBody] AsientosEncabezado.Data data)
		{
			return objAsientosEncabezado.EliminarAsientosEncabezado(data);
		}
	}
}
