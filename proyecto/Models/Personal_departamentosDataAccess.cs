using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class Personal_departamentosDataAccess
	{
		Personal_departamentos.State _state = new Personal_departamentos.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Personal_departamentos ConsultarPersonal_departamentos()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Personal_departamentos", "0");
			List<Personal_departamentos.Data> lstPersonal_departamentos = new List<Personal_departamentos.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Personal_departamentos_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Personal_departamentos.Data _Personal_departamentos= new Personal_departamentos.Data();
					_Personal_departamentos.personal_departamento = Convert.ToInt32(rdr["personal_departamento"].ToString());
					_Personal_departamentos.nombre = Convert.ToString(rdr["nombre"].ToString());
					_Personal_departamentos.minimo = Convert.ToDouble(rdr["minimo"].ToString());
					_Personal_departamentos.maximo = Convert.ToDouble(rdr["maximo"].ToString());
					_Personal_departamentos.empresa = Convert.ToInt32(rdr["empresa"].ToString());
					lstPersonal_departamentos.Add(_Personal_departamentos);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Personal_departamentos", _state.error.ToString());
				return new Personal_departamentos(_state, lstPersonal_departamentos);
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
			return new Personal_departamentos(_state);
		}
		public Personal_departamentos BuscarPersonal_departamentos(Personal_departamentos.Data _Personal_departamentosData)
		{
			List<Personal_departamentos.Data> lstPersonal_departamentos = new List<Personal_departamentos.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Personal_departamentos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Personal_departamentos_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@personal_departamento", _Personal_departamentosData.personal_departamento);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Personal_departamentos.Data _Personal_departamentos= new Personal_departamentos.Data();
					_Personal_departamentos.personal_departamento = Convert.ToInt32(rdr["personal_departamento"].ToString());
					_Personal_departamentos.nombre = Convert.ToString(rdr["nombre"].ToString());
					_Personal_departamentos.minimo = Convert.ToDouble(rdr["minimo"].ToString());
					_Personal_departamentos.maximo = Convert.ToDouble(rdr["maximo"].ToString());
					_Personal_departamentos.empresa = Convert.ToInt32(rdr["empresa"].ToString());
					lstPersonal_departamentos.Add(_Personal_departamentos);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Personal_departamentos", _state.error.ToString());
				return new Personal_departamentos(_state, lstPersonal_departamentos);
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
			return new Personal_departamentos(_state);
		}
		public Personal_departamentos.State InsertarPersonal_departamentos(Personal_departamentos.Data _Personal_departamentos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Personal_departamentos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Personal_departamentos_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@personal_departamento", _Personal_departamentos.personal_departamento);
				SqlCmd.Parameters.AddWithValue("@nombre", _Personal_departamentos.nombre);
				SqlCmd.Parameters.AddWithValue("@minimo", _Personal_departamentos.minimo);
				SqlCmd.Parameters.AddWithValue("@maximo", _Personal_departamentos.maximo);
				SqlCmd.Parameters.AddWithValue("@empresa", _Personal_departamentos.empresa);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Personal_departamentos", _state.error.ToString());
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
		public Personal_departamentos.State ActualizarPersonal_departamentos(Personal_departamentos.Data _Personal_departamentos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Personal_departamentos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Personal_departamentos_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@personal_departamento", _Personal_departamentos.personal_departamento);
				SqlCmd.Parameters.AddWithValue("@nombre", _Personal_departamentos.nombre);
				SqlCmd.Parameters.AddWithValue("@minimo", _Personal_departamentos.minimo);
				SqlCmd.Parameters.AddWithValue("@maximo", _Personal_departamentos.maximo);
				SqlCmd.Parameters.AddWithValue("@empresa", _Personal_departamentos.empresa);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Personal_departamentos", _state.error.ToString());
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
		public Personal_departamentos.State EliminarPersonal_departamentos(Personal_departamentos.Data _Personal_departamentos)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Personal_departamentos", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Personal_departamentos_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@personal_departamento", _Personal_departamentos.personal_departamento);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Personal_departamentos", _state.error.ToString());
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
