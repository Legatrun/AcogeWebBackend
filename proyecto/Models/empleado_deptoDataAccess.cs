using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class empleado_deptoDataAccess
	{
		empleado_depto.State _state = new empleado_depto.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public empleado_depto Consultarempleado_depto()
		{
		    _log.Traceo("Ingresa a Metodo Consultar empleado_depto", "0");
			List<empleado_depto.Data> lstempleado_depto = new List<empleado_depto.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_empleado_depto_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					empleado_depto.Data _empleado_depto= new empleado_depto.Data();
					_empleado_depto.empleado = Convert.ToInt32(rdr["empleado"].ToString());
					_empleado_depto.departamento = Convert.ToInt32(rdr["departamento"].ToString());
					_empleado_depto.cargo = Convert.ToString(rdr["cargo"].ToString());
					_empleado_depto.haber_basico = Convert.ToDouble(rdr["haber_basico"].ToString());
					_empleado_depto.quincena = !rdr.IsDBNull(4) ?  Convert.ToDouble(rdr["quincena"].ToString()) : (System.Double)0;
					_empleado_depto.fecha_ingreso = Convert.ToDateTime(rdr["fecha_ingreso"].ToString());
					_empleado_depto.fecha_quinquenio = Convert.ToDateTime(rdr["fecha_quinquenio"].ToString());
					_empleado_depto.correlativo = Convert.ToInt32(rdr["correlativo"].ToString());
					_empleado_depto.tipoempleado = Convert.ToInt32(rdr["tipoempleado"].ToString());
					_empleado_depto.planilla = Convert.ToInt32(rdr["planilla"].ToString());
					_empleado_depto.jerarquia = Convert.ToInt32(rdr["jerarquia"].ToString());
					_empleado_depto.cuenta = !rdr.IsDBNull(11) ?  Convert.ToString(rdr["cuenta"].ToString()).Trim() : "";
					_empleado_depto.oficina = Convert.ToString(rdr["oficina"].ToString()).Trim();
					_empleado_depto.estado = Convert.ToBoolean(rdr["estado"].ToString());
					_empleado_depto.saldo_anterior_iva = !rdr.IsDBNull(14) ?  Convert.ToDouble(rdr["saldo_anterior_iva"].ToString()) : (System.Double)0;
					_empleado_depto.envio_email = Convert.ToBoolean(rdr["envio_email"].ToString());
					lstempleado_depto.Add(_empleado_depto);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar empleado_depto", _state.error.ToString());
				return new empleado_depto(_state, lstempleado_depto);
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
			return new empleado_depto(_state);
		}
		public empleado_depto Buscarempleado_depto(empleado_depto.Data _empleado_deptoData)
		{
			List<empleado_depto.Data> lstempleado_depto = new List<empleado_depto.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar empleado_depto", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_empleado_depto_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _empleado_deptoData.empleado);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					empleado_depto.Data _empleado_depto= new empleado_depto.Data();
					_empleado_depto.empleado = Convert.ToInt32(rdr["empleado"].ToString());
					_empleado_depto.departamento = Convert.ToInt32(rdr["departamento"].ToString());
					_empleado_depto.cargo = Convert.ToString(rdr["cargo"].ToString());
					_empleado_depto.haber_basico = Convert.ToDouble(rdr["haber_basico"].ToString());
					_empleado_depto.quincena = !rdr.IsDBNull(4) ? Convert.ToDouble(rdr["quincena"].ToString()) : (System.Double)0;
					_empleado_depto.fecha_ingreso = Convert.ToDateTime(rdr["fecha_ingreso"].ToString());
					_empleado_depto.fecha_quinquenio = Convert.ToDateTime(rdr["fecha_quinquenio"].ToString());
					_empleado_depto.correlativo = Convert.ToInt32(rdr["correlativo"].ToString());
					_empleado_depto.tipoempleado = Convert.ToInt32(rdr["tipoempleado"].ToString());
					_empleado_depto.planilla = Convert.ToInt32(rdr["planilla"].ToString());
					_empleado_depto.jerarquia = Convert.ToInt32(rdr["jerarquia"].ToString());
					_empleado_depto.cuenta = !rdr.IsDBNull(11) ? Convert.ToString(rdr["cuenta"].ToString()) : "";
					_empleado_depto.oficina = Convert.ToString(rdr["oficina"].ToString());
					_empleado_depto.estado = Convert.ToBoolean(rdr["estado"].ToString());
					_empleado_depto.saldo_anterior_iva = !rdr.IsDBNull(14) ? Convert.ToDouble(rdr["saldo_anterior_iva"].ToString()) : (System.Double)0;
					_empleado_depto.envio_email = Convert.ToBoolean(rdr["envio_email"].ToString());
					lstempleado_depto.Add(_empleado_depto);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar empleado_depto", _state.error.ToString());
				return new empleado_depto(_state, lstempleado_depto);
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
			return new empleado_depto(_state);
		}
		public empleado_depto.State Insertarempleado_depto(empleado_depto.Data _empleado_depto)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar empleado_depto", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_empleado_depto_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _empleado_depto.empleado);
				SqlCmd.Parameters.AddWithValue("@departamento", _empleado_depto.departamento);
				SqlCmd.Parameters.AddWithValue("@cargo", _empleado_depto.cargo);
				SqlCmd.Parameters.AddWithValue("@haber_basico", _empleado_depto.haber_basico);
				SqlCmd.Parameters.AddWithValue("@quincena", _empleado_depto.quincena);
				SqlCmd.Parameters.AddWithValue("@fecha_ingreso", _empleado_depto.fecha_ingreso);
				SqlCmd.Parameters.AddWithValue("@fecha_quinquenio", _empleado_depto.fecha_quinquenio);
				SqlCmd.Parameters.AddWithValue("@correlativo", _empleado_depto.correlativo);
				SqlCmd.Parameters.AddWithValue("@tipoempleado", _empleado_depto.tipoempleado);
				SqlCmd.Parameters.AddWithValue("@planilla", _empleado_depto.planilla);
				SqlCmd.Parameters.AddWithValue("@jerarquia", _empleado_depto.jerarquia);
				SqlCmd.Parameters.AddWithValue("@cuenta", _empleado_depto.cuenta);
				SqlCmd.Parameters.AddWithValue("@oficina", _empleado_depto.oficina);
				SqlCmd.Parameters.AddWithValue("@estado", _empleado_depto.estado);
				SqlCmd.Parameters.AddWithValue("@saldo_anterior_iva", _empleado_depto.saldo_anterior_iva);
				SqlCmd.Parameters.AddWithValue("@envio_email", _empleado_depto.envio_email);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar empleado_depto", _state.error.ToString());
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
		public empleado_depto.State Actualizarempleado_depto(empleado_depto.Data _empleado_depto)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar empleado_depto", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_empleado_depto_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _empleado_depto.empleado);
				SqlCmd.Parameters.AddWithValue("@departamento", _empleado_depto.departamento);
				SqlCmd.Parameters.AddWithValue("@cargo", _empleado_depto.cargo);
				SqlCmd.Parameters.AddWithValue("@haber_basico", _empleado_depto.haber_basico);
				SqlCmd.Parameters.AddWithValue("@quincena", _empleado_depto.quincena);
				SqlCmd.Parameters.AddWithValue("@fecha_ingreso", _empleado_depto.fecha_ingreso);
				SqlCmd.Parameters.AddWithValue("@fecha_quinquenio", _empleado_depto.fecha_quinquenio);
				SqlCmd.Parameters.AddWithValue("@correlativo", _empleado_depto.correlativo);
				SqlCmd.Parameters.AddWithValue("@tipoempleado", _empleado_depto.tipoempleado);
				SqlCmd.Parameters.AddWithValue("@planilla", _empleado_depto.planilla);
				SqlCmd.Parameters.AddWithValue("@jerarquia", _empleado_depto.jerarquia);
				SqlCmd.Parameters.AddWithValue("@cuenta", _empleado_depto.cuenta);
				SqlCmd.Parameters.AddWithValue("@oficina", _empleado_depto.oficina);
				SqlCmd.Parameters.AddWithValue("@estado", _empleado_depto.estado);
				SqlCmd.Parameters.AddWithValue("@saldo_anterior_iva", _empleado_depto.saldo_anterior_iva);
				SqlCmd.Parameters.AddWithValue("@envio_email", _empleado_depto.envio_email);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar empleado_depto", _state.error.ToString());
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
		public empleado_depto.State Eliminarempleado_depto(empleado_depto.Data _empleado_depto)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar empleado_depto", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_empleado_depto_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _empleado_depto.empleado);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar empleado_depto", _state.error.ToString());
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
