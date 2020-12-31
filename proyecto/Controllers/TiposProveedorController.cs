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
	[RoutePrefix("api/TiposProveedor")]
	public class TiposProveedorController: ApiController
	{
		TiposProveedorDataAccess objTiposProveedor = new TiposProveedorDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public TiposProveedor Consultar()
		{
			return objTiposProveedor.ConsultarTiposProveedor();
		}
       [HttpPost]
       [Route("Buscar")]
		public TiposProveedor Buscar([FromBody] TiposProveedor.Data data)
		{
			return objTiposProveedor.BuscarTiposProveedor(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public TiposProveedor.State Insertar([FromBody] TiposProveedor.Data data)
		{
			return objTiposProveedor.InsertarTiposProveedor(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public TiposProveedor.State Actualizar([FromBody] TiposProveedor.Data data)
		{
			return objTiposProveedor.ActualizarTiposProveedor(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public TiposProveedor.State Eliminar([FromBody] TiposProveedor.Data data)
		{
			return objTiposProveedor.EliminarTiposProveedor(data);
		}
	}
}
