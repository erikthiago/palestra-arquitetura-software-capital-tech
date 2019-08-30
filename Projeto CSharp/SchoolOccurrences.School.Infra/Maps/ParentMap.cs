using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOccurrences.School.Domain.Entities;

namespace SchoolOccurrences.School.Infra.Maps
{
    // Configuração da tabela Responsável e seus dados
    public class ParentMap : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.ToTable("ResResponsavel");

            builder.Property(r => r.Id)
                .HasColumnName("ResId");

            builder.Property(r => r.ResponsibleName)
              .HasColumnName("ResNome")
              .HasColumnType("varchar(100)")
              .IsRequired();

            builder.OwnsOne(r => r.ResponsibleDocument, documento =>
            {
                documento.Property(d => d.Number)
                    .IsRequired()
                    .HasColumnName("ResNumeroDocumento")
                    .HasColumnType("varchar(14)");

                documento.Property(d => d.Type)
                    .IsRequired()
                    .HasColumnName("ResTipoDocumento")
                    .HasColumnType("int");
            });


            builder.Property(r => r.EFamilyType)
                .IsRequired()
                .HasColumnName("ResFamiliaridade")
                .HasColumnType("int");

            builder.Property(r => r.Telephone)
                .IsRequired()
               .HasColumnName("ResTelefonePrincipal")
               .HasColumnType("varchar(10)");

            builder.Property(f => f.AlternativeTelephone)
              .HasColumnName("ResTelefoneAlternativo")
              .HasColumnType("varchar(10)");

            builder.Property(f => f.ContactTelephone)
              .HasColumnName("ResTelefoneContato")
              .HasColumnType("varchar(10)");

            builder.OwnsOne(r => r.Email, email =>
            {
                email.Property(d => d.Address)
                    .IsRequired()
                    .HasColumnName("ResEmail")
                    .HasColumnType("varchar(255)");
            });

            builder.HasOne(r => r.Student)
                .WithMany(s => s.Parents);

            //Ignorar a herança do Flunt
            builder.Ignore(o => o.Invalid);
            builder.Ignore(o => o.Valid);
        }
    }
}
