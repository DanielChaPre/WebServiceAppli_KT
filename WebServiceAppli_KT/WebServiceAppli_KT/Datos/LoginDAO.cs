using MySql.Data.MySqlClient;
using System;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class LoginDAO
    {
        ConexionAppliktDAO conexion = new ConexionAppliktDAO();
        MySqlConnection con;



        public bool ValidarUsuario(string usuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From usuario where nombre_usuario = @user";
                cmd.Parameters.AddWithValue("@user", usuario);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en el logeo, " + ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ValidarContrasenia(string contrasenia, string usuario, string idAlumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From usuario where contrasena = @pass and nombre_usuario = @usuario and idAlumno = @idAlumno";
                cmd.Parameters.AddWithValue("@pass", contrasenia);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return true;
                else
                    return false;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en el logeo, " + ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

       // public bool CrearCuenta(string usuario, string contrasenia)
        public bool CrearCuenta(string usuario, string contrasena, string idAlumno, string tipoUsuario)
        {
            try
            {
                
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "Insert into usuario(nombre_usuario,contrasena, idAlumno, tipo_usuario) " +
                    "values(@usuario, @contrasena,@idAlumno, @tipoUsuario) ";
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                cmd.Parameters.AddWithValue("@tipoUsuario", Convert.ToInt16(tipoUsuario));
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al insertar la cuenta " + ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool RecuperarContraseña(string usuario, string nuevaContrasena)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE usuario SET contrasena = @contrasena where nombre_usuario = @nombre_usuario";
                cmd.Parameters.AddWithValue("@contrasena", nuevaContrasena);
                cmd.Parameters.AddWithValue("@nombre_usuario", usuario);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool VerificarRegistroAlumno(string contrasena, string idAlumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "Select * from usuario where contrasena = @contrasena and idAlumno = @idAlumno";
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}