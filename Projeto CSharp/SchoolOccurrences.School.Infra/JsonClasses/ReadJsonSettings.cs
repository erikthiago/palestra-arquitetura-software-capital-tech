using Microsoft.Extensions.Configuration;
using System.IO;

namespace SchoolOccurrences.School.Infra.JsonClasses
{
    // Classe responsável por encontrar o arquivo appsettings.json que contem a conexão com o banco de dados
    public class ReadJsonSettings
    {
        public string ConnectionString()
        {
            return GetConnectionString();
        }

        private string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return (config.GetConnectionString("connectionString"));
        }
    }
}
