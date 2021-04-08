using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class AsientosDetalleDataAccess
	{
		AsientosDetalle.State _state = new AsientosDetalle.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public AsientosDetalle ConsultarAsientosDetalle()
		{
		    _log.Traceo("Ingresa a Metodo Consultar AsientosDetalle", "0");
			List<AsientosDetalle.Data> lstAsientosDetalle = new List<AsientosDetalle.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AsientosDetalle_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					AsientosDetalle.Data _AsientosDetalle= new AsientosDetalle.Data();
					_AsientosDetalle.idtipocomprobante = Convert.ToInt16(rdr["idtipocomprobante"].ToString());
					_AsientosDetalle.numerocomprobante = Convert.ToString(rdr["numerocomprobante"].ToString());
					_AsientosDetalle.nrolinea = Convert.ToInt16(rdr["nrolinea"].ToString());
					_AsientosDetalle.cuenta = !rdr.IsDBNull(3) ? Convert.ToString(rdr["cuenta"].ToString()) : "";
					_AsientosDetalle.glosadetalle = !rdr.IsDBNull(4) ? Convert.ToString(rdr["glosadetalle"].ToString()) : "";
					_AsientosDetalle.tipomov = !rdr.IsDBNull(5) ? Convert.ToString(rdr["tipomov"].ToString()) : "";
					_AsientosDetalle.montobs = !rdr.IsDBNull(6) ? Convert.ToDouble(rdr["montobs"].ToString()) : (System.Double)0;
					_AsientosDetalle.montosus = !rdr.IsDBNull(7) ? Convert.ToDouble(rdr["montosus"].ToString()) : (System.Double)0;
					lstAsientosDetalle.Add(_AsientosDetalle);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar AsientosDetalle", _state.error.ToString());
				return new AsientosDetalle(_state, lstAsientosDetalle);
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
			return new AsientosDetalle(_state);
		}
		public AsientosDetalle BuscarAsientosDetalle(AsientosDetalle.Data _AsientosDetalleData)
		{
			List<AsientosDetalle.Data> lstAsientosDetalle = new List<AsientosDetalle.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar AsientosDetalle", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AsientosDetalle_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _AsientosDetalleData.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@numerocomprobante", _AsientosDetalleData.numerocomprobante);
				SqlCmd.Parameters.AddWithValue("@nrolinea", _AsientosDetalleData.nrolinea);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					AsientosDetalle.Data _AsientosDetalle= new AsientosDetalle.Data();
					_AsientosDetalle.idtipocomprobante = Convert.ToInt16(rdr["idtipocomprobante"].ToString());
					_AsientosDetalle.numerocomprobante = Convert.ToString(rdr["numerocomprobante"].ToString());
					_AsientosDetalle.nrolinea = Convert.ToInt16(rdr["nrolinea"].ToString());
					_AsientosDetalle.cuenta = !rdr.IsDBNull(3) ? Convert.ToString(rdr["cuenta"].ToString()) : "";
					_AsientosDetalle.glosadetalle = !rdr.IsDBNull(4) ? Convert.ToString(rdr["glosadetalle"].ToString()) : "";
					_AsientosDetalle.tipomov = !rdr.IsDBNull(5) ? Convert.ToString(rdr["tipomov"].ToString()) : "";
					_AsientosDetalle.montobs = !rdr.IsDBNull(6) ? Convert.ToDouble(rdr["montobs"].ToString()) : (System.Double)0;
					_AsientosDetalle.montosus = !rdr.IsDBNull(7) ? Convert.ToDouble(rdr["montosus"].ToString()) : (System.Double)0;
					lstAsientosDetalle.Add(_AsientosDetalle);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar AsientosDetalle", _state.error.ToString());
				return new AsientosDetalle(_state, lstAsientosDetalle);
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
			return new AsientosDetalle(_state);
		}
		public AsientosDetalle.State InsertarAsientosDetalle(AsientosDetalle.Data _AsientosDetalle)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar AsientosDetalle", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AsientosDetalle_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _AsientosDetalle.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@numerocomprobante", _AsientosDetalle.numerocomprobante);
				SqlCmd.Parameters.AddWithValue("@nrolinea", _AsientosDetalle.nrolinea);
				SqlCmd.Parameters.AddWithValue("@cuenta", _AsientosDetalle.cuenta);
				SqlCmd.Parameters.AddWithValue("@glosadetalle", _AsientosDetalle.glosadetalle);
				SqlCmd.Parameters.AddWithValue("@tipomov", _AsientosDetalle.tipomov);
				SqlCmd.Parameters.AddWithValue("@montobs", _AsientosDetalle.montobs);
				SqlCmd.Parameters.AddWithValue("@montosus", _AsientosDetalle.montosus);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar AsientosDetalle", _state.error.ToString());
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
		public AsientosDetalle.State ActualizarAsientosDetalle(AsientosDetalle.Data _AsientosDetalle)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar AsientosDetalle", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AsientosDetalle_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _AsientosDetalle.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@numerocomprobante", _AsientosDetalle.numerocomprobante);
				SqlCmd.Parameters.AddWithValue("@nrolinea", _AsientosDetalle.nrolinea);
				SqlCmd.Parameters.AddWithValue("@cuenta", _AsientosDetalle.cuenta);
				SqlCmd.Parameters.AddWithValue("@glosadetalle", _AsientosDetalle.glosadetalle);
				SqlCmd.Parameters.AddWithValue("@tipomov", _AsientosDetalle.tipomov);
				SqlCmd.Parameters.AddWithValue("@montobs", _AsientosDetalle.montobs);
				SqlCmd.Parameters.AddWithValue("@montosus", _AsientosDetalle.montosus);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar AsientosDetalle", _state.error.ToString());
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
		public AsientosDetalle.State EliminarAsientosDetalle(AsientosDetalle.Data _AsientosDetalle)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar AsientosDetalle", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AsientosDetalle_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _AsientosDetalle.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@numerocomprobante", _AsientosDetalle.numerocomprobante);
				SqlCmd.Parameters.AddWithValue("@nrolinea", _AsientosDetalle.nrolinea);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar AsientosDetalle", _state.error.ToString());
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
