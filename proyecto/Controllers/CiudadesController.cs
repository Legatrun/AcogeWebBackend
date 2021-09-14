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
	[RoutePrefix("api/Ciudades")]
	public class CiudadesController: ApiController
	{
		CiudadesDataAccess objCiudades = new CiudadesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Ciudades Consultar()
		{
			return objCiudades.ConsultarCiudades();
		}
		[HttpPost]
		[Route("ConsultarFilter")]
		public Ciudades ConsultarFilter([FromBody] Ciudades.Data data)
		{
			return objCiudades.ConsultarCiudadesFilter(data);
		}
		[HttpPost]
       [Route("Buscar")]
		public Ciudades Buscar([FromBody] Ciudades.Data data)
		{
			return objCiudades.BuscarCiudades(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Ciudades.State Insertar([FromBody] Ciudades.Data data)
		{
			return objCiudades.InsertarCiudades(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Ciudades.State Actualizar([FromBody] Ciudades.Data data)
		{
			return objCiudades.ActualizarCiudades(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Ciudades.State Eliminar([FromBody] Ciudades.Data data)
		{
			return objCiudades.EliminarCiudades(data);
		}
	}
}
