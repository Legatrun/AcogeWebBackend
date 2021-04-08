using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class CorrelativosTiposComprobantes
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public CorrelativosTiposComprobantes(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public CorrelativosTiposComprobantes(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int16 idtipocomprobante{ get; set; }
			public System.Int16 anio{ get; set; }
			public System.Int16 mes{ get; set; }
			public System.Int16 correlativo{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
