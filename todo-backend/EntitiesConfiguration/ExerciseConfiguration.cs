using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todo_backend.Entities;

namespace todo_backend.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Description).HasMaxLength(300).IsRequired();
            builder.Property(p => p.IsCompleted).IsRequired();

            builder.HasData(
                new Exercise
                {
                    Id = 1,
                    Description = "Exercício 1",
                    IsCompleted = true
                },
                new Exercise
                {
                    Id = 2,
                    Description = "Exercício 2",
                    IsCompleted = false
                },
                new Exercise
                {
                    Id = 3,
                    Description = "Exercício 3",
                    IsCompleted = true 
                },
                 new Exercise
                 {
                     Id = 4,
                     Description = "Exercício 4",
                     IsCompleted = true
                 }
            );

        }
    }
}
