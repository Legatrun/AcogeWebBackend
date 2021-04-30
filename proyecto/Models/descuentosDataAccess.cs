using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class descuentosDataAccess
	{
		descuentos.State _state = new descuentos.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public descuentos Consultardescuentos()
		{
		    _log.Traceo("Ingresa a Metodo Consultar descuentos", "0");
			List<descuentos.Data> lstdescuentos = new List<descuentos.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_descuentos_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					descuentos.Data _descuentos= new descuentos.Data();
					_descuentos.descuento = Convert.ToInt32(rdr["descuento"].ToString());
					_descuentos.nombre = Convert.ToString(rdr["nombre"].ToString());
					_descuentos.calculo = Convert.ToBoolean(rdr["calculo"].ToString());
					_descuentos.valor = Convert.ToDouble(rdr["valor"].ToString());
					_descuentos.tipo = Convert.ToBoolean(rdr["tipo"].ToString());
					_descuentos.tipo_descuento = Convert.ToInt32(rdr["tipo_descuento"].ToString());
					_descuentos.basico = Convert.ToBoolean(rdr["basico"].ToString());
					_descuentos.eventual = Convert.ToInt16(rdr["eventual"].ToString());
					lstdescuentos.Add(_descuentos);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar descuentos", _state.error.ToString());
				return new descuentos(_state, lstdescuentos);
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
			return new descuentos(_state);
		}
		public descuentos Buscardescuentos(descuentos.Data _descuentosData)
		{
			List<descuentos.Data> lstdescuentos = new List<descuentos.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar descuentos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_descuentos_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@descuento", _descuentosData.descuento);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					descuentos.Data _descuentos= new descuentos.Data();
					_descuentos.descuento = Convert.ToInt32(rdr["descuento"].ToString());
					_descuentos.nombre = Convert.ToString(rdr["nombre"].ToString());
					_descuentos.calculo = Convert.ToBoolean(rdr["calculo"].ToString());
					_descuentos.valor = Convert.ToDouble(rdr["valor"].ToString());
					_descuentos.tipo = Convert.ToBoolean(rdr["tipo"].ToString());
					_descuentos.tipo_descuento = Convert.ToInt32(rdr["tipo_descuento"].ToString());
					_descuentos.basico = Convert.ToBoolean(rdr["basico"].ToString());
					_descuentos.eventual = Convert.ToInt16(rdr["eventual"].ToString());
					lstdescuentos.Add(_descuentos);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar descuentos", _state.error.ToString());
				return new descuentos(_state, lstdescuentos);
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
			return new descuentos(_state);
		}
		public descuentos.State Insertardescuentos(descuentos.Data _descuentos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar descuentos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_descuentos_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pdescuento = new SqlParameter();
				pdescuento.ParameterName = "@descuento";
				pdescuento.Value = 0;
				SqlCmd.Parameters.Add(pdescuento);
				pdescuento.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@nombre", _descuentos.nombre);
				SqlCmd.Parameters.AddWithValue("@calculo", _descuentos.calculo);
				SqlCmd.Parameters.AddWithValue("@valor", _descuentos.valor);
				SqlCmd.Parameters.AddWithValue("@tipo", _descuentos.tipo);
				SqlCmd.Parameters.AddWithValue("@tipo_descuento", _descuentos.tipo_descuento);
				SqlCmd.Parameters.AddWithValue("@basico", _descuentos.basico);
				SqlCmd.Parameters.AddWithValue("@eventual", _descuentos.eventual);

				SqlCmd.ExecuteNonQuery();
				_descuentos.descuento = (System.Int32)pdescuento.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar descuentos", _state.error.ToString());
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
		public descuentos.State Actualizardescuentos(descuentos.Data _descuentos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar descuentos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_descuentos_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@descuento", _descuentos.descuento);
				SqlCmd.Parameters.AddWithValue("@nombre", _descuentos.nombre);
				SqlCmd.Parameters.AddWithValue("@calculo", _descuentos.calculo);
				SqlCmd.Parameters.AddWithValue("@valor", _descuentos.valor);
				SqlCmd.Parameters.AddWithValue("@tipo", _descuentos.tipo);
				SqlCmd.Parameters.AddWithValue("@tipo_descuento", _descuentos.tipo_descuento);
				SqlCmd.Parameters.AddWithValue("@basico", _descuentos.basico);
				SqlCmd.Parameters.AddWithValue("@eventual", _descuentos.eventual);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar descuentos", _state.error.ToString());
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
		public descuentos.State Eliminardescuentos(descuentos.Data _descuentos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar descuentos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_descuentos_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@descuento", _descuentos.descuento);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar descuentos", _state.error.ToString());
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
