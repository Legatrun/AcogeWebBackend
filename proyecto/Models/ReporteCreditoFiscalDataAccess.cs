using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class ReporteCreditoFiscalDataAccess
	{
		ReporteCreditoFiscal.State _state = new ReporteCreditoFiscal.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public ReporteCreditoFiscal ConsultarReporteCreditoFiscal()
		{
		    _log.Traceo("Ingresa a Metodo Consultar ReporteCreditoFiscal", "0");
			List<ReporteCreditoFiscal.Data> lstReporteCreditoFiscal = new List<ReporteCreditoFiscal.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ReporteCreditoFiscal_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					ReporteCreditoFiscal.Data _ReporteCreditoFiscal= new ReporteCreditoFiscal.Data();
					_ReporteCreditoFiscal.mes = !rdr.IsDBNull(0) ?  Convert.ToInt32(rdr["mes"].ToString()) : (System.Int32)0;
					_ReporteCreditoFiscal.año = !rdr.IsDBNull(1) ?  Convert.ToInt32(rdr["año"].ToString()) : (System.Int32)0;
					_ReporteCreditoFiscal.empleado = !rdr.IsDBNull(2) ?  Convert.ToInt32(rdr["empleado"].ToString()) : (System.Int32)0;
					_ReporteCreditoFiscal.cempleado = !rdr.IsDBNull(3) ?  Convert.ToString(rdr["cempleado"].ToString()) : "";
					_ReporteCreditoFiscal.basico = !rdr.IsDBNull(4) ?  Convert.ToInt64(rdr["basico"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.antiguedad = !rdr.IsDBNull(5) ?  Convert.ToInt64(rdr["antiguedad"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.totalganado = !rdr.IsDBNull(6) ?  Convert.ToInt64(rdr["totalganado"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.descuentosdeley = !rdr.IsDBNull(7) ?  Convert.ToInt64(rdr["descuentosdeley"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.totalsueldo = !rdr.IsDBNull(8) ?  Convert.ToInt64(rdr["totalsueldo"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.otrosingresos = !rdr.IsDBNull(9) ?  Convert.ToInt64(rdr["otrosingresos"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.sueldoneto = !rdr.IsDBNull(10) ?  Convert.ToInt64(rdr["sueldoneto"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.minimonoimp = !rdr.IsDBNull(11) ?  Convert.ToInt64(rdr["minimonoimp"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.difsujetaimp = !rdr.IsDBNull(12) ?  Convert.ToInt64(rdr["difsujetaimp"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal._13porciva = !rdr.IsDBNull(13) ?  Convert.ToInt64(rdr["_13porciva"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.form87decl = !rdr.IsDBNull(14) ?  Convert.ToInt64(rdr["form87decl"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal._13s_2min = !rdr.IsDBNull(15) ?  Convert.ToInt64(rdr["_13s_2min"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.saldoa_f_fisco = !rdr.IsDBNull(16) ?  Convert.ToInt64(rdr["saldoa_f_fisco"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.saldoa_f_depent = !rdr.IsDBNull(17) ?  Convert.ToInt64(rdr["saldoa_f_depent"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.saldoanterior = !rdr.IsDBNull(18) ?  Convert.ToInt64(rdr["saldoanterior"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.actualizacion = Convert.ToInt64(rdr["actualizacion"].ToString());
					_ReporteCreditoFiscal.saldototal = !rdr.IsDBNull(20) ?  Convert.ToInt64(rdr["saldototal"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.saldototaldep = !rdr.IsDBNull(21) ?  Convert.ToInt64(rdr["saldototaldep"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.saldoutilizado = !rdr.IsDBNull(22) ?  Convert.ToInt64(rdr["saldoutilizado"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.impuestoretenido = !rdr.IsDBNull(23) ?  Convert.ToInt64(rdr["impuestoretenido"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.saldosigmes = !rdr.IsDBNull(24) ?  Convert.ToInt64(rdr["saldosigmes"].ToString()) : (System.Int64)0;
					lstReporteCreditoFiscal.Add(_ReporteCreditoFiscal);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar ReporteCreditoFiscal", _state.error.ToString());
				return new ReporteCreditoFiscal(_state, lstReporteCreditoFiscal);
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Consulta de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new ReporteCreditoFiscal(_state);
		}
		public ReporteCreditoFiscal BuscarReporteCreditoFiscal(ReporteCreditoFiscal.Data _ReporteCreditoFiscalData)
		{
			List<ReporteCreditoFiscal.Data> lstReporteCreditoFiscal = new List<ReporteCreditoFiscal.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar ReporteCreditoFiscal", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ReporteCreditoFiscal_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					ReporteCreditoFiscal.Data _ReporteCreditoFiscal= new ReporteCreditoFiscal.Data();
					_ReporteCreditoFiscal.mes = !rdr.IsDBNull(0) ? Convert.ToInt32(rdr["mes"].ToString()) : (System.Int32)0;
					_ReporteCreditoFiscal.año = !rdr.IsDBNull(1) ? Convert.ToInt32(rdr["año"].ToString()) : (System.Int32)0;
					_ReporteCreditoFiscal.empleado = !rdr.IsDBNull(2) ? Convert.ToInt32(rdr["empleado"].ToString()) : (System.Int32)0;
					_ReporteCreditoFiscal.cempleado = !rdr.IsDBNull(3) ? Convert.ToString(rdr["cempleado"].ToString()) : "";
					_ReporteCreditoFiscal.basico = !rdr.IsDBNull(4) ? Convert.ToInt64(rdr["basico"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.antiguedad = !rdr.IsDBNull(5) ? Convert.ToInt64(rdr["antiguedad"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.totalganado = !rdr.IsDBNull(6) ? Convert.ToInt64(rdr["totalganado"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.descuentosdeley = !rdr.IsDBNull(7) ? Convert.ToInt64(rdr["descuentosdeley"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.totalsueldo = !rdr.IsDBNull(8) ? Convert.ToInt64(rdr["totalsueldo"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.otrosingresos = !rdr.IsDBNull(9) ? Convert.ToInt64(rdr["otrosingresos"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.sueldoneto = !rdr.IsDBNull(10) ? Convert.ToInt64(rdr["sueldoneto"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.minimonoimp = !rdr.IsDBNull(11) ? Convert.ToInt64(rdr["minimonoimp"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.difsujetaimp = !rdr.IsDBNull(12) ? Convert.ToInt64(rdr["difsujetaimp"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal._13porciva = !rdr.IsDBNull(13) ? Convert.ToInt64(rdr["_13porciva"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.form87decl = !rdr.IsDBNull(14) ? Convert.ToInt64(rdr["form87decl"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal._13s_2min = !rdr.IsDBNull(15) ? Convert.ToInt64(rdr["_13s_2min"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.saldoa_f_fisco = !rdr.IsDBNull(16) ? Convert.ToInt64(rdr["saldoa_f_fisco"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.saldoa_f_depent = !rdr.IsDBNull(17) ? Convert.ToInt64(rdr["saldoa_f_depent"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.saldoanterior = !rdr.IsDBNull(18) ? Convert.ToInt64(rdr["saldoanterior"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.actualizacion = Convert.ToInt64(rdr["actualizacion"].ToString());
					_ReporteCreditoFiscal.saldototal = !rdr.IsDBNull(20) ? Convert.ToInt64(rdr["saldototal"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.saldototaldep = !rdr.IsDBNull(21) ? Convert.ToInt64(rdr["saldototaldep"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.saldoutilizado = !rdr.IsDBNull(22) ? Convert.ToInt64(rdr["saldoutilizado"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.impuestoretenido = !rdr.IsDBNull(23) ? Convert.ToInt64(rdr["impuestoretenido"].ToString()) : (System.Int64)0;
					_ReporteCreditoFiscal.saldosigmes = !rdr.IsDBNull(24) ? Convert.ToInt64(rdr["saldosigmes"].ToString()) : (System.Int64)0;
					lstReporteCreditoFiscal.Add(_ReporteCreditoFiscal);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar ReporteCreditoFiscal", _state.error.ToString());
				return new ReporteCreditoFiscal(_state, lstReporteCreditoFiscal);
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Consulta de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return new ReporteCreditoFiscal(_state);
		}
		public ReporteCreditoFiscal.State InsertarReporteCreditoFiscal(ReporteCreditoFiscal.Data _ReporteCreditoFiscal)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar ReporteCreditoFiscal", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ReporteCreditoFiscal_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@mes", _ReporteCreditoFiscal.mes);
				SqlCmd.Parameters.AddWithValue("@año", _ReporteCreditoFiscal.año);
				SqlCmd.Parameters.AddWithValue("@empleado", _ReporteCreditoFiscal.empleado);
				SqlCmd.Parameters.AddWithValue("@cempleado", _ReporteCreditoFiscal.cempleado);
				SqlCmd.Parameters.AddWithValue("@basico", _ReporteCreditoFiscal.basico);
				SqlCmd.Parameters.AddWithValue("@antiguedad", _ReporteCreditoFiscal.antiguedad);
				SqlCmd.Parameters.AddWithValue("@totalganado", _ReporteCreditoFiscal.totalganado);
				SqlCmd.Parameters.AddWithValue("@descuentosdeley", _ReporteCreditoFiscal.descuentosdeley);
				SqlCmd.Parameters.AddWithValue("@totalsueldo", _ReporteCreditoFiscal.totalsueldo);
				SqlCmd.Parameters.AddWithValue("@otrosingresos", _ReporteCreditoFiscal.otrosingresos);
				SqlCmd.Parameters.AddWithValue("@sueldoneto", _ReporteCreditoFiscal.sueldoneto);
				SqlCmd.Parameters.AddWithValue("@minimonoimp", _ReporteCreditoFiscal.minimonoimp);
				SqlCmd.Parameters.AddWithValue("@difsujetaimp", _ReporteCreditoFiscal.difsujetaimp);
				SqlCmd.Parameters.AddWithValue("@_13porciva", _ReporteCreditoFiscal._13porciva);
				SqlCmd.Parameters.AddWithValue("@form87decl", _ReporteCreditoFiscal.form87decl);
				SqlCmd.Parameters.AddWithValue("@_13s_2min", _ReporteCreditoFiscal._13s_2min);
				SqlCmd.Parameters.AddWithValue("@saldoa_f_fisco", _ReporteCreditoFiscal.saldoa_f_fisco);
				SqlCmd.Parameters.AddWithValue("@saldoa_f_depent", _ReporteCreditoFiscal.saldoa_f_depent);
				SqlCmd.Parameters.AddWithValue("@saldoanterior", _ReporteCreditoFiscal.saldoanterior);
				SqlCmd.Parameters.AddWithValue("@actualizacion", _ReporteCreditoFiscal.actualizacion);
				SqlCmd.Parameters.AddWithValue("@saldototal", _ReporteCreditoFiscal.saldototal);
				SqlCmd.Parameters.AddWithValue("@saldototaldep", _ReporteCreditoFiscal.saldototaldep);
				SqlCmd.Parameters.AddWithValue("@saldoutilizado", _ReporteCreditoFiscal.saldoutilizado);
				SqlCmd.Parameters.AddWithValue("@impuestoretenido", _ReporteCreditoFiscal.impuestoretenido);
				SqlCmd.Parameters.AddWithValue("@saldosigmes", _ReporteCreditoFiscal.saldosigmes);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar ReporteCreditoFiscal", _state.error.ToString());
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Insertar de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return _state;
		}
		public ReporteCreditoFiscal.State ActualizarReporteCreditoFiscal(ReporteCreditoFiscal.Data _ReporteCreditoFiscal)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar ReporteCreditoFiscal", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ReporteCreditoFiscal_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@mes", _ReporteCreditoFiscal.mes);
				SqlCmd.Parameters.AddWithValue("@año", _ReporteCreditoFiscal.año);
				SqlCmd.Parameters.AddWithValue("@empleado", _ReporteCreditoFiscal.empleado);
				SqlCmd.Parameters.AddWithValue("@cempleado", _ReporteCreditoFiscal.cempleado);
				SqlCmd.Parameters.AddWithValue("@basico", _ReporteCreditoFiscal.basico);
				SqlCmd.Parameters.AddWithValue("@antiguedad", _ReporteCreditoFiscal.antiguedad);
				SqlCmd.Parameters.AddWithValue("@totalganado", _ReporteCreditoFiscal.totalganado);
				SqlCmd.Parameters.AddWithValue("@descuentosdeley", _ReporteCreditoFiscal.descuentosdeley);
				SqlCmd.Parameters.AddWithValue("@totalsueldo", _ReporteCreditoFiscal.totalsueldo);
				SqlCmd.Parameters.AddWithValue("@otrosingresos", _ReporteCreditoFiscal.otrosingresos);
				SqlCmd.Parameters.AddWithValue("@sueldoneto", _ReporteCreditoFiscal.sueldoneto);
				SqlCmd.Parameters.AddWithValue("@minimonoimp", _ReporteCreditoFiscal.minimonoimp);
				SqlCmd.Parameters.AddWithValue("@difsujetaimp", _ReporteCreditoFiscal.difsujetaimp);
				SqlCmd.Parameters.AddWithValue("@_13porciva", _ReporteCreditoFiscal._13porciva);
				SqlCmd.Parameters.AddWithValue("@form87decl", _ReporteCreditoFiscal.form87decl);
				SqlCmd.Parameters.AddWithValue("@_13s_2min", _ReporteCreditoFiscal._13s_2min);
				SqlCmd.Parameters.AddWithValue("@saldoa_f_fisco", _ReporteCreditoFiscal.saldoa_f_fisco);
				SqlCmd.Parameters.AddWithValue("@saldoa_f_depent", _ReporteCreditoFiscal.saldoa_f_depent);
				SqlCmd.Parameters.AddWithValue("@saldoanterior", _ReporteCreditoFiscal.saldoanterior);
				SqlCmd.Parameters.AddWithValue("@actualizacion", _ReporteCreditoFiscal.actualizacion);
				SqlCmd.Parameters.AddWithValue("@saldototal", _ReporteCreditoFiscal.saldototal);
				SqlCmd.Parameters.AddWithValue("@saldototaldep", _ReporteCreditoFiscal.saldototaldep);
				SqlCmd.Parameters.AddWithValue("@saldoutilizado", _ReporteCreditoFiscal.saldoutilizado);
				SqlCmd.Parameters.AddWithValue("@impuestoretenido", _ReporteCreditoFiscal.impuestoretenido);
				SqlCmd.Parameters.AddWithValue("@saldosigmes", _ReporteCreditoFiscal.saldosigmes);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar ReporteCreditoFiscal", _state.error.ToString());
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Actualizar de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return _state;
		}
		public ReporteCreditoFiscal.State EliminarReporteCreditoFiscal(ReporteCreditoFiscal.Data _ReporteCreditoFiscal)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar ReporteCreditoFiscal", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ReporteCreditoFiscal_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar ReporteCreditoFiscal", _state.error.ToString());
			}
			catch (SqlException XcpSQL)
			{
				foreach (SqlError se in XcpSQL.Errors)
				{
					if (se.Number <= 50000)
					{
						_state.error = -1;
						_state.descripcion = se.Message;
						_log.Error(_state.descripcion, _state.error.ToString());
					}
					else
					{
						_state.error = -2;
						_state.descripcion = "Error en Operacion de Eliminar de Datos";
						_log.Error(_state.descripcion, _state.error.ToString());
					}
				}
			}
			catch (Exception Ex)
			{
				_state.error = -3;
				_state.descripcion = Ex.Message;
				_log.Error(_state.descripcion, _state.error.ToString());
			}
			return _state;
		}
	}
}
