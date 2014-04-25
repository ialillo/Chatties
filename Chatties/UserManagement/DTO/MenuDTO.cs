using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatties.Model.UserManagement.DTO
{
    public class MenuDTO
    {
        public int idModulo { get; set; }
        public string descModulo { get; set; }
        public int idSubmodulo { get; set; }
        public string descSubmodulo { get; set; }
        public string url { get; set; }
    }
}
