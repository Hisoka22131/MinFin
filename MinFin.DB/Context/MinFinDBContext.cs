using Microsoft.EntityFrameworkCore;
using MinFin.DB.Context.Seed;
using MinFin.DB.Domain;

namespace MinFin.DB.Context;

public class MinFinDbContext : DbContext
{
    public MinFinDbContext(DbContextOptions<MinFinDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Seed();
    }
}
