using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class AperturayCierreGestionDataAccess
	{
		AperturayCierreGestion.State _state = new AperturayCierreGestion.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public AperturayCierreGestion ConsultarAperturayCierreGestion()
		{
		    _log.Traceo("Ingresa a Metodo Consultar AperturayCierreGestion", "0");
			List<AperturayCierreGestion.Data> lstAperturayCierreGestion = new List<AperturayCierreGestion.Data>();
			try
			{
                //SqlConnection SqlCnn;
                //SqlCnn = Base.AbrirConexion();
                //SqlCommand SqlCmd = new SqlCommand("Proc_AperturayCierreGestion_Select", SqlCnn);
                //SqlCmd.CommandType = CommandType.StoredProcedure;
                //SqlDataReader rdr = SqlCmd.ExecuteReader();
                //while (rdr.Read())
                //{
                //	AperturayCierreGestion.Data _AperturayCierreGestion= new AperturayCierreGestion.Data();
                //	_AperturayCierreGestion.gestion = Convert.ToString(rdr["gestion"].ToString());
                //	_AperturayCierreGestion.mes = Convert.ToInt16(rdr["mes"].ToString());
                //	_AperturayCierreGestion.abierta = !rdr.IsDBNull(2) ? Convert.ToBoolean(rdr["abierta"].ToString()) : true;
                //	lstAperturayCierreGestion.Add(_AperturayCierreGestion);
                //}
                SqlConnection SqlCnn;
                SqlCnn = Base.AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand("Proc_AperturayCierreGestion_onlyGestion_Select", SqlCnn);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = SqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    AperturayCierreGestion.Data _AperturayCierreGestion = new AperturayCierreGestion.Data();
                    _AperturayCierreGestion.gestion = Convert.ToString(rdr["gestion"].ToString());
                    lstAperturayCierreGestion.Add(_AperturayCierreGestion);
                }
                Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar AperturayCierreGestion", _state.error.ToString());
				return new AperturayCierreGestion(_state, lstAperturayCierreGestion);
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
			return new AperturayCierreGestion(_state);
		}
		public AperturayCierreGestion BuscarAperturayCierreGestion(AperturayCierreGestion.Data _AperturayCierreGestionData)
		{
			List<AperturayCierreGestion.Data> lstAperturayCierreGestion = new List<AperturayCierreGestion.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar AperturayCierreGestion", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AperturayCierreGestion_onlyGestionSearch", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@gestion", _AperturayCierreGestionData.gestion);
				//SqlCmd.Parameters.AddWithValue("@mes", _AperturayCierreGestionData.mes);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					AperturayCierreGestion.Data _AperturayCierreGestion= new AperturayCierreGestion.Data();
					_AperturayCierreGestion.gestion = Convert.ToString(rdr["gestion"].ToString());
					_AperturayCierreGestion.mes = Convert.ToInt16(rdr["mes"].ToString());
					_AperturayCierreGestion.abierta = !rdr.IsDBNull(2) ? Convert.ToBoolean(rdr["abierta"].ToString()) : true;
					lstAperturayCierreGestion.Add(_AperturayCierreGestion);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar AperturayCierreGestion", _state.error.ToString());
				return new AperturayCierreGestion(_state, lstAperturayCierreGestion);
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
			return new AperturayCierreGestion(_state);
		}
		public AperturayCierreGestion.State InsertarAperturayCierreGestion(AperturayCierreGestion.Data _AperturayCierreGestion)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar AperturayCierreGestion", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("[Proc_AperturayCierreGestion_Autom_Insert]", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@gestion", _AperturayCierreGestion.gestion);
				//SqlCmd.Parameters.AddWithValue("@mes", _AperturayCierreGestion.mes);
				//SqlCmd.Parameters.AddWithValue("@abierta", _AperturayCierreGestion.abierta);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar AperturayCierreGestion", _state.error.ToString());
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
		public AperturayCierreGestion.State ActualizarAperturayCierreGestion(AperturayCierreGestion.Data _AperturayCierreGestion)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar AperturayCierreGestion", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AperturayCierreGestion_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@gestion", _AperturayCierreGestion.gestion);
				SqlCmd.Parameters.AddWithValue("@mes", _AperturayCierreGestion.mes);
				SqlCmd.Parameters.AddWithValue("@abierta", _AperturayCierreGestion.abierta);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar AperturayCierreGestion", _state.error.ToString());
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
		public AperturayCierreGestion.State EliminarAperturayCierreGestion(AperturayCierreGestion.Data _AperturayCierreGestion)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar AperturayCierreGestion", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_AperturayCierreGestion_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@gestion", _AperturayCierreGestion.gestion);
				SqlCmd.Parameters.AddWithValue("@mes", _AperturayCierreGestion.mes);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar AperturayCierreGestion", _state.error.ToString());
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
