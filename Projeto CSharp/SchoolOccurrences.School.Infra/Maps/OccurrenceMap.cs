using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOccurrences.School.Domain.Entities;

namespace SchoolOccurrences.School.Infra.Maps
{
    // Configuração da tabela Ocorrencia e seus dados
    public class OccurrenceMap : IEntityTypeConfiguration<Occurrence>
    {
        public void Configure(EntityTypeBuilder<Occurrence> builder)
        {
            builder.ToTable("OcrOcorrencia");

            builder.Property(o => o.Id)
                .HasColumnName("OcrId");

            builder.Property(o => o.OccurrenceType)
                .IsRequired()
                .HasColumnName("OcrTipo")
                .HasColumnType("int");

            builder.Property(o => o.Cause)
                .HasColumnName("OcrCausa")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(o => o.Description)
                .HasColumnName("OcrDescricao")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(o => o.OccurrenceStatus)
                .IsRequired()
                .HasColumnName("OcrSituacao")
                .HasColumnType("int");

            builder.Property(o => o.Date)
                .HasColumnName("OcrData")
                .HasColumnType("datetime2")
                .IsRequired();

            builder.HasOne(e => e.Student)
                .WithMany(o => o.Occurrences);

            //Ignorar a herança do Flunt
            builder.Ignore(o => o.Invalid);
            builder.Ignore(o => o.Valid);
        }
    }
}
