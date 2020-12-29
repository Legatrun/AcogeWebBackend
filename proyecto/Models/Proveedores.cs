using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Proveedores
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Proveedores(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Proveedores(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String codigoproveedor{ get; set; }
			public System.Int16 iddocumentoidentidad{ get; set; }
			public System.String numerodocumento{ get; set; }
			public System.String razonsocial{ get; set; }
			public System.String direccion{ get; set; }
			public System.Int16 idpais{ get; set; }
			public System.Int16 idciudad{ get; set; }
			public System.Int16 idmoneda{ get; set; }
			public System.String contacto{ get; set; }
			public System.String telefonos{ get; set; }
			public System.String fax{ get; set; }
			public System.String cuenta{ get; set; }
			public System.Int16 idtipoproveedor{ get; set; }
			public System.DateTime fechacreacion{ get; set; }
			public System.String codaduana{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
