using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.DBContext
{
    public class Conexion
    {
        SqlConnection con;
        IConfiguration configuration;
        public Conexion(string conexion)
        {
            Console.WriteLine("Cadena Conexion");
            Console.WriteLine(conexion);
            this.con = new SqlConnection(conexion);
        }

        public SqlConnection getConexion()
        {
            return this.con;
        }

        public string Select()
        {
            this.con.Open();
            string queryString = "SELECT * FROM dbo.Student;";
            SqlCommand command = new SqlCommand(queryString, this.con);
            SqlDataReader reader = command.ExecuteReader();
            return "Ok";
        }
    }

}
