using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class tipo_empleadoDataAccess
	{
		tipo_empleado.State _state = new tipo_empleado.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public tipo_empleado Consultartipo_empleado()
		{
		    _log.Traceo("Ingresa a Metodo Consultar tipo_empleado", "0");
			List<tipo_empleado.Data> lsttipo_empleado = new List<tipo_empleado.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tipo_empleado_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tipo_empleado.Data _tipo_empleado= new tipo_empleado.Data();
					_tipo_empleado.tipo_empleado = Convert.ToInt32(rdr["tipo_empleado"].ToString());
					_tipo_empleado.nombre = Convert.ToString(rdr["nombre"].ToString());
					lsttipo_empleado.Add(_tipo_empleado);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar tipo_empleado", _state.error.ToString());
				return new tipo_empleado(_state, lsttipo_empleado);
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
			return new tipo_empleado(_state);
		}
		public tipo_empleado Buscartipo_empleado(tipo_empleado.Data _tipo_empleadoData)
		{
			List<tipo_empleado.Data> lsttipo_empleado = new List<tipo_empleado.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar tipo_empleado", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tipo_empleado_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@tipo_empleado", _tipo_empleadoData.tipo_empleado);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tipo_empleado.Data _tipo_empleado= new tipo_empleado.Data();
					_tipo_empleado.tipo_empleado = Convert.ToInt32(rdr["tipo_empleado"].ToString());
					_tipo_empleado.nombre = Convert.ToString(rdr["nombre"].ToString());
					lsttipo_empleado.Add(_tipo_empleado);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar tipo_empleado", _state.error.ToString());
				return new tipo_empleado(_state, lsttipo_empleado);
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
			return new tipo_empleado(_state);
		}
		public tipo_empleado.State Insertartipo_empleado(tipo_empleado.Data _tipo_empleado)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar tipo_empleado", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tipo_empleado_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter ptipo_empleado = new SqlParameter();
				ptipo_empleado.ParameterName = "@tipo_empleado";
				ptipo_empleado.Value = 0;
				SqlCmd.Parameters.Add(ptipo_empleado);
				ptipo_empleado.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@nombre", _tipo_empleado.nombre);

				SqlCmd.ExecuteNonQuery();
				_tipo_empleado.tipo_empleado = (System.Int32)ptipo_empleado.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar tipo_empleado", _state.error.ToString());
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
		public tipo_empleado.State Actualizartipo_empleado(tipo_empleado.Data _tipo_empleado)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar tipo_empleado", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tipo_empleado_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@tipo_empleado", _tipo_empleado.tipo_empleado);
				SqlCmd.Parameters.AddWithValue("@nombre", _tipo_empleado.nombre);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar tipo_empleado", _state.error.ToString());
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
		public tipo_empleado.State Eliminartipo_empleado(tipo_empleado.Data _tipo_empleado)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar tipo_empleado", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tipo_empleado_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@tipo_empleado", _tipo_empleado.tipo_empleado);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar tipo_empleado", _state.error.ToString());
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
