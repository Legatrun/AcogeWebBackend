using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Items
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Items(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Items(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String codigoitem{ get; set; }
			public System.String modelonroparte{ get; set; }
			public System.String descripcion{ get; set; }
			public System.DateTime fechacreacion{ get; set; }
			public System.DateTime fechaultimomovimiento{ get; set; }
			public System.Double costoinicial{ get; set; }
			public System.Double costoactual{ get; set; }
			public System.Int32 saldoinicial{ get; set; }
			public System.Int32 saldoactual{ get; set; }
			public System.Int16 idclase{ get; set; }
			public System.Int16 idtipoitem{ get; set; }
			public System.Int16 idunidadmanejo{ get; set; }
			public System.String codigoitemsup{ get; set; }
			public System.Int32 cantidadminima{ get; set; }
			public System.Int32 cantidadmaxima{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
