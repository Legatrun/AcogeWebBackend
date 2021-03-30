using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class TiposCliente
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public TiposCliente(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public TiposCliente(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int16 idtipocliente{ get; set; }
			public System.String descripcion{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
