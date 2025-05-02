using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class DbContext(DbContextOptions<DbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<CustomerCar> CustomerCars { get; set; }
    public DbSet<OrderService> OrderServices { get; set; }
    public DbSet<RoleUser> RoleUsers { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User 
        modelBuilder.Entity<User>()
            .HasKey(x => x.Id);
        
        // Brand 
        modelBuilder.Entity<Brand>()
            .HasMany(b => b.Cars)
            .WithOne(c => c.Brand)
            .HasForeignKey(c => c.BrandId);
    
        // CustomerCar 
        modelBuilder.Entity<CustomerCar>()
            .HasOne(cc => cc.Car)
            .WithMany(c => c.CustomerCars)
            .HasForeignKey(cc => cc.CarId);
    
        modelBuilder.Entity<CustomerCar>()
            .HasOne(cc => cc.Customer)
            .WithMany(u => u.CustomerCars)
            .HasForeignKey(cc => cc.CustomerId);
    
        // Order 
        modelBuilder.Entity<Order>()
            .HasOne(o => o.CustomerCar)
            .WithMany(cc => cc.Orders)
            .HasForeignKey(o => o.CustomersCarId);
    
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Administrator)
            .WithMany(u => u.OrdersAsAdministrator)
            .HasForeignKey(o => o.AdministratorId)
            .OnDelete(DeleteBehavior.Restrict);
    
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Employee)
            .WithMany(u => u.OrdersAsEmployee)
            .HasForeignKey(o => o.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    
        // OrderService (м-к-м)
        modelBuilder.Entity<OrderService>()
            .HasKey(os => os.Id);
    
        modelBuilder.Entity<OrderService>()
            .HasOne(os => os.Order)
            .WithMany(o => o.OrderServices)
            .HasForeignKey(os => os.OrderId);
    
        modelBuilder.Entity<OrderService>()
            .HasOne(os => os.Service)
            .WithMany(s => s.OrderServices)
            .HasForeignKey(os => os.ServiceId);
    
        // RoleUser (м-к-м)
        modelBuilder.Entity<RoleUser>()
            .HasKey(ru => ru.Id);
    
        modelBuilder.Entity<RoleUser>()
            .HasOne(ru => ru.User)
            .WithMany(u => u.RoleUsers)
            .HasForeignKey(ru => ru.UserId);

        modelBuilder.Entity<RoleUser>()
            .HasOne(ru => ru.Role)
            .WithMany(r => r.RoleUsers)
            .HasForeignKey(ru => ru.RoleId);
        
        base.OnModelCreating(modelBuilder);
    }
}