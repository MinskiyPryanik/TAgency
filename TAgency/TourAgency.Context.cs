﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TAgency
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TourAgencyEntities : DbContext
    {
        public TourAgencyEntities()
            : base("name=TourAgencyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Food_Type> Food_Type { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<Tour_Type> Tour_Type { get; set; }
        public virtual DbSet<Town> Town { get; set; }
        public virtual DbSet<Type_Of_Allocation> Type_Of_Allocation { get; set; }
    }
}
