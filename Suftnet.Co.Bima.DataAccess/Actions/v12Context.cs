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

        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<AspNetUser> AspNetUser { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<BuyerAddress> BuyerAddress { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<LogViewer> LogViewer { get; set; }
        public virtual DbSet<MobileLogger> MobileLogger { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuse { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }
        public virtual DbSet<Produce> Produce { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<SellerAddress> SellerAddress { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
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
