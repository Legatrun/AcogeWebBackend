using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class empleado_depto
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public empleado_depto(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public empleado_depto(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 empleado{ get; set; }
			public System.Int32 departamento{ get; set; }
			public System.String cargo{ get; set; }
			public System.Double haber_basico{ get; set; }
			public System.Double quincena{ get; set; }
			public System.DateTime fecha_ingreso{ get; set; }
			public System.DateTime fecha_quinquenio{ get; set; }
			public System.Int32 correlativo{ get; set; }
			public System.Int32 tipoempleado{ get; set; }
			public System.Int32 planilla{ get; set; }
			public System.Int32 jerarquia{ get; set; }
			public System.String cuenta{ get; set; }
			public System.String oficina{ get; set; }
			public System.Boolean estado{ get; set; }
			public System.Double saldo_anterior_iva{ get; set; }
			public System.Boolean envio_email{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
