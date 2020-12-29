using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class CuentasBancos
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public CuentasBancos(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public CuentasBancos(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int16 idbanco{ get; set; }
			public System.String nrocuenta{ get; set; }
			public System.Int16 idmoneda{ get; set; }
			public System.Double saldoactual{ get; set; }
			public System.String cuentacontable{ get; set; }
			public System.DateTime fechaapertura{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
