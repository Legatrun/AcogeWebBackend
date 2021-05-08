using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class ReporteCreditoFiscal
	{
		public List<Data> _data = new List<Data>();
		public State _error = new State();

		public ReporteCreditoFiscal(State error, List<Data> data)
		{
			_error = error;
			_data = data;
		}
		public ReporteCreditoFiscal(State error)
		{
			_error = error;
			_data = null;
		}
		public class Data
		{
			public System.Int32 mes{ get; set; }
			public System.Int32 año{ get; set; }
			public System.Int32 empleado{ get; set; }
			public System.String cempleado{ get; set; }
			public System.Int64 basico{ get; set; }
			public System.Int64 antiguedad{ get; set; }
			public System.Int64 totalganado{ get; set; }
			public System.Int64 descuentosdeley{ get; set; }
			public System.Int64 totalsueldo{ get; set; }
			public System.Int64 otrosingresos{ get; set; }
			public System.Int64 sueldoneto{ get; set; }
			public System.Int64 minimonoimp{ get; set; }
			public System.Int64 difsujetaimp{ get; set; }
			public System.Int64 _13porciva{ get; set; }
			public System.Int64 form87decl{ get; set; }
			public System.Int64 _13s_2min{ get; set; }
			public System.Int64 saldoa_f_fisco{ get; set; }
			public System.Int64 saldoa_f_depent{ get; set; }
			public System.Int64 saldoanterior{ get; set; }
			public System.Int64 actualizacion{ get; set; }
			public System.Int64 saldototal{ get; set; }
			public System.Int64 saldototaldep{ get; set; }
			public System.Int64 saldoutilizado{ get; set; }
			public System.Int64 impuestoretenido{ get; set; }
			public System.Int64 saldosigmes{ get; set; }
		}
		public class State
		{
			public System.Int32 error { get; set; }
			public System.String descripcion { get; set; }
		}
	}
}
