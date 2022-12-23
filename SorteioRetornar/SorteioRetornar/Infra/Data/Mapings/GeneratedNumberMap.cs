using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SorteioRetornar.Domain.Entities;

namespace SorteioRetornar.Infra.Data.Mapings
{
    public class GeneratedNumberMap : IEntityTypeConfiguration<GeneratedNumber>
    {
        public void Configure(EntityTypeBuilder<GeneratedNumber> builder)
        {
            // Tabela
            builder.ToTable("GeneratedNumber");

            // Chave primária
            builder.HasKey("Id");

            // Propriedades
            builder.Property(x => x.RandomNumber)
                .IsRequired()
                .HasColumnName("RandomNumber");

            builder.HasIndex(x => x.RandomNumber, "IX_Random_Number")
                .IsUnique();

            // Relacionamentos
            builder.HasOne(x => x.Client)
                .WithMany(x => x.GeneratedNumbers)
                .HasConstraintName("FK_GeneratedNumbers_Client")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
