using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.Serialization;

namespace Chatties.DTO.Tools.Mailing
{
    [DataContract]
    public class Email : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Metodo necesario para la serialización
        /// </summary>
        public Email() { }

        /// <summary>
        /// Id del tipo de Mail en la base de datos
        /// </summary>
        [DataMember]
        public int IdMail { get; set; }

        /// <summary>
        /// Nombre asignado al mail
        /// </summary>
        [DataMember]
        public string Nombre { get; set; }

        /// <summary>
        /// Remitente del correo
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// <summary>
        /// Tema del correo
        /// </summary>
        [DataMember]
        public string Subject { get; set; }

        /// <summary>
        /// Especifica si el cuerpo del correo es HTML o no
        /// </summary>
        [DataMember]
        public bool IsBodyHtml { get; set; }

        /// <summary>
        /// El cuerpo del correo
        /// </summary>
        [DataMember]
        public string Body { get; set; }

        /// <summary>
        /// Destinatario del correo
        /// </summary>
        [DataMember]
        public string To { get; set; }

        /// <summary>
        /// Especifica si tiene un attachment
        /// </summary>
        [IgnoreDataMember]
        public bool HasAttachment { get; set; }

        /// <summary>
        /// La ruta del archivo que se quiera adjuntar
        /// </summary>
        [IgnoreDataMember]
        public string FileAttachmentPath { get; set; }

        /// <summary>
        /// El host del Servidor Smtp a Usar
        /// </summary>
        [IgnoreDataMember]
        public string SmtpHost { get; set; }

        /// <summary>
        /// El puerto del Servidor Smtp a Usar
        /// </summary>
        [IgnoreDataMember]
        public string SmtpPort { get; set; }

        /// <summary>
        /// El usuario de las credenciales para logearse en el servidor Smtp
        /// </summary>
        [IgnoreDataMember]
        public string SmtpUser { get; set; }

        /// <summary>
        /// La contraseña de las credenciales para logearse en el servidor Smtp
        /// </summary>
        [IgnoreDataMember]
        public string SmtpPassword { get; set; }

        /// <summary>
        /// Método que envía un correo
        /// </summary>
        public void SendMail()
        {
            //Declaramos el cliente de correo a usar
            SmtpClient client = new SmtpClient(this.SmtpHost, int.Parse(this.SmtpPort));
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            //Establecemos las credenciales para logearse al servidor de correo.
            NetworkCredential credentialsInfo = new NetworkCredential(this.SmtpUser, this.SmtpPassword);
            client.Credentials = credentialsInfo;

            //Creamos el correo
            MailMessage message = new MailMessage();
            message.From = new MailAddress(this.From);

            //Agregamos las direcciones remitentes del correo.
            foreach (string address in this.To.Split(','))
            {
                message.To.Add(new MailAddress(address));
            }

            //Establecemos el Titulo y cuerpo del correo.
            message.Subject = this.Subject;
            message.Body = this.Body;
            message.IsBodyHtml = this.IsBodyHtml;

            //Adjuntamos los documentos si es que tiene.
            if (this.HasAttachment)
            {
                Attachment data = new Attachment(this.FileAttachmentPath, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(this.FileAttachmentPath);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(this.FileAttachmentPath);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(this.FileAttachmentPath);
                message.Attachments.Add(data);
                data.Dispose();
            }

            //Enviamos el correo.
            client.Send(message);
        }

        /// <summary>
        /// Obtiene una instancia de la clase Email
        /// </summary>
        /// <param name="idMail">El id del layout de mail a obtener</param>
        /// <returns>Regresa una instancia de la clase Email</returns>
        public Email GetMailLayout(int idMail)
        {
            using (DAL.DBAccess<Email> mailDbAccess = new DAL.DBAccess<Email>())
            {
                return mailDbAccess.GetObject("Services.ObtenMailLayout", idMail);
            }
        }

        /// <summary>
        /// Destruye las instancias creadas asincronamente
        /// </summary>
        ~Email()
        {
            Dispose(false);
        }

        /// <summary>
        /// Destruye las instancias internas condicionalmente
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        /// <summary>
        /// Utiliza el garbage collector para destruir las instancias propias
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
