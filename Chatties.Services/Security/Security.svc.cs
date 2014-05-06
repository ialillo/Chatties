using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chatties.Services.Security
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Security" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Security.svc or Security.svc.cs at the Solution Explorer and start debugging.
    public class Security : ISecurity
    {
        /// <summary>
        /// Autentica un usuario en la base de datos
        /// </summary>
        /// <param name="user">Contiene el usuario a autenticar</param>
        /// <param name="password">Password a autenticar</param>
        /// <returns></returns>
        public DTO.General.Result Authenticate(DTO.General.User user, string password)
        {
            using (DTO.General.ResultGeneric<DTO.Security.LoggedUser> result = new DTO.General.ResultGeneric<DTO.Security.LoggedUser>())
            {
                try
                {
                    ///Si no existe el usuario manda la excepcion
                    if (!user.VerifyUserExists())
                    {
                        throw new Chatties.Exception.Login.LoginException("El usuario no existe en la base de datos.");
                    }

                    ///Verifica si el usuario está activo o no
                    if (!user.VerifyActiveUser())
                    {
                        throw new Chatties.Exception.Login.LoginException("El usuario no está activo.");
                    }

                    ///Verifica si el usuario no tiene la nueva seguridad
                    result.Object = user.VerifyOldUser(password);

                    /// Si el usuario tiene la vieja seguridad, se guarda el usuario en sesión y se regresa la notificación al cliente
                    if (result.Object != null)
                    {
                        result.Success = true;
                        result.ServiceMessage = "Viejo";

                        HttpContext.Current.Session["User"] = result.Object;

                        return new DTO.General.Result(result.Success, result.ServiceMessage);
                    }

                    result.Object = user.Authenticate(password);

                    if (result.Object == null)
                    {
                        throw new Chatties.Exception.Login.LoginException("Contraseña no válida.");
                    }

                    result.Object.SessionID = HttpContext.Current.Session.SessionID;
                    HttpContext.Current.Session["User"] = result.Object;

                    result.Success = true;
                    result.ServiceMessage = "OK";
                }
                catch(System.Exception ex)
                {
                    result.Success = false;
                    result.ServiceMessage = ex.Message;
                }
                return new DTO.General.Result(result.Success, result.ServiceMessage);
            }
        }

        /// <summary>
        /// Cambia la contraseña de un usuario
        /// </summary>
        /// <param name="user">Usuario</param>
        /// <param name="password">Contraseña</param>
        /// <returns></returns>
        public DTO.General.Result ChangePassword(string oldPassword, string newPassword)
        {
            DTO.General.User user = new DTO.General.User(((DTO.Security.LoggedUser)HttpContext.Current.Session["User"]).Usuario);

            using (DTO.General.Result result = new DTO.General.Result())
            {
                string mensajeSP = string.Empty;

                try
                {
                    mensajeSP = user.ChangePassword(oldPassword, newPassword);

                    if (mensajeSP != "OK")
                    {
                        throw new Chatties.Exception.Login.LoginException("Contraseña no válida");
                    }
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.ServiceMessage = ex.Message;

                    return result;
                }

                result.Success = true;
                result.ServiceMessage = "OK";

                return result;
            }
        }

        /// <summary>
        /// Método que obtiene información del usuario en la sesión actual
        /// </summary>
        /// <returns>El usuario en sesión</returns>
        public DTO.General.ResultGeneric<DTO.Security.LoggedUser> CurrentSessionUser()
        {
            using (DTO.General.ResultGeneric<DTO.Security.LoggedUser> result = new DTO.General.ResultGeneric<DTO.Security.LoggedUser>())
            {
                try
                {
                    DTO.Security.LoggedUser lu = (DTO.Security.LoggedUser)HttpContext.Current.Session["User"];
                    DTO.Security.LoggedUser luMin = new DTO.Security.LoggedUser();

                    luMin.Nombre = lu.Nombre;
                    luMin.ApellidoPaterno = lu.ApellidoPaterno;
                    luMin.ApellidoMaterno = lu.ApellidoMaterno;
                    luMin.Perfil = lu.Perfil;
                    luMin.Email = lu.Email;

                    result.Object = luMin;
                    result.Success = true;
                    result.ServiceMessage = "OK";
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.ServiceMessage = ex.Message;
                }

                return result;
            }
        }
    }
}
