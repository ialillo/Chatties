using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChattiesModel.User_Management;
using ChattiesModel.User_Management.DTO;

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
        /// <returns>Verdadero o Falso</returns>
        public bool validaLogin(string usuario, string password)
        {
            bool esValido;
            int numRows;

            using (var ee = new ENLASYSEntities())
            {
                numRows = (from u in ee.Empleados
                            where u.usuario == usuario 
                            && u.contrasena == password
                            && u.activo == true
                            select u.ID).Count();
            }

            esValido = numRows > 0 ? true : false;

            return esValido;
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