using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChattiesModel.User_Management;

namespace ChattiesModel.UserManagement
{
    public class UserManagement : IDisposable
    {
        bool _disposed;

        public UserManagement() { }

        public List<Empleado> ObtieneEmpleadosActivos()
        {
            List<Empleado> empleados;

            using (var ee = new ENLASYSEntities())
            {
                var query = from empleado in ee.Empleados
                            where empleado.activo == true
                            orderby empleado.nombre
                            select new Empleado 
                            { 
                                ID = empleado.ID, nombre = empleado.nombre, apPaterno = empleado.apPaterno, apMaterno = empleado.apMaterno,
                                correo = empleado.correo, NivelAcceso = empleado.NivelAcceso, usuario = empleado.usuario, encPassword = empleado.encPassword, 
                                activo = empleado.activo
                            };

                empleados = query.ToList();
            }

            return empleados;
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