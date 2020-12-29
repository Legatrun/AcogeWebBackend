using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Clientes
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Clientes(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Clientes(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String codigocliente{ get; set; }
			public System.String codigoclienteprincipal{ get; set; }
			public System.Int16 iddocumentoidentidad{ get; set; }
			public System.String numerodocumento{ get; set; }
			public System.String razonsocial{ get; set; }
			public System.Int16 idpais{ get; set; }
			public System.Int16 idciudad{ get; set; }
			public System.Int16 idzona{ get; set; }
			public System.Int16 idtipocliente{ get; set; }
			public System.String descripciondireccion{ get; set; }
			public System.String telefono{ get; set; }
			public System.String correoelectronico{ get; set; }
			public System.String casillacorreo{ get; set; }
			public System.String cuentacontable{ get; set; }
			public System.String cuentacontableanticipos{ get; set; }
			public System.Boolean activo{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
