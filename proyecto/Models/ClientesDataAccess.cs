using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class ClientesDataAccess
	{
		Clientes.State _state = new Clientes.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Clientes ConsultarClientes()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Clientes", "0");
			List<Clientes.Data> lstClientes = new List<Clientes.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Clientes_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Clientes.Data _Clientes= new Clientes.Data();
					_Clientes.codigocliente = Convert.ToString(rdr["codigocliente"].ToString().Trim());
					_Clientes.codigoclienteprincipal = !rdr.IsDBNull(1) ? Convert.ToString(rdr["codigoclienteprincipal"].ToString().Trim()) : "";
					_Clientes.iddocumentoidentidad = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["iddocumentoidentidad"].ToString()) : (System.Int16)0;
					_Clientes.numerodocumento = !rdr.IsDBNull(3) ? Convert.ToString(rdr["numerodocumento"].ToString().Trim()) : "";
					_Clientes.razonsocial = !rdr.IsDBNull(4) ? Convert.ToString(rdr["razonsocial"].ToString().Trim()) : "";
					_Clientes.idpais = !rdr.IsDBNull(5) ? Convert.ToInt16(rdr["idpais"].ToString()) : (System.Int16)0;
					_Clientes.idciudad = !rdr.IsDBNull(6) ? Convert.ToInt16(rdr["idciudad"].ToString()) : (System.Int16)0;
					_Clientes.idzona = !rdr.IsDBNull(7) ? Convert.ToInt16(rdr["idzona"].ToString()) : (System.Int16)0;
					_Clientes.idtipocliente = !rdr.IsDBNull(8) ? Convert.ToInt16(rdr["idtipocliente"].ToString()) : (System.Int16)0;
					_Clientes.descripciondireccion = !rdr.IsDBNull(9) ? Convert.ToString(rdr["descripciondireccion"].ToString().Trim()) : "";
					_Clientes.telefono = !rdr.IsDBNull(10) ? Convert.ToString(rdr["telefono"].ToString().Trim()) : "";
					_Clientes.correoelectronico = !rdr.IsDBNull(11) ? Convert.ToString(rdr["correoelectronico"].ToString().Trim()) : "";
					_Clientes.casillacorreo = !rdr.IsDBNull(12) ? Convert.ToString(rdr["casillacorreo"].ToString().Trim()) : "";
					_Clientes.cuentacontable = !rdr.IsDBNull(13) ? Convert.ToString(rdr["cuentacontable"].ToString().Trim()) : "";
					_Clientes.cuentacontableanticipos = !rdr.IsDBNull(14) ? Convert.ToString(rdr["cuentacontableanticipos"].ToString().Trim()) : "";
					_Clientes.activo = !rdr.IsDBNull(12) ? Convert.ToBoolean(rdr["activo"].ToString()) : true;
					lstClientes.Add(_Clientes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Clientes", _state.error.ToString());
				return new Clientes(_state, lstClientes);
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
			return new Clientes(_state);
		}
		public Clientes BuscarClientes(Clientes.Data _ClientesData)
		{
			List<Clientes.Data> lstClientes = new List<Clientes.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Clientes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Clientes_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigocliente", _ClientesData.codigocliente);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Clientes.Data _Clientes= new Clientes.Data();
                    _Clientes.codigocliente = Convert.ToString(rdr["codigocliente"].ToString().Trim());
                    _Clientes.codigoclienteprincipal = !rdr.IsDBNull(1) ? Convert.ToString(rdr["codigoclienteprincipal"].ToString().Trim()) : "";
                    _Clientes.iddocumentoidentidad = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["iddocumentoidentidad"].ToString()) : (System.Int16)0;
                    _Clientes.numerodocumento = !rdr.IsDBNull(3) ? Convert.ToString(rdr["numerodocumento"].ToString().Trim()) : "";
                    _Clientes.razonsocial = !rdr.IsDBNull(4) ? Convert.ToString(rdr["razonsocial"].ToString().Trim()) : "";
                    _Clientes.idpais = !rdr.IsDBNull(5) ? Convert.ToInt16(rdr["idpais"].ToString()) : (System.Int16)0;
                    _Clientes.idciudad = !rdr.IsDBNull(6) ? Convert.ToInt16(rdr["idciudad"].ToString()) : (System.Int16)0;
                    _Clientes.idzona = !rdr.IsDBNull(7) ? Convert.ToInt16(rdr["idzona"].ToString()) : (System.Int16)0;
                    _Clientes.idtipocliente = !rdr.IsDBNull(8) ? Convert.ToInt16(rdr["idtipocliente"].ToString()) : (System.Int16)0;
                    _Clientes.descripciondireccion = !rdr.IsDBNull(9) ? Convert.ToString(rdr["descripciondireccion"].ToString().Trim()) : "";
                    _Clientes.telefono = !rdr.IsDBNull(10) ? Convert.ToString(rdr["telefono"].ToString().Trim()) : "";
                    _Clientes.correoelectronico = !rdr.IsDBNull(11) ? Convert.ToString(rdr["correoelectronico"].ToString().Trim()) : "";
                    _Clientes.casillacorreo = !rdr.IsDBNull(12) ? Convert.ToString(rdr["casillacorreo"].ToString().Trim()) : "";
                    _Clientes.cuentacontable = !rdr.IsDBNull(13) ? Convert.ToString(rdr["cuentacontable"].ToString().Trim()) : "";
                    _Clientes.cuentacontableanticipos = !rdr.IsDBNull(14) ? Convert.ToString(rdr["cuentacontableanticipos"].ToString().Trim()) : "";
                    _Clientes.activo = !rdr.IsDBNull(12) ? Convert.ToBoolean(rdr["activo"].ToString()) : true;
                    lstClientes.Add(_Clientes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Clientes", _state.error.ToString());
				return new Clientes(_state, lstClientes);
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
			return new Clientes(_state);
		}
		public Clientes.State InsertarClientes(Clientes.Data _Clientes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Clientes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Clientes_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigocliente", _Clientes.codigocliente);
				SqlCmd.Parameters.AddWithValue("@codigoclienteprincipal", _Clientes.codigoclienteprincipal);
				SqlCmd.Parameters.AddWithValue("@iddocumentoidentidad", _Clientes.iddocumentoidentidad);
				SqlCmd.Parameters.AddWithValue("@numerodocumento", _Clientes.numerodocumento);
				SqlCmd.Parameters.AddWithValue("@razonsocial", _Clientes.razonsocial);
				SqlCmd.Parameters.AddWithValue("@idpais", _Clientes.idpais);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Clientes.idciudad);
				SqlCmd.Parameters.AddWithValue("@idzona", _Clientes.idzona);
				SqlCmd.Parameters.AddWithValue("@idtipocliente", _Clientes.idtipocliente);
				SqlCmd.Parameters.AddWithValue("@descripciondireccion", _Clientes.descripciondireccion);
				SqlCmd.Parameters.AddWithValue("@telefono", _Clientes.telefono);
				SqlCmd.Parameters.AddWithValue("@correoelectronico", _Clientes.correoelectronico);
				SqlCmd.Parameters.AddWithValue("@casillacorreo", _Clientes.casillacorreo);
				SqlCmd.Parameters.AddWithValue("@cuentacontable", _Clientes.cuentacontable);
				SqlCmd.Parameters.AddWithValue("@cuentacontableanticipos", _Clientes.cuentacontableanticipos);
				SqlCmd.Parameters.AddWithValue("@activo", _Clientes.activo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Clientes", _state.error.ToString());
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
		public Clientes.State ActualizarClientes(Clientes.Data _Clientes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Clientes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Clientes_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigocliente", _Clientes.codigocliente);
				SqlCmd.Parameters.AddWithValue("@codigoclienteprincipal", _Clientes.codigoclienteprincipal);
				SqlCmd.Parameters.AddWithValue("@iddocumentoidentidad", _Clientes.iddocumentoidentidad);
				SqlCmd.Parameters.AddWithValue("@numerodocumento", _Clientes.numerodocumento);
				SqlCmd.Parameters.AddWithValue("@razonsocial", _Clientes.razonsocial);
				SqlCmd.Parameters.AddWithValue("@idpais", _Clientes.idpais);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Clientes.idciudad);
				SqlCmd.Parameters.AddWithValue("@idzona", _Clientes.idzona);
				SqlCmd.Parameters.AddWithValue("@idtipocliente", _Clientes.idtipocliente);
				SqlCmd.Parameters.AddWithValue("@descripciondireccion", _Clientes.descripciondireccion);
				SqlCmd.Parameters.AddWithValue("@telefono", _Clientes.telefono);
				SqlCmd.Parameters.AddWithValue("@correoelectronico", _Clientes.correoelectronico);
				SqlCmd.Parameters.AddWithValue("@casillacorreo", _Clientes.casillacorreo);
				SqlCmd.Parameters.AddWithValue("@cuentacontable", _Clientes.cuentacontable);
				SqlCmd.Parameters.AddWithValue("@cuentacontableanticipos", _Clientes.cuentacontableanticipos);
				SqlCmd.Parameters.AddWithValue("@activo", _Clientes.activo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Clientes", _state.error.ToString());
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
		public Clientes.State EliminarClientes(Clientes.Data _Clientes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Clientes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Clientes_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigocliente", _Clientes.codigocliente);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Clientes", _state.error.ToString());
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
