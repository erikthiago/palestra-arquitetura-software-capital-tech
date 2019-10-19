using SchoolOccurrences.School.Infra.JsonClasses;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SchoolOccurrences.School.Infra.Contexts.Dapper
{
    // Classe utilizada para configurar o banco de dados e fazer com o Dapper faça as pesquisas
    public class DapperContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public DapperContext()
        {
            ReadJsonSettings readJsonSettings = new ReadJsonSettings();
            Connection = new SqlConnection(readJsonSettings.ConnectionString());
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
