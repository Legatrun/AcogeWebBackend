using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class ClaseItemsDataAccess
	{
		ClaseItems.State _state = new ClaseItems.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public ClaseItems ConsultarClaseItems()
		{
		    _log.Traceo("Ingresa a Metodo Consultar ClaseItems", "0");
			List<ClaseItems.Data> lstClaseItems = new List<ClaseItems.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ClaseItems_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					ClaseItems.Data _ClaseItems= new ClaseItems.Data();
					_ClaseItems.idclase = Convert.ToInt16(rdr["idclase"].ToString());
					_ClaseItems.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_ClaseItems.sigla = !rdr.IsDBNull(2) ? Convert.ToString(rdr["sigla"].ToString().Trim()) : "";
					_ClaseItems.cuentaventa = !rdr.IsDBNull(3) ? Convert.ToString(rdr["cuentaventa"].ToString()) : "";
					_ClaseItems.cuentacosto = !rdr.IsDBNull(4) ? Convert.ToString(rdr["cuentacosto"].ToString()) : "";
					_ClaseItems.cuentagasto = !rdr.IsDBNull(5) ? Convert.ToString(rdr["cuentagasto"].ToString()) : "";
					_ClaseItems.cuentainventario = !rdr.IsDBNull(6) ? Convert.ToString(rdr["cuentainventario"].ToString()) : "";
					_ClaseItems.ingresainventario = !rdr.IsDBNull(6) ? Convert.ToBoolean(rdr["ingresainventario"].ToString()) : true;
					lstClaseItems.Add(_ClaseItems);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar ClaseItems", _state.error.ToString());
				return new ClaseItems(_state, lstClaseItems);
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
			return new ClaseItems(_state);
		}
		public ClaseItems BuscarClaseItems(ClaseItems.Data _ClaseItemsData)
		{
			List<ClaseItems.Data> lstClaseItems = new List<ClaseItems.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar ClaseItems", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ClaseItems_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idclase", _ClaseItemsData.idclase);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					ClaseItems.Data _ClaseItems= new ClaseItems.Data();
					_ClaseItems.idclase = Convert.ToInt16(rdr["idclase"].ToString());
					_ClaseItems.descripcion = !rdr.IsDBNull(rdr.GetOrdinal("descripcion")) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_ClaseItems.sigla = !rdr.IsDBNull(rdr.GetOrdinal("sigla")) ? Convert.ToString(rdr["sigla"].ToString()).Trim() : "";
					_ClaseItems.cuentaventa = !rdr.IsDBNull(rdr.GetOrdinal("cuentaventa")) ? Convert.ToString(rdr["cuentaventa"].ToString()) : "";
					_ClaseItems.cuentacosto = !rdr.IsDBNull(rdr.GetOrdinal("cuentacosto")) ? Convert.ToString(rdr["cuentacosto"].ToString()) : "";
					_ClaseItems.cuentagasto = !rdr.IsDBNull(rdr.GetOrdinal("cuentagasto")) ? Convert.ToString(rdr["cuentagasto"].ToString()) : "";
					_ClaseItems.cuentainventario = !rdr.IsDBNull(rdr.GetOrdinal("cuentainventario")) ? Convert.ToString(rdr["cuentainventario"].ToString()) : "";
					_ClaseItems.ingresainventario = !rdr.IsDBNull(rdr.GetOrdinal("ingresainventario")) ? Convert.ToBoolean(rdr["ingresainventario"].ToString()) : true;
					lstClaseItems.Add(_ClaseItems);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar ClaseItems", _state.error.ToString());
				return new ClaseItems(_state, lstClaseItems);
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
			return new ClaseItems(_state);
		}
		public ClaseItems.State InsertarClaseItems(ClaseItems.Data _ClaseItems)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar ClaseItems", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ClaseItems_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDClase = new SqlParameter();
				pIDClase.ParameterName = "@IDClase";
				pIDClase.Value = 0;
				SqlCmd.Parameters.Add(pIDClase);
				pIDClase.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _ClaseItems.descripcion);
				SqlCmd.Parameters.AddWithValue("@sigla", _ClaseItems.sigla);
				SqlCmd.Parameters.AddWithValue("@cuentaventa", _ClaseItems.cuentaventa);
				SqlCmd.Parameters.AddWithValue("@cuentacosto", _ClaseItems.cuentacosto);
				SqlCmd.Parameters.AddWithValue("@cuentagasto", _ClaseItems.cuentagasto);
				SqlCmd.Parameters.AddWithValue("@cuentainventario", _ClaseItems.cuentainventario);
				SqlCmd.Parameters.AddWithValue("@ingresainventario", _ClaseItems.ingresainventario);

				SqlCmd.ExecuteNonQuery();
				//_ClaseItems.idclase = (System.Int16)pIDClase.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar ClaseItems", _state.error.ToString());
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
		public ClaseItems.State ActualizarClaseItems(ClaseItems.Data _ClaseItems)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar ClaseItems", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ClaseItems_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idclase", _ClaseItems.idclase);
				SqlCmd.Parameters.AddWithValue("@descripcion", _ClaseItems.descripcion);
				SqlCmd.Parameters.AddWithValue("@sigla", _ClaseItems.sigla);
				SqlCmd.Parameters.AddWithValue("@cuentaventa", _ClaseItems.cuentaventa);
				SqlCmd.Parameters.AddWithValue("@cuentacosto", _ClaseItems.cuentacosto);
				SqlCmd.Parameters.AddWithValue("@cuentagasto", _ClaseItems.cuentagasto);
				SqlCmd.Parameters.AddWithValue("@cuentainventario", _ClaseItems.cuentainventario);
				SqlCmd.Parameters.AddWithValue("@ingresainventario", _ClaseItems.ingresainventario);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar ClaseItems", _state.error.ToString());
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
		public ClaseItems.State EliminarClaseItems(ClaseItems.Data _ClaseItems)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar ClaseItems", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ClaseItems_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idclase", _ClaseItems.idclase);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar ClaseItems", _state.error.ToString());
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
