using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class AperturayCierreGestion
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public AperturayCierreGestion(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public AperturayCierreGestion(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String gestion{ get; set; }
			public System.Int16 mes{ get; set; }
			public System.Boolean abierta{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
