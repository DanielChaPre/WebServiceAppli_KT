using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class AlumnoDAO
    {
        ConexionDAO conexion = new ConexionDAO();
        MySqlConnection con;
        Alumno alumno;

        public bool GuardarAlummo(Alumno alumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Insert into Alumno() Values ()";
                cmd.Parameters.AddWithValue("@", alumno);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: "+ex.Message);
                return false;
            }
        }

        public bool EliminarAlumno(int idAlumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Delete from ALumno where idAlumno = @idAlumno";
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool ModificarAlumno(Alumno alumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Update set Alumno ";
                cmd.Parameters.AddWithValue("@", alumno);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Alumno ConsultarAlumno(string usuario, string contraseña)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From Alumno where  = @user and  = @pass";
                cmd.Parameters.AddWithValue("@user", usuario);
                cmd.Parameters.AddWithValue("@pass", contraseña);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    alumno = new Alumno();
                }

                return alumno;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}