using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.Serialization;

namespace Chatties.DTO.Tools.Mailing
{
    [DataContract]
    class Email : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// 
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
        public string SmptPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="fileAttachUrl"></param>
        public void SendMail()
        {
            NetworkCredential credentialsInfo = new NetworkCredential(this.SmtpUser, this.SmptPassword);

            SmtpClient client = new SmtpClient(this.SmtpHost);
            client.UseDefaultCredentials = false;
            client.Credentials = credentialsInfo;

            MailMessage message = new MailMessage(this.From, this.To, this.Subject, this.Body);
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = this.IsBodyHtml;

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

            client.Send(message);
        }

        /// <summary>
        /// 
        /// </summary>
        ~Email()
        {
            Dispose(false);
        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
