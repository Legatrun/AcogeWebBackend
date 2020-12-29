using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class MonedasDataAccess
	{
		Monedas.State _state = new Monedas.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Monedas ConsultarMonedas()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Monedas", "0");
			List<Monedas.Data> lstMonedas = new List<Monedas.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Monedas_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Monedas.Data _Monedas= new Monedas.Data();
					_Monedas.idmoneda = Convert.ToInt16(rdr["idmoneda"].ToString());
					_Monedas.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Monedas.sigla = !rdr.IsDBNull(2) ? Convert.ToString(rdr["sigla"].ToString()) : "";
					_Monedas.monedalocal = !rdr.IsDBNull(3) ? Convert.ToBoolean(rdr["monedalocal"].ToString()) : true;
					lstMonedas.Add(_Monedas);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Monedas", _state.error.ToString());
				return new Monedas(_state, lstMonedas);
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
			return new Monedas(_state);
		}
		public Monedas BuscarMonedas(Monedas.Data _MonedasData)
		{
			List<Monedas.Data> lstMonedas = new List<Monedas.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Monedas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Monedas_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idmoneda", _MonedasData.idmoneda);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Monedas.Data _Monedas= new Monedas.Data();
					_Monedas.idmoneda = Convert.ToInt16(rdr["idmoneda"].ToString());
					_Monedas.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Monedas.sigla = !rdr.IsDBNull(2) ? Convert.ToString(rdr["sigla"].ToString()) : "";
					_Monedas.monedalocal = !rdr.IsDBNull(3) ? Convert.ToBoolean(rdr["monedalocal"].ToString()) : true;
					lstMonedas.Add(_Monedas);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Monedas", _state.error.ToString());
				return new Monedas(_state, lstMonedas);
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
			return new Monedas(_state);
		}
		public Monedas.State InsertarMonedas(Monedas.Data _Monedas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Monedas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Monedas_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDMoneda = new SqlParameter();
				pIDMoneda.ParameterName = "@IDMoneda";
				pIDMoneda.Value = 0;
				SqlCmd.Parameters.Add(pIDMoneda);
				pIDMoneda.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _Monedas.descripcion);
				SqlCmd.Parameters.AddWithValue("@sigla", _Monedas.sigla);
				SqlCmd.Parameters.AddWithValue("@monedalocal", _Monedas.monedalocal);

				SqlCmd.ExecuteNonQuery();
				_Monedas.idmoneda = (System.Int16)pIDMoneda.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Monedas", _state.error.ToString());
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
		public Monedas.State ActualizarMonedas(Monedas.Data _Monedas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Monedas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Monedas_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idmoneda", _Monedas.idmoneda);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Monedas.descripcion);
				SqlCmd.Parameters.AddWithValue("@sigla", _Monedas.sigla);
				SqlCmd.Parameters.AddWithValue("@monedalocal", _Monedas.monedalocal);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Monedas", _state.error.ToString());
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
		public Monedas.State EliminarMonedas(Monedas.Data _Monedas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Monedas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Monedas_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idmoneda", _Monedas.idmoneda);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Monedas", _state.error.ToString());
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
