using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class CreditoFiscal
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public CreditoFiscal(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public CreditoFiscal(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 empleado{ get; set; }
			public System.Int16 mes{ get; set; }
			public System.Int16 año{ get; set; }
			public System.Double declarado{ get; set; }
			public System.Double actualizacion{ get; set; }
			public System.Double saldo{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
