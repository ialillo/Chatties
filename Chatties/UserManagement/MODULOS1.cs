//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chatties.Model.UserManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class MODULOS1
    {
        public MODULOS1()
        {
            this.SUBMODULOS = new HashSet<SUBMODULOS>();
        }
    
        public int idModulo { get; set; }
        public string descModulo { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual ICollection<SUBMODULOS> SUBMODULOS { get; set; }
    }
}