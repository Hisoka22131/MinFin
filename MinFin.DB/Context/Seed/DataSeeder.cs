using Microsoft.EntityFrameworkCore;

namespace MinFin.DB.Context.Seed;

public static class DataSeeder
{
    internal static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.SeedUsers();
    }
}