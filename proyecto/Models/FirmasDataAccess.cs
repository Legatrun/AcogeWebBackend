using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class FirmasDataAccess
	{
		Firmas.State _state = new Firmas.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Firmas ConsultarFirmas()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Firmas", "0");
			List<Firmas.Data> lstFirmas = new List<Firmas.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Firmas_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Firmas.Data _Firmas= new Firmas.Data();
					_Firmas.firma1 = !rdr.IsDBNull(0) ?  Convert.ToString(rdr["firma1"].ToString()) : "";
					_Firmas.cargo1 = !rdr.IsDBNull(1) ?  Convert.ToString(rdr["cargo1"].ToString()) : "";
					_Firmas.firma2 = !rdr.IsDBNull(2) ?  Convert.ToString(rdr["firma2"].ToString()) : "";
					_Firmas.cargo2 = !rdr.IsDBNull(3) ?  Convert.ToString(rdr["cargo2"].ToString()) : "";
					lstFirmas.Add(_Firmas);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Firmas", _state.error.ToString());
				return new Firmas(_state, lstFirmas);
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
			return new Firmas(_state);
		}
		public Firmas BuscarFirmas(Firmas.Data _FirmasData)
		{
			List<Firmas.Data> lstFirmas = new List<Firmas.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Firmas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Firmas_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Firmas.Data _Firmas= new Firmas.Data();
					_Firmas.firma1 = !rdr.IsDBNull(0) ? Convert.ToString(rdr["firma1"].ToString()) : "";
					_Firmas.cargo1 = !rdr.IsDBNull(1) ? Convert.ToString(rdr["cargo1"].ToString()) : "";
					_Firmas.firma2 = !rdr.IsDBNull(2) ? Convert.ToString(rdr["firma2"].ToString()) : "";
					_Firmas.cargo2 = !rdr.IsDBNull(3) ? Convert.ToString(rdr["cargo2"].ToString()) : "";
					lstFirmas.Add(_Firmas);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Firmas", _state.error.ToString());
				return new Firmas(_state, lstFirmas);
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
			return new Firmas(_state);
		}
		public Firmas.State InsertarFirmas(Firmas.Data _Firmas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Firmas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Firmas_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@firma1", _Firmas.firma1);
				SqlCmd.Parameters.AddWithValue("@cargo1", _Firmas.cargo1);
				SqlCmd.Parameters.AddWithValue("@firma2", _Firmas.firma2);
				SqlCmd.Parameters.AddWithValue("@cargo2", _Firmas.cargo2);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Firmas", _state.error.ToString());
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
		public Firmas.State ActualizarFirmas(Firmas.Data _Firmas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Firmas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Firmas_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@firma1", _Firmas.firma1);
				SqlCmd.Parameters.AddWithValue("@cargo1", _Firmas.cargo1);
				SqlCmd.Parameters.AddWithValue("@firma2", _Firmas.firma2);
				SqlCmd.Parameters.AddWithValue("@cargo2", _Firmas.cargo2);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Firmas", _state.error.ToString());
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
		public Firmas.State EliminarFirmas(Firmas.Data _Firmas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Firmas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Firmas_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Firmas", _state.error.ToString());
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
