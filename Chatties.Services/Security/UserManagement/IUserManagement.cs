﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Chatties.Services.Security.UserManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserManagement" in both code and config file together.
    [ServiceContract]
    public interface IUserManagement
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        DTO.General.ResultGeneric<DTO.Security.UserManagement> GetUsersFromDB();
    }
}