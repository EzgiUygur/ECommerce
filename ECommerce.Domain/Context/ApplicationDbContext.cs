using System.Linq.Expressions;
using ECommerce.Domain.Configurations;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Domain.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserBasket> UserBaskets { get; set; }

        // CodeFirst yaklaşımda veritabanına göndereceğim DDL - DML configurationları ayarlıyorum.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);

            // Db Initialize Data
            modelBuilder.Entity<Role>().HasData(new Role()
            {
                Id = (long)UserRole.Merchant,
                Name = UserRole.Merchant.ToString(),
                Description = "Merchant Description"
            });

            modelBuilder.Entity<Role>().HasData(new Role()
            {
                Id = (long)UserRole.Customer,
                Name = UserRole.Customer.ToString(),
                Description = "Customer Description"
            });

            // Her tablo için default filtre ekliyorum. (IsDeleted = false)
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var isDeletedProp = entity.FindProperty("IsDeleted");

                var parameter = Expression.Parameter(entity.ClrType, "p");
                var filter = Expression.Lambda(Expression.Not(Expression.Property(parameter, isDeletedProp.PropertyInfo)), parameter);
                _ = modelBuilder.Entity(entity.ClrType).HasQueryFilter(filter);
            }

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = this._configuration.GetRequiredSection("DatabaseSettings:ConnectionString").Value;
            optionsBuilder.UseSqlServer(configuration);
        }
    }
}
