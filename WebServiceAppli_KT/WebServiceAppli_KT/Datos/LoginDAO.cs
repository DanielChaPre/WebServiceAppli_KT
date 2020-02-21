using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        public bool ValidarUsuarioAliasRed(string alias_red)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From usuario where alias_red = @alias_red";
                cmd.Parameters.AddWithValue("@alias_red", alias_red);
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

        public bool ValidarUsuarioAlumno(string idAlumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From usuario where idAlumno = @idAlumno";
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

        public List<string> ValidarContrasenia(string contrasenia, string usuario, string idAlumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select usuario.tipo_usuario, usuario.cve_usuario, persona.nombre, persona.apellido_paterno from usuario" +
                    " inner join persona on persona.cve_usuario = (Select cve_usuario from usuario where(contrasena = @pass)" +
                    " and(nombre_usuario = @usuario) and(idAlumno = @idAlumno)) and" +
                    " (usuario.contrasena = @pass and usuario.nombre_usuario = @usuario and usuario.idAlumno = @idAlumno)";
                cmd.Parameters.AddWithValue("@pass", contrasenia);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                con.Open();
                var lstresultado = new List<string>();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lstresultado.Add(reader["tipo_usuario"].ToString());
                    lstresultado.Add(reader["cve_usuario"].ToString());
                    lstresultado.Add(reader["nombre"].ToString());
                    lstresultado.Add(reader["apellido_paterno"].ToString());
                }
                else
                {
                    con.Close();
                    cmd.CommandText = "Select usuario.tipo_usuario, usuario.cve_usuario from usuario where" +
                       " (usuario.contrasena = @pass and usuario.nombre_usuario = @usuario and usuario.idAlumno = @idAlumno) ";
                    con.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lstresultado.Add(reader["tipo_usuario"].ToString());
                        lstresultado.Add(reader["cve_usuario"].ToString());
                        lstresultado.Add(" ");
                        lstresultado.Add(" ");
                    }
                }
                return lstresultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el logeo, " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<string> ValidarContrasenaAlumno(string contrasenia, string usuario, string idAlumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "    Select usuario.tipo_usuario, usuario.cve_usuario, suredsu.alumnos.Nombre, suredsu.alumnos.ApellidoPaterno from usuario" +
                    " inner join suredsu.alumnos" +
                    " on suredsu.alumnos.idAlumno = (Select idAlumno from usuario where(contrasena = @pass) and(nombre_usuario = @usuario) and(idAlumno = @idAlumno)) and" +
                    " (usuario.contrasena = @pass and usuario.nombre_usuario = @usuario and usuario.idAlumno = @idAlumno)";
                cmd.Parameters.AddWithValue("@pass", contrasenia);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                con.Open();
                var lstresultado = new List<string>();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lstresultado.Add(reader["tipo_usuario"].ToString());
                    lstresultado.Add(reader["cve_usuario"].ToString());
                    lstresultado.Add(reader["Nombre"].ToString());
                    lstresultado.Add(reader["ApellidoPaterno"].ToString());
                }
                return lstresultado;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

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

        public bool CrearCuentaAliasRed(string alias_red)
        {
            try
            {

                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "Insert into usuario(alias_red, tipo_usuario) " +
                    "values(@alias_red, @tipoUsuario) ";
                cmd.Parameters.AddWithValue("@alias_red", alias_red);
                cmd.Parameters.AddWithValue("@tipoUsuario", 1);
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

                //cmd.CommandText = "Select * from usuario where contrasena = @contrasena and idAlumno = @idAlumno";
                cmd.CommandText = "Select * from usuario where idAlumno = @idAlumno";
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

        public Usuario ConsultarUsuarioAlumno(string idAlumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "Select * from usuario where idAlumno = @idAlumno";
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                con.Open();
                var usuario = new Usuario();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usuario.Cve_Usuario = Convert.ToInt32(reader["cve_usuario"].ToString());
                    usuario.IdAlumno = Convert.ToInt32(reader["idAlumno"].ToString());
                    usuario.Nombre_Usuario = reader["nombre_usuario"].ToString();
                    usuario.Contrasena = reader["contrasena"].ToString();
                    usuario.Fecha_Registro =reader["fecha_registro"].ToString();
                    usuario.Estatus = reader["estatus"].ToString();
                    usuario.Alias_Red = reader["alias_red"].ToString();
                }
                return usuario;
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }
    }
}