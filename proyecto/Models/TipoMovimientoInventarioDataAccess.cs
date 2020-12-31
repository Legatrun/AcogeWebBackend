using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class TipoMovimientoInventarioDataAccess
	{
		TipoMovimientoInventario.State _state = new TipoMovimientoInventario.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public TipoMovimientoInventario ConsultarTipoMovimientoInventario()
		{
		    _log.Traceo("Ingresa a Metodo Consultar TipoMovimientoInventario", "0");
			List<TipoMovimientoInventario.Data> lstTipoMovimientoInventario = new List<TipoMovimientoInventario.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TipoMovimientoInventario_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TipoMovimientoInventario.Data _TipoMovimientoInventario= new TipoMovimientoInventario.Data();
					_TipoMovimientoInventario.idtipomovimiento = Convert.ToInt16(rdr["idtipomovimiento"].ToString());
					_TipoMovimientoInventario.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					lstTipoMovimientoInventario.Add(_TipoMovimientoInventario);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar TipoMovimientoInventario", _state.error.ToString());
				return new TipoMovimientoInventario(_state, lstTipoMovimientoInventario);
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
			return new TipoMovimientoInventario(_state);
		}
		public TipoMovimientoInventario BuscarTipoMovimientoInventario(TipoMovimientoInventario.Data _TipoMovimientoInventarioData)
		{
			List<TipoMovimientoInventario.Data> lstTipoMovimientoInventario = new List<TipoMovimientoInventario.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar TipoMovimientoInventario", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TipoMovimientoInventario_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipomovimiento", _TipoMovimientoInventarioData.idtipomovimiento);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TipoMovimientoInventario.Data _TipoMovimientoInventario= new TipoMovimientoInventario.Data();
					_TipoMovimientoInventario.idtipomovimiento = Convert.ToInt16(rdr["idtipomovimiento"].ToString());
					_TipoMovimientoInventario.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					lstTipoMovimientoInventario.Add(_TipoMovimientoInventario);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar TipoMovimientoInventario", _state.error.ToString());
				return new TipoMovimientoInventario(_state, lstTipoMovimientoInventario);
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
			return new TipoMovimientoInventario(_state);
		}
		public TipoMovimientoInventario.State InsertarTipoMovimientoInventario(TipoMovimientoInventario.Data _TipoMovimientoInventario)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar TipoMovimientoInventario", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TipoMovimientoInventario_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipomovimiento", _TipoMovimientoInventario.idtipomovimiento);
				SqlCmd.Parameters.AddWithValue("@descripcion", _TipoMovimientoInventario.descripcion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar TipoMovimientoInventario", _state.error.ToString());
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
		public TipoMovimientoInventario.State ActualizarTipoMovimientoInventario(TipoMovimientoInventario.Data _TipoMovimientoInventario)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar TipoMovimientoInventario", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TipoMovimientoInventario_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipomovimiento", _TipoMovimientoInventario.idtipomovimiento);
				SqlCmd.Parameters.AddWithValue("@descripcion", _TipoMovimientoInventario.descripcion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar TipoMovimientoInventario", _state.error.ToString());
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
		public TipoMovimientoInventario.State EliminarTipoMovimientoInventario(TipoMovimientoInventario.Data _TipoMovimientoInventario)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar TipoMovimientoInventario", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TipoMovimientoInventario_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipomovimiento", _TipoMovimientoInventario.idtipomovimiento);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar TipoMovimientoInventario", _state.error.ToString());
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
