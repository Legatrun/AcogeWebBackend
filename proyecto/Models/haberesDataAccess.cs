using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class haberesDataAccess
	{
		haberes.State _state = new haberes.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public haberes Consultarhaberes()
		{
		    _log.Traceo("Ingresa a Metodo Consultar haberes", "0");
			List<haberes.Data> lsthaberes = new List<haberes.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_haberes_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					haberes.Data _haberes= new haberes.Data();
					_haberes.haber = Convert.ToInt32(rdr["haber"].ToString());
					_haberes.nombre = Convert.ToString(rdr["nombre"].ToString());
					_haberes.calculo = Convert.ToBoolean(rdr["calculo"].ToString());
					_haberes.retencion = Convert.ToBoolean(rdr["retencion"].ToString());
					_haberes.tipo = Convert.ToBoolean(rdr["tipo"].ToString());
					_haberes.valor = Convert.ToDouble(rdr["valor"].ToString());
					_haberes.tipo_haber = Convert.ToInt32(rdr["tipo_haber"].ToString());
					_haberes.basico = Convert.ToBoolean(rdr["basico"].ToString());
					_haberes.extra = Convert.ToBoolean(rdr["extra"].ToString());
					_haberes.eventual = Convert.ToInt16(rdr["eventual"].ToString());
					lsthaberes.Add(_haberes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar haberes", _state.error.ToString());
				return new haberes(_state, lsthaberes);
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
			return new haberes(_state);
		}
		public haberes Buscarhaberes(haberes.Data _haberesData)
		{
			List<haberes.Data> lsthaberes = new List<haberes.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar haberes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_haberes_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@haber", _haberesData.haber);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					haberes.Data _haberes= new haberes.Data();
					_haberes.haber = Convert.ToInt32(rdr["haber"].ToString());
					_haberes.nombre = Convert.ToString(rdr["nombre"].ToString());
					_haberes.calculo = Convert.ToBoolean(rdr["calculo"].ToString());
					_haberes.retencion = Convert.ToBoolean(rdr["retencion"].ToString());
					_haberes.tipo = Convert.ToBoolean(rdr["tipo"].ToString());
					_haberes.valor = Convert.ToDouble(rdr["valor"].ToString());
					_haberes.tipo_haber = Convert.ToInt32(rdr["tipo_haber"].ToString());
					_haberes.basico = Convert.ToBoolean(rdr["basico"].ToString());
					_haberes.extra = Convert.ToBoolean(rdr["extra"].ToString());
					_haberes.eventual = Convert.ToInt16(rdr["eventual"].ToString());
					lsthaberes.Add(_haberes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar haberes", _state.error.ToString());
				return new haberes(_state, lsthaberes);
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
			return new haberes(_state);
		}
		public haberes.State Insertarhaberes(haberes.Data _haberes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar haberes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_haberes_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter phaber = new SqlParameter();
				phaber.ParameterName = "@haber";
				phaber.Value = 0;
				SqlCmd.Parameters.Add(phaber);
				phaber.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@nombre", _haberes.nombre);
				SqlCmd.Parameters.AddWithValue("@calculo", _haberes.calculo);
				SqlCmd.Parameters.AddWithValue("@retencion", _haberes.retencion);
				SqlCmd.Parameters.AddWithValue("@tipo", _haberes.tipo);
				SqlCmd.Parameters.AddWithValue("@valor", _haberes.valor);
				SqlCmd.Parameters.AddWithValue("@tipo_haber", _haberes.tipo_haber);
				SqlCmd.Parameters.AddWithValue("@basico", _haberes.basico);
				SqlCmd.Parameters.AddWithValue("@extra", _haberes.extra);
				SqlCmd.Parameters.AddWithValue("@eventual", _haberes.eventual);

				SqlCmd.ExecuteNonQuery();
				_haberes.haber = (System.Int32)phaber.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar haberes", _state.error.ToString());
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
		public haberes.State Actualizarhaberes(haberes.Data _haberes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar haberes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_haberes_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@haber", _haberes.haber);
				SqlCmd.Parameters.AddWithValue("@nombre", _haberes.nombre);
				SqlCmd.Parameters.AddWithValue("@calculo", _haberes.calculo);
				SqlCmd.Parameters.AddWithValue("@retencion", _haberes.retencion);
				SqlCmd.Parameters.AddWithValue("@tipo", _haberes.tipo);
				SqlCmd.Parameters.AddWithValue("@valor", _haberes.valor);
				SqlCmd.Parameters.AddWithValue("@tipo_haber", _haberes.tipo_haber);
				SqlCmd.Parameters.AddWithValue("@basico", _haberes.basico);
				SqlCmd.Parameters.AddWithValue("@extra", _haberes.extra);
				SqlCmd.Parameters.AddWithValue("@eventual", _haberes.eventual);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar haberes", _state.error.ToString());
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
		public haberes.State Eliminarhaberes(haberes.Data _haberes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar haberes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_haberes_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@haber", _haberes.haber);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar haberes", _state.error.ToString());
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
