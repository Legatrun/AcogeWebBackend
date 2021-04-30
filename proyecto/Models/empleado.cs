using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class empleado
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public empleado(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public empleado(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 empleado{ get; set; }
			public System.String paterno{ get; set; }
			public System.String materno{ get; set; }
			public System.String nombres{ get; set; }
			public System.DateTime fecha_nac{ get; set; }
			public System.String identificacion{ get; set; }
			public System.String cod_asegurado{ get; set; }
			public System.String direccion{ get; set; }
			public System.String email{ get; set; }
			public System.String telefono{ get; set; }
			public System.String lugar_nac{ get; set; }
			public System.String nacionalidad{ get; set; }
			public System.Int16 sexo{ get; set; }
			public System.Int16 estado_civil{ get; set; }
			public System.Int16 patmes{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
