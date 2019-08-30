using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOccurrences.School.Domain.Entities;

namespace SchoolOccurrences.School.Infra.Maps
{
    // Configuração da tabela Estudante e seus dados
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("EstEstudante");

            builder.Property(e => e.Id)
                .HasColumnName("EstId");

            builder.OwnsOne(e => e.Name, nome =>
            {
                nome.Property(n => n.FirstName)
                    .IsRequired()
                    .HasColumnName("EstNome")
                    .HasColumnType("varchar(60)");

                nome.Property(n => n.LastName)
                    .IsRequired()
                    .HasColumnName("EstSobreNome")
                    .HasColumnType("varchar(60)");
            });

            builder.OwnsOne(e => e.Address, endereco =>
            {
                endereco.Property(a => a.Street)
                    .IsRequired()
                    .HasColumnName("EstRua")
                    .HasColumnType("varchar(50)");

                endereco.Property(a => a.Number)
                    .HasColumnName("EstEnderecoNumero")
                    .HasColumnType("int");

                endereco.Property(a => a.Neighborhood)
                    .IsRequired()
                    .HasColumnName("EstBairro")
                    .HasColumnType("varchar(50)");

                endereco.Property(a => a.City)
                    .IsRequired()
                    .HasColumnName("EstCidade")
                    .HasColumnType("varchar(50)");

                endereco.Property(a => a.Abbr)
                     .IsRequired()
                     .HasColumnName("EstSiglaUf")
                     .HasColumnType("int");

                endereco.Property(a => a.StateName)
                    .IsRequired()
                    .HasColumnName("EstUf")
                    .HasColumnType("varchar(50)");

                endereco.Property(a => a.Country)
                    .IsRequired()
                    .HasColumnName("EstPais")
                    .HasColumnType("varchar(50)");

                endereco.Property(a => a.ZipCode)
                    .IsRequired()
                    .HasColumnName("EstCep")
                    .HasColumnType("varchar(9)");
            });

            builder.Property(e => e.BirthDate)
                .HasColumnName("EstDataNascimento")
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(e => e.Shifts)
                .IsRequired()
                .HasColumnName("EstTurno")
                .HasColumnType("int");

            builder.Property(e => e.ETypeOfEducation)
                .IsRequired()
                .HasColumnName("EstTipoEnsino")
                .HasColumnType("int");

            builder.Property(e => e.AcademicYear)
                .HasColumnName("EstAnoLetivo")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.Serie)
               .IsRequired()
               .HasColumnName("EstSerie")
               .HasColumnType("int");

            builder.Property(e => e.Grade)
               .IsRequired()
               .HasColumnName("EstTurma")
               .HasColumnType("varchar(1)");

            builder.Property(e => e.CalledNumber)
               .IsRequired()
               .HasColumnName("EstNumeroChamada")
               .HasColumnType("int");

            builder.Property(e => e.Note)
              .IsRequired()
              .HasColumnName("EstObservacao")
              .HasColumnType("varchar(255)");

            builder.HasOne(e => e.School)
                .WithMany(s => s.Students);

            builder.HasMany(e => e.Parents)
                .WithOne(p => p.Student)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Occurrences)
                .WithOne(o => o.Student)
                .OnDelete(DeleteBehavior.Cascade);

            //Ignorar a herança do Flunt
            builder.Ignore(o => o.Invalid);
            builder.Ignore(o => o.Valid);

        }
    }
}
