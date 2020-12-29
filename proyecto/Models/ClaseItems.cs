using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class ClaseItems
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public ClaseItems(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public ClaseItems(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int16 idclase{ get; set; }
			public System.String descripcion{ get; set; }
			public System.String sigla{ get; set; }
			public System.String cuentaventa{ get; set; }
			public System.String cuentacosto{ get; set; }
			public System.String cuentagasto{ get; set; }
			public System.String cuentainventario{ get; set; }
			public System.Boolean ingresainventario{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
