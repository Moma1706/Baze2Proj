﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contract
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FudbalskiTurnirContainer : DbContext
    {
        public FudbalskiTurnirContainer()
            : base("name=FudbalskiTurnirContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ucesnik> Ucesniks { get; set; }
        public virtual DbSet<Trener> Ucesniks_Trener { get; set; }
        public virtual DbSet<Igrac> Ucesniks_Igrac { get; set; }
        public virtual DbSet<Sudija> Ucesniks_Sudija
        {
            get; set;
        }
        public virtual DbSet<Tim> Tims { get; set; }
        public virtual DbSet<Sponzor> Sponzors { get; set; }
        public virtual DbSet<Turnir> Turnirs { get; set; }
        public virtual DbSet<Mec> Mecs { get; set; }
        public virtual DbSet<Teren> Terens { get; set; }
        public virtual DbSet<Statistika> Statistikas { get; set; }
        public virtual DbSet<SePrijavljuje> SePrijavljujes { get; set; }
        public virtual DbSet<SeKvalifikuje> SeKvalifikujes { get; set; }
    }
}