using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Suftnet.Co.Bima.DataAccess.Identity;

namespace Suftnet.Co.Bima.DataAccess.Actions
{
    public partial class v12Context : IdentityDbContext<ApplicationUser>
    {
        public v12Context()
        {
        }

        public v12Context(DbContextOptions<v12Context> options)
            : base(options)
        {
        }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<Area> Area { get; set; }       
        public virtual DbSet<Bargain> Bargain { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<BuyerAddress> BuyerAddress { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<LogViewer> LogViewer { get; set; }
        public virtual DbSet<MobileLogger> MobileLogger { get; set; }
        public virtual DbSet<OfferStatus> OfferStatus { get; set; }
        public virtual DbSet<Offers> Offers { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductStatus> ProductStatus { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<SellerAddress> SellerAddress { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.\\;Database=v12;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
        }
    }
}
