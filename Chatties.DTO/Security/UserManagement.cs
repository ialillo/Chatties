using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Chatties.DTO.Security
{
    public class UserManagement : IDisposable
    {
        private bool _disposed;
        /// <summary>
        /// Metodo requerido para la serializacion
        /// </summary>
        public UserManagement() { }

        /// <summary>
        /// Representa un arreglo de usuarios loggeados
        /// </summary>
        [XmlElement(ElementName = "LoggedUser")]
        public LoggedUser[] LoggedUsers { get; set; }

        /// <summary>
        /// Representa un arreglo de perfiles de usuario del sistema
        /// </summary>
        [XmlElement(ElementName = "Perfiles")]
        public DTO.General.Controls.Select[] Selects { get; set; }

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

        /// <summary>
        /// Trae los perfiles activos
        /// </summary>
        /// <returns></returns>
        public UserManagement GetProfiles()
        {
            using (DAL.DBAccess<UserManagement> profilesSelect = new DAL.DBAccess<UserManagement>())
            {
                return profilesSelect.GetObject("Usuarios.ObtenPerfiles");
            }
        }

        /// <summary>
        /// Obtiene un usuario de la base de datos recibiendo el id del usuario.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public LoggedUser GetUserById(int idUsuario)
        {
            using (DAL.DBAccess<LoggedUser> user = new DAL.DBAccess<LoggedUser>())
            {
                return user.GetObject("Usuarios.ObtenUsuario", idUsuario);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        public void SaveNewUser(LoggedUser usuario, string password)
        {
            using (DAL.DBAccess<LoggedUser> user = new DAL.DBAccess<LoggedUser>())
            {
                user.ExecuteScalar("Usuarios.IsertaUsuario", usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Usuario, password, usuario.Email, usuario.IdPerfil);
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

        /// <summary>
        /// Destruye las instancias creadas asincronamente
        /// </summary>
        ~UserManagement()
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
    }
}
