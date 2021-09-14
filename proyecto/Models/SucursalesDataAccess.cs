using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class SucursalesDataAccess
	{
		Sucursales.State _state = new Sucursales.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Sucursales ConsultarSucursales()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Sucursales", "0");
			List<Sucursales.Data> lstSucursales = new List<Sucursales.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Sucursales_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Sucursales.Data _Sucursales= new Sucursales.Data();
					_Sucursales.idsucursal = Convert.ToInt16(rdr["idsucursal"].ToString());
					_Sucursales.idempresa = Convert.ToInt16(rdr["idempresa"].ToString());
					_Sucursales.idzona = Convert.ToInt16(rdr["idzona"].ToString());
					_Sucursales.nombre = Convert.ToString(rdr["nombre"].ToString()).Trim();
					_Sucursales.direccion = Convert.ToString(rdr["direccion"].ToString()).Trim();
					_Sucursales.numero = !rdr.IsDBNull(5) ? Convert.ToInt32(rdr["numero"].ToString()) : (System.Int32)0;
					_Sucursales.telefonos = !rdr.IsDBNull(6) ? Convert.ToString(rdr["telefonos"].ToString()) : "";
					_Sucursales.email = !rdr.IsDBNull(7) ? Convert.ToString(rdr["email"].ToString()) : "";
					_Sucursales.codigopostal = !rdr.IsDBNull(8) ? Convert.ToString(rdr["codigopostal"].ToString()).Trim() : "";
					lstSucursales.Add(_Sucursales);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Sucursales", _state.error.ToString());
				return new Sucursales(_state, lstSucursales);
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
			return new Sucursales(_state);
		}
		public Sucursales BuscarSucursales(Sucursales.Data _SucursalesData)
		{
			List<Sucursales.Data> lstSucursales = new List<Sucursales.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Sucursales", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Sucursales_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idsucursal", _SucursalesData.idsucursal);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Sucursales.Data _Sucursales= new Sucursales.Data();
					_Sucursales.idsucursal = Convert.ToInt16(rdr["idsucursal"].ToString());
					_Sucursales.idempresa = Convert.ToInt16(rdr["idempresa"].ToString());
					_Sucursales.idzona = Convert.ToInt16(rdr["idzona"].ToString());
					_Sucursales.nombre = Convert.ToString(rdr["nombre"].ToString());
					_Sucursales.direccion = Convert.ToString(rdr["direccion"].ToString());
					_Sucursales.numero = !rdr.IsDBNull(5) ? Convert.ToInt32(rdr["numero"].ToString()) : (System.Int32)0;
					_Sucursales.telefonos = !rdr.IsDBNull(6) ? Convert.ToString(rdr["telefonos"].ToString()) : "";
					_Sucursales.email = !rdr.IsDBNull(7) ? Convert.ToString(rdr["email"].ToString()) : "";
					_Sucursales.codigopostal = !rdr.IsDBNull(8) ? Convert.ToString(rdr["codigopostal"].ToString()) : "";
					lstSucursales.Add(_Sucursales);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Sucursales", _state.error.ToString());
				return new Sucursales(_state, lstSucursales);
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
			return new Sucursales(_state);
		}
		public Sucursales.State InsertarSucursales(Sucursales.Data _Sucursales)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Sucursales", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Sucursales_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idsucursal", _Sucursales.idsucursal);
				SqlCmd.Parameters.AddWithValue("@idempresa", _Sucursales.idempresa);
				SqlCmd.Parameters.AddWithValue("@idzona", _Sucursales.idzona);
				SqlCmd.Parameters.AddWithValue("@nombre", _Sucursales.nombre);
				SqlCmd.Parameters.AddWithValue("@direccion", _Sucursales.direccion);
				SqlCmd.Parameters.AddWithValue("@numero", _Sucursales.numero);
				SqlCmd.Parameters.AddWithValue("@telefonos", _Sucursales.telefonos);
				SqlCmd.Parameters.AddWithValue("@email", _Sucursales.email);
				SqlCmd.Parameters.AddWithValue("@codigopostal", _Sucursales.codigopostal);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Sucursales", _state.error.ToString());
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
		public Sucursales.State ActualizarSucursales(Sucursales.Data _Sucursales)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Sucursales", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Sucursales_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idsucursal", _Sucursales.idsucursal);
				SqlCmd.Parameters.AddWithValue("@idempresa", _Sucursales.idempresa);
				SqlCmd.Parameters.AddWithValue("@idzona", _Sucursales.idzona);
				SqlCmd.Parameters.AddWithValue("@nombre", _Sucursales.nombre);
				SqlCmd.Parameters.AddWithValue("@direccion", _Sucursales.direccion);
				SqlCmd.Parameters.AddWithValue("@numero", _Sucursales.numero);
				SqlCmd.Parameters.AddWithValue("@telefonos", _Sucursales.telefonos);
				SqlCmd.Parameters.AddWithValue("@email", _Sucursales.email);
				SqlCmd.Parameters.AddWithValue("@codigopostal", _Sucursales.codigopostal);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Sucursales", _state.error.ToString());
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
		public Sucursales.State EliminarSucursales(Sucursales.Data _Sucursales)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Sucursales", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Sucursales_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idsucursal", _Sucursales.idsucursal);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Sucursales", _state.error.ToString());
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
