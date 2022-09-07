using SingleResponsability.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SingleResponsability.Models.Services
{
    public class SubjectServices
    {
        public List<SubjectViewModel> List()
        {
            var oSubject = new List<SubjectViewModel>();
            var con = Conexion.getConexion;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spSubject", con);
                cmd.Parameters.AddWithValue("Op", "Listar");
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oSubject.Add(new SubjectViewModel()
                    {
                        subject_id = Convert.ToInt32(reader["subject_id"]),
                        name = reader["name"].ToString(),
                        description = reader["description"].ToString(),
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
            return oSubject;
        }

        public bool Create(SubjectViewModel subject)
        {
            bool resp;
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            try
            {
                var con = Conexion.getConexion;
                con.Open();
                SqlCommand cmd = new SqlCommand("spSubject", con);
                cmd.Parameters.AddWithValue("Op", "Guardar");
                cmd.Parameters.AddWithValue("name", subject.name);
                cmd.Parameters.AddWithValue("descripcion", subject.description);
                cmd.Parameters.AddWithValue("isActive", subject.isActive);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
