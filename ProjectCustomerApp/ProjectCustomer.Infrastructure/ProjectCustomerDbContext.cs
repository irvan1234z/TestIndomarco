using Microsoft.EntityFrameworkCore;
using ProjectCustomer.Domain.Entities;

namespace ProjectCustomer.Infrastructure;

public class ProjectCustomerDbContext : DbContext
{
    public ProjectCustomerDbContext(DbContextOptions<ProjectCustomerDbContext> options) : base(options) {}

    public DbSet<Customer> Customer => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customer");

            //melakukan lower case data karena untuk postgre db nya baik tabel maupun field harus lowe
            entity.HasKey(e => e.CustomerId);
            entity.Property(e => e.CustomerId).HasColumnName("customerid");
            entity.Property(e => e.CustomerCode).HasColumnName("customercode");
            entity.Property(e => e.CustomerName).HasColumnName("customername");
            entity.Property(e => e.CustomerAddress).HasColumnName("customeraddress");
            entity.Property(e => e.CreatedBy).HasColumnName("createdby");
            entity.Property(e => e.CreatedAt).HasColumnName("createdat");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedby");
            entity.Property(e => e.ModifiedAt).HasColumnName("modifiedat");
        });
    }
}