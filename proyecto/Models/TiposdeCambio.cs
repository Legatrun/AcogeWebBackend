using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class TiposdeCambio
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public TiposdeCambio(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public TiposdeCambio(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.DateTime fecha{ get; set; }
			public System.Int16 idmonedaorigen{ get; set; }
			public System.Int16 idmonedadestino{ get; set; }
			public System.Double cotizacionoficial{ get; set; }
			public System.Double cotizacioncompra{ get; set; }
			public System.Double cotizacionventa{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
