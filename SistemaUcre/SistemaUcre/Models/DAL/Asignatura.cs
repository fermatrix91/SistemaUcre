//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaUcre.Models.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Asignatura
    {
        public Asignatura()
        {
            this.DetalleAsignatura = new HashSet<DetalleAsignatura>();
            this.Modulo = new HashSet<Modulo>();
        }
    
        public int IdAsignatura { get; set; }
        public int IdProfesor { get; set; }
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    
        public virtual Curso Curso { get; set; }
        public virtual Profesor Profesor { get; set; }
        public virtual ICollection<DetalleAsignatura> DetalleAsignatura { get; set; }
        public virtual ICollection<Modulo> Modulo { get; set; }
    }
}
