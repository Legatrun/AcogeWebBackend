using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class CreditoFiscalDataAccess
	{
		CreditoFiscal.State _state = new CreditoFiscal.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public CreditoFiscal ConsultarCreditoFiscal()
		{
		    _log.Traceo("Ingresa a Metodo Consultar CreditoFiscal", "0");
			List<CreditoFiscal.Data> lstCreditoFiscal = new List<CreditoFiscal.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CreditoFiscal_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					CreditoFiscal.Data _CreditoFiscal= new CreditoFiscal.Data();
					_CreditoFiscal.empleado = Convert.ToInt32(rdr["empleado"].ToString());
					_CreditoFiscal.mes = Convert.ToInt16(rdr["mes"].ToString());
					_CreditoFiscal.año = Convert.ToInt16(rdr["año"].ToString());
					_CreditoFiscal.declarado = Convert.ToDouble(rdr["declarado"].ToString());
					_CreditoFiscal.actualizacion = Convert.ToDouble(rdr["actualizacion"].ToString());
					_CreditoFiscal.saldo = Convert.ToDouble(rdr["saldo"].ToString());
					lstCreditoFiscal.Add(_CreditoFiscal);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar CreditoFiscal", _state.error.ToString());
				return new CreditoFiscal(_state, lstCreditoFiscal);
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
			return new CreditoFiscal(_state);
		}
		public CreditoFiscal BuscarCreditoFiscal(CreditoFiscal.Data _CreditoFiscalData)
		{
			List<CreditoFiscal.Data> lstCreditoFiscal = new List<CreditoFiscal.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar CreditoFiscal", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CreditoFiscal_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _CreditoFiscalData.empleado);
				SqlCmd.Parameters.AddWithValue("@mes", _CreditoFiscalData.mes);
				SqlCmd.Parameters.AddWithValue("@año", _CreditoFiscalData.año);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					CreditoFiscal.Data _CreditoFiscal= new CreditoFiscal.Data();
					_CreditoFiscal.empleado = Convert.ToInt32(rdr["empleado"].ToString());
					_CreditoFiscal.mes = Convert.ToInt16(rdr["mes"].ToString());
					_CreditoFiscal.año = Convert.ToInt16(rdr["año"].ToString());
					_CreditoFiscal.declarado = Convert.ToDouble(rdr["declarado"].ToString());
					_CreditoFiscal.actualizacion = Convert.ToDouble(rdr["actualizacion"].ToString());
					_CreditoFiscal.saldo = Convert.ToDouble(rdr["saldo"].ToString());
					lstCreditoFiscal.Add(_CreditoFiscal);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar CreditoFiscal", _state.error.ToString());
				return new CreditoFiscal(_state, lstCreditoFiscal);
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
			return new CreditoFiscal(_state);
		}
		public CreditoFiscal.State InsertarCreditoFiscal(CreditoFiscal.Data _CreditoFiscal)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar CreditoFiscal", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CreditoFiscal_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _CreditoFiscal.empleado);
				SqlCmd.Parameters.AddWithValue("@mes", _CreditoFiscal.mes);
				SqlCmd.Parameters.AddWithValue("@año", _CreditoFiscal.año);
				SqlCmd.Parameters.AddWithValue("@declarado", _CreditoFiscal.declarado);
				SqlCmd.Parameters.AddWithValue("@actualizacion", _CreditoFiscal.actualizacion);
				SqlCmd.Parameters.AddWithValue("@saldo", _CreditoFiscal.saldo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar CreditoFiscal", _state.error.ToString());
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
		public CreditoFiscal.State ActualizarCreditoFiscal(CreditoFiscal.Data _CreditoFiscal)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar CreditoFiscal", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CreditoFiscal_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _CreditoFiscal.empleado);
				SqlCmd.Parameters.AddWithValue("@mes", _CreditoFiscal.mes);
				SqlCmd.Parameters.AddWithValue("@año", _CreditoFiscal.año);
				SqlCmd.Parameters.AddWithValue("@declarado", _CreditoFiscal.declarado);
				SqlCmd.Parameters.AddWithValue("@actualizacion", _CreditoFiscal.actualizacion);
				SqlCmd.Parameters.AddWithValue("@saldo", _CreditoFiscal.saldo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar CreditoFiscal", _state.error.ToString());
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
		public CreditoFiscal.State EliminarCreditoFiscal(CreditoFiscal.Data _CreditoFiscal)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar CreditoFiscal", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CreditoFiscal_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _CreditoFiscal.empleado);
				SqlCmd.Parameters.AddWithValue("@mes", _CreditoFiscal.mes);
				SqlCmd.Parameters.AddWithValue("@año", _CreditoFiscal.año);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar CreditoFiscal", _state.error.ToString());
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
