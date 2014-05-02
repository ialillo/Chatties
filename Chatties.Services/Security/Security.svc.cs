﻿using System;
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
                    if (!user.UserExists())
                    {
                        throw new Chatties.Exception.Login.LoginException("El usuario no existe en la base de datos.");
                    }

                    ///Verifica si el usuario está activo o no
                    if (!user.ActiveUser())
                    {
                        throw new Chatties.Exception.Login.LoginException("El usuario no está activo.");
                    }

                    ///Verifica si el usuario no tiene la nueva seguridad
                    if (user.OldUser(password))
                    {
                        result.Success = true;
                        result.ServiceMessage = "Viejo";
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
        public DTO.General.Result ChangePassword(DTO.General.User user, string password)
        {
            using (DTO.General.Result result = new DTO.General.Result())
            {
                try
                {
                    user.ChangePassword(password);
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
    }
}
