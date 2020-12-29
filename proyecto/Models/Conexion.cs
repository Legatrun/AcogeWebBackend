using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using proyecto.Helpers;

namespace proyecto
{
	class Conexion
	{
        private AdministradorParametros.SQLParams administradorParametros = new AdministradorParametros.SQLParams();
        private Log _log = new Log();

        public SqlConnection AbrirConexion()
		{
			SqlConnection Cnn = new SqlConnection();
			try
			{
                string SQLConnection = administradorParametros.SQLServerConnectionString;
                Cnn.ConnectionString = SQLConnection;
                Cnn.Open();
                return Cnn;
			}
			catch(Exception ex)
			{
                _log.Error(ex.Message,"-1");
                throw new Exception("Error al Abrir la Conexion a la Base de Datos");
            }
		}
		public void CerrarConexion(SqlConnection Cnn)
		{
			try
			{
				Cnn.Close();
			}
			catch(Exception ex)
			{
                _log.Error(ex.Message,"-1");
                throw new Exception("Error al Cerrar la Conexion a la Base de Datos");
			}
		}
	}
}
