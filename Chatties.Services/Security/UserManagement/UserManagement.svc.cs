using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
        public DTO.General.ResultGeneric<DTO.Security.UserManagement> GetProfiles()
        {
            using (DTO.General.ResultGeneric<DTO.Security.UserManagement> result = new DTO.General.ResultGeneric<DTO.Security.UserManagement>())
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
    }
}
