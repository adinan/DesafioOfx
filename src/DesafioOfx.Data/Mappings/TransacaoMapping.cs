using DesafioOfx.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioOfx.Data.Mappings
{

    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.TipoTransacao)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.DataLancamento)
               .IsRequired()
               .HasColumnType("datetime");

            builder.Property(c => c.Valor)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

            builder.Property(c => c.CodigoUnico)
               .IsRequired()
               .HasColumnType("varchar(34)");

            builder.Property(c => c.CodigoReferencia)
               .IsRequired()
               .HasColumnType("varchar(22)");

            builder.Property(c => c.Descricacao)
               .IsRequired()
               .HasColumnType("varchar(1000)");
             

            builder.HasOne(t => t.Conta)
                .WithMany(c => c.Transacaos)
                .HasForeignKey(p => p.ContaId);

            builder.ToTable("Transacoes");
        }
    }
}
