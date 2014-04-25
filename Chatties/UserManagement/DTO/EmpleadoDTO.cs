using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatties.Model.UserManagement.DTO
{
    public class EmpleadoDTO
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public string usuario { get; set; }
        public Nullable<int> NivelAcceso { get; set; }
        public string encPassword { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}
