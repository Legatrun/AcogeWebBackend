using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class TiposComprobantes
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public TiposComprobantes(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public TiposComprobantes(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 idtipocomprobante{ get; set; }
			public System.String descripcion{ get; set; }
			public System.String sigla{ get; set; }
			public System.Boolean automatico{ get; set; }
			public System.Int16 idsucursal{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
