using System;
using System.Web;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Chatties.Services.Security.UserManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserManagement.svc or UserManagement.svc.cs at the Solution Explorer and start debugging.
    public class UserManagement : IUserManagement
    {
        /// <summary>
        /// Trae los usuarios que existen en la base de datos
        /// </summary>
        /// <returns></returns>
        public DTO.General.ResultGeneric<DTO.Security.UserManagement> GetUsersFromDB()
        {
            using (DTO.General.ResultGeneric<DTO.Security.UserManagement> result = new DTO.General.ResultGeneric<DTO.Security.UserManagement>())
            {
                try
                {
                    using (DTO.Security.UserManagement um = new DTO.Security.UserManagement())
                    {
                        result.Object = um.GetUsersFromDB();
                        result.Success = true;
                        result.ServiceMessage = "OK";

                        return result;
                    }
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.Object = null;
                    result.ServiceMessage = ex.Message;

                    return result;
                }
            }
        }

        /// <summary>
        /// Obtiene los perfiles de la base de datos
        /// </summary>
        /// <returns></returns>
        public DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> GetProfiles()
        {
            using (DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs> result = new DTO.General.ResultGeneric<DTO.General.Catalogs.SelectCatalogs>())
            {
                try
                {
                    using (DTO.Security.UserManagement um = new DTO.Security.UserManagement())
                    {
                        result.Object = um.GetProfiles();
                        result.Success = true;
                        result.ServiceMessage = "OK";

                        return result;
                    }
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.Object = null;
                    result.ServiceMessage = ex.Message;

                    return result;
                }
            }
        }

        /// <summary>
        /// Traé un usuario de la base de datos mediante su Id
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public DTO.General.ResultGeneric<DTO.Security.LoggedUser> GetUserById(int idUsuario)
        {
            using (DTO.General.ResultGeneric<DTO.Security.LoggedUser> result = new DTO.General.ResultGeneric<DTO.Security.LoggedUser>())
            {
                try
                {
                    using (DTO.Security.UserManagement um = new DTO.Security.UserManagement())
                    {
                        result.Object = um.GetUserById(idUsuario);
                        result.Success = true;
                        result.ServiceMessage = "OK";

                        return result;
                    }
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.Object = null;
                    result.ServiceMessage = ex.Message;

                    return result;
                }
            }
        }

        /// <summary>
        /// Guardamos un nuevo usuario en la base de datos y le envíamos un correo con sus credenciales para ingresar al sistema.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public DTO.General.Result SaveNewUser(DTO.Security.LoggedUser user)
        {
            using (DTO.General.Result result = new DTO.General.Result())
            {
                try
                {
                    using (DTO.Security.UserManagement um = new DTO.Security.UserManagement())
                    {
                        //Guardamos el usuario en la base de datos y obtenemos su contraseña generada dinámicamente.
                        string randomPassword = um.SaveNewUser(user, int.Parse(System.Configuration.ConfigurationManager.AppSettings["RandomPasswordLength"]));

                        using (DTO.Tools.Mailing.Email mail = new DTO.Tools.Mailing.Email())
                        {
                            //Obtenemos el layout del mail con el id 1 que pertenece a las Altas de Usuario.
                            DTO.Tools.Mailing.Email nMail = mail.GetMailLayout(1);

                            //Configuramos los valores del servidor smtp para poder enviar el correo.
                            nMail.SmtpHost = System.Configuration.ConfigurationManager.AppSettings["MailingHost"];
                            nMail.SmtpPort = System.Configuration.ConfigurationManager.AppSettings["MailingPort"];
                            nMail.SmtpUser = System.Configuration.ConfigurationManager.AppSettings["MailingUser"];
                            nMail.SmtpPassword = System.Configuration.ConfigurationManager.AppSettings["MailingPwd"];

                            //Reemplazamos los campos dinámicos del correo.
                            nMail.Body = nMail.Body.Replace("@nombreUsuario", user.Nombre);
                            nMail.Body = nMail.Body.Replace("@usuario", user.Usuario);
                            nMail.Body = nMail.Body.Replace("@contrasena", randomPassword);

                            //Concatenamos al usuario recien creado para enviarle sus credenciales.
                            nMail.To += nMail.To != string.Empty ?  "," + user.Email : user.Email;

                            //Enviamos el correo.
                            nMail.SendMail();

                            //Llenamos el objeto result.
                            result.Success = true;
                            result.ServiceMessage = "Se cre&oacute; el usuario con &eacute;xito.";

                            //Regresamos la instancia de resultado
                            return result;
                        }
                    }
                }
                    //Si existe un error al enviar el correo regresamos el detalle.
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.ServiceMessage = ex.Message;

                    return result;
                }
            }
        }

        /// <summary>
        /// Edita un usuario existente en la base de datos.
        /// </summary>
        /// <param name="user">Instancia del usuario a editar.</param>
        /// <returns>Instancia de la clase resultado.</returns>
        public DTO.General.Result SaveUser(DTO.Security.LoggedUser user)
        {
            using (DTO.General.Result result = new DTO.General.Result())
            {
                try
                {
                    using (DTO.Security.UserManagement um = new DTO.Security.UserManagement())
                    {
                        um.SaveUser(user);
                        result.Success = true;
                        result.ServiceMessage = "Usuario editado con &eacute;xito.";

                        return result;
                    }
                }
                catch(System.Exception ex)
                {
                    result.Success = false;
                    result.ServiceMessage = ex.Message;

                    return result;
                }
            }
        }

        /// <summary>
        /// Desactiva un usuario existente en la base de datos
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public DTO.General.Result DeactivateUser(int idUsuario)
        {
            using (DTO.General.Result result = new DTO.General.Result())
            {
                try
                {
                    using (DTO.Security.UserManagement um = new DTO.Security.UserManagement())
                    {
                        um.DeactivateUser(idUsuario);
                        result.Success = true;
                        result.ServiceMessage = "Usuario desactivado con &eacute;xito.";

                        return result;
                    }
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.ServiceMessage = ex.Message;

                    return result;
                }
            }
        }
    }
}
