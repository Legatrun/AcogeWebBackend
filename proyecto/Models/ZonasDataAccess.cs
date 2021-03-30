using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class ZonasDataAccess
	{
		Zonas.State _state = new Zonas.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Zonas ConsultarZonas()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Zonas", "0");
			List<Zonas.Data> lstZonas = new List<Zonas.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Zonas_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Zonas.Data _Zonas= new Zonas.Data();
					_Zonas.idzona = Convert.ToInt16(rdr["idzona"].ToString());
					_Zonas.idpais = !rdr.IsDBNull(1) ? Convert.ToInt16(rdr["idpais"].ToString()) : (System.Int16)0;
					_Zonas.idciudad = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["idciudad"].ToString()) : (System.Int16)0;
					_Zonas.descripcion = !rdr.IsDBNull(3) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					lstZonas.Add(_Zonas);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Zonas", _state.error.ToString());
				return new Zonas(_state, lstZonas);
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
			return new Zonas(_state);
		}
		public Zonas BuscarZonas(Zonas.Data _ZonasData)
		{
			List<Zonas.Data> lstZonas = new List<Zonas.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Zonas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Zonas_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idzona", _ZonasData.idzona);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Zonas.Data _Zonas= new Zonas.Data();
					_Zonas.idzona = Convert.ToInt16(rdr["idzona"].ToString());
					_Zonas.idpais = !rdr.IsDBNull(1) ? Convert.ToInt16(rdr["idpais"].ToString()) : (System.Int16)0;
					_Zonas.idciudad = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["idciudad"].ToString()) : (System.Int16)0;
					_Zonas.descripcion = !rdr.IsDBNull(3) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					lstZonas.Add(_Zonas);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Zonas", _state.error.ToString());
				return new Zonas(_state, lstZonas);
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
			return new Zonas(_state);
		}
		public Zonas.State InsertarZonas(Zonas.Data _Zonas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Zonas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Zonas_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDZona = new SqlParameter();
				pIDZona.ParameterName = "@IDZona";
				pIDZona.Value = 0;
				SqlCmd.Parameters.Add(pIDZona);
				pIDZona.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idpais", _Zonas.idpais);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Zonas.idciudad);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Zonas.descripcion);

				SqlCmd.ExecuteNonQuery();
				//_Zonas.idzona = (System.Int16)pIDZona.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Zonas", _state.error.ToString());
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
		public Zonas.State ActualizarZonas(Zonas.Data _Zonas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Zonas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Zonas_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idzona", _Zonas.idzona);
				SqlCmd.Parameters.AddWithValue("@idpais", _Zonas.idpais);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Zonas.idciudad);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Zonas.descripcion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Zonas", _state.error.ToString());
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
		public Zonas.State EliminarZonas(Zonas.Data _Zonas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Zonas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Zonas_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idzona", _Zonas.idzona);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Zonas", _state.error.ToString());
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
