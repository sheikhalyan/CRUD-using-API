﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AirportmanagementEntities1 : DbContext
    {
        public AirportmanagementEntities1()
            : base("name=AirportmanagementEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Loginn> Loginns { get; set; }

        public System.Data.Entity.DbSet<WebApplication3.ViewModels.AirportViewModel> AirportViewModels { get; set; }
    }
}