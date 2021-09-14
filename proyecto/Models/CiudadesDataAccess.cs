using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class CiudadesDataAccess
	{
		Ciudades.State _state = new Ciudades.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Ciudades ConsultarCiudades()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Ciudades", "0");
			List<Ciudades.Data> lstCiudades = new List<Ciudades.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudades_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Ciudades.Data _Ciudades= new Ciudades.Data();
					_Ciudades.idciudad = Convert.ToInt16(rdr["idciudad"].ToString());
					_Ciudades.idpais = Convert.ToInt16(rdr["idpais"].ToString());
					_Ciudades.descripcion = !rdr.IsDBNull(2) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Ciudades.sigla = !rdr.IsDBNull(3) ? Convert.ToString(rdr["sigla"].ToString()) : "";
					_Ciudades.idmoneda = !rdr.IsDBNull(4) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					lstCiudades.Add(_Ciudades);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Ciudades", _state.error.ToString());
				return new Ciudades(_state, lstCiudades);
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
			return new Ciudades(_state);
		}
		public Ciudades ConsultarCiudadesFilter(Ciudades.Data _CiudadesData)
		{
			_log.Traceo("Ingresa a Metodo Consultar Ciudades", "0");
			List<Ciudades.Data> lstCiudades = new List<Ciudades.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudades_Filter", SqlCnn);
				SqlCmd.Parameters.AddWithValue("@IDPAIS", _CiudadesData.idpais);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Ciudades.Data _Ciudades = new Ciudades.Data();
					_Ciudades.idciudad = Convert.ToInt16(rdr["idciudad"].ToString());
					_Ciudades.idpais = Convert.ToInt16(rdr["idpais"].ToString());
					_Ciudades.descripcion = !rdr.IsDBNull(2) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Ciudades.sigla = !rdr.IsDBNull(3) ? Convert.ToString(rdr["sigla"].ToString()) : "";
					_Ciudades.idmoneda = !rdr.IsDBNull(4) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					lstCiudades.Add(_Ciudades);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Ciudades", _state.error.ToString());
				return new Ciudades(_state, lstCiudades);
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
			return new Ciudades(_state);
		}
		public Ciudades BuscarCiudades(Ciudades.Data _CiudadesData)
		{
			List<Ciudades.Data> lstCiudades = new List<Ciudades.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Ciudades", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudades_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idciudad", _CiudadesData.idciudad);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Ciudades.Data _Ciudades= new Ciudades.Data();
					_Ciudades.idciudad = Convert.ToInt16(rdr["idciudad"].ToString());
					_Ciudades.idpais = Convert.ToInt16(rdr["idpais"].ToString());
					_Ciudades.descripcion = !rdr.IsDBNull(2) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Ciudades.sigla = !rdr.IsDBNull(3) ? Convert.ToString(rdr["sigla"].ToString()) : "";
					_Ciudades.idmoneda = !rdr.IsDBNull(4) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					lstCiudades.Add(_Ciudades);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Ciudades", _state.error.ToString());
				return new Ciudades(_state, lstCiudades);
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
			return new Ciudades(_state);
		}
		public Ciudades.State InsertarCiudades(Ciudades.Data _Ciudades)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Ciudades", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudades_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDCiudad = new SqlParameter();
				pIDCiudad.ParameterName = "@IDCiudad";
				pIDCiudad.Value = 0;
				SqlCmd.Parameters.Add(pIDCiudad);
				pIDCiudad.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idpais", _Ciudades.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Ciudades.descripcion);
				SqlCmd.Parameters.AddWithValue("@sigla", _Ciudades.sigla);
				SqlCmd.Parameters.AddWithValue("@idmoneda", _Ciudades.idmoneda);

				SqlCmd.ExecuteNonQuery();
				//_Ciudades.idciudad = (System.Int16)pIDCiudad.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Ciudades", _state.error.ToString());
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
		public Ciudades.State ActualizarCiudades(Ciudades.Data _Ciudades)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Ciudades", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudades_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idciudad", _Ciudades.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _Ciudades.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Ciudades.descripcion);
				SqlCmd.Parameters.AddWithValue("@sigla", _Ciudades.sigla);
				SqlCmd.Parameters.AddWithValue("@idmoneda", _Ciudades.idmoneda);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Ciudades", _state.error.ToString());
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
		public Ciudades.State EliminarCiudades(Ciudades.Data _Ciudades)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Ciudades", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Ciudades_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idciudad", _Ciudades.idciudad);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Ciudades", _state.error.ToString());
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
