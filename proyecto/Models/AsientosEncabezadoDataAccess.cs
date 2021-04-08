using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class AsientosEncabezadoDataAccess
	{
		AsientosEncabezado.State _state = new AsientosEncabezado.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public AsientosEncabezado ConsultarAsientosEncabezado()
		{
		    _log.Traceo("Ingresa a Metodo Consultar AsientosEncabezado", "0");
			List<AsientosEncabezado.Data> lstAsientosEncabezado = new List<AsientosEncabezado.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AsientosEncabezado_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					AsientosEncabezado.Data _AsientosEncabezado= new AsientosEncabezado.Data();
					_AsientosEncabezado.idtipocomprobante = Convert.ToInt16(rdr["idtipocomprobante"].ToString());
					_AsientosEncabezado.numerocomprobante = Convert.ToString(rdr["numerocomprobante"].ToString());
					_AsientosEncabezado.fecha = Convert.ToDateTime(rdr["fecha"].ToString());
					_AsientosEncabezado.referencia = !rdr.IsDBNull(3) ? Convert.ToString(rdr["referencia"].ToString()) : "";
					_AsientosEncabezado.glosa = !rdr.IsDBNull(4) ? Convert.ToString(rdr["glosa"].ToString()) : "";
					_AsientosEncabezado.cotizacion = !rdr.IsDBNull(5) ? Convert.ToDouble(rdr["cotizacion"].ToString()) : (System.Double)0;
					_AsientosEncabezado.codigomodulo = !rdr.IsDBNull(6) ? Convert.ToString(rdr["codigomodulo"].ToString()) : "";
					lstAsientosEncabezado.Add(_AsientosEncabezado);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar AsientosEncabezado", _state.error.ToString());
				return new AsientosEncabezado(_state, lstAsientosEncabezado);
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
			return new AsientosEncabezado(_state);
		}
		public AsientosEncabezado BuscarAsientosEncabezado(AsientosEncabezado.Data _AsientosEncabezadoData)
		{
			List<AsientosEncabezado.Data> lstAsientosEncabezado = new List<AsientosEncabezado.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar AsientosEncabezado", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AsientosEncabezado_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _AsientosEncabezadoData.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@numerocomprobante", _AsientosEncabezadoData.numerocomprobante);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					AsientosEncabezado.Data _AsientosEncabezado= new AsientosEncabezado.Data();
					_AsientosEncabezado.idtipocomprobante = Convert.ToInt16(rdr["idtipocomprobante"].ToString());
					_AsientosEncabezado.numerocomprobante = Convert.ToString(rdr["numerocomprobante"].ToString());
					_AsientosEncabezado.fecha = Convert.ToDateTime(rdr["fecha"].ToString());
					_AsientosEncabezado.referencia = !rdr.IsDBNull(3) ? Convert.ToString(rdr["referencia"].ToString()) : "";
					_AsientosEncabezado.glosa = !rdr.IsDBNull(4) ? Convert.ToString(rdr["glosa"].ToString()) : "";
					_AsientosEncabezado.cotizacion = !rdr.IsDBNull(5) ? Convert.ToDouble(rdr["cotizacion"].ToString()) : (System.Double)0;
					_AsientosEncabezado.codigomodulo = !rdr.IsDBNull(6) ? Convert.ToString(rdr["codigomodulo"].ToString()) : "";
					lstAsientosEncabezado.Add(_AsientosEncabezado);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar AsientosEncabezado", _state.error.ToString());
				return new AsientosEncabezado(_state, lstAsientosEncabezado);
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
			return new AsientosEncabezado(_state);
		}
		public AsientosEncabezado.State InsertarAsientosEncabezado(AsientosEncabezado.Data _AsientosEncabezado)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar AsientosEncabezado", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AsientosEncabezado_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _AsientosEncabezado.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@numerocomprobante", _AsientosEncabezado.numerocomprobante);
				SqlCmd.Parameters.AddWithValue("@fecha", _AsientosEncabezado.fecha);
				SqlCmd.Parameters.AddWithValue("@referencia", _AsientosEncabezado.referencia);
				SqlCmd.Parameters.AddWithValue("@glosa", _AsientosEncabezado.glosa);
				SqlCmd.Parameters.AddWithValue("@cotizacion", _AsientosEncabezado.cotizacion);
				SqlCmd.Parameters.AddWithValue("@codigomodulo", _AsientosEncabezado.codigomodulo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar AsientosEncabezado", _state.error.ToString());
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
		public AsientosEncabezado.State ActualizarAsientosEncabezado(AsientosEncabezado.Data _AsientosEncabezado)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar AsientosEncabezado", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AsientosEncabezado_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _AsientosEncabezado.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@numerocomprobante", _AsientosEncabezado.numerocomprobante);
				SqlCmd.Parameters.AddWithValue("@fecha", _AsientosEncabezado.fecha);
				SqlCmd.Parameters.AddWithValue("@referencia", _AsientosEncabezado.referencia);
				SqlCmd.Parameters.AddWithValue("@glosa", _AsientosEncabezado.glosa);
				SqlCmd.Parameters.AddWithValue("@cotizacion", _AsientosEncabezado.cotizacion);
				SqlCmd.Parameters.AddWithValue("@codigomodulo", _AsientosEncabezado.codigomodulo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar AsientosEncabezado", _state.error.ToString());
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
		public AsientosEncabezado.State EliminarAsientosEncabezado(AsientosEncabezado.Data _AsientosEncabezado)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar AsientosEncabezado", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AsientosEncabezado_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _AsientosEncabezado.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@numerocomprobante", _AsientosEncabezado.numerocomprobante);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar AsientosEncabezado", _state.error.ToString());
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
