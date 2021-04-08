using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class CorrelativosTiposComprobantesDataAccess
	{
		CorrelativosTiposComprobantes.State _state = new CorrelativosTiposComprobantes.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public CorrelativosTiposComprobantes ConsultarCorrelativosTiposComprobantes()
		{
		    _log.Traceo("Ingresa a Metodo Consultar CorrelativosTiposComprobantes", "0");
			List<CorrelativosTiposComprobantes.Data> lstCorrelativosTiposComprobantes = new List<CorrelativosTiposComprobantes.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CorrelativosTiposComprobantes_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					CorrelativosTiposComprobantes.Data _CorrelativosTiposComprobantes= new CorrelativosTiposComprobantes.Data();
					_CorrelativosTiposComprobantes.idtipocomprobante = Convert.ToInt16(rdr["idtipocomprobante"].ToString());
					_CorrelativosTiposComprobantes.anio = Convert.ToInt16(rdr["anio"].ToString());
					_CorrelativosTiposComprobantes.mes = Convert.ToInt16(rdr["mes"].ToString());
					_CorrelativosTiposComprobantes.correlativo = !rdr.IsDBNull(3) ? Convert.ToInt16(rdr["correlativo"].ToString()) : (System.Int16)0;
					lstCorrelativosTiposComprobantes.Add(_CorrelativosTiposComprobantes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar CorrelativosTiposComprobantes", _state.error.ToString());
				return new CorrelativosTiposComprobantes(_state, lstCorrelativosTiposComprobantes);
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
			return new CorrelativosTiposComprobantes(_state);
		}
		public CorrelativosTiposComprobantes BuscarCorrelativosTiposComprobantes(CorrelativosTiposComprobantes.Data _CorrelativosTiposComprobantesData)
		{
			List<CorrelativosTiposComprobantes.Data> lstCorrelativosTiposComprobantes = new List<CorrelativosTiposComprobantes.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar CorrelativosTiposComprobantes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CorrelativosTiposComprobantes_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _CorrelativosTiposComprobantesData.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@anio", _CorrelativosTiposComprobantesData.anio);
				SqlCmd.Parameters.AddWithValue("@mes", _CorrelativosTiposComprobantesData.mes);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					CorrelativosTiposComprobantes.Data _CorrelativosTiposComprobantes= new CorrelativosTiposComprobantes.Data();
					_CorrelativosTiposComprobantes.idtipocomprobante = Convert.ToInt16(rdr["idtipocomprobante"].ToString());
					_CorrelativosTiposComprobantes.anio = Convert.ToInt16(rdr["anio"].ToString());
					_CorrelativosTiposComprobantes.mes = Convert.ToInt16(rdr["mes"].ToString());
					_CorrelativosTiposComprobantes.correlativo = !rdr.IsDBNull(3) ? Convert.ToInt16(rdr["correlativo"].ToString()) : (System.Int16)0;
					lstCorrelativosTiposComprobantes.Add(_CorrelativosTiposComprobantes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar CorrelativosTiposComprobantes", _state.error.ToString());
				return new CorrelativosTiposComprobantes(_state, lstCorrelativosTiposComprobantes);
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
			return new CorrelativosTiposComprobantes(_state);
		}
		public CorrelativosTiposComprobantes.State InsertarCorrelativosTiposComprobantes(CorrelativosTiposComprobantes.Data _CorrelativosTiposComprobantes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar CorrelativosTiposComprobantes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CorrelativosTiposComprobantes_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _CorrelativosTiposComprobantes.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@anio", _CorrelativosTiposComprobantes.anio);
				SqlCmd.Parameters.AddWithValue("@mes", _CorrelativosTiposComprobantes.mes);
				SqlCmd.Parameters.AddWithValue("@correlativo", _CorrelativosTiposComprobantes.correlativo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar CorrelativosTiposComprobantes", _state.error.ToString());
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
		public CorrelativosTiposComprobantes.State ActualizarCorrelativosTiposComprobantes(CorrelativosTiposComprobantes.Data _CorrelativosTiposComprobantes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar CorrelativosTiposComprobantes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CorrelativosTiposComprobantes_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _CorrelativosTiposComprobantes.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@anio", _CorrelativosTiposComprobantes.anio);
				SqlCmd.Parameters.AddWithValue("@mes", _CorrelativosTiposComprobantes.mes);
				SqlCmd.Parameters.AddWithValue("@correlativo", _CorrelativosTiposComprobantes.correlativo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar CorrelativosTiposComprobantes", _state.error.ToString());
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
		public CorrelativosTiposComprobantes.State EliminarCorrelativosTiposComprobantes(CorrelativosTiposComprobantes.Data _CorrelativosTiposComprobantes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar CorrelativosTiposComprobantes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CorrelativosTiposComprobantes_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _CorrelativosTiposComprobantes.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@anio", _CorrelativosTiposComprobantes.anio);
				SqlCmd.Parameters.AddWithValue("@mes", _CorrelativosTiposComprobantes.mes);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar CorrelativosTiposComprobantes", _state.error.ToString());
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
