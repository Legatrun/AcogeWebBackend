using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class CuentasBancosDataAccess
	{
		CuentasBancos.State _state = new CuentasBancos.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public CuentasBancos ConsultarCuentasBancos()
		{
		    _log.Traceo("Ingresa a Metodo Consultar CuentasBancos", "0");
			List<CuentasBancos.Data> lstCuentasBancos = new List<CuentasBancos.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CuentasBancos_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					CuentasBancos.Data _CuentasBancos= new CuentasBancos.Data();
					_CuentasBancos.idbanco = Convert.ToInt16(rdr["idbanco"].ToString());
					_CuentasBancos.nrocuenta = Convert.ToString(rdr["nrocuenta"].ToString());
					_CuentasBancos.idmoneda = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					_CuentasBancos.saldoactual = !rdr.IsDBNull(3) ? Convert.ToDouble(rdr["saldoactual"].ToString()) : (System.Double)0;
					_CuentasBancos.cuentacontable = !rdr.IsDBNull(4) ? Convert.ToString(rdr["cuentacontable"].ToString()) : "";
					_CuentasBancos.fechaapertura = !rdr.IsDBNull(5) ? Convert.ToDateTime(rdr["fechaapertura"].ToString()) : System.DateTime.Now;
					lstCuentasBancos.Add(_CuentasBancos);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar CuentasBancos", _state.error.ToString());
				return new CuentasBancos(_state, lstCuentasBancos);
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
			return new CuentasBancos(_state);
		}
		public CuentasBancos BuscarCuentasBancos(CuentasBancos.Data _CuentasBancosData)
		{
			List<CuentasBancos.Data> lstCuentasBancos = new List<CuentasBancos.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar CuentasBancos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CuentasBancos_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idbanco", _CuentasBancosData.idbanco);
				SqlCmd.Parameters.AddWithValue("@nrocuenta", _CuentasBancosData.nrocuenta);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					CuentasBancos.Data _CuentasBancos= new CuentasBancos.Data();
					_CuentasBancos.idbanco = Convert.ToInt16(rdr["idbanco"].ToString());
					_CuentasBancos.nrocuenta = Convert.ToString(rdr["nrocuenta"].ToString());
					_CuentasBancos.idmoneda = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					_CuentasBancos.saldoactual = !rdr.IsDBNull(3) ? Convert.ToDouble(rdr["saldoactual"].ToString()) : (System.Double)0;
					_CuentasBancos.cuentacontable = !rdr.IsDBNull(4) ? Convert.ToString(rdr["cuentacontable"].ToString()) : "";
					_CuentasBancos.fechaapertura = !rdr.IsDBNull(5) ? Convert.ToDateTime(rdr["fechaapertura"].ToString()) : System.DateTime.Now;
					lstCuentasBancos.Add(_CuentasBancos);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar CuentasBancos", _state.error.ToString());
				return new CuentasBancos(_state, lstCuentasBancos);
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
			return new CuentasBancos(_state);
		}
		public CuentasBancos.State InsertarCuentasBancos(CuentasBancos.Data _CuentasBancos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar CuentasBancos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CuentasBancos_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idbanco", _CuentasBancos.idbanco);
				SqlCmd.Parameters.AddWithValue("@nrocuenta", _CuentasBancos.nrocuenta);
				SqlCmd.Parameters.AddWithValue("@idmoneda", _CuentasBancos.idmoneda);
				SqlCmd.Parameters.AddWithValue("@saldoactual", _CuentasBancos.saldoactual);
				SqlCmd.Parameters.AddWithValue("@cuentacontable", _CuentasBancos.cuentacontable);
				SqlCmd.Parameters.AddWithValue("@fechaapertura", _CuentasBancos.fechaapertura);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar CuentasBancos", _state.error.ToString());
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
		public CuentasBancos.State ActualizarCuentasBancos(CuentasBancos.Data _CuentasBancos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar CuentasBancos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CuentasBancos_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idbanco", _CuentasBancos.idbanco);
				SqlCmd.Parameters.AddWithValue("@nrocuenta", _CuentasBancos.nrocuenta);
				SqlCmd.Parameters.AddWithValue("@idmoneda", _CuentasBancos.idmoneda);
				SqlCmd.Parameters.AddWithValue("@saldoactual", _CuentasBancos.saldoactual);
				SqlCmd.Parameters.AddWithValue("@cuentacontable", _CuentasBancos.cuentacontable);
				SqlCmd.Parameters.AddWithValue("@fechaapertura", _CuentasBancos.fechaapertura);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar CuentasBancos", _state.error.ToString());
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
		public CuentasBancos.State EliminarCuentasBancos(CuentasBancos.Data _CuentasBancos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar CuentasBancos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CuentasBancos_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idbanco", _CuentasBancos.idbanco);
				SqlCmd.Parameters.AddWithValue("@nrocuenta", _CuentasBancos.nrocuenta);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar CuentasBancos", _state.error.ToString());
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
