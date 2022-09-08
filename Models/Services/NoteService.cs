using SingleResponsability.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SingleResponsability.Models.Services
{
    public class NoteService
    {
        public NoteService()
        {

        }

        public List<NoteViewModel> List(int student_id)
        {
            var oNote = new List<NoteViewModel>();
            var con = Conexion.getConexion;
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("spNotes", con);
                cmd.Parameters.AddWithValue("Op", "Listar");
                cmd.Parameters.AddWithValue("student_id", student_id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oNote.Add(new NoteViewModel()
                    {
                        note_id = Convert.ToInt32(reader["note_id"]),
                        student_id = Convert.ToInt32(reader["student_id"]),
                        subject_id = Convert.ToInt32(reader["subject_id"]),
                        name = reader["name"].ToString(),
                        note = Convert.ToInt32(reader["note"])
                    });
                }
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
                throw;
            }

            return oNote;
        }

        public bool Create(NoteViewModel note)
        {
            bool resp;
            try
            {
                var con = Conexion.getConexion;
                con.Open();
                SqlCommand cmd = new SqlCommand("spNotes", con);
                cmd.Parameters.AddWithValue("Op", "Guardar");
                cmd.Parameters.AddWithValue("subject_id", note.subject_id);
                cmd.Parameters.AddWithValue("student_id", note.student_id);
                cmd.Parameters.AddWithValue("note", note.note);
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
