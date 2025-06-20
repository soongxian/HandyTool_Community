using CsvHelper;
using HandyTool.HandyTool.Domain.Model;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace HandyTool.HandyTool.Infrastructure
{
    public class SqlConnectionHelper
    {
        public SqlConnection InitializeSqlConnection(ContainerForm form)
        {
            string server = form.GetSelectedServerName();
            if (string.IsNullOrEmpty(server))
            {
                return null;
            }

            if (!File.Exists(DatabaseCsv.FilePath))
            {
                return null;
            }

            using (var reader = new StreamReader(DatabaseCsv.FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ServerCredential>().ToList();
                var matched = records.FirstOrDefault(r => r.Server == server && r.Deleted == 0);

                if (matched != null)
                {
                    string connectionString;

                    if (matched.LoginNeeded)
                    {
                        // SQL Server Authentication
                        connectionString = $"Server={matched.Server};User Id={matched.Username};Password={matched.Password};TrustServerCertificate=true";
                    }
                    else
                    {
                        // Windows Authentication
                        connectionString = $"Server={matched.Server};Trusted_Connection=true;TrustServerCertificate=true";
                    }

                    return new SqlConnection(connectionString);
                }
            }

            return null;
        }
    }
}
