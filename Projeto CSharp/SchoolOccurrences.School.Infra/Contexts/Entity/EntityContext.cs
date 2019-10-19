using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using SchoolOccurrences.School.Domain.Entities;
using SchoolOccurrences.School.Infra.JsonClasses;
using SchoolOccurrences.School.Infra.Maps;

namespace SchoolOccurrences.School.Infra.Contexts.Entity
{
    // Instancias das entidades e chamda a classe de configuração das tabelas no banco de dados
    // Classe utilizada nas operações de CRUD para encontrar a tabela correta
    public class EntityContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Domain.Entities.School> Schools { get; set; }
        public DbSet<Occurrence> Occurrences { get; set; }
        public DbSet<Parent> Parents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new SchoolMap());
            modelBuilder.ApplyConfiguration(new OccurrenceMap());
            modelBuilder.ApplyConfiguration(new ParentMap());
            modelBuilder.Ignore<Notification>();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ReadJsonSettings readJsonSettings = new ReadJsonSettings();
            optionsBuilder.UseSqlServer(readJsonSettings.ConnectionString());
        }
    }
}
