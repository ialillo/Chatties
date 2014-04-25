using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Chatties.Model.UserManagement;
using Chatties.Model.UserManagement.DTO;
using Chatties.Exception.Login;

namespace Chatties.Model.UserManagement
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
        public LoggedUserDTO validaLogin(string usuario, string password, string encPassword)
        {
            LoggedUserDTO loggedUser = new LoggedUserDTO();

            using (var ee = new ENLASYSEntities())
            {
                int existeEmpleado = (from u in ee.Empleados
                                      where u.usuario == usuario
                                      select u).Count();

                if (existeEmpleado < 1)
                {
                    throw new LoginException("El usuario ingresado no existe");
                }

                var estaActivo = (from u in ee.Empleados
                                  where u.usuario == usuario
                                  && u.activo == true
                                  select u).FirstOrDefault();

                if (estaActivo == null)
                {
                    throw new LoginException("El usuario ingresado se encuentra deshabilitado");
                }

                if (estaActivo.encPassword == null)
                {
                    var query = (from u in ee.Empleados
                                 where u.usuario == usuario
                                 && u.contrasena == password
                                 && u.activo == true
                                 select u).FirstOrDefault();

                    if (query == null)
                    {
                        throw new LoginException("Contraseña incorrecta");
                    }

                    loggedUser.ID = query.ID;
                    loggedUser.nombreCompleto = "Viejo";
                    loggedUser.correo = query.correo;
                    loggedUser.usuario = query.usuario;
                    loggedUser.idNivelAcceso = query.Niveles_Acceso.ID;
                    loggedUser.descNivelAcceso = query.Niveles_Acceso.NombreNivel;
                }
                else
                {
                    var query = (from u in ee.Empleados
                                 where u.usuario == usuario
                                 && u.encPassword == encPassword
                                 && u.activo == true
                                 select u).FirstOrDefault();

                    if (query == null)
                    {
                        throw new LoginException("Contraseña incorrecta recuerde que se validan mayusculas y minusculas");
                    }

                    loggedUser.ID = query.ID;
                    loggedUser.nombreCompleto = (!string.IsNullOrEmpty(query.nombre) ? query.nombre : "").ToUpper() + " " + 
                        (!string.IsNullOrEmpty(query.apPaterno) ? query.apPaterno : "").ToUpper() + " " + 
                        (!string.IsNullOrEmpty(query.apMaterno) ? query.apMaterno : "").ToUpper();
                    loggedUser.correo = query.correo;
                    loggedUser.usuario = query.usuario;
                    loggedUser.idNivelAcceso = query.Niveles_Acceso.ID;
                    loggedUser.descNivelAcceso = query.Niveles_Acceso.NombreNivel;
                }
            }

            return loggedUser;
        }

        /// <summary>
        /// Verifica si el password enviado es correcto
        /// </summary>
        /// <param name="usuarioDTO"></param>
        /// <returns>Verdadero o falso</returns>
        public bool validaPasswordActual(LoginDTO usuarioDTO)
        {
            bool passwordValido = false;

            try
            {
                using (var ee = new ENLASYSEntities())
                {
                    int usuarios = (from u in ee.Empleados
                                    where u.usuario == usuarioDTO.Login
                                    && u.encPassword == usuarioDTO.Password
                                    && u.activo == true
                                    select u).Count();

                    if (usuarios > 0)
                    {
                        passwordValido = true;
                    }
                    else
                    {
                        throw new LoginException("Password incorrecto");
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw new LoginException(ex.Message, ex);
            }

            return passwordValido;
        }

        /// <summary>
        /// Cambia el password por el obtenido en el objeto
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <returns>Verdadero o falso</returns>
        public bool cambiaPassword(LoginDTO usuario)
        {
            bool cambioExitoso = false;

            try
            {
                using (var ee = new ENLASYSEntities())
                {
                    Empleado user = (from u in ee.Empleados
                                     where u.usuario == usuario.Login
                                     && u.activo == true
                                     select u).FirstOrDefault();

                    ee.Empleados.Attach(user);

                    user.encPassword = usuario.Password;

                    ee.SaveChanges();

                    cambioExitoso = true;
                }
            }
            catch (System.Exception ex)
            {
                throw new LoginException(ex.Message, ex);
            }

            return cambioExitoso;
        }

        /// <summary>
        /// Obtiene  el menu de un usuario
        /// </summary>
        /// <param name="idUsuario">id del Usuario logeado</param>
        /// <returns>un objeto de menu</returns>
        public List<MenuDTO> obtenMenu(int idUsuario)
        {
            List<MenuDTO> listaMenu = new List<MenuDTO>();

            using (ENLASYSEntities ee = new ENLASYSEntities())
            {
                var entityMenu = ee.ObtenMenu(idUsuario).ToList();

                if (entityMenu != null)
                {
                    foreach (var menuItem in entityMenu)
                    {
                        MenuDTO menu = new MenuDTO();

                        menu.idModulo = menuItem.idModulo;
                        menu.descModulo = menuItem.descModulo;
                        menu.idSubmodulo = menuItem.idSubmodulo;
                        menu.descSubmodulo = menuItem.descSubmodulo;
                        menu.url = menuItem.url;

                        listaMenu.Add(menu);
                    }

                }
            }

            return listaMenu;
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