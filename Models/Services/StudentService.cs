using SingleResponsability.Data;
using SingleResponsability.Utils;
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
            var con = Conexion.getConexion;
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand("spStudent", con);
                cmd.Parameters.AddWithValue("Op", "Listar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oStudent.Add(new StudentViewModel()
                    {
                        Student_id = Convert.ToInt32(reader["student_id"]),
                        dni = reader["dni"].ToString(),
                        firstName = reader["firstName"].ToString(),
                        lastName = reader["lastName"].ToString(),
                        dateOfBirth = Convert.ToDateTime(reader["dateOfBirth"]),
                        Genre = reader["genre"].ToString(),
                        Email = reader["email"].ToString(),
                        isActive = Convert.ToInt32(reader["isActive"])
                    });
                }
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }
           
            return oStudent;
        }
        public bool Create(StudentViewModel student)
        {
            bool resp;
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            try
            {
               var con = Conexion.getConexion;
                con.Open();
                SqlCommand cmd = new SqlCommand("spStudent", con);
                cmd.Parameters.AddWithValue("Op", "Guardar");
                cmd.Parameters.AddWithValue("dni",student.dni);
                cmd.Parameters.AddWithValue("firstName", student.firstName);
                cmd.Parameters.AddWithValue("lastName", student.lastName);
                cmd.Parameters.AddWithValue("dateOfBirth", student.dateOfBirth);
                cmd.Parameters.AddWithValue("genre", student.Genre);
                cmd.Parameters.AddWithValue("email", student.Email);
                cmd.Parameters.AddWithValue("isActive", student.isActive);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //SqlDataReader reader = cmd.ExecuteReader();
                //for (var i = 0; i < reader.FieldCount; i++)
                //    cols.Add(reader.GetName(i));

                //while (reader.Read())
                //    results.Add(utils.SerializeRow(cols, reader));
                cmd.ExecuteNonQuery();
                con.Close();
                resp = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                resp = false;
            }
            return resp;
        }
    }
}
