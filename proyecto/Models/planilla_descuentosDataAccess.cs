using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class planilla_descuentosDataAccess
	{
		planilla_descuentos.State _state = new planilla_descuentos.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public planilla_descuentos Consultarplanilla_descuentos()
		{
		    _log.Traceo("Ingresa a Metodo Consultar planilla_descuentos", "0");
			List<planilla_descuentos.Data> lstplanilla_descuentos = new List<planilla_descuentos.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_descuentos_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					planilla_descuentos.Data _planilla_descuentos= new planilla_descuentos.Data();
					_planilla_descuentos.empleado = Convert.ToInt32(rdr["empleado"].ToString());
					_planilla_descuentos.mes = Convert.ToInt16(rdr["mes"].ToString());
					_planilla_descuentos.año = Convert.ToInt16(rdr["año"].ToString());
					_planilla_descuentos.descuento = Convert.ToInt32(rdr["descuento"].ToString());
					_planilla_descuentos.correlativo = Convert.ToInt16(rdr["correlativo"].ToString());
					_planilla_descuentos.fecha = Convert.ToDateTime(rdr["fecha"].ToString());
					_planilla_descuentos.valor = Convert.ToDouble(rdr["valor"].ToString());
					lstplanilla_descuentos.Add(_planilla_descuentos);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar planilla_descuentos", _state.error.ToString());
				return new planilla_descuentos(_state, lstplanilla_descuentos);
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
			return new planilla_descuentos(_state);
		}
		public planilla_descuentos Buscarplanilla_descuentos(planilla_descuentos.Data _planilla_descuentosData)
		{
			List<planilla_descuentos.Data> lstplanilla_descuentos = new List<planilla_descuentos.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar planilla_descuentos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_descuentos_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _planilla_descuentosData.empleado);
				SqlCmd.Parameters.AddWithValue("@mes", _planilla_descuentosData.mes);
				SqlCmd.Parameters.AddWithValue("@año", _planilla_descuentosData.año);
				SqlCmd.Parameters.AddWithValue("@descuento", _planilla_descuentosData.descuento);
				SqlCmd.Parameters.AddWithValue("@correlativo", _planilla_descuentosData.correlativo);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					planilla_descuentos.Data _planilla_descuentos= new planilla_descuentos.Data();
					_planilla_descuentos.empleado = Convert.ToInt32(rdr["empleado"].ToString());
					_planilla_descuentos.mes = Convert.ToInt16(rdr["mes"].ToString());
					_planilla_descuentos.año = Convert.ToInt16(rdr["año"].ToString());
					_planilla_descuentos.descuento = Convert.ToInt32(rdr["descuento"].ToString());
					_planilla_descuentos.correlativo = Convert.ToInt16(rdr["correlativo"].ToString());
					_planilla_descuentos.fecha = Convert.ToDateTime(rdr["fecha"].ToString());
					_planilla_descuentos.valor = Convert.ToDouble(rdr["valor"].ToString());
					lstplanilla_descuentos.Add(_planilla_descuentos);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar planilla_descuentos", _state.error.ToString());
				return new planilla_descuentos(_state, lstplanilla_descuentos);
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
			return new planilla_descuentos(_state);
		}
		public planilla_descuentos.State Insertarplanilla_descuentos(planilla_descuentos.Data _planilla_descuentos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar planilla_descuentos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_descuentos_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _planilla_descuentos.empleado);
				SqlCmd.Parameters.AddWithValue("@mes", _planilla_descuentos.mes);
				SqlCmd.Parameters.AddWithValue("@año", _planilla_descuentos.año);
				SqlCmd.Parameters.AddWithValue("@descuento", _planilla_descuentos.descuento);
				SqlCmd.Parameters.AddWithValue("@correlativo", _planilla_descuentos.correlativo);
				SqlCmd.Parameters.AddWithValue("@fecha", _planilla_descuentos.fecha);
				SqlCmd.Parameters.AddWithValue("@valor", _planilla_descuentos.valor);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar planilla_descuentos", _state.error.ToString());
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
		public planilla_descuentos.State Actualizarplanilla_descuentos(planilla_descuentos.Data _planilla_descuentos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar planilla_descuentos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_descuentos_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _planilla_descuentos.empleado);
				SqlCmd.Parameters.AddWithValue("@mes", _planilla_descuentos.mes);
				SqlCmd.Parameters.AddWithValue("@año", _planilla_descuentos.año);
				SqlCmd.Parameters.AddWithValue("@descuento", _planilla_descuentos.descuento);
				SqlCmd.Parameters.AddWithValue("@correlativo", _planilla_descuentos.correlativo);
				SqlCmd.Parameters.AddWithValue("@fecha", _planilla_descuentos.fecha);
				SqlCmd.Parameters.AddWithValue("@valor", _planilla_descuentos.valor);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar planilla_descuentos", _state.error.ToString());
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
		public planilla_descuentos.State Eliminarplanilla_descuentos(planilla_descuentos.Data _planilla_descuentos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar planilla_descuentos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_planilla_descuentos_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _planilla_descuentos.empleado);
				SqlCmd.Parameters.AddWithValue("@mes", _planilla_descuentos.mes);
				SqlCmd.Parameters.AddWithValue("@año", _planilla_descuentos.año);
				SqlCmd.Parameters.AddWithValue("@descuento", _planilla_descuentos.descuento);
				SqlCmd.Parameters.AddWithValue("@correlativo", _planilla_descuentos.correlativo);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar planilla_descuentos", _state.error.ToString());
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
