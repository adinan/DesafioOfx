using DesafioOfx.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioOfx.Data.Mappings
{

    public class AgenciaMapping : IEntityTypeConfiguration<Agencia>
    {
        public void Configure(EntityTypeBuilder<Agencia> builder)
        {
             

            //*/
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Codigo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Digito)
               .IsRequired()
               .HasColumnType("varchar(2)");

            builder.Property(c => c.Nome)
               .IsRequired()
               .HasColumnType("varchar(1000)");
             

            builder.HasOne(a => a.Banco)
                .WithMany(c => c.Agencias)
                .HasForeignKey(p => p.BancoId);

            builder.ToTable("Agencias");
        }
    }
}
