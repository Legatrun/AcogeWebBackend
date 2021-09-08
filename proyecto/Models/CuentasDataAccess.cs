using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class CuentasDataAccess
	{
		Cuentas.State _state = new Cuentas.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Cuentas ConsultarCuentas()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Cuentas", "0");
			List<Cuentas.Data> lstCuentas = new List<Cuentas.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cuentas_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Cuentas.Data _Cuentas= new Cuentas.Data();
					_Cuentas.cuenta = Convert.ToString(rdr["cuenta"].ToString().Trim());
					_Cuentas.nombrecuenta = !rdr.IsDBNull(1) ? Convert.ToString(rdr["nombrecuenta"].ToString().Trim()) : "";
					_Cuentas.idmoneda = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					_Cuentas.nivel = !rdr.IsDBNull(3) ? Convert.ToInt16(rdr["nivel"].ToString()) : (System.Int16)0;
					_Cuentas.cuentaasiento = !rdr.IsDBNull(4) ? Convert.ToBoolean(rdr["cuentaasiento"].ToString()) : true;
					_Cuentas.cuentasumar = !rdr.IsDBNull(5) ? Convert.ToString(rdr["cuentasumar"].ToString().Trim()) : "";
					_Cuentas.activopasivo = !rdr.IsDBNull(6) ? Convert.ToInt32(rdr["activopasivo"].ToString()) : (System.Int32)0;
					lstCuentas.Add(_Cuentas);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Cuentas", _state.error.ToString());
				return new Cuentas(_state, lstCuentas);
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
			return new Cuentas(_state);
		}
		public Cuentas BuscarCuentas(Cuentas.Data _CuentasData)
		{
			List<Cuentas.Data> lstCuentas = new List<Cuentas.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Cuentas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cuentas_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@cuenta", _CuentasData.cuenta);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Cuentas.Data _Cuentas= new Cuentas.Data();
					_Cuentas.cuenta = Convert.ToString(rdr["cuenta"].ToString());
					_Cuentas.nombrecuenta = !rdr.IsDBNull(1) ? Convert.ToString(rdr["nombrecuenta"].ToString()) : "";
					_Cuentas.idmoneda = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					_Cuentas.nivel = !rdr.IsDBNull(3) ? Convert.ToInt16(rdr["nivel"].ToString()) : (System.Int16)0;
					_Cuentas.cuentaasiento = !rdr.IsDBNull(4) ? Convert.ToBoolean(rdr["cuentaasiento"].ToString()) : true;
					_Cuentas.cuentasumar = !rdr.IsDBNull(5) ? Convert.ToString(rdr["cuentasumar"].ToString()) : "";
					_Cuentas.activopasivo = !rdr.IsDBNull(6) ? Convert.ToInt32(rdr["activopasivo"].ToString()) : (System.Int32)0;
					lstCuentas.Add(_Cuentas);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Cuentas", _state.error.ToString());
				return new Cuentas(_state, lstCuentas);
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
			return new Cuentas(_state);
		}
		public Cuentas.State InsertarCuentas(Cuentas.Data _Cuentas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Cuentas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cuentas_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@cuenta", _Cuentas.cuenta);
				SqlCmd.Parameters.AddWithValue("@nombrecuenta", _Cuentas.nombrecuenta);
				SqlCmd.Parameters.AddWithValue("@idmoneda", _Cuentas.idmoneda);
				SqlCmd.Parameters.AddWithValue("@nivel", _Cuentas.nivel);
				SqlCmd.Parameters.AddWithValue("@cuentaasiento", _Cuentas.cuentaasiento);
				SqlCmd.Parameters.AddWithValue("@cuentasumar", _Cuentas.cuentasumar);
				SqlCmd.Parameters.AddWithValue("@activopasivo", _Cuentas.activopasivo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Cuentas", _state.error.ToString());
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
		public Cuentas.State ActualizarCuentas(Cuentas.Data _Cuentas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Cuentas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cuentas_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@cuenta", _Cuentas.cuenta);
				SqlCmd.Parameters.AddWithValue("@nombrecuenta", _Cuentas.nombrecuenta);
				SqlCmd.Parameters.AddWithValue("@idmoneda", _Cuentas.idmoneda);
				SqlCmd.Parameters.AddWithValue("@nivel", _Cuentas.nivel);
				SqlCmd.Parameters.AddWithValue("@cuentaasiento", _Cuentas.cuentaasiento);
				SqlCmd.Parameters.AddWithValue("@cuentasumar", _Cuentas.cuentasumar);
				SqlCmd.Parameters.AddWithValue("@activopasivo", _Cuentas.activopasivo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Cuentas", _state.error.ToString());
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
		public Cuentas.State EliminarCuentas(Cuentas.Data _Cuentas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Cuentas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cuentas_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@cuenta", _Cuentas.cuenta);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Cuentas", _state.error.ToString());
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
