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
	[RoutePrefix("api/Proveedores")]
	public class ProveedoresController: ApiController
	{
		ProveedoresDataAccess objProveedores = new ProveedoresDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Proveedores Consultar()
		{
			return objProveedores.ConsultarProveedores();
		}
       [HttpPost]
       [Route("Buscar")]
		public Proveedores Buscar([FromBody] Proveedores.Data data)
		{
			return objProveedores.BuscarProveedores(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Proveedores.State Insertar([FromBody] Proveedores.Data data)
		{
			return objProveedores.InsertarProveedores(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Proveedores.State Actualizar([FromBody] Proveedores.Data data)
		{
			return objProveedores.ActualizarProveedores(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Proveedores.State Eliminar([FromBody] Proveedores.Data data)
		{
			return objProveedores.EliminarProveedores(data);
		}
	}
}
