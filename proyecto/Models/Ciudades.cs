using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Ciudades
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Ciudades(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Ciudades(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int16 idciudad{ get; set; }
			public System.Int16 idpais{ get; set; }
			public System.String descripcion{ get; set; }
			public System.String sigla{ get; set; }
			public System.Int16 idmoneda{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
