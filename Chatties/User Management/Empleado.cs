//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChattiesModel.User_Management
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado
    {
        public Empleado()
        {
            this.Orden_de_Compra_Autorizaciones = new HashSet<Orden_de_Compra_Autorizaciones>();
        }
    
        public int ID { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public string usuario { get; set; }
        public Nullable<int> NivelAcceso { get; set; }
        public string encPassword { get; set; }
    
        public virtual Niveles_Acceso Niveles_Acceso { get; set; }
        public virtual ICollection<Orden_de_Compra_Autorizaciones> Orden_de_Compra_Autorizaciones { get; set; }
    }
}
