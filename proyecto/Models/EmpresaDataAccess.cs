using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using proyecto.Helpers;
namespace proyecto.Models
{
    public class EmpresaDataAccess
    {
        Empresa.State _state = new Empresa.State();
        private Log _log = new Log();
        private Encriptador _crypto = new Encriptador();
        private AdministradorParametros.ActiveDirectoryParams _params = new AdministradorParametros.ActiveDirectoryParams();
        private Conexion Base = new Conexion();
        public Empresa ConsultarEmpresa()
        {
            _log.Traceo("Ingresa a Metodo Consultar Empresa", "0");
            List<Empresa.Data> lstEmpresa = new List<Empresa.Data>();
            try
            {
                SqlConnection SqlCnn;
                SqlCnn = Base.AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand("Proc_Empresa_Select", SqlCnn);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = SqlCmd.ExecuteReader();
                while (rdr.Read())
                {
                    Empresa.Data _Empresa = new Empresa.Data();
                    _Empresa.idempresa = !rdr.IsDBNull(0) ? Convert.ToInt16(rdr["idempresa"].ToString()) : (System.Int16)0;
                    _Empresa.idpais = !rdr.IsDBNull(1) ? Convert.ToInt16(rdr["idpais"].ToString()) : (System.Int16)0;
                    _Empresa.idciudad = !rdr.IsDBNull(2) ? Convert.ToInt16(rdr["idciudad"].ToString()) : (System.Int16)0;
                    _Empresa.descripcion = !rdr.IsDBNull(3) ? Convert.ToString(rdr["descripcion"].ToString()) : "";
                    _Empresa.logo = !rdr.IsDBNull(4) ? Convert.ToString(rdr["logo"].ToString()) : "";
                    _Empresa.NIT = !rdr.IsDBNull(5) ? Convert.ToString(rdr["NIT"].ToString()) : "";
                    _Empresa.patronal = !rdr.IsDBNull(6) ? Convert.ToString(rdr["patronal"].ToString()) : "";
                    _Empresa.estado = !rdr.IsDBNull(7) ? Convert.ToBoolean(rdr["estado"].ToString()) : true;
                    lstEmpresa.Add(_Empresa);
                }
                Base.CerrarConexion(SqlCnn);
                _state.error = 0;
                _state.descripcion = "Operacion Realizada";
                _log.Traceo(_state.descripcion + " Operacion Consultar Empresa", _state.error.ToString());
                return new Empresa(_state, lstEmpresa);
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
            return new Empresa(_state);
        }
    }
}