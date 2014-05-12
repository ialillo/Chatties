using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chatties.DTO.Security
{
    public class UserManagement
    {
        /// <summary>
        /// Metodo requerido para la serializacion
        /// </summary>
        public UserManagement() { }

        [XmlElement(ElementName = "LoggedUser")]
        public LoggedUser[] LoggedUsers { get; set; }

        /// <summary>
        /// Trae una lista de todos los usuarios en la base de datos
        /// </summary>
        /// <returns></returns>
        public UserManagement GetUsersFromDB()
        {
            using (DAL.DBAccess<UserManagement> usersList = new DAL.DBAccess<UserManagement>())
            {
                return usersList.GetObject("Usuarios.ObtenUsuarios");
            }
        }
    }
}
