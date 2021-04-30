using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class tipo_empleado
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public tipo_empleado(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public tipo_empleado(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 tipo_empleado{ get; set; }
			public System.String nombre{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
