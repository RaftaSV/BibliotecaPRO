//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminLabrary.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class solicitudes
    {
        public int id_soli { get; set; }
        public int id_lector { get; set; }
        public int libros { get; set; }
        public Nullable<int> estado { get; set; }
        public Nullable<int> Cantidad { get; set; }
    
        public virtual Lectores Lectores { get; set; }
        public virtual Libros Libros1 { get; set; }
    }
}
