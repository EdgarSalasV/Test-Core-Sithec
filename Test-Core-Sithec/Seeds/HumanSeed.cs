using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Test_Core_Sithec.Models;

namespace Test_Core_Sithec.Seeds
{
    internal class HumanConfiguration : IEntityTypeConfiguration<Human>
    {
        public void Configure(EntityTypeBuilder<Human> builder)
        {
            builder.ToTable("Humans");
            builder.HasKey(x => x.Id);
            builder.HasData(new List<Human> {
            new Human
            {
                Id = 1,
                Name= "Human 1",
                Gender = false,
                Age = 23,
                Height = 1.11m,
                Weight = 112,
            },
            new Human
            {
                Id = 2,
                Name= "Human 2",
                Gender = true,
                Age = 18,
                Height = 1.56M,
                Weight = 112,
            },
        });
        }
    }
}
