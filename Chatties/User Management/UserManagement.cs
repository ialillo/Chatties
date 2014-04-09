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
        /// Obtiene los usuarios activos del sistema
        /// </summary>
        /// <returns>Una lista de usuarios activos</returns>
        public IList<EmpleadoDTO> ObtieneEmpleadosActivos()
        {
            IList<EmpleadoDTO> empleados;

            using (var ee = new ENLASYSEntities())
            {
                empleados = (from empleado in ee.Empleados
                             where empleado.activo == true
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
        /// Verifica si el login es valido
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <param name="password">contrasena</param>
        /// <returns>Verdadero o Falso</returns>
        public bool validaLogin(string usuario, string password)
        {
            bool esValido;
            int numRows;

            using (var enlasis = new ENLASYSEntities())
            {
                numRows = (from u in enlasis.Empleados
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