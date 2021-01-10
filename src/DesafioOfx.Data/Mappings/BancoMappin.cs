using DesafioOfx.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioOfx.Data.Mappings
{

    public class BancoMapping : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Codigo)
                .IsRequired()
                .HasColumnType("int");
             
            builder.Property(c => c.Nome)
               .IsRequired()
               .HasColumnType("varchar(1000)");

            builder.ToTable("Bancos");
        }
    }
}
