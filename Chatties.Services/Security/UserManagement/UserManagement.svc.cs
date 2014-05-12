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
        public DTO.General.ResultGeneric<DTO.Security.UserManagement> GetUsersFromDB()
        {
            using (DTO.General.ResultGeneric<DTO.Security.UserManagement> result = new DTO.General.ResultGeneric<DTO.Security.UserManagement>())
            {
                try
                {
                    DTO.Security.UserManagement um = new DTO.Security.UserManagement();

                    result.Object = um.GetUsersFromDB();
                    result.Success = true;
                    result.ServiceMessage = "OK";

                    return result;
                }
                catch (System.Exception ex)
                {
                    result.Success = false;
                    result.Object = null;
                    result.ServiceMessage = ex.Message;
                }

                return result;
            }
        }
    }
}
