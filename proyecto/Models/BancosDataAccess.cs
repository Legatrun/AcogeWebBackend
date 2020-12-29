using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class BancosDataAccess
	{
		Bancos.State _state = new Bancos.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Bancos ConsultarBancos()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Bancos", "0");
			List<Bancos.Data> lstBancos = new List<Bancos.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Bancos_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Bancos.Data _Bancos= new Bancos.Data();
					_Bancos.idbanco = Convert.ToInt16(rdr["idbanco"].ToString());
					_Bancos.nit = !rdr.IsDBNull(1) ? Convert.ToString(rdr["nit"].ToString()) : "";
					_Bancos.descripcion = !rdr.IsDBNull(2) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Bancos.bancopropio = !rdr.IsDBNull(3) ? Convert.ToBoolean(rdr["bancopropio"].ToString()) : true;
					_Bancos.idpais = !rdr.IsDBNull(4) ? Convert.ToInt32(rdr["idpais"].ToString()) : (System.Int32)0;
					_Bancos.idciudad = !rdr.IsDBNull(5) ? Convert.ToInt32(rdr["idciudad"].ToString()) : (System.Int32)0;
					lstBancos.Add(_Bancos);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Bancos", _state.error.ToString());
				return new Bancos(_state, lstBancos);
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
			return new Bancos(_state);
		}
		public Bancos BuscarBancos(Bancos.Data _BancosData)
		{
			List<Bancos.Data> lstBancos = new List<Bancos.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Bancos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Bancos_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idbanco", _BancosData.idbanco);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Bancos.Data _Bancos= new Bancos.Data();
					_Bancos.idbanco = Convert.ToInt16(rdr["idbanco"].ToString());
					_Bancos.nit = !rdr.IsDBNull(1) ? Convert.ToString(rdr["nit"].ToString()) : "";
					_Bancos.descripcion = !rdr.IsDBNull(2) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Bancos.bancopropio = !rdr.IsDBNull(3) ? Convert.ToBoolean(rdr["bancopropio"].ToString()) : true;
					_Bancos.idpais = !rdr.IsDBNull(4) ? Convert.ToInt32(rdr["idpais"].ToString()) : (System.Int32)0;
					_Bancos.idciudad = !rdr.IsDBNull(5) ? Convert.ToInt32(rdr["idciudad"].ToString()) : (System.Int32)0;
					lstBancos.Add(_Bancos);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Bancos", _state.error.ToString());
				return new Bancos(_state, lstBancos);
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
			return new Bancos(_state);
		}
		public Bancos.State InsertarBancos(Bancos.Data _Bancos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Bancos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Bancos_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDBanco = new SqlParameter();
				pIDBanco.ParameterName = "@IDBanco";
				pIDBanco.Value = 0;
				SqlCmd.Parameters.Add(pIDBanco);
				pIDBanco.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@nit", _Bancos.nit);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Bancos.descripcion);
				SqlCmd.Parameters.AddWithValue("@bancopropio", _Bancos.bancopropio);
				SqlCmd.Parameters.AddWithValue("@idpais", _Bancos.idpais);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Bancos.idciudad);

				SqlCmd.ExecuteNonQuery();
				_Bancos.idbanco = (System.Int16)pIDBanco.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Bancos", _state.error.ToString());
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
		public Bancos.State ActualizarBancos(Bancos.Data _Bancos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Bancos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Bancos_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idbanco", _Bancos.idbanco);
				SqlCmd.Parameters.AddWithValue("@nit", _Bancos.nit);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Bancos.descripcion);
				SqlCmd.Parameters.AddWithValue("@bancopropio", _Bancos.bancopropio);
				SqlCmd.Parameters.AddWithValue("@idpais", _Bancos.idpais);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Bancos.idciudad);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Bancos", _state.error.ToString());
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
		public Bancos.State EliminarBancos(Bancos.Data _Bancos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Bancos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Bancos_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idbanco", _Bancos.idbanco);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Bancos", _state.error.ToString());
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
