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
        // ConexionAppliktDAO conexion = new ConexionAppliktDAO();
        ConexionSuredsuDAO conexion = new ConexionSuredsuDAO();
        MySqlConnection con;
        Alumno alumno;

        public List<int> GuardarAlummo(Persona persona)
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
                return null;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public bool EliminarAlumno(int idAlumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Delete from Alumno where idAlumno = @idAlumno";
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

        public Alumno ConsultarAlumno(int idAlumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select Nombre, ApellidoPaterno, ApellidoMaterno, CURP, Sexo, Calle, NumeroExterior, NumeroInterior," +
                    " Email, Celular, Telefono, FOLIOSUREDSU, FolioSUREMS, idColonia, Nacionalidad, idMunicipio, idPais, ClavePlantelESEC," +
                    " idPlantelEMS from alumnos where idAlumno = @idAlumno";
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    alumno = new Alumno();
                    alumno.IdAlumno = idAlumno;
                    alumno.Nombre1 = reader["Nombre"].ToString();
                    alumno.ApellidoPaterno1 = reader["ApellidoPaterno"].ToString();
                    alumno.ApellidoMaterno1 = reader["ApellidoMaterno"].ToString();
                    alumno.CURP1 = reader["CURP"].ToString();
                    alumno.Sexo1 = reader["Sexo"].ToString();
                    alumno.Calle1 = reader["Calle"].ToString();
                    alumno.NumeroExterior1 = reader["NumeroExterior"].ToString();
                    alumno.NumeroInterior1 = reader["NumeroInterior"].ToString();
                    alumno.Email1 = reader["Email"].ToString();
                    alumno.Celular1 = reader["Celular"].ToString();
                    alumno.Telefono1 = reader["Telefono"].ToString();
                    alumno.FOLIOSUREDSU1 = reader["FOLIOSUREDSU"].ToString();
                    alumno.FolioSUREMS1 = reader["FolioSUREMS"].ToString();
                    alumno.IdColonia = Convert.ToInt32(reader["idColonia"].ToString());
                    alumno.IdMunicipio = Convert.ToInt32(reader["idMunicipio"].ToString());
                    alumno.IdPais = Convert.ToInt32(reader["idPais"].ToString());
                    alumno.ClavePlantelESEC1 = reader["ClavePlantelESEC"].ToString();
                    alumno.IdPlantelEMS = Convert.ToInt32(reader["idPlantelEMS"].ToString());
                    alumno.Nacionalidad1 = reader["Nacionalidad"].ToString();
                }
                return alumno;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int BuscarIdAlumnoCurp(string curp)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select idAlumno From alumnos where CURP = @curp";
                cmd.Parameters.AddWithValue("@curp", curp);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                int idAlumno = 0;
                if (reader.Read())
                {
                    idAlumno = Convert.ToInt32(reader["idAlumno"].ToString());
                }
                return idAlumno;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}