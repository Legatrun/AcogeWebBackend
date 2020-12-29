using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
	public class ItemsDataAccess
	{
		Items.State _state = new Items.State();
		private Log _log = new Log();
		private Encriptador _crypto = new Encriptador();
		private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
		private Conexion Base = new Conexion();
		public Items ConsultarItems()
		{
		    _log.Traceo("Ingresa a Metodo Consultar Items", "0");
			List<Items.Data> lstItems = new List<Items.Data>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Items_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Items.Data _Items= new Items.Data();
					_Items.codigoitem = Convert.ToString(rdr["codigoitem"].ToString());
					_Items.modelonroparte = !rdr.IsDBNull(1) ? Convert.ToString(rdr["modelonroparte"].ToString()) : "";
					_Items.descripcion = !rdr.IsDBNull(2) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Items.fechacreacion = !rdr.IsDBNull(3) ? Convert.ToDateTime(rdr["fechacreacion"].ToString()) : System.DateTime.Now;
					_Items.fechaultimomovimiento = !rdr.IsDBNull(4) ? Convert.ToDateTime(rdr["fechaultimomovimiento"].ToString()) : System.DateTime.Now;
					_Items.costoinicial = !rdr.IsDBNull(5) ? Convert.ToDouble(rdr["costoinicial"].ToString()) : (System.Double)0;
					_Items.costoactual = !rdr.IsDBNull(6) ? Convert.ToDouble(rdr["costoactual"].ToString()) : (System.Double)0;
					_Items.saldoinicial = !rdr.IsDBNull(7) ? Convert.ToInt32(rdr["saldoinicial"].ToString()) : (System.Int32)0;
					_Items.saldoactual = !rdr.IsDBNull(8) ? Convert.ToInt32(rdr["saldoactual"].ToString()) : (System.Int32)0;
					_Items.idclase = !rdr.IsDBNull(9) ? Convert.ToInt16(rdr["idclase"].ToString()) : (System.Int16)0;
					_Items.idtipoitem = !rdr.IsDBNull(10) ? Convert.ToInt16(rdr["idtipoitem"].ToString()) : (System.Int16)0;
					_Items.idunidadmanejo = !rdr.IsDBNull(11) ? Convert.ToInt16(rdr["idunidadmanejo"].ToString()) : (System.Int16)0;
					_Items.codigoitemsup = !rdr.IsDBNull(12) ? Convert.ToString(rdr["codigoitemsup"].ToString()) : "";
					_Items.cantidadminima = !rdr.IsDBNull(13) ? Convert.ToInt32(rdr["cantidadminima"].ToString()) : (System.Int32)0;
					_Items.cantidadmaxima = !rdr.IsDBNull(14) ? Convert.ToInt32(rdr["cantidadmaxima"].ToString()) : (System.Int32)0;
					lstItems.Add(_Items);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Consultar Items", _state.error.ToString());
				return new Items(_state, lstItems);
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
			return new Items(_state);
		}
		public Items BuscarItems(Items.Data _ItemsData)
		{
			List<Items.Data> lstItems = new List<Items.Data>();
			try
			{
		        _log.Traceo("Ingresa a Metodo Buscar Items", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Items_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigoitem", _ItemsData.codigoitem);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Items.Data _Items= new Items.Data();
					_Items.codigoitem = Convert.ToString(rdr["codigoitem"].ToString());
					_Items.modelonroparte = !rdr.IsDBNull(1) ? Convert.ToString(rdr["modelonroparte"].ToString()) : "";
					_Items.descripcion = !rdr.IsDBNull(2) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
					_Items.fechacreacion = !rdr.IsDBNull(3) ? Convert.ToDateTime(rdr["fechacreacion"].ToString()) : System.DateTime.Now;
					_Items.fechaultimomovimiento = !rdr.IsDBNull(4) ? Convert.ToDateTime(rdr["fechaultimomovimiento"].ToString()) : System.DateTime.Now;
					_Items.costoinicial = !rdr.IsDBNull(5) ? Convert.ToDouble(rdr["costoinicial"].ToString()) : (System.Double)0;
					_Items.costoactual = !rdr.IsDBNull(6) ? Convert.ToDouble(rdr["costoactual"].ToString()) : (System.Double)0;
					_Items.saldoinicial = !rdr.IsDBNull(7) ? Convert.ToInt32(rdr["saldoinicial"].ToString()) : (System.Int32)0;
					_Items.saldoactual = !rdr.IsDBNull(8) ? Convert.ToInt32(rdr["saldoactual"].ToString()) : (System.Int32)0;
					_Items.idclase = !rdr.IsDBNull(9) ? Convert.ToInt16(rdr["idclase"].ToString()) : (System.Int16)0;
					_Items.idtipoitem = !rdr.IsDBNull(10) ? Convert.ToInt16(rdr["idtipoitem"].ToString()) : (System.Int16)0;
					_Items.idunidadmanejo = !rdr.IsDBNull(11) ? Convert.ToInt16(rdr["idunidadmanejo"].ToString()) : (System.Int16)0;
					_Items.codigoitemsup = !rdr.IsDBNull(12) ? Convert.ToString(rdr["codigoitemsup"].ToString()) : "";
					_Items.cantidadminima = !rdr.IsDBNull(13) ? Convert.ToInt32(rdr["cantidadminima"].ToString()) : (System.Int32)0;
					_Items.cantidadmaxima = !rdr.IsDBNull(14) ? Convert.ToInt32(rdr["cantidadmaxima"].ToString()) : (System.Int32)0;
					lstItems.Add(_Items);
				}
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Buscar Items", _state.error.ToString());
				return new Items(_state, lstItems);
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
			return new Items(_state);
		}
		public Items.State InsertarItems(Items.Data _Items)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Insertar Items", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Items_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigoitem", _Items.codigoitem);
				SqlCmd.Parameters.AddWithValue("@modelonroparte", _Items.modelonroparte);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Items.descripcion);
				SqlCmd.Parameters.AddWithValue("@fechacreacion", _Items.fechacreacion);
				SqlCmd.Parameters.AddWithValue("@fechaultimomovimiento", _Items.fechaultimomovimiento);
				SqlCmd.Parameters.AddWithValue("@costoinicial", _Items.costoinicial);
				SqlCmd.Parameters.AddWithValue("@costoactual", _Items.costoactual);
				SqlCmd.Parameters.AddWithValue("@saldoinicial", _Items.saldoinicial);
				SqlCmd.Parameters.AddWithValue("@saldoactual", _Items.saldoactual);
				SqlCmd.Parameters.AddWithValue("@idclase", _Items.idclase);
				SqlCmd.Parameters.AddWithValue("@idtipoitem", _Items.idtipoitem);
				SqlCmd.Parameters.AddWithValue("@idunidadmanejo", _Items.idunidadmanejo);
				SqlCmd.Parameters.AddWithValue("@codigoitemsup", _Items.codigoitemsup);
				SqlCmd.Parameters.AddWithValue("@cantidadminima", _Items.cantidadminima);
				SqlCmd.Parameters.AddWithValue("@cantidadmaxima", _Items.cantidadmaxima);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Insertar Items", _state.error.ToString());
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
		public Items.State ActualizarItems(Items.Data _Items)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Actualizar Items", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Items_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigoitem", _Items.codigoitem);
				SqlCmd.Parameters.AddWithValue("@modelonroparte", _Items.modelonroparte);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Items.descripcion);
				SqlCmd.Parameters.AddWithValue("@fechacreacion", _Items.fechacreacion);
				SqlCmd.Parameters.AddWithValue("@fechaultimomovimiento", _Items.fechaultimomovimiento);
				SqlCmd.Parameters.AddWithValue("@costoinicial", _Items.costoinicial);
				SqlCmd.Parameters.AddWithValue("@costoactual", _Items.costoactual);
				SqlCmd.Parameters.AddWithValue("@saldoinicial", _Items.saldoinicial);
				SqlCmd.Parameters.AddWithValue("@saldoactual", _Items.saldoactual);
				SqlCmd.Parameters.AddWithValue("@idclase", _Items.idclase);
				SqlCmd.Parameters.AddWithValue("@idtipoitem", _Items.idtipoitem);
				SqlCmd.Parameters.AddWithValue("@idunidadmanejo", _Items.idunidadmanejo);
				SqlCmd.Parameters.AddWithValue("@codigoitemsup", _Items.codigoitemsup);
				SqlCmd.Parameters.AddWithValue("@cantidadminima", _Items.cantidadminima);
				SqlCmd.Parameters.AddWithValue("@cantidadmaxima", _Items.cantidadmaxima);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Actualizar Items", _state.error.ToString());
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
		public Items.State EliminarItems(Items.Data _Items)
		{
			try
			{
		        _log.Traceo("Ingresa a Metodo Eliminar Items", "0");
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Items_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@codigoitem", _Items.codigoitem);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				_state.error = 0;
				_state.descripcion = "Operacion Realizada";
				_log.Traceo(_state.descripcion + " Operacion Eliminar Items", _state.error.ToString());
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
