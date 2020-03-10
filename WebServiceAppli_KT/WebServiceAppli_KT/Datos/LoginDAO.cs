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

        public List<string> ValidarUsuarioFacebook(string alias_red)
        {
            try
            {
                var tipousuario = ValidarTipoUsuario(alias_red, "");
                var listResultado = new List<string>();
                if (tipousuario == 2)
                {
                    //alumno
                    listResultado = ValidarRedSocialAlumno(alias_red, "");
                }
                else
                {
                    //otros usuarios
                    listResultado = ValidarRedSocialUsuario(alias_red, "");
                }

                return listResultado;
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en el logeo, " + ex.Message);
                return null;
            }
        }

        private List<string> ValidarRedSocialAlumno(string perfilFacebook, string perfilGoogle)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " Select usuario.tipo_usuario, usuario.cve_usuario, usuario.idAlumno, suredsu.alumnos.Nombre, suredsu.alumnos.ApellidoPaterno from usuario" +
                    " inner join suredsu.alumnos on suredsu.alumnos.idAlumno in " +
                    "(Select idAlumno from usuario where(nombre_usuario_FB = @fb or nombre_usuario_GM = @gm )) and" +
                    " (nombre_usuario_FB = @fb or nombre_usuario_GM = @gm)";
                cmd.Parameters.AddWithValue("@fb", perfilFacebook);
                cmd.Parameters.AddWithValue("@gm", perfilGoogle);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                var listaResultado = new List<string>();
                if (reader.Read())
                {
                    listaResultado.Add(reader["tipo_usuario"].ToString());
                    listaResultado.Add(reader["cve_usuario"].ToString());
                    listaResultado.Add(reader["idAlumno"].ToString());
                    listaResultado.Add(reader["Nombre"].ToString());
                    listaResultado.Add(reader["ApellidoPaterno"].ToString());
                }
                return listaResultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<string> ValidarRedSocialUsuario(string perfilFacebook, string perfilGoogle)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = " Select  usuario.tipo_usuario, usuario.cve_usuario, persona.nombre, persona.apellido_paterno from usuario" +
                    " inner join persona on persona.cve_usuario = " +
                    "(Select cve_usuario from usuario where(nombre_usuario_FB = @fb or nombre_usuario_GM = @gm )) and" +
                    " (nombre_usuario_FB = @fb or nombre_usuario_GM = @gm)";
                cmd.Parameters.AddWithValue("@fb", perfilFacebook);
                cmd.Parameters.AddWithValue("@gm", perfilGoogle);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                var listaResultado = new List<string>();
                if (reader.Read())
                {
                    listaResultado.Add(reader["tipo_usuariox"].ToString());
                    listaResultado.Add(reader["cve_usuario"].ToString());
                    listaResultado.Add("0");
                    listaResultado.Add(reader["nombre"].ToString());
                    listaResultado.Add(reader["apellido_paterno"].ToString());
                }
                else
                {
                    con.Close();
                    cmd.CommandText = "Select usuario.tipo_usuario, usuario.cve_usuario from usuario where" +
                       " (nombre_usuario_FB = @fb or nombre_usuario_GM = @gm) ";
                    con.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listaResultado.Add(reader["tipo_usuariox"].ToString());
                        listaResultado.Add(reader["cve_usuario"].ToString());
                        listaResultado.Add("");
                        listaResultado.Add("");
                    }
                }
                return listaResultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int ValidarTipoUsuario(string aliasredfecebook, string aliasredgoogle)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select tipo_usuario from usuario where nombre_usuario_FB = @fb or nombre_usuario_GM = @gm";
                cmd.Parameters.AddWithValue("@fb", aliasredfecebook);
                cmd.Parameters.AddWithValue("@gm", aliasredgoogle);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["tipo_usuario"].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<string> ValidarUsuarioGoogle(string alias_red)
        {
            try
            {
                var tipousuario = ValidarTipoUsuario("", alias_red);
                var listResultado = new List<string>();
                if (tipousuario == 2)
                {
                    //alumno
                    listResultado = ValidarRedSocialAlumno("", alias_red);
                }
                else
                {
                    //otros usuarios
                    listResultado = ValidarRedSocialUsuario("", alias_red);
                }

                return listResultado;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en el logeo, " + ex.Message);
                return null;
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
                    " on suredsu.alumnos.idAlumno = (Select idAlumno from usuario where(contrasena = @pass) and  (idAlumno = @idAlumno)) and" +
                    " (usuario.contrasena = @pass and usuario.idAlumno = @idAlumno)";
                cmd.Parameters.AddWithValue("@pass", contrasenia);
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

        public List<string> RelacionarFacebookUsuario(string alias_red, string usuario, string contrasena)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update usuario set nombre_usuario_FB = @aliasRed" +
                    "  where nombre_usuario = @usuario and contrasena = @contrasena";
                cmd.Parameters.AddWithValue("@aliasRed", alias_red);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                con.Open();
                cmd.ExecuteNonQuery();
                return ValidarRedSocialUsuario(alias_red,"");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al insertar la cuenta " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<string> RelacionarGoogleUsuario(string alias_red, string usuario, string contrasena)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update usuario set nombre_usuario_GM = @aliasRed" +
                    "  where nombre_usuario = @usuario and contrasena = @contrasena";
                cmd.Parameters.AddWithValue("@aliasRed", alias_red);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                con.Open();
                cmd.ExecuteNonQuery();
                return ValidarRedSocialUsuario("",alias_red);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al insertar la cuenta " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<string> RelacionarFacebookAlumno(string alias_red, string curp, string contrasena)
        {
            try
            {
                AlumnoDAO alumnoDAO = new AlumnoDAO();
                var idAlumno = alumnoDAO.BuscarIdAlumnoCurp(curp);
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update usuario set nombre_usuario_FB = @aliasRed" +
                    "  where idAlumno = @idAlumno and contrasena = @contrasena";
                cmd.Parameters.AddWithValue("@aliasRed", alias_red);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                con.Open();
                cmd.ExecuteNonQuery();
                return ValidarRedSocialAlumno(alias_red, "");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al insertar la cuenta " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<string> RelacionarGoogleAlumno(string alias_red, string curp, string contrasena)
        {
            try
            {
                AlumnoDAO alumnoDAO = new AlumnoDAO();
                var idAlumno = alumnoDAO.BuscarIdAlumnoCurp(curp);
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update usuario set nombre_usuario_GM = @aliasRed" +
                    "  where idAlumno = @idAlumno and contrasena = @contrasena";
                cmd.Parameters.AddWithValue("@aliasRed", alias_red);
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                con.Open();
                cmd.ExecuteNonQuery();
                return ValidarRedSocialAlumno("",alias_red);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al insertar la cuenta " + ex.Message);
                return null;
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