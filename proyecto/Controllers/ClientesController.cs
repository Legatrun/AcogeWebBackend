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
	[RoutePrefix("api/Clientes")]
	public class ClientesController: ApiController
	{
		ClientesDataAccess objClientes = new ClientesDataAccess();

       [HttpPost]
       [Route("Consultar")]
		public Clientes Consultar()
		{
			return objClientes.ConsultarClientes();
		}
       [HttpPost]
       [Route("Buscar")]
		public Clientes Buscar([FromBody] Clientes.Data data)
		{
			return objClientes.BuscarClientes(data);
		}

       [HttpPost]
       [Route("Insertar")]
		public Clientes.State Insertar([FromBody] Clientes.Data data)
		{
			return objClientes.InsertarClientes(data);
		}

       [HttpPut]
       [Route("Actualizar")]
		public Clientes.State Actualizar([FromBody] Clientes.Data data)
		{
			return objClientes.ActualizarClientes(data);
		}

       [HttpDelete]
       [Route("Eliminar")]
		public Clientes.State Eliminar([FromBody] Clientes.Data data)
		{
			return objClientes.EliminarClientes(data);
		}
	}
}
