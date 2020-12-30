using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class ProveedoresDataAccess
	{
		Proveedores.State _state = new Proveedores.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Proveedores ConsultarProveedores()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Proveedores", "0");
			List<Proveedores.Data> lstProveedores = new List<Proveedores.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Proveedores_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Proveedores.Data _Proveedores= new Proveedores.Data();
					_Proveedores.codigoproveedor = Convert.ToString(rdr["codigoproveedor"].ToString());
					_Proveedores.iddocumentoidentidad = !rdr.IsDBNull(1) ? Convert.ToInt16(rdr["iddocumentoidentidad"].ToString()) : (System.Int16)0;
					_Proveedores.numerodocumento = !rdr.IsDBNull(2) ? Convert.ToString(rdr["numerodocumento"].ToString()) : "";
					_Proveedores.razonsocial = !rdr.IsDBNull(3) ? Convert.ToString(rdr["razonsocial"].ToString()) : "";
					_Proveedores.direccion = !rdr.IsDBNull(4) ? Convert.ToString(rdr["direccion"].ToString()) : "";
					_Proveedores.idpais = !rdr.IsDBNull(5) ? Convert.ToInt16(rdr["idpais"].ToString()) : (System.Int16)0;
					_Proveedores.idciudad = !rdr.IsDBNull(6) ? Convert.ToInt16(rdr["idciudad"].ToString()) : (System.Int16)0;
					_Proveedores.idmoneda = !rdr.IsDBNull(7) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					_Proveedores.contacto = !rdr.IsDBNull(8) ? Convert.ToString(rdr["contacto"].ToString()) : "";
					_Proveedores.telefonos = !rdr.IsDBNull(9) ? Convert.ToString(rdr["telefonos"].ToString()) : "";
					_Proveedores.fax = !rdr.IsDBNull(10) ? Convert.ToString(rdr["fax"].ToString()) : "";
					_Proveedores.cuenta = !rdr.IsDBNull(11) ? Convert.ToString(rdr["cuenta"].ToString()) : "";
					_Proveedores.idtipoproveedor = !rdr.IsDBNull(12) ? Convert.ToInt16(rdr["idtipoproveedor"].ToString()) : (System.Int16)0;
					_Proveedores.fechacreacion = !rdr.IsDBNull(14) ? Convert.ToDateTime(rdr["fechacreacion"].ToString()) : System.DateTime.Now;
					_Proveedores.codaduana = !rdr.IsDBNull(14) ? Convert.ToString(rdr["codaduana"].ToString()) : "";
					lstProveedores.Add(_Proveedores);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Proveedores", _state.error.ToString());
				return new Proveedores(_state, lstProveedores);
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
			return new Proveedores(_state);
		}
		public Proveedores BuscarProveedores(Proveedores.Data _ProveedoresData)
		{
			List<Proveedores.Data> lstProveedores = new List<Proveedores.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Proveedores", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Proveedores_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigoproveedor", _ProveedoresData.codigoproveedor);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Proveedores.Data _Proveedores= new Proveedores.Data();
					_Proveedores.codigoproveedor = Convert.ToString(rdr["codigoproveedor"].ToString());
					_Proveedores.iddocumentoidentidad = !rdr.IsDBNull(1) ? Convert.ToInt16(rdr["iddocumentoidentidad"].ToString()) : (System.Int16)0;
					_Proveedores.numerodocumento = !rdr.IsDBNull(2) ? Convert.ToString(rdr["numerodocumento"].ToString()) : "";
					_Proveedores.razonsocial = !rdr.IsDBNull(3) ? Convert.ToString(rdr["razonsocial"].ToString()) : "";
					_Proveedores.direccion = !rdr.IsDBNull(4) ? Convert.ToString(rdr["direccion"].ToString()) : "";
					_Proveedores.idpais = !rdr.IsDBNull(5) ? Convert.ToInt16(rdr["idpais"].ToString()) : (System.Int16)0;
					_Proveedores.idciudad = !rdr.IsDBNull(6) ? Convert.ToInt16(rdr["idciudad"].ToString()) : (System.Int16)0;
					_Proveedores.idmoneda = !rdr.IsDBNull(7) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					_Proveedores.contacto = !rdr.IsDBNull(8) ? Convert.ToString(rdr["contacto"].ToString()) : "";
					_Proveedores.telefonos = !rdr.IsDBNull(9) ? Convert.ToString(rdr["telefonos"].ToString()) : "";
					_Proveedores.fax = !rdr.IsDBNull(10) ? Convert.ToString(rdr["fax"].ToString()) : "";
					_Proveedores.cuenta = !rdr.IsDBNull(11) ? Convert.ToString(rdr["cuenta"].ToString()) : "";
					_Proveedores.idtipoproveedor = !rdr.IsDBNull(12) ? Convert.ToInt16(rdr["idtipoproveedor"].ToString()) : (System.Int16)0;
					_Proveedores.fechacreacion = !rdr.IsDBNull(14) ? Convert.ToDateTime(rdr["fechacreacion"].ToString()) : System.DateTime.Now;
					_Proveedores.codaduana = !rdr.IsDBNull(15) ? Convert.ToString(rdr["codaduana"].ToString()) : "";
					lstProveedores.Add(_Proveedores);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Proveedores", _state.error.ToString());
				return new Proveedores(_state, lstProveedores);
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
			return new Proveedores(_state);
		}
		public Proveedores.State InsertarProveedores(Proveedores.Data _Proveedores)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Proveedores", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Proveedores_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigoproveedor", _Proveedores.codigoproveedor);
				SqlCmd.Parameters.AddWithValue("@iddocumentoidentidad", _Proveedores.iddocumentoidentidad);
				SqlCmd.Parameters.AddWithValue("@numerodocumento", _Proveedores.numerodocumento);
				SqlCmd.Parameters.AddWithValue("@razonsocial", _Proveedores.razonsocial);
				SqlCmd.Parameters.AddWithValue("@direccion", _Proveedores.direccion);
				SqlCmd.Parameters.AddWithValue("@idpais", _Proveedores.idpais);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Proveedores.idciudad);
				SqlCmd.Parameters.AddWithValue("@idmoneda", _Proveedores.idmoneda);
				SqlCmd.Parameters.AddWithValue("@contacto", _Proveedores.contacto);
				SqlCmd.Parameters.AddWithValue("@telefonos", _Proveedores.telefonos);
				SqlCmd.Parameters.AddWithValue("@fax", _Proveedores.fax);
				SqlCmd.Parameters.AddWithValue("@cuenta", _Proveedores.cuenta);
				SqlCmd.Parameters.AddWithValue("@idtipoproveedor", _Proveedores.idtipoproveedor);
				SqlCmd.Parameters.AddWithValue("@fechacreacion", _Proveedores.fechacreacion);
				SqlCmd.Parameters.AddWithValue("@codaduana", _Proveedores.codaduana);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Proveedores", _state.error.ToString());
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
		public Proveedores.State ActualizarProveedores(Proveedores.Data _Proveedores)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Proveedores", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Proveedores_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigoproveedor", _Proveedores.codigoproveedor);
				SqlCmd.Parameters.AddWithValue("@iddocumentoidentidad", _Proveedores.iddocumentoidentidad);
				SqlCmd.Parameters.AddWithValue("@numerodocumento", _Proveedores.numerodocumento);
				SqlCmd.Parameters.AddWithValue("@razonsocial", _Proveedores.razonsocial);
				SqlCmd.Parameters.AddWithValue("@direccion", _Proveedores.direccion);
				SqlCmd.Parameters.AddWithValue("@idpais", _Proveedores.idpais);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Proveedores.idciudad);
				SqlCmd.Parameters.AddWithValue("@idmoneda", _Proveedores.idmoneda);
				SqlCmd.Parameters.AddWithValue("@contacto", _Proveedores.contacto);
				SqlCmd.Parameters.AddWithValue("@telefonos", _Proveedores.telefonos);
				SqlCmd.Parameters.AddWithValue("@fax", _Proveedores.fax);
				SqlCmd.Parameters.AddWithValue("@cuenta", _Proveedores.cuenta);
				SqlCmd.Parameters.AddWithValue("@idtipoproveedor", _Proveedores.idtipoproveedor);
				SqlCmd.Parameters.AddWithValue("@fechacreacion", _Proveedores.fechacreacion);
				SqlCmd.Parameters.AddWithValue("@codaduana", _Proveedores.codaduana);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Proveedores", _state.error.ToString());
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
		public Proveedores.State EliminarProveedores(Proveedores.Data _Proveedores)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Proveedores", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Proveedores_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigoproveedor", _Proveedores.codigoproveedor);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Proveedores", _state.error.ToString());
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
