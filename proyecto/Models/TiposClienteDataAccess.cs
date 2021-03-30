using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class TiposClienteDataAccess
	{
		TiposCliente.State _state = new TiposCliente.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public TiposCliente ConsultarTiposCliente()
		{
		    _log.Traceo("Ingresa a Metodo Consultar TiposCliente", "0");
			List<TiposCliente.Data> lstTiposCliente = new List<TiposCliente.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposCliente_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TiposCliente.Data _TiposCliente= new TiposCliente.Data();
					_TiposCliente.idtipocliente = Convert.ToInt16(rdr["idtipocliente"].ToString());
					_TiposCliente.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					lstTiposCliente.Add(_TiposCliente);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar TiposCliente", _state.error.ToString());
				return new TiposCliente(_state, lstTiposCliente);
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
			return new TiposCliente(_state);
		}
		public TiposCliente BuscarTiposCliente(TiposCliente.Data _TiposClienteData)
		{
			List<TiposCliente.Data> lstTiposCliente = new List<TiposCliente.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar TiposCliente", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposCliente_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocliente", _TiposClienteData.idtipocliente);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TiposCliente.Data _TiposCliente= new TiposCliente.Data();
					_TiposCliente.idtipocliente = Convert.ToInt16(rdr["idtipocliente"].ToString());
					_TiposCliente.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					lstTiposCliente.Add(_TiposCliente);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar TiposCliente", _state.error.ToString());
				return new TiposCliente(_state, lstTiposCliente);
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
			return new TiposCliente(_state);
		}
		public TiposCliente.State InsertarTiposCliente(TiposCliente.Data _TiposCliente)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar TiposCliente", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposCliente_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDTipoCliente = new SqlParameter();
				pIDTipoCliente.ParameterName = "@IDTipoCliente";
				pIDTipoCliente.Value = 0;
				SqlCmd.Parameters.Add(pIDTipoCliente);
				pIDTipoCliente.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _TiposCliente.descripcion);

				SqlCmd.ExecuteNonQuery();
				//_TiposCliente.idtipocliente = (System.Int16)pIDTipoCliente.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar TiposCliente", _state.error.ToString());
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
		public TiposCliente.State ActualizarTiposCliente(TiposCliente.Data _TiposCliente)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar TiposCliente", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposCliente_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocliente", _TiposCliente.idtipocliente);
				SqlCmd.Parameters.AddWithValue("@descripcion", _TiposCliente.descripcion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar TiposCliente", _state.error.ToString());
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
		public TiposCliente.State EliminarTiposCliente(TiposCliente.Data _TiposCliente)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar TiposCliente", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposCliente_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtipocliente", _TiposCliente.idtipocliente);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar TiposCliente", _state.error.ToString());
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
