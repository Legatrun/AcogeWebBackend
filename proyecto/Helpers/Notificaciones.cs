using System;
using System.Net.Mail;

namespace proyecto.Helpers
{
    public class Notificaciones
    {
        /* Clase de Trabajo con Correo Electrónico */
        public class CorreoElectronico 
        {
            private static string ServidorIP { get; set; }
            private static Int32 ServidorPuerto { get; set; }
            private static string Remitente { get; set; }

            private static SmtpClient ConfigurarServidor()
            {
                var _log = new Log();

                try
                {
                    var _CorreoParams = new AdministradorParametros.EmailParams();
                    ServidorIP = "webmail.alphasys.com.bo";
                    if (_CorreoParams.ServidorIP != "")
                    {
                        ServidorIP = _CorreoParams.ServidorIP;
                    }
                    ServidorPuerto = 25;
                    if (_CorreoParams.ServidorPuerto != "")
                    {
                        ServidorPuerto = Convert.ToInt32(_CorreoParams.ServidorPuerto);
                    }
                    Type type = typeof(Log);
                    Remitente = type.Namespace.Replace(".Helpers", "") + "@alphasys.com.bo";
                    if (_CorreoParams.CorreoElectronicoSistema != "")
                    {
                        Remitente = _CorreoParams.CorreoElectronicoSistema;
                    }
                    SmtpClient SMTP = new SmtpClient();
                    SMTP.Host = ServidorIP;
                    SMTP.Port = ServidorPuerto;
                    SMTP.EnableSsl = false;

                    return SMTP;
                }
                catch (Exception ex)
                {
                    _log.Error(ex.Message, "-1");
                    return new SmtpClient();
                }
            }

            private string CargarTemplate()
            {
                var correo = ""; 
                correo = correo += " <html> ";
                correo += " <body> ";
                correo += " <table> ";
                correo += " <tr> ";
                correo += " <td  align='center'><font size ='3', color ='#87cf72'>ALPHA SYSTEMS S.R.L.</font></td> ";
                correo += " </tr>  ";
                correo += " <tr> ";
                correo += " <td  align='center'>Estimado usuario del Sistema </td> ";
                correo += " </tr>  ";
                correo += " <tr>  ";
                correo += " <td  align='center'>**************************************** </td> ";
                correo += " </tr>  ";
                correo += " <tr>  ";
                correo += " <td align='center'>Este es un correo informativo </td>  ";
                correo += " </tr>  ";
                correo += " <tr>  ";
                correo += " </tr> ";
                correo += " <tr>  ";
                correo += " </tr> ";
                correo += " </table> ";
                correo += " </body>  ";
                correo += " </html> ";

                return correo;
            }

            private static MailMessage PrepararCorreo()
            {
                var _log = new Log();

                try
                {
                    var _CorreoXEnviar = new MailMessage();
                    _CorreoXEnviar.IsBodyHtml = true;
                    _CorreoXEnviar.From = new MailAddress(Remitente);
                    _CorreoXEnviar.Priority = System.Net.Mail.MailPriority.Normal;
                    return _CorreoXEnviar;
                }
                catch (Exception ex)
                {
                    _log.Error(ex.Message, "-1");
                    return new MailMessage();
                }
            }

            public void EnviarCorreoElectronico(String Destinatarios, Char SeparadorDestinatarios, String Asunto, String CuerpoCorreoOTemplate)
            {
                var _log = new Log();

                try
                {
                    var ServidorSMTP = CorreoElectronico.ConfigurarServidor();
                    var CorreoElectronicoXEnviar = CorreoElectronico.PrepararCorreo();
                    CorreoElectronicoXEnviar.Body = CuerpoCorreoOTemplate;
                    if (CuerpoCorreoOTemplate == "") {
                        CorreoElectronicoXEnviar.Body = CargarTemplate();
                    }
                    CorreoElectronicoXEnviar.Subject = Asunto;
                    //Correos destinatarios
                    string[] CorreosDestino = Destinatarios.Split(SeparadorDestinatarios);
                    int cantidad = CorreosDestino.Length;
                    int cont = 0;
                    do
                    {
                        CorreoElectronicoXEnviar.To.Add(CorreosDestino[cont]);
                        cont += 1;
                    }
                    while (cont != cantidad);
                    ServidorSMTP.Send(CorreoElectronicoXEnviar);
                }
                catch (Exception ex)
                {
                    _log.Error(ex.Message, "-1");
                }
            }
        }
    }
}