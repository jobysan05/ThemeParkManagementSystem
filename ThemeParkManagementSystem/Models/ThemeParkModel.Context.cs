﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThemeParkManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class tpdatabaseEntities : DbContext
    {
        public tpdatabaseEntities()
            : base("name=tpdatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GUEST> GUESTs { get; set; }
        public virtual DbSet<GUEST_SHOPS> GUEST_SHOPS { get; set; }
        public virtual DbSet<INVENTORY> INVENTORies { get; set; }
        public virtual DbSet<MAINTENANCE> MAINTENANCEs { get; set; }
        public virtual DbSet<RIDE> RIDES { get; set; }
        public virtual DbSet<SHOP> SHOPS { get; set; }
        public virtual DbSet<STAFF> STAFFs { get; set; }
        public virtual DbSet<TICKET> TICKETs { get; set; }
        public virtual DbSet<GUEST_RIDES> GUEST_RIDES { get; set; }
        public virtual DbSet<RIDES_STAFF> RIDES_STAFF { get; set; }
        public virtual DbSet<SHOP_STAFF> SHOP_STAFF { get; set; }
        public virtual DbSet<TICKETLOOKUP> TICKETLOOKUPs { get; set; }
        public virtual DbSet<GUEST_TICKET> GUEST_TICKET { get; set; }
        public virtual DbSet<SHOPLOOKUP> SHOPLOOKUPs { get; set; }
        public virtual DbSet<STAFFLOOKUP> STAFFLOOKUPs { get; set; }
    }
}
