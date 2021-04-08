using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class AsientosDetalle
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public AsientosDetalle(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public AsientosDetalle(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int16 idtipocomprobante{ get; set; }
			public System.String numerocomprobante{ get; set; }
			public System.Int16 nrolinea{ get; set; }
			public System.String cuenta{ get; set; }
			public System.String glosadetalle{ get; set; }
			public System.String tipomov{ get; set; }
			public System.Double montobs{ get; set; }
			public System.Double montosus{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
