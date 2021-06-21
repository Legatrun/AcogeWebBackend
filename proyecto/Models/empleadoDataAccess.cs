using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class empleadoDataAccess
	{
		empleado.State _state = new empleado.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public empleado Consultarempleado()
		{
		    _log.Traceo("Ingresa a Metodo Consultar empleado", "0");
			List<empleado.Data> lstempleado = new List<empleado.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_empleado_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					empleado.Data _empleado= new empleado.Data();
					_empleado.empleado = Convert.ToInt32(rdr["empleado"].ToString());
					_empleado.paterno = !rdr.IsDBNull(1) ? Convert.ToString(rdr["paterno"].ToString()) : "";
					_empleado.materno = !rdr.IsDBNull(2) ? Convert.ToString(rdr["materno"].ToString()) : "";
					_empleado.nombres = Convert.ToString(rdr["nombres"].ToString());
					_empleado.fecha_nac = Convert.ToDateTime(rdr["fecha_nac"].ToString());
					_empleado.identificacion = Convert.ToString(rdr["identificacion"].ToString()).Trim();
					_empleado.cod_asegurado = !rdr.IsDBNull(6) ? Convert.ToString(rdr["cod_asegurado"].ToString()).Trim() : "";
					_empleado.direccion = !rdr.IsDBNull(7) ? Convert.ToString(rdr["direccion"].ToString()) : "";
					_empleado.email = !rdr.IsDBNull(8) ? Convert.ToString(rdr["email"].ToString()) : "";
					_empleado.telefono = !rdr.IsDBNull(9) ? Convert.ToString(rdr["telefono"].ToString()) : "";
					_empleado.lugar_nac = !rdr.IsDBNull(10) ? Convert.ToString(rdr["lugar_nac"].ToString()) : "";
					_empleado.nacionalidad = !rdr.IsDBNull(11) ? Convert.ToString(rdr["nacionalidad"].ToString()) : "";
					_empleado.sexo = Convert.ToInt16(rdr["sexo"].ToString());
					_empleado.estado_civil = Convert.ToInt16(rdr["estado_civil"].ToString());
					_empleado.patmes = Convert.ToInt16(rdr["patmes"].ToString());
					lstempleado.Add(_empleado);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar empleado", _state.error.ToString());
				return new empleado(_state, lstempleado);
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
			return new empleado(_state);
		}
		public empleado Buscarempleado(empleado.Data _empleadoData)
		{
			List<empleado.Data> lstempleado = new List<empleado.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar empleado", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_empleado_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _empleadoData.empleado);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					empleado.Data _empleado= new empleado.Data();
					_empleado.empleado = Convert.ToInt32(rdr["empleado"].ToString());
					_empleado.paterno = !rdr.IsDBNull(1) ? Convert.ToString(rdr["paterno"].ToString()) : "";
					_empleado.materno = !rdr.IsDBNull(2) ? Convert.ToString(rdr["materno"].ToString()) : "";
					_empleado.nombres = Convert.ToString(rdr["nombres"].ToString());
					_empleado.fecha_nac = Convert.ToDateTime(rdr["fecha_nac"].ToString());
					_empleado.identificacion = Convert.ToString(rdr["identificacion"].ToString());
					_empleado.cod_asegurado = !rdr.IsDBNull(6) ? Convert.ToString(rdr["cod_asegurado"].ToString()) : "";
					_empleado.direccion = !rdr.IsDBNull(7) ? Convert.ToString(rdr["direccion"].ToString()) : "";
					_empleado.email = !rdr.IsDBNull(8) ? Convert.ToString(rdr["email"].ToString()) : "";
					_empleado.telefono = !rdr.IsDBNull(9) ? Convert.ToString(rdr["telefono"].ToString()) : "";
					_empleado.lugar_nac = !rdr.IsDBNull(10) ? Convert.ToString(rdr["lugar_nac"].ToString()) : "";
					_empleado.nacionalidad = !rdr.IsDBNull(11) ? Convert.ToString(rdr["nacionalidad"].ToString()) : "";
					_empleado.sexo = Convert.ToInt16(rdr["sexo"].ToString());
					_empleado.estado_civil = Convert.ToInt16(rdr["estado_civil"].ToString());
					_empleado.patmes = Convert.ToInt16(rdr["patmes"].ToString());
					lstempleado.Add(_empleado);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar empleado", _state.error.ToString());
				return new empleado(_state, lstempleado);
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
			return new empleado(_state);
		}
		public empleado.State Insertarempleado(empleado.Data _empleado)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar empleado", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_empleado_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pempleado = new SqlParameter();
				pempleado.ParameterName = "@empleado";
				pempleado.Value = 0;
				SqlCmd.Parameters.Add(pempleado);
				pempleado.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@paterno", _empleado.paterno);
				SqlCmd.Parameters.AddWithValue("@materno", _empleado.materno);
				SqlCmd.Parameters.AddWithValue("@nombres", _empleado.nombres);
				SqlCmd.Parameters.AddWithValue("@fecha_nac", _empleado.fecha_nac);
				SqlCmd.Parameters.AddWithValue("@identificacion", _empleado.identificacion);
				SqlCmd.Parameters.AddWithValue("@cod_asegurado", _empleado.cod_asegurado);
				SqlCmd.Parameters.AddWithValue("@direccion", _empleado.direccion);
				SqlCmd.Parameters.AddWithValue("@email", _empleado.email);
				SqlCmd.Parameters.AddWithValue("@telefono", _empleado.telefono);
				SqlCmd.Parameters.AddWithValue("@lugar_nac", _empleado.lugar_nac);
				SqlCmd.Parameters.AddWithValue("@nacionalidad", _empleado.nacionalidad);
				SqlCmd.Parameters.AddWithValue("@sexo", _empleado.sexo);
				SqlCmd.Parameters.AddWithValue("@estado_civil", _empleado.estado_civil);
				SqlCmd.Parameters.AddWithValue("@patmes", _empleado.patmes);

				SqlCmd.ExecuteNonQuery();
				_empleado.empleado = (System.Int32)pempleado.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar empleado", _state.error.ToString());
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
		public empleado.State Actualizarempleado(empleado.Data _empleado)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar empleado", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_empleado_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
                

				SqlCmd.Parameters.AddWithValue("@empleado", _empleado.empleado);
				SqlCmd.Parameters.AddWithValue("@paterno", _empleado.paterno);
				SqlCmd.Parameters.AddWithValue("@materno", _empleado.materno);
				SqlCmd.Parameters.AddWithValue("@nombres", _empleado.nombres);
				SqlCmd.Parameters.AddWithValue("@fecha_nac", _empleado.fecha_nac);
				SqlCmd.Parameters.AddWithValue("@identificacion", _empleado.identificacion);
				SqlCmd.Parameters.AddWithValue("@cod_asegurado", _empleado.cod_asegurado);
				SqlCmd.Parameters.AddWithValue("@direccion", _empleado.direccion);
				SqlCmd.Parameters.AddWithValue("@email", _empleado.email);
				SqlCmd.Parameters.AddWithValue("@telefono", _empleado.telefono);
				SqlCmd.Parameters.AddWithValue("@lugar_nac", _empleado.lugar_nac);
				SqlCmd.Parameters.AddWithValue("@nacionalidad", _empleado.nacionalidad);
				SqlCmd.Parameters.AddWithValue("@sexo", _empleado.sexo);
				SqlCmd.Parameters.AddWithValue("@estado_civil", _empleado.estado_civil);
				SqlCmd.Parameters.AddWithValue("@patmes", _empleado.patmes);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar empleado", _state.error.ToString());
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
		public empleado.State Eliminarempleado(empleado.Data _empleado)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar empleado", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_empleado_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@empleado", _empleado.empleado);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar empleado", _state.error.ToString());
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
