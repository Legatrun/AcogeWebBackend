using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Threading.Tasks;

namespace proyecto.Helpers
{
    public class Log
    {
        private string RutaLogs { get; set; }
        private string TituloLog { get; set; }
        Type type = typeof(Log);

        public Log()
        {
            RutaLogs = @"C:\AlphaSystems\Logs";
            TituloLog = type.Namespace.Replace(".Helpers","");
        }

        public void Info(string log)
        {
            EscribirArchivo(log,null,"INFORMACION");
        }

        public void Advertencia(string log)
        {
            EscribirArchivo(log,null, "ADVERTENCIA");
        }
        public void Error(string log, string codigoasociado)
        {
            EscribirArchivo(log,codigoasociado, "ERROR");
        }
        public void Debug(string log)
        {
            EscribirArchivo(log, null, "DEBUG");
        }
        public void Comentario(string log)
        {
            EscribirArchivo(log, null, "COMENTARIO");
        }
        public void Traceo(string log,string codigoasociado)
        {
            EscribirArchivo(log, codigoasociado, "TRACEO");
        }

        private void EscribirArchivo(string log, string codigoasociado, string categoria)
        {
            try
            {
                if (!(Directory.Exists(@RutaLogs)))
                {
                    Directory.CreateDirectory(@RutaLogs);
                }
                string ArchivoLog = @RutaLogs + "/" + DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + "_" + @TituloLog + ".log";
                string texto;
                string Fechahora = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss:ffff");
                texto = Fechahora + "|" + log;
                Boolean existe = false;
                if (System.IO.File.Exists(ArchivoLog))
                {
                    existe = true;
                }
                else
                {
                    existe = false;
                }
                System.IO.StreamWriter sw = new System.IO.StreamWriter(ArchivoLog, existe);
                sw.WriteLine("Categoria: " + categoria);
                if (String.IsNullOrEmpty(codigoasociado)) {
                    codigoasociado = "Sin codigo asociado";
                }
                sw.WriteLine("Código Asociado :"+ codigoasociado);
                sw.WriteLine(texto);
                sw.WriteLine("--------------------------------------------------");
                sw.Close();
            }
            catch (Exception err)
            {
                return;
            }
        }
    }
}