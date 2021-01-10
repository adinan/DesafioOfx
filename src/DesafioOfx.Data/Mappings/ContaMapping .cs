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

            builder.HasOne(t => t.Agencia)
                .WithMany(c => c.Contas)
                .HasForeignKey(p => p.AgenciaId);

            builder.ToTable("Contas");
        }
    }
}
