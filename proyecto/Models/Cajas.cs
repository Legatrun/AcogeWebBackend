using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Cajas
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Cajas(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Cajas(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int16 idcaja{ get; set; }
			public System.String descripcion{ get; set; }
			public System.String cuenta{ get; set; }
			public System.Double monto{ get; set; }
			public System.Int16 idmoneda{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
