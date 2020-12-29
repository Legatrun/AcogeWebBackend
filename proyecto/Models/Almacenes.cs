using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Almacenes
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Almacenes(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Almacenes(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String codigoalmacen{ get; set; }
			public System.String descripcion{ get; set; }
			public System.Int16 idtipomovimiento{ get; set; }
			public System.Int16 idciudad{ get; set; }
			public System.Boolean Virtual{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
