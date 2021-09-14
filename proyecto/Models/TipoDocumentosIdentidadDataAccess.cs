using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class TipoDocumentosIdentidadDataAccess
	{
		TipoDocumentosIdentidad.State _state = new TipoDocumentosIdentidad.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public TipoDocumentosIdentidad ConsultarTipoDocumentosIdentidad()
		{
		    _log.Traceo("Ingresa a Metodo Consultar TipoDocumentosIdentidad", "0");
			List<TipoDocumentosIdentidad.Data> lstTipoDocumentosIdentidad = new List<TipoDocumentosIdentidad.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TipoDocumentosIdentidad_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TipoDocumentosIdentidad.Data _TipoDocumentosIdentidad= new TipoDocumentosIdentidad.Data();
					_TipoDocumentosIdentidad.iddocumentoidentidad = Convert.ToInt16(rdr["iddocumentoidentidad"].ToString());
					_TipoDocumentosIdentidad.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString().Trim()) : "";
					_TipoDocumentosIdentidad.sigla = !rdr.IsDBNull(2) ? Convert.ToString(rdr["sigla"].ToString().Trim()) : "";
					lstTipoDocumentosIdentidad.Add(_TipoDocumentosIdentidad);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar TipoDocumentosIdentidad", _state.error.ToString());
				return new TipoDocumentosIdentidad(_state, lstTipoDocumentosIdentidad);
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
			return new TipoDocumentosIdentidad(_state);
		}
		public TipoDocumentosIdentidad BuscarTipoDocumentosIdentidad(TipoDocumentosIdentidad.Data _TipoDocumentosIdentidadData)
		{
			List<TipoDocumentosIdentidad.Data> lstTipoDocumentosIdentidad = new List<TipoDocumentosIdentidad.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar TipoDocumentosIdentidad", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TipoDocumentosIdentidad_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddocumentoidentidad", _TipoDocumentosIdentidadData.iddocumentoidentidad);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TipoDocumentosIdentidad.Data _TipoDocumentosIdentidad= new TipoDocumentosIdentidad.Data();
					_TipoDocumentosIdentidad.iddocumentoidentidad = Convert.ToInt16(rdr["iddocumentoidentidad"].ToString());
					_TipoDocumentosIdentidad.descripcion = !rdr.IsDBNull(1) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_TipoDocumentosIdentidad.sigla = !rdr.IsDBNull(2) ? Convert.ToString(rdr["sigla"].ToString()) : "";
					lstTipoDocumentosIdentidad.Add(_TipoDocumentosIdentidad);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar TipoDocumentosIdentidad", _state.error.ToString());
				return new TipoDocumentosIdentidad(_state, lstTipoDocumentosIdentidad);
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
			return new TipoDocumentosIdentidad(_state);
		}
		public TipoDocumentosIdentidad.State InsertarTipoDocumentosIdentidad(TipoDocumentosIdentidad.Data _TipoDocumentosIdentidad)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar TipoDocumentosIdentidad", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TipoDocumentosIdentidad_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDDocumentoIdentidad = new SqlParameter();
				pIDDocumentoIdentidad.ParameterName = "@IDDocumentoIdentidad";
				pIDDocumentoIdentidad.Value = 0;
				SqlCmd.Parameters.Add(pIDDocumentoIdentidad);
				pIDDocumentoIdentidad.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@descripcion", _TipoDocumentosIdentidad.descripcion);
				SqlCmd.Parameters.AddWithValue("@sigla", _TipoDocumentosIdentidad.sigla);

				SqlCmd.ExecuteNonQuery();
				//_TipoDocumentosIdentidad.iddocumentoidentidad = (System.Int16)pIDDocumentoIdentidad.Value;
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar TipoDocumentosIdentidad", _state.error.ToString());
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
		public TipoDocumentosIdentidad.State ActualizarTipoDocumentosIdentidad(TipoDocumentosIdentidad.Data _TipoDocumentosIdentidad)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar TipoDocumentosIdentidad", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TipoDocumentosIdentidad_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddocumentoidentidad", _TipoDocumentosIdentidad.iddocumentoidentidad);
				SqlCmd.Parameters.AddWithValue("@descripcion", _TipoDocumentosIdentidad.descripcion);
				SqlCmd.Parameters.AddWithValue("@sigla", _TipoDocumentosIdentidad.sigla);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar TipoDocumentosIdentidad", _state.error.ToString());
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
		public TipoDocumentosIdentidad.State EliminarTipoDocumentosIdentidad(TipoDocumentosIdentidad.Data _TipoDocumentosIdentidad)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar TipoDocumentosIdentidad", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TipoDocumentosIdentidad_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddocumentoidentidad", _TipoDocumentosIdentidad.iddocumentoidentidad);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar TipoDocumentosIdentidad", _state.error.ToString());
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
