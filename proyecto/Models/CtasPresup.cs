using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class CtasPresup
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public CtasPresup(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public CtasPresup(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String cuentapresup{ get; set; }
			public System.String nombrecuentapresup{ get; set; }
			public System.Int16 idmoneda{ get; set; }
			public System.Int32 nivel{ get; set; }
			public System.DateTime fechacreacion{ get; set; }
			public System.DateTime fechamodificacion{ get; set; }
			public System.Boolean balancecuenta{ get; set; }
			public System.Boolean cuentaasiento{ get; set; }
			public System.Boolean grabado{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
