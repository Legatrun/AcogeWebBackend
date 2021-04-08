using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class TiposdeCambioDataAccess
	{
		TiposdeCambio.State _state = new TiposdeCambio.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public TiposdeCambio ConsultarTiposdeCambio()
		{
		    _log.Traceo("Ingresa a Metodo Consultar TiposdeCambio", "0");
			List<TiposdeCambio.Data> lstTiposdeCambio = new List<TiposdeCambio.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposdeCambio_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TiposdeCambio.Data _TiposdeCambio= new TiposdeCambio.Data();
					_TiposdeCambio.fecha = Convert.ToDateTime(rdr["fecha"].ToString());
					_TiposdeCambio.idmonedaorigen = Convert.ToInt16(rdr["idmonedaorigen"].ToString());
					_TiposdeCambio.idmonedadestino = Convert.ToInt16(rdr["idmonedadestino"].ToString());
					_TiposdeCambio.cotizacionoficial = !rdr.IsDBNull(3) ? Convert.ToDouble(rdr["cotizacionoficial"].ToString()) : (System.Double)0;
					_TiposdeCambio.cotizacioncompra = !rdr.IsDBNull(4) ? Convert.ToDouble(rdr["cotizacioncompra"].ToString()) : (System.Double)0;
					_TiposdeCambio.cotizacionventa = !rdr.IsDBNull(5) ? Convert.ToDouble(rdr["cotizacionventa"].ToString()) : (System.Double)0;
					lstTiposdeCambio.Add(_TiposdeCambio);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar TiposdeCambio", _state.error.ToString());
				return new TiposdeCambio(_state, lstTiposdeCambio);
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
			return new TiposdeCambio(_state);
		}
		public TiposdeCambio BuscarTiposdeCambio(TiposdeCambio.Data _TiposdeCambioData)
		{
			List<TiposdeCambio.Data> lstTiposdeCambio = new List<TiposdeCambio.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar TiposdeCambio", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposdeCambio_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@fecha", _TiposdeCambioData.fecha);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TiposdeCambio.Data _TiposdeCambio= new TiposdeCambio.Data();
					_TiposdeCambio.fecha = Convert.ToDateTime(rdr["fecha"].ToString());
					_TiposdeCambio.idmonedaorigen = Convert.ToInt16(rdr["idmonedaorigen"].ToString());
					_TiposdeCambio.idmonedadestino = Convert.ToInt16(rdr["idmonedadestino"].ToString());
					_TiposdeCambio.cotizacionoficial = !rdr.IsDBNull(3) ? Convert.ToDouble(rdr["cotizacionoficial"].ToString()) : (System.Double)0;
					_TiposdeCambio.cotizacioncompra = !rdr.IsDBNull(4) ? Convert.ToDouble(rdr["cotizacioncompra"].ToString()) : (System.Double)0;
					_TiposdeCambio.cotizacionventa = !rdr.IsDBNull(5) ? Convert.ToDouble(rdr["cotizacionventa"].ToString()) : (System.Double)0;
					lstTiposdeCambio.Add(_TiposdeCambio);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar TiposdeCambio", _state.error.ToString());
				return new TiposdeCambio(_state, lstTiposdeCambio);
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
			return new TiposdeCambio(_state);
		}
		public TiposdeCambio.State InsertarTiposdeCambio(TiposdeCambio.Data _TiposdeCambio)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar TiposdeCambio", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposdeCambio_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@fecha", _TiposdeCambio.fecha);
				SqlCmd.Parameters.AddWithValue("@idmonedaorigen", _TiposdeCambio.idmonedaorigen);
				SqlCmd.Parameters.AddWithValue("@idmonedadestino", _TiposdeCambio.idmonedadestino);
				SqlCmd.Parameters.AddWithValue("@cotizacionoficial", _TiposdeCambio.cotizacionoficial);
				SqlCmd.Parameters.AddWithValue("@cotizacioncompra", _TiposdeCambio.cotizacioncompra);
				SqlCmd.Parameters.AddWithValue("@cotizacionventa", _TiposdeCambio.cotizacionventa);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar TiposdeCambio", _state.error.ToString());
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
		public TiposdeCambio.State ActualizarTiposdeCambio(TiposdeCambio.Data _TiposdeCambio)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar TiposdeCambio", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposdeCambio_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@fecha", _TiposdeCambio.fecha);
				SqlCmd.Parameters.AddWithValue("@idmonedaorigen", _TiposdeCambio.idmonedaorigen);
				SqlCmd.Parameters.AddWithValue("@idmonedadestino", _TiposdeCambio.idmonedadestino);
				SqlCmd.Parameters.AddWithValue("@cotizacionoficial", _TiposdeCambio.cotizacionoficial);
				SqlCmd.Parameters.AddWithValue("@cotizacioncompra", _TiposdeCambio.cotizacioncompra);
				SqlCmd.Parameters.AddWithValue("@cotizacionventa", _TiposdeCambio.cotizacionventa);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar TiposdeCambio", _state.error.ToString());
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
		public TiposdeCambio.State EliminarTiposdeCambio(TiposdeCambio.Data _TiposdeCambio)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar TiposdeCambio", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TiposdeCambio_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@fecha", _TiposdeCambio.fecha);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar TiposdeCambio", _state.error.ToString());
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
