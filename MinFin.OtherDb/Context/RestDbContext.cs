using Microsoft.EntityFrameworkCore;
using MinFin.OtherDb.Context.Configuration;
using MinFin.OtherDb.Domain;

namespace MinFin.OtherDb.Context;

public class RestDbContext : DbContext
{
    public RestDbContext(DbContextOptions<RestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }
    
    public virtual DbSet<District> Districts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DistrictConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }
}