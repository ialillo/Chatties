using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ChattiesModel.User_Management;
using ChattiesModel.User_Management.DTO;
using ChattiesException.Login;

namespace ChattiesModel.UserManagement
{
    public class UserManagement : IDisposable
    {
        bool _disposed;

        public UserManagement() { }

        /// <summary>
        /// Obtiene los usuarios del sistema
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public IList<EmpleadoDTO> ObtieneUsuarios()
        {
            IList<EmpleadoDTO> empleados;

            using (var ee = new ENLASYSEntities())
            {
                empleados = (from empleado in ee.Empleados
                                orderby empleado.nombre
                                select new EmpleadoDTO
                                {
                                    ID = empleado.ID,
                                    nombre = empleado.nombre,
                                    apPaterno = empleado.apPaterno,
                                    apMaterno = empleado.apMaterno,
                                    correo = empleado.correo,
                                    NivelAcceso = empleado.NivelAcceso,
                                    usuario = empleado.usuario,
                                    encPassword = empleado.encPassword,
                                    activo = empleado.activo
                                }).ToList();
            }

            return empleados;
        }

        /// <summary>
        /// Obtiene la info de un usuario 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public EmpleadoDTO ObtenUsuarioPorId(int idUsuario)
        {
            EmpleadoDTO usuario = new EmpleadoDTO();

            using (var ee = new ENLASYSEntities())
            {
                var query = from usr in ee.Empleados
                            where usr.ID == idUsuario
                            select usr;

                foreach (var n in query)
                {
                    usuario.ID = n.ID;
                    usuario.nombre = n.nombre;
                    usuario.apPaterno = n.apPaterno;
                    usuario.apMaterno = n.apMaterno;
                    usuario.correo = n.correo;
                    usuario.NivelAcceso = n.NivelAcceso;
                    usuario.usuario = n.usuario;
                    usuario.encPassword = n.encPassword;
                    usuario.activo = n.activo;
                }
            }
            return usuario;
        }

        /// <summary>
        /// Verifica si el login es valido
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <param name="password">contrasena</param>
        /// <returns>El login del usuario</returns>
        public LoggedUserDTO validaLogin(string usuario, string password)
        {
            LoggedUserDTO loggedUser = new LoggedUserDTO();

            using (var ee = new ENLASYSEntities())
            {
                int existeEmpleado = (from u in ee.Empleados
                                      where u.usuario == usuario
                                      select u).Count();

                if (existeEmpleado < 1)
                {
                    throw new LoginException("Error El usuario ingresado no existe");
                }

                existeEmpleado = (from u in ee.Empleados
                                      where u.usuario == usuario
                                      && u.activo == true
                                      select u).Count();

                if (existeEmpleado < 1)
                {
                    throw new LoginException("Error El usuario ingresado se encuentra deshabilitado");
                }

                var query = from u in ee.Empleados
                            where u.usuario == usuario
                            && u.contrasena == password
                            && u.activo == true
                            select u;

                foreach (var n in query)
                {
                    loggedUser.ID = n.ID;
                    loggedUser.nombreCompleto = n.nombre + " " + n.apPaterno + " " + n.apMaterno;
                    loggedUser.correo = n.correo;
                    loggedUser.usuario = n.usuario;
                    loggedUser.idNivelAcceso = n.Niveles_Acceso.ID;
                    loggedUser.descNivelAcceso = n.Niveles_Acceso.NombreNivel;
                }

                if (loggedUser.ID == 0)
                {
                    throw new LoginException("Error Contraseña incorrecta");
                }
            }

            return loggedUser;
        }

        /// <summary>
        /// Verifica si el password del usuario es valido
        /// </summary>
        /// <param name="idUsuario">id del usuario</param>
        /// <param name="password">password del usuario</param>
        /// <returns>verdadero o falso</returns>
        public bool validaPasswordActual(LoginDTO usuarioDTO)
        {
            bool passwordValido = false;

            using(var ee = new ENLASYSEntities())
            {
                int usuarios = (from u in ee.Empleados
                                where u.usuario == usuarioDTO.Login
                                && u.contrasena == usuarioDTO.Password
                                && u.activo == true
                                select u).Count();

                if(usuarios > 0)
                {
                    passwordValido = true;
                }
            }

            return passwordValido;
        }


        ~UserManagement()
        {
            Dispose(true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }
}