using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace SingleResponsability.Data
{
    public class Conexion
    {
        private string StringSql = string.Empty;
        SqlConnection con;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            this.con = new SqlConnection(builder.GetSection("StringConnections:Samtel").Value;
        }

    }
}
