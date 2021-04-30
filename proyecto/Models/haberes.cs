using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class haberes
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public haberes(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public haberes(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 haber{ get; set; }
			public System.String nombre{ get; set; }
			public System.Boolean calculo{ get; set; }
			public System.Boolean retencion{ get; set; }
			public System.Boolean tipo{ get; set; }
			public System.Double valor{ get; set; }
			public System.Int32 tipo_haber{ get; set; }
			public System.Boolean basico{ get; set; }
			public System.Boolean extra{ get; set; }
			public System.Int16 eventual{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
