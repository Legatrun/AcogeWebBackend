using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Firmas
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public Firmas(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public Firmas(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.String firma1{ get; set; }
			public System.String cargo1{ get; set; }
			public System.String firma2{ get; set; }
			public System.String cargo2{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
