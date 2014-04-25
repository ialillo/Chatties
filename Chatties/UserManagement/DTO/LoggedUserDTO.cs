using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatties.Model.UserManagement.DTO
{
    public class LoggedUserDTO
    {
        public int ID { get; set; }
        public string nombreCompleto { get; set; }
        public string correo { get; set; }
        public string usuario { get; set; }
        public int idNivelAcceso { get; set; }
        public string descNivelAcceso { get; set; }
    }
}