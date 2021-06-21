using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class UnidadDeManejoDataAccess
	{
		UnidadDeManejo.State _state = new UnidadDeManejo.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public UnidadDeManejo ConsultarUnidadDeManejo()
		{
		    _log.Traceo("Ingresa a Metodo Consultar UnidadDeManejo", "0");
			List<UnidadDeManejo.Data> lstUnidadDeManejo = new List<UnidadDeManejo.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UnidadDeManejo_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					UnidadDeManejo.Data _UnidadDeManejo= new UnidadDeManejo.Data();
					_UnidadDeManejo.idunidadmanejo = Convert.ToInt16(rdr["idunidadmanejo"].ToString());
					_UnidadDeManejo.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()).Trim() : "";
					lstUnidadDeManejo.Add(_UnidadDeManejo);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar UnidadDeManejo", _state.error.ToString());
				return new UnidadDeManejo(_state, lstUnidadDeManejo);
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
			return new UnidadDeManejo(_state);
		}
		public UnidadDeManejo BuscarUnidadDeManejo(UnidadDeManejo.Data _UnidadDeManejoData)
		{
			List<UnidadDeManejo.Data> lstUnidadDeManejo = new List<UnidadDeManejo.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar UnidadDeManejo", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UnidadDeManejo_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idunidadmanejo", _UnidadDeManejoData.idunidadmanejo);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					UnidadDeManejo.Data _UnidadDeManejo= new UnidadDeManejo.Data();
					_UnidadDeManejo.idunidadmanejo = Convert.ToInt16(rdr["idunidadmanejo"].ToString());
					_UnidadDeManejo.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					lstUnidadDeManejo.Add(_UnidadDeManejo);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar UnidadDeManejo", _state.error.ToString());
				return new UnidadDeManejo(_state, lstUnidadDeManejo);
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
			return new UnidadDeManejo(_state);
		}
		public UnidadDeManejo.State InsertarUnidadDeManejo(UnidadDeManejo.Data _UnidadDeManejo)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar UnidadDeManejo", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UnidadDeManejo_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDUnidadManejo = new SqlParameter();
				pIDUnidadManejo.ParameterName = "@IDUnidadManejo";
				pIDUnidadManejo.Value = 0;
				SqlCmd.Parameters.Add(pIDUnidadManejo);
				pIDUnidadManejo.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _UnidadDeManejo.descripcion);

				SqlCmd.ExecuteNonQuery();
				//_UnidadDeManejo.idunidadmanejo = (System.Int16)pIDUnidadManejo.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar UnidadDeManejo", _state.error.ToString());
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
		public UnidadDeManejo.State ActualizarUnidadDeManejo(UnidadDeManejo.Data _UnidadDeManejo)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar UnidadDeManejo", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UnidadDeManejo_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idunidadmanejo", _UnidadDeManejo.idunidadmanejo);
				SqlCmd.Parameters.AddWithValue("@descripcion", _UnidadDeManejo.descripcion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar UnidadDeManejo", _state.error.ToString());
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
		public UnidadDeManejo.State EliminarUnidadDeManejo(UnidadDeManejo.Data _UnidadDeManejo)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar UnidadDeManejo", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_UnidadDeManejo_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idunidadmanejo", _UnidadDeManejo.idunidadmanejo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar UnidadDeManejo", _state.error.ToString());
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
