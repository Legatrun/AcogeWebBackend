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
	[RoutePrefix("api/Sucursales")]
	public class SucursalesController: ApiController
	{
		SucursalesDataAccess objSucursales = new SucursalesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Sucursales Consultar()
		{
			return objSucursales.ConsultarSucursales();
		}
       [HttpPost]
       [Route("Buscar")]
		public Sucursales Buscar([FromBody] Sucursales.Data data)
		{
			return objSucursales.BuscarSucursales(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Sucursales.State Insertar([FromBody] Sucursales.Data data)
		{
			return objSucursales.InsertarSucursales(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Sucursales.State Actualizar([FromBody] Sucursales.Data data)
		{
			return objSucursales.ActualizarSucursales(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Sucursales.State Eliminar([FromBody] Sucursales.Data data)
		{
			return objSucursales.EliminarSucursales(data);
		}
	}
}
