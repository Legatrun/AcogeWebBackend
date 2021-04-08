using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class AsientosEncabezado
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public AsientosEncabezado(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public AsientosEncabezado(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int16 idtipocomprobante{ get; set; }
			public System.String numerocomprobante{ get; set; }
			public System.DateTime fecha{ get; set; }
			public System.String referencia{ get; set; }
			public System.String glosa{ get; set; }
			public System.Double cotizacion{ get; set; }
			public System.String codigomodulo{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
