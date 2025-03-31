using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTool.HandyTool.Infrastructure
{
    public static class SqlConnectionHelper
    {
        public static SqlConnection InitializeSqlConnection(string server)
        {
            if (!string.IsNullOrEmpty(server))
            {
                return new SqlConnection($"Server={server};Trusted_Connection=true;TrustServerCertificate=true");
            }
            return null;
        }
    }
}
