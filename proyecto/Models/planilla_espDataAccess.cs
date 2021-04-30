using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class planilla_espDataAccess
	{
		planilla_esp.State _state = new planilla_esp.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public planilla_esp Consultarplanilla_esp()
		{
		    _log.Traceo("Ingresa a Metodo Consultar planilla_esp", "0");
			List<planilla_esp.Data> lstplanilla_esp = new List<planilla_esp.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_esp_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					planilla_esp.Data _planilla_esp= new planilla_esp.Data();
					_planilla_esp.planilla_esp = Convert.ToInt32(rdr["planilla_esp"].ToString());
					_planilla_esp.descripcion = Convert.ToString(rdr["descripcion"].ToString());
					_planilla_esp.haber = Convert.ToInt32(rdr["haber"].ToString());
					_planilla_esp.tipo = Convert.ToString(rdr["tipo"].ToString());
					lstplanilla_esp.Add(_planilla_esp);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar planilla_esp", _state.error.ToString());
				return new planilla_esp(_state, lstplanilla_esp);
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
			return new planilla_esp(_state);
		}
		public planilla_esp Buscarplanilla_esp(planilla_esp.Data _planilla_espData)
		{
			List<planilla_esp.Data> lstplanilla_esp = new List<planilla_esp.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar planilla_esp", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_esp_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@planilla_esp", _planilla_espData.planilla_esp);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					planilla_esp.Data _planilla_esp= new planilla_esp.Data();
					_planilla_esp.planilla_esp = Convert.ToInt32(rdr["planilla_esp"].ToString());
					_planilla_esp.descripcion = Convert.ToString(rdr["descripcion"].ToString());
					_planilla_esp.haber = Convert.ToInt32(rdr["haber"].ToString());
					_planilla_esp.tipo = Convert.ToString(rdr["tipo"].ToString());
					lstplanilla_esp.Add(_planilla_esp);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar planilla_esp", _state.error.ToString());
				return new planilla_esp(_state, lstplanilla_esp);
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
			return new planilla_esp(_state);
		}
		public planilla_esp.State Insertarplanilla_esp(planilla_esp.Data _planilla_esp)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar planilla_esp", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_esp_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pplanilla_esp = new SqlParameter();
				pplanilla_esp.ParameterName = "@planilla_esp";
				pplanilla_esp.Value = 0;
				SqlCmd.Parameters.Add(pplanilla_esp);
				pplanilla_esp.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _planilla_esp.descripcion);
				SqlCmd.Parameters.AddWithValue("@haber", _planilla_esp.haber);
				SqlCmd.Parameters.AddWithValue("@tipo", _planilla_esp.tipo);

				SqlCmd.ExecuteNonQuery();
				_planilla_esp.planilla_esp = (System.Int32)pplanilla_esp.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar planilla_esp", _state.error.ToString());
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
		public planilla_esp.State Actualizarplanilla_esp(planilla_esp.Data _planilla_esp)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar planilla_esp", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_esp_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@planilla_esp", _planilla_esp.planilla_esp);
				SqlCmd.Parameters.AddWithValue("@descripcion", _planilla_esp.descripcion);
				SqlCmd.Parameters.AddWithValue("@haber", _planilla_esp.haber);
				SqlCmd.Parameters.AddWithValue("@tipo", _planilla_esp.tipo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar planilla_esp", _state.error.ToString());
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
		public planilla_esp.State Eliminarplanilla_esp(planilla_esp.Data _planilla_esp)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar planilla_esp", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_esp_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@planilla_esp", _planilla_esp.planilla_esp);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar planilla_esp", _state.error.ToString());
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
