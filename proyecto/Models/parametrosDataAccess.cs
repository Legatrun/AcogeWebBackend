using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class parametrosDataAccess
	{
		parametros.State _state = new parametros.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public parametros Consultarparametros()
		{
		    _log.Traceo("Ingresa a Metodo Consultar parametros", "0");
			List<parametros.Data> lstparametros = new List<parametros.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_parametros_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					parametros.Data _parametros= new parametros.Data();
					_parametros.mes = Convert.ToInt16(rdr["mes"].ToString());
					_parametros.año = Convert.ToInt16(rdr["año"].ToString());
					_parametros.cotizacion = Convert.ToDouble(rdr["cotizacion"].ToString());
					_parametros.minimo_nacional = Convert.ToDouble(rdr["minimo_nacional"].ToString());
					_parametros.ufb = !rdr.IsDBNull(4) ? Convert.ToDecimal(rdr["ufb"].ToString()) : (System.Decimal)0;
					lstparametros.Add(_parametros);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar parametros", _state.error.ToString());
				return new parametros(_state, lstparametros);
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
			return new parametros(_state);
		}
		public parametros Buscarparametros(parametros.Data _parametrosData)
		{
			List<parametros.Data> lstparametros = new List<parametros.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar parametros", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_parametros_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@mes", _parametrosData.mes);
				SqlCmd.Parameters.AddWithValue("@año", _parametrosData.año);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					parametros.Data _parametros= new parametros.Data();
					_parametros.mes = Convert.ToInt16(rdr["mes"].ToString());
					_parametros.año = Convert.ToInt16(rdr["año"].ToString());
					_parametros.cotizacion = Convert.ToDouble(rdr["cotizacion"].ToString());
					_parametros.minimo_nacional = Convert.ToDouble(rdr["minimo_nacional"].ToString());
					_parametros.ufb = !rdr.IsDBNull(4) ? Convert.ToDecimal(rdr["ufb"].ToString()) : (System.Decimal)0;
					lstparametros.Add(_parametros);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar parametros", _state.error.ToString());
				return new parametros(_state, lstparametros);
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
			return new parametros(_state);
		}
		public parametros.State Insertarparametros(parametros.Data _parametros)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar parametros", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_parametros_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@mes", _parametros.mes);
				SqlCmd.Parameters.AddWithValue("@año", _parametros.año);
				SqlCmd.Parameters.AddWithValue("@cotizacion", _parametros.cotizacion);
				SqlCmd.Parameters.AddWithValue("@minimo_nacional", _parametros.minimo_nacional);
				SqlCmd.Parameters.AddWithValue("@ufb", _parametros.ufb);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar parametros", _state.error.ToString());
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
		public parametros.State Actualizarparametros(parametros.Data _parametros)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar parametros", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_parametros_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@mes", _parametros.mes);
				SqlCmd.Parameters.AddWithValue("@año", _parametros.año);
				SqlCmd.Parameters.AddWithValue("@cotizacion", _parametros.cotizacion);
				SqlCmd.Parameters.AddWithValue("@minimo_nacional", _parametros.minimo_nacional);
				SqlCmd.Parameters.AddWithValue("@ufb", _parametros.ufb);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar parametros", _state.error.ToString());
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
		public parametros.State Eliminarparametros(parametros.Data _parametros)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar parametros", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_parametros_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@mes", _parametros.mes);
				SqlCmd.Parameters.AddWithValue("@año", _parametros.año);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar parametros", _state.error.ToString());
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
