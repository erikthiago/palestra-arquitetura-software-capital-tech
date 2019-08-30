using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolOccurrences.School.Infra.Maps
{
    // Configuração da tabela Escola e seus dados
    public class SchoolMap : IEntityTypeConfiguration<Domain.Entities.School>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.School> builder)
        {
            builder.ToTable("EscEscola");

            builder.Property(e => e.Id)
                .HasColumnName("EscId");

            builder.Property(e => e.Name)
              .HasColumnName("EscNome")
              .HasColumnType("varchar(50)")
              .IsRequired();

            builder.OwnsOne(e => e.Document, documento =>
            {
                documento.Property(d => d.Number)
                    .IsRequired()
                    .HasColumnName("EscNumeroDocumento")
                    .HasColumnType("varchar(14)");

                documento.Property(d => d.Type)
                    .IsRequired()
                    .HasColumnName("EscTipoDocumento")
                    .HasColumnType("int");
            });

            builder.OwnsOne(e => e.Address, endereco =>
            {
                endereco.Property(a => a.Street)
                    .IsRequired()
                    .HasColumnName("EscRua")
                    .HasColumnType("varchar(50)");

                endereco.Property(a => a.Number)
                    .HasColumnName("EscEnderecoNumero")
                    .HasColumnType("int");

                endereco.Property(a => a.Neighborhood)
                    .IsRequired()
                    .HasColumnName("EscBairro")
                    .HasColumnType("varchar(50)");

                endereco.Property(a => a.City)
                    .IsRequired()
                    .HasColumnName("EscCidade")
                    .HasColumnType("varchar(50)");

                endereco.Property(a => a.Abbr)
                  .IsRequired()
                  .HasColumnName("EscSiglaUf")
                  .HasColumnType("int");

                endereco.Property(a => a.StateName)
                  .IsRequired()
                  .HasColumnName("EscUf")
                  .HasColumnType("varchar(50)");

                endereco.Property(a => a.Country)
                    .IsRequired()
                    .HasColumnName("EscPais")
                    .HasColumnType("varchar(50)");

                endereco.Property(a => a.ZipCode)
                    .IsRequired()
                    .HasColumnName("EscCep")
                    .HasColumnType("varchar(9)");
            });

            builder.Property(f => f.Phone)
              .HasColumnName("EscTelefone")
              .HasColumnType("varchar(10)")
              .IsRequired();

            //Ignorar a herança do Flunt
            builder.Ignore(o => o.Invalid);
            builder.Ignore(o => o.Valid);
        }
    }
}
