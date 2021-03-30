using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class TiposItemsDataAccess
	{
		TiposItems.State _state = new TiposItems.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public TiposItems ConsultarTiposItems()
		{
		    _log.Traceo("Ingresa a Metodo Consultar TiposItems", "0");
			List<TiposItems.Data> lstTiposItems = new List<TiposItems.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposItems_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TiposItems.Data _TiposItems= new TiposItems.Data();
					_TiposItems.idtipoitem = Convert.ToInt16(rdr["idtipoitem"].ToString());
					_TiposItems.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_TiposItems.sigla = !rdr.IsDBNull(2) ? Convert.ToString(rdr["sigla"].ToString()) : "";
					_TiposItems.ingresainventario = !rdr.IsDBNull(2) ? Convert.ToBoolean(rdr["ingresainventario"].ToString()) : true;
					lstTiposItems.Add(_TiposItems);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar TiposItems", _state.error.ToString());
				return new TiposItems(_state, lstTiposItems);
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
			return new TiposItems(_state);
		}
		public TiposItems BuscarTiposItems(TiposItems.Data _TiposItemsData)
		{
			List<TiposItems.Data> lstTiposItems = new List<TiposItems.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar TiposItems", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposItems_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipoitem", _TiposItemsData.idtipoitem);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TiposItems.Data _TiposItems= new TiposItems.Data();
					_TiposItems.idtipoitem = Convert.ToInt16(rdr["idtipoitem"].ToString());
					_TiposItems.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_TiposItems.sigla = !rdr.IsDBNull(2) ? Convert.ToString(rdr["sigla"].ToString()) : "";
					_TiposItems.ingresainventario = !rdr.IsDBNull(4) ? Convert.ToBoolean(rdr["ingresainventario"].ToString()) : true;
					lstTiposItems.Add(_TiposItems);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar TiposItems", _state.error.ToString());
				return new TiposItems(_state, lstTiposItems);
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
			return new TiposItems(_state);
		}
		public TiposItems.State InsertarTiposItems(TiposItems.Data _TiposItems)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar TiposItems", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposItems_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDTipoItem = new SqlParameter();
				pIDTipoItem.ParameterName = "@IDTipoItem";
				pIDTipoItem.Value = 0;
				SqlCmd.Parameters.Add(pIDTipoItem);
				pIDTipoItem.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _TiposItems.descripcion);
				SqlCmd.Parameters.AddWithValue("@sigla", _TiposItems.sigla);
				SqlCmd.Parameters.AddWithValue("@ingresainventario", _TiposItems.ingresainventario);

				SqlCmd.ExecuteNonQuery();
				//_TiposItems.idtipoitem = (System.Int16)pIDTipoItem.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar TiposItems", _state.error.ToString());
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
		public TiposItems.State ActualizarTiposItems(TiposItems.Data _TiposItems)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar TiposItems", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposItems_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipoitem", _TiposItems.idtipoitem);
				SqlCmd.Parameters.AddWithValue("@descripcion", _TiposItems.descripcion);
				SqlCmd.Parameters.AddWithValue("@sigla", _TiposItems.sigla);
				SqlCmd.Parameters.AddWithValue("@ingresainventario", _TiposItems.ingresainventario);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar TiposItems", _state.error.ToString());
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
		public TiposItems.State EliminarTiposItems(TiposItems.Data _TiposItems)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar TiposItems", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposItems_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipoitem", _TiposItems.idtipoitem);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar TiposItems", _state.error.ToString());
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
