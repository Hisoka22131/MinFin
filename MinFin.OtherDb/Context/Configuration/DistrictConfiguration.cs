using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinFin.OtherDb.Domain;

namespace MinFin.OtherDb.Context.Configuration;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        var districts = new List<District>
        {
            new()
            {
                Id = 1,
                Name = "Кировский"
            },
            new()
            {
                Id = 2,
                Name = "Западный"
            }
        };

        builder.HasData(districts);
    }
}