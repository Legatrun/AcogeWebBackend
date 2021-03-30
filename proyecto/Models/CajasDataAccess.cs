using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class CajasDataAccess
	{
		Cajas.State _state = new Cajas.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Cajas ConsultarCajas()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Cajas", "0");
			List<Cajas.Data> lstCajas = new List<Cajas.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cajas_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Cajas.Data _Cajas= new Cajas.Data();
					_Cajas.idcaja = Convert.ToInt16(rdr["idcaja"].ToString());
					_Cajas.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Cajas.cuenta = !rdr.IsDBNull(2) ? Convert.ToString(rdr["cuenta"].ToString()) : "";
					_Cajas.monto = !rdr.IsDBNull(3) ? Convert.ToDouble(rdr["monto"].ToString()) : (System.Double)0;
					_Cajas.idmoneda = !rdr.IsDBNull(4) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					lstCajas.Add(_Cajas);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Cajas", _state.error.ToString());
				return new Cajas(_state, lstCajas);
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
			return new Cajas(_state);
		}
		public Cajas BuscarCajas(Cajas.Data _CajasData)
		{
			List<Cajas.Data> lstCajas = new List<Cajas.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Cajas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cajas_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcaja", _CajasData.idcaja);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Cajas.Data _Cajas= new Cajas.Data();
					_Cajas.idcaja = Convert.ToInt16(rdr["idcaja"].ToString());
					_Cajas.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Cajas.cuenta = !rdr.IsDBNull(2) ? Convert.ToString(rdr["cuenta"].ToString()) : "";
					_Cajas.monto = !rdr.IsDBNull(3) ? Convert.ToDouble(rdr["monto"].ToString()) : (System.Double)0;
					_Cajas.idmoneda = !rdr.IsDBNull(4) ? Convert.ToInt16(rdr["idmoneda"].ToString()) : (System.Int16)0;
					lstCajas.Add(_Cajas);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Cajas", _state.error.ToString());
				return new Cajas(_state, lstCajas);
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
			return new Cajas(_state);
		}
		public Cajas.State InsertarCajas(Cajas.Data _Cajas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Cajas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cajas_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDCaja = new SqlParameter();
				pIDCaja.ParameterName = "@IDCaja";
				pIDCaja.Value = 0;
				SqlCmd.Parameters.Add(pIDCaja);
				pIDCaja.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _Cajas.descripcion);
				SqlCmd.Parameters.AddWithValue("@cuenta", _Cajas.cuenta);
				SqlCmd.Parameters.AddWithValue("@monto", _Cajas.monto);
				SqlCmd.Parameters.AddWithValue("@idmoneda", _Cajas.idmoneda);

				SqlCmd.ExecuteNonQuery();
				//_Cajas.idcaja = (System.Int16)pIDCaja.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Cajas", _state.error.ToString());
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
		public Cajas.State ActualizarCajas(Cajas.Data _Cajas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Cajas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cajas_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcaja", _Cajas.idcaja);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Cajas.descripcion);
				SqlCmd.Parameters.AddWithValue("@cuenta", _Cajas.cuenta);
				SqlCmd.Parameters.AddWithValue("@monto", _Cajas.monto);
				SqlCmd.Parameters.AddWithValue("@idmoneda", _Cajas.idmoneda);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Cajas", _state.error.ToString());
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
		public Cajas.State EliminarCajas(Cajas.Data _Cajas)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Cajas", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Cajas_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcaja", _Cajas.idcaja);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Cajas", _state.error.ToString());
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
