using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class planilla_haberesDataAccess
	{
		planilla_haberes.State _state = new planilla_haberes.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public planilla_haberes Consultarplanilla_haberes()
		{
		    _log.Traceo("Ingresa a Metodo Consultar planilla_haberes", "0");
			List<planilla_haberes.Data> lstplanilla_haberes = new List<planilla_haberes.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_haberes_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					planilla_haberes.Data _planilla_haberes= new planilla_haberes.Data();
					_planilla_haberes.empleado = Convert.ToInt32(rdr["empleado"].ToString());
					_planilla_haberes.mes = Convert.ToInt16(rdr["mes"].ToString());
					_planilla_haberes.año = Convert.ToInt16(rdr["año"].ToString());
					_planilla_haberes.haber = Convert.ToInt32(rdr["haber"].ToString());
					_planilla_haberes.correlativo = Convert.ToInt16(rdr["correlativo"].ToString());
					_planilla_haberes.fecha = Convert.ToDateTime(rdr["fecha"].ToString());
					_planilla_haberes.valor = Convert.ToDouble(rdr["valor"].ToString());
					lstplanilla_haberes.Add(_planilla_haberes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar planilla_haberes", _state.error.ToString());
				return new planilla_haberes(_state, lstplanilla_haberes);
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
			return new planilla_haberes(_state);
		}
		public planilla_haberes Buscarplanilla_haberes(planilla_haberes.Data _planilla_haberesData)
		{
			List<planilla_haberes.Data> lstplanilla_haberes = new List<planilla_haberes.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar planilla_haberes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_haberes_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _planilla_haberesData.empleado);
				SqlCmd.Parameters.AddWithValue("@mes", _planilla_haberesData.mes);
				SqlCmd.Parameters.AddWithValue("@año", _planilla_haberesData.año);
				SqlCmd.Parameters.AddWithValue("@haber", _planilla_haberesData.haber);
				SqlCmd.Parameters.AddWithValue("@correlativo", _planilla_haberesData.correlativo);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					planilla_haberes.Data _planilla_haberes= new planilla_haberes.Data();
					_planilla_haberes.empleado = Convert.ToInt32(rdr["empleado"].ToString());
					_planilla_haberes.mes = Convert.ToInt16(rdr["mes"].ToString());
					_planilla_haberes.año = Convert.ToInt16(rdr["año"].ToString());
					_planilla_haberes.haber = Convert.ToInt32(rdr["haber"].ToString());
					_planilla_haberes.correlativo = Convert.ToInt16(rdr["correlativo"].ToString());
					_planilla_haberes.fecha = Convert.ToDateTime(rdr["fecha"].ToString());
					_planilla_haberes.valor = Convert.ToDouble(rdr["valor"].ToString());
					lstplanilla_haberes.Add(_planilla_haberes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar planilla_haberes", _state.error.ToString());
				return new planilla_haberes(_state, lstplanilla_haberes);
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
			return new planilla_haberes(_state);
		}
		public planilla_haberes.State Insertarplanilla_haberes(planilla_haberes.Data _planilla_haberes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar planilla_haberes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_haberes_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _planilla_haberes.empleado);
				SqlCmd.Parameters.AddWithValue("@mes", _planilla_haberes.mes);
				SqlCmd.Parameters.AddWithValue("@año", _planilla_haberes.año);
				SqlCmd.Parameters.AddWithValue("@haber", _planilla_haberes.haber);
				SqlCmd.Parameters.AddWithValue("@correlativo", _planilla_haberes.correlativo);
				SqlCmd.Parameters.AddWithValue("@fecha", _planilla_haberes.fecha);
				SqlCmd.Parameters.AddWithValue("@valor", _planilla_haberes.valor);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar planilla_haberes", _state.error.ToString());
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
		public planilla_haberes.State Actualizarplanilla_haberes(planilla_haberes.Data _planilla_haberes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar planilla_haberes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_haberes_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _planilla_haberes.empleado);
				SqlCmd.Parameters.AddWithValue("@mes", _planilla_haberes.mes);
				SqlCmd.Parameters.AddWithValue("@año", _planilla_haberes.año);
				SqlCmd.Parameters.AddWithValue("@haber", _planilla_haberes.haber);
				SqlCmd.Parameters.AddWithValue("@correlativo", _planilla_haberes.correlativo);
				SqlCmd.Parameters.AddWithValue("@fecha", _planilla_haberes.fecha);
				SqlCmd.Parameters.AddWithValue("@valor", _planilla_haberes.valor);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar planilla_haberes", _state.error.ToString());
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
		public planilla_haberes.State Eliminarplanilla_haberes(planilla_haberes.Data _planilla_haberes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar planilla_haberes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_haberes_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _planilla_haberes.empleado);
				SqlCmd.Parameters.AddWithValue("@mes", _planilla_haberes.mes);
				SqlCmd.Parameters.AddWithValue("@año", _planilla_haberes.año);
				SqlCmd.Parameters.AddWithValue("@haber", _planilla_haberes.haber);
				SqlCmd.Parameters.AddWithValue("@correlativo", _planilla_haberes.correlativo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar planilla_haberes", _state.error.ToString());
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
