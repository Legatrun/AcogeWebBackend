using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Bancos
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Bancos(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Bancos(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int16 idbanco{ get; set; }
			public System.String nit{ get; set; }
			public System.String descripcion{ get; set; }
			public System.Boolean bancopropio{ get; set; }
			public System.Int32 idpais{ get; set; }
			public System.Int32 idciudad{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
