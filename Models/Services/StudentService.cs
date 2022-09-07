using SingleResponsability.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Models.Services
{
    public class StudentService
    {
        public List<StudentViewModel> List()
        {
            var oStudent = new List<StudentViewModel>();
            return oStudent;
        }
        public bool Create(StudentViewModel student)
        {
            try
            {
               var con = Conexion.getConexion;
                con.Open();
                SqlCommand cmd = new SqlCommand("spStudent", con);
                cmd.Parameters.AddWithValue("Op","Guardar");
                cmd.Parameters.AddWithValue("dni",student.dni);
                cmd.Parameters.AddWithValue("firstName", student.firstName);
                cmd.Parameters.AddWithValue("lastName", student.lastName);
                cmd.Parameters.AddWithValue("genre", student.Genre);
                cmd.Parameters.AddWithValue("email", student.Email);
                cmd.Parameters.AddWithValue("isActive", student.isActive);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
    }
}
