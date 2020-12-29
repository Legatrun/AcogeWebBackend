using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Sucursales
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Sucursales(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Sucursales(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int16 idsucursal{ get; set; }
			public System.Int16 idempresa{ get; set; }
			public System.Int16 idzona{ get; set; }
			public System.String nombre{ get; set; }
			public System.String direccion{ get; set; }
			public System.Int32 numero{ get; set; }
			public System.String telefonos{ get; set; }
			public System.String email{ get; set; }
			public System.String codigopostal{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
