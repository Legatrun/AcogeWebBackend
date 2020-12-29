using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class CtasPresupDataAccess
	{
		CtasPresup.State _state = new CtasPresup.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public CtasPresup ConsultarCtasPresup()
		{
		    _log.Traceo("Ingresa a Metodo Consultar CtasPresup", "0");
			List<CtasPresup.Data> lstCtasPresup = new List<CtasPresup.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CtasPresup_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					CtasPresup.Data _CtasPresup= new CtasPresup.Data();
					_CtasPresup.cuentapresup = Convert.ToString(rdr["cuentapresup"].ToString());
					_CtasPresup.nombrecuentapresup = !rdr.IsDBNull(1) ? Convert.ToString(rdr["nombrecuentapresup"].ToString()) : "";
					_CtasPresup.idmoneda = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					_CtasPresup.nivel = !rdr.IsDBNull(3) ? Convert.ToInt32(rdr["nivel"].ToString()) : (System.Int32)0;
					_CtasPresup.fechacreacion = !rdr.IsDBNull(4) ? Convert.ToDateTime(rdr["fechacreacion"].ToString()) : System.DateTime.Now;
					_CtasPresup.fechamodificacion = !rdr.IsDBNull(5) ? Convert.ToDateTime(rdr["fechamodificacion"].ToString()) : System.DateTime.Now;
					_CtasPresup.balancecuenta = !rdr.IsDBNull(6) ? Convert.ToBoolean(rdr["balancecuenta"].ToString()) : true;
					_CtasPresup.cuentaasiento = !rdr.IsDBNull(7) ? Convert.ToBoolean(rdr["cuentaasiento"].ToString()) : true;
					_CtasPresup.grabado = !rdr.IsDBNull(8) ? Convert.ToBoolean(rdr["grabado"].ToString()) : true;
					lstCtasPresup.Add(_CtasPresup);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar CtasPresup", _state.error.ToString());
				return new CtasPresup(_state, lstCtasPresup);
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
			return new CtasPresup(_state);
		}
		public CtasPresup BuscarCtasPresup(CtasPresup.Data _CtasPresupData)
		{
			List<CtasPresup.Data> lstCtasPresup = new List<CtasPresup.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar CtasPresup", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CtasPresup_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@cuentapresup", _CtasPresupData.cuentapresup);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					CtasPresup.Data _CtasPresup= new CtasPresup.Data();
					_CtasPresup.cuentapresup = Convert.ToString(rdr["cuentapresup"].ToString());
					_CtasPresup.nombrecuentapresup = !rdr.IsDBNull(1) ? Convert.ToString(rdr["nombrecuentapresup"].ToString()) : "";
					_CtasPresup.idmoneda = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					_CtasPresup.nivel = !rdr.IsDBNull(3) ? Convert.ToInt32(rdr["nivel"].ToString()) : (System.Int32)0;
					_CtasPresup.fechacreacion = !rdr.IsDBNull(4) ? Convert.ToDateTime(rdr["fechacreacion"].ToString()) : System.DateTime.Now;
					_CtasPresup.fechamodificacion = !rdr.IsDBNull(5) ? Convert.ToDateTime(rdr["fechamodificacion"].ToString()) : System.DateTime.Now;
					_CtasPresup.balancecuenta = !rdr.IsDBNull(6) ? Convert.ToBoolean(rdr["balancecuenta"].ToString()) : true;
					_CtasPresup.cuentaasiento = !rdr.IsDBNull(7) ? Convert.ToBoolean(rdr["cuentaasiento"].ToString()) : true;
					_CtasPresup.grabado = !rdr.IsDBNull(8) ? Convert.ToBoolean(rdr["grabado"].ToString()) : true;
					lstCtasPresup.Add(_CtasPresup);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar CtasPresup", _state.error.ToString());
				return new CtasPresup(_state, lstCtasPresup);
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
			return new CtasPresup(_state);
		}
		public CtasPresup.State InsertarCtasPresup(CtasPresup.Data _CtasPresup)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar CtasPresup", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CtasPresup_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@cuentapresup", _CtasPresup.cuentapresup);
				SqlCmd.Parameters.AddWithValue("@nombrecuentapresup", _CtasPresup.nombrecuentapresup);
				SqlCmd.Parameters.AddWithValue("@idmoneda", _CtasPresup.idmoneda);
				SqlCmd.Parameters.AddWithValue("@nivel", _CtasPresup.nivel);
				SqlCmd.Parameters.AddWithValue("@fechacreacion", _CtasPresup.fechacreacion);
				SqlCmd.Parameters.AddWithValue("@fechamodificacion", _CtasPresup.fechamodificacion);
				SqlCmd.Parameters.AddWithValue("@balancecuenta", _CtasPresup.balancecuenta);
				SqlCmd.Parameters.AddWithValue("@cuentaasiento", _CtasPresup.cuentaasiento);
				SqlCmd.Parameters.AddWithValue("@grabado", _CtasPresup.grabado);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar CtasPresup", _state.error.ToString());
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
		public CtasPresup.State ActualizarCtasPresup(CtasPresup.Data _CtasPresup)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar CtasPresup", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CtasPresup_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@cuentapresup", _CtasPresup.cuentapresup);
				SqlCmd.Parameters.AddWithValue("@nombrecuentapresup", _CtasPresup.nombrecuentapresup);
				SqlCmd.Parameters.AddWithValue("@idmoneda", _CtasPresup.idmoneda);
				SqlCmd.Parameters.AddWithValue("@nivel", _CtasPresup.nivel);
				SqlCmd.Parameters.AddWithValue("@fechacreacion", _CtasPresup.fechacreacion);
				SqlCmd.Parameters.AddWithValue("@fechamodificacion", _CtasPresup.fechamodificacion);
				SqlCmd.Parameters.AddWithValue("@balancecuenta", _CtasPresup.balancecuenta);
				SqlCmd.Parameters.AddWithValue("@cuentaasiento", _CtasPresup.cuentaasiento);
				SqlCmd.Parameters.AddWithValue("@grabado", _CtasPresup.grabado);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar CtasPresup", _state.error.ToString());
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
		public CtasPresup.State EliminarCtasPresup(CtasPresup.Data _CtasPresup)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar CtasPresup", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CtasPresup_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@cuentapresup", _CtasPresup.cuentapresup);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar CtasPresup", _state.error.ToString());
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
