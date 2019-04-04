using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using US.ASP.EscapeRooms.DAL;
using US.ASP.EscapeRooms.DAL.Entities;

namespace UC.CSP.MeetingCenter.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}