﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UcreEntities : DbContext
    {
        public UcreEntities()
            : base("name=UcreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Asignatura> Asignatura { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<DetalleAsignatura> DetalleAsignatura { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Recurso> Recurso { get; set; }
        public DbSet<TipoRecurso> TipoRecurso { get; set; }
    }
}
