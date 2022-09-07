using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;

namespace SingleResponsability.Data
{
    public class Conexion
    {
        private string StringSql = string.Empty;
        SqlConnection con;

        private static SqlConnection instancia = null;
        private static readonly object padlock = new object();

        private Conexion()
        {
        }

        public static SqlConnection getConexion
        {
            get
            {
                lock (padlock)
                {
                    if (instancia == null)
                    {
                        instancia = new SqlConnection();
                        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                        instancia.ConnectionString = builder.GetSection("StringConnections:Samtel").Value;
                    }
                    return instancia;
                }
            }
        }


        public static void Open()
        {
            if (instancia != null)
                instancia.Open();
        }

        public static void Close()
        {
            if (instancia != null)
                instancia.Close();
        }

        //public Conexion()
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        //    this.con = new SqlConnection(builder.GetSection("StringConnections:Samtel").Value);
        //}

    }
}
