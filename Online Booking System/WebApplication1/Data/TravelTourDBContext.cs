using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class TravelTourDBContext : DbContext
    {
        public TravelTourDBContext() : base("name=connectionStr")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ImageAttachment> ImageAttachments { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<TBLImage> TBLImages { get; set; }
        public DbSet<tblStudent> tblStudents { get; set; }
        public DbSet<tblClass> tblClasses { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.DTOs.Info.InfoResponse> InfoResponses { get; set; }
    }
}