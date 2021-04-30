using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class tipo_descuentoDataAccess
	{
		tipo_descuento.State _state = new tipo_descuento.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public tipo_descuento Consultartipo_descuento()
		{
		    _log.Traceo("Ingresa a Metodo Consultar tipo_descuento", "0");
			List<tipo_descuento.Data> lsttipo_descuento = new List<tipo_descuento.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tipo_descuento_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tipo_descuento.Data _tipo_descuento= new tipo_descuento.Data();
					_tipo_descuento.tipo_descuento = Convert.ToInt32(rdr["tipo_descuento"].ToString());
					_tipo_descuento.nombre = Convert.ToString(rdr["nombre"].ToString());
					lsttipo_descuento.Add(_tipo_descuento);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar tipo_descuento", _state.error.ToString());
				return new tipo_descuento(_state, lsttipo_descuento);
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
			return new tipo_descuento(_state);
		}
		public tipo_descuento Buscartipo_descuento(tipo_descuento.Data _tipo_descuentoData)
		{
			List<tipo_descuento.Data> lsttipo_descuento = new List<tipo_descuento.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar tipo_descuento", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tipo_descuento_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@tipo_descuento", _tipo_descuentoData.tipo_descuento);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					tipo_descuento.Data _tipo_descuento= new tipo_descuento.Data();
					_tipo_descuento.tipo_descuento = Convert.ToInt32(rdr["tipo_descuento"].ToString());
					_tipo_descuento.nombre = Convert.ToString(rdr["nombre"].ToString());
					lsttipo_descuento.Add(_tipo_descuento);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar tipo_descuento", _state.error.ToString());
				return new tipo_descuento(_state, lsttipo_descuento);
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
			return new tipo_descuento(_state);
		}
		public tipo_descuento.State Insertartipo_descuento(tipo_descuento.Data _tipo_descuento)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar tipo_descuento", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tipo_descuento_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter ptipo_descuento = new SqlParameter();
				ptipo_descuento.ParameterName = "@tipo_descuento";
				ptipo_descuento.Value = 0;
				SqlCmd.Parameters.Add(ptipo_descuento);
				ptipo_descuento.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@nombre", _tipo_descuento.nombre);

				SqlCmd.ExecuteNonQuery();
				_tipo_descuento.tipo_descuento = (System.Int32)ptipo_descuento.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar tipo_descuento", _state.error.ToString());
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
		public tipo_descuento.State Actualizartipo_descuento(tipo_descuento.Data _tipo_descuento)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar tipo_descuento", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tipo_descuento_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@tipo_descuento", _tipo_descuento.tipo_descuento);
				SqlCmd.Parameters.AddWithValue("@nombre", _tipo_descuento.nombre);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar tipo_descuento", _state.error.ToString());
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
		public tipo_descuento.State Eliminartipo_descuento(tipo_descuento.Data _tipo_descuento)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar tipo_descuento", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_tipo_descuento_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@tipo_descuento", _tipo_descuento.tipo_descuento);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar tipo_descuento", _state.error.ToString());
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
