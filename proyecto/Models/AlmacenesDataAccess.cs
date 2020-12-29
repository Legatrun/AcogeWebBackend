using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class AlmacenesDataAccess
	{
		Almacenes.State _state = new Almacenes.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Almacenes ConsultarAlmacenes()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Almacenes", "0");
			List<Almacenes.Data> lstAlmacenes = new List<Almacenes.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Almacenes_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Almacenes.Data _Almacenes= new Almacenes.Data();
					_Almacenes.codigoalmacen = Convert.ToString(rdr["codigoalmacen"].ToString());
					_Almacenes.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Almacenes.idtipomovimiento = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["idtipomovimiento"].ToString()) : (System.Int16)0;
					_Almacenes.idciudad = !rdr.IsDBNull(3) ? Convert.ToInt16(rdr["idciudad"].ToString()) : (System.Int16)0;
					_Almacenes.Virtual = !rdr.IsDBNull(4) ? Convert.ToBoolean(rdr["virtual"].ToString()) : true;
					lstAlmacenes.Add(_Almacenes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Almacenes", _state.error.ToString());
				return new Almacenes(_state, lstAlmacenes);
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
			return new Almacenes(_state);
		}
		public Almacenes BuscarAlmacenes(Almacenes.Data _AlmacenesData)
		{
			List<Almacenes.Data> lstAlmacenes = new List<Almacenes.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Almacenes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Almacenes_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigoalmacen", _AlmacenesData.codigoalmacen);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Almacenes.Data _Almacenes= new Almacenes.Data();
					_Almacenes.codigoalmacen = Convert.ToString(rdr["codigoalmacen"].ToString());
					_Almacenes.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Almacenes.idtipomovimiento = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["idtipomovimiento"].ToString()) : (System.Int16)0;
					_Almacenes.idciudad = !rdr.IsDBNull(3) ? Convert.ToInt16(rdr["idciudad"].ToString()) : (System.Int16)0;
					_Almacenes.Virtual = !rdr.IsDBNull(4) ? Convert.ToBoolean(rdr["virtual"].ToString()) : true;
					lstAlmacenes.Add(_Almacenes);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Almacenes", _state.error.ToString());
				return new Almacenes(_state, lstAlmacenes);
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
			return new Almacenes(_state);
		}
		public Almacenes.State InsertarAlmacenes(Almacenes.Data _Almacenes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Almacenes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Almacenes_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigoalmacen", _Almacenes.codigoalmacen);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Almacenes.descripcion);
				SqlCmd.Parameters.AddWithValue("@idtipomovimiento", _Almacenes.idtipomovimiento);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Almacenes.idciudad);
				SqlCmd.Parameters.AddWithValue("@virtual", _Almacenes.Virtual);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Almacenes", _state.error.ToString());
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
		public Almacenes.State ActualizarAlmacenes(Almacenes.Data _Almacenes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Almacenes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Almacenes_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigoalmacen", _Almacenes.codigoalmacen);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Almacenes.descripcion);
				SqlCmd.Parameters.AddWithValue("@idtipomovimiento", _Almacenes.idtipomovimiento);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Almacenes.idciudad);
				SqlCmd.Parameters.AddWithValue("@virtual", _Almacenes.Virtual);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Almacenes", _state.error.ToString());
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
		public Almacenes.State EliminarAlmacenes(Almacenes.Data _Almacenes)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Almacenes", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Almacenes_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigoalmacen", _Almacenes.codigoalmacen);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Almacenes", _state.error.ToString());
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
