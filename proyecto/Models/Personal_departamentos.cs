using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Personal_departamentos
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Personal_departamentos(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Personal_departamentos(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 personal_departamento{ get; set; }
			public System.String nombre{ get; set; }
			public System.Double minimo{ get; set; }
			public System.Double maximo{ get; set; }
			public System.Int32 empresa{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
