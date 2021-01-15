using DesafioOfx.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioOfx.Data.Mappings
{

    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Codigo)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(c => c.Digito)
               .HasColumnType("varchar(2)");

            builder.HasOne(t => t.Agencia)
                .WithMany(c => c.Contas)
                .HasForeignKey(p => p.AgenciaId);

            builder.ToTable("Contas");
        }
    }
}
