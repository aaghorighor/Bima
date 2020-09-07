using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Suftnet.Co.Bima.DataAccess.Identity;

namespace Suftnet.Co.Bima.DataAccess.Models
{
    public partial class BimaContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public BimaContext()
        {
        }

        public BimaContext(DbContextOptions<BimaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }       
        public virtual DbSet<Chapter> Chapter { get; set; }
        public virtual DbSet<Common> Common { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAccount> CustomerAccount { get; set; }
        public virtual DbSet<DeliveryAddress> DeliveryAddress { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<DriverAccount> DriverAccount { get; set; }
        public virtual DbSet<Editor> Editor { get; set; }
        public virtual DbSet<Faq> Faq { get; set; }
        public virtual DbSet<Global> Global { get; set; }
        public virtual DbSet<LogViewer> LogViewer { get; set; }
        public virtual DbSet<MobileLogger> MobileLogger { get; set; }
        public virtual DbSet<MobilePermission> MobilePermission { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDelivery> OrderDelivery { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderPayment> OrderPayment { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<OrderType> OrderType { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PickUpAddress> PickUpAddress { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<SubTopic> SubTopic { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=Bima;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
