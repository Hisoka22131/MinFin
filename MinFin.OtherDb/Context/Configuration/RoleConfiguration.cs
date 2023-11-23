using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinFin.OtherDb.Domain;

namespace MinFin.OtherDb.Context.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        var roles = new List<Role>
        {
            new()
            {
                Id = 1,
                Name = "Admin"
            },
            new()
            {
                Id = 2,
                Name = "Manager"
            }
        };
        
        builder.HasData(roles);
    }
}