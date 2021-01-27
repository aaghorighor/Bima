using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Suftnet.Co.Bima.DataAccess.Identity;

#nullable disable

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

        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<BuyerAddress> BuyerAddresses { get; set; }
        public virtual DbSet<BuyerOrder> BuyerOrders { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<DeliveryOffer> DeliveryOffers { get; set; }
        public virtual DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<LogViewer> LogViewers { get; set; }
        public virtual DbSet<MobileLogger> MobileLoggers { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<OfferStatus> OfferStatuses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Produce> Produce { get; set; }
        public virtual DbSet<ProduceBuyer> ProduceBuyers { get; set; }
        public virtual DbSet<ProductStatus> ProductStatuses { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<SellerAddress> SellerAddresses { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }

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
