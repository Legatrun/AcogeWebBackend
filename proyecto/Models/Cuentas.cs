using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Cuentas
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Cuentas(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Cuentas(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String cuenta{ get; set; }
			public System.String nombrecuenta{ get; set; }
			public System.Int16 idmoneda{ get; set; }
			public System.Int16 nivel{ get; set; }
			public System.Boolean cuentaasiento{ get; set; }
			public System.String cuentasumar{ get; set; }
			public System.Int32 activopasivo{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
