using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class TiposComprobantesDataAccess
	{
		TiposComprobantes.State _state = new TiposComprobantes.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public TiposComprobantes ConsultarTiposComprobantes()
		{
		    _log.Traceo("Ingresa a Metodo Consultar TiposComprobantes", "0");
			List<TiposComprobantes.Data> lstTiposComprobantes = new List<TiposComprobantes.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposComprobantes_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TiposComprobantes.Data _TiposComprobantes= new TiposComprobantes.Data();
					_TiposComprobantes.idtipocomprobante = Convert.ToInt16(rdr["idtipocomprobante"].ToString());
					_TiposComprobantes.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_TiposComprobantes.sigla = !rdr.IsDBNull(2) ? Convert.ToString(rdr["sigla"].ToString()) : "";
					_TiposComprobantes.automatico = !rdr.IsDBNull(3) ? Convert.ToBoolean(rdr["automatico"].ToString()) : true;
					_TiposComprobantes.idsucursal = !rdr.IsDBNull(4) ? Convert.ToInt16(rdr["idsucursal"].ToString()) : (System.Int16)0;
					lstTiposComprobantes.Add(_TiposComprobantes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar TiposComprobantes", _state.error.ToString());
				return new TiposComprobantes(_state, lstTiposComprobantes);
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
			return new TiposComprobantes(_state);
		}
		public TiposComprobantes BuscarTiposComprobantes(TiposComprobantes.Data _TiposComprobantesData)
		{
			List<TiposComprobantes.Data> lstTiposComprobantes = new List<TiposComprobantes.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar TiposComprobantes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposComprobantes_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _TiposComprobantesData.idtipocomprobante);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TiposComprobantes.Data _TiposComprobantes= new TiposComprobantes.Data();
					_TiposComprobantes.idtipocomprobante = Convert.ToInt16(rdr["idtipocomprobante"].ToString());
					_TiposComprobantes.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_TiposComprobantes.sigla = !rdr.IsDBNull(2) ? Convert.ToString(rdr["sigla"].ToString()) : "";
					_TiposComprobantes.automatico = !rdr.IsDBNull(3) ? Convert.ToBoolean(rdr["automatico"].ToString()) : true;
					_TiposComprobantes.idsucursal = !rdr.IsDBNull(4) ? Convert.ToInt16(rdr["idsucursal"].ToString()) : (System.Int16)0;
					lstTiposComprobantes.Add(_TiposComprobantes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar TiposComprobantes", _state.error.ToString());
				return new TiposComprobantes(_state, lstTiposComprobantes);
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
			return new TiposComprobantes(_state);
		}
		public TiposComprobantes.State InsertarTiposComprobantes(TiposComprobantes.Data _TiposComprobantes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar TiposComprobantes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposComprobantes_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDTipoComprobante = new SqlParameter();
				pIDTipoComprobante.ParameterName = "@IDTipoComprobante";
				pIDTipoComprobante.Value = 0;
				SqlCmd.Parameters.Add(pIDTipoComprobante);
				pIDTipoComprobante.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _TiposComprobantes.descripcion);
				SqlCmd.Parameters.AddWithValue("@sigla", _TiposComprobantes.sigla);
				SqlCmd.Parameters.AddWithValue("@automatico", _TiposComprobantes.automatico);
				SqlCmd.Parameters.AddWithValue("@idsucursal", _TiposComprobantes.idsucursal);

				SqlCmd.ExecuteNonQuery();
				//_TiposComprobantes.idtipocomprobante = (System.Int16)pIDTipoComprobante.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar TiposComprobantes", _state.error.ToString());
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
		public TiposComprobantes.State ActualizarTiposComprobantes(TiposComprobantes.Data _TiposComprobantes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar TiposComprobantes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposComprobantes_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _TiposComprobantes.idtipocomprobante);
				SqlCmd.Parameters.AddWithValue("@descripcion", _TiposComprobantes.descripcion);
				SqlCmd.Parameters.AddWithValue("@sigla", _TiposComprobantes.sigla);
				SqlCmd.Parameters.AddWithValue("@automatico", _TiposComprobantes.automatico);
				SqlCmd.Parameters.AddWithValue("@idsucursal", _TiposComprobantes.idsucursal);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar TiposComprobantes", _state.error.ToString());
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
		public TiposComprobantes.State EliminarTiposComprobantes(TiposComprobantes.Data _TiposComprobantes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar TiposComprobantes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposComprobantes_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocomprobante", _TiposComprobantes.idtipocomprobante);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar TiposComprobantes", _state.error.ToString());
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
