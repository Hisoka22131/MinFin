using Microsoft.EntityFrameworkCore;
using MinFin.DB.Domain;

namespace MinFin.DB.Context;

public class MinFinDBContext : DbContext
{
    /// <summary>
    /// todo: Перенести в AppSettings
    /// </summary>
    private const string ConString = "Server=.\\; Database=MinFin; Trusted_Connection=True; MultipleActiveResultSets=True; TrustServerCertificate=True";
    
    public MinFinDBContext()
    {
    }

    public MinFinDBContext(DbContextOptions<MinFinDBContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConString);
        }
    }
}