using Microsoft.Data.SqlClient;

namespace HandyTool.HandyTool.Infrastructure
{
    public class SqlConnectionHelper
    {
        public SqlConnection InitializeSqlConnection(ContainerForm form)
        {
            string server = form.GetSelectedServerName();
            if (!string.IsNullOrEmpty(server))
            {
                return new SqlConnection($"Server={server};Trusted_Connection=true;TrustServerCertificate=true");
            }
            return null;
        }
    }
}
