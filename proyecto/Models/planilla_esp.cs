using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class planilla_esp
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public planilla_esp(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public planilla_esp(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 planilla_esp{ get; set; }
			public System.String descripcion{ get; set; }
			public System.Int32 haber{ get; set; }
			public System.String tipo{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
