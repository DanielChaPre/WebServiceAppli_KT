using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class PerfilDAO
    {
        ConexionDAO conexion = new ConexionDAO();
        MySqlConnection con;
        Usuario usuario;
        Persona persona;

        public bool GuardarPerfilPersona(Usuario usuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Call p_crear_perfil(@nombre, @apePaterno, @apeMaterno, @rfc, @curp, @sexo" +
                    ", @fechaReg, @numTelefono, @correo, @estadoCivil, @nacionalidad, @municipio, @fechaNac, @colonia, @nombreUser" +
                    ", @contrasenia, @fechaRegUser, @rol)";
                //Datos de la persona
                #region Datos de la persona
                cmd.Parameters.AddWithValue("@nombre", usuario.persona.nombre);
                cmd.Parameters.AddWithValue("@apePaterno", usuario.persona.apellido_paterno);
                cmd.Parameters.AddWithValue("@apeMaterno", usuario.persona.apellido_materno);
                cmd.Parameters.AddWithValue("@rfc", usuario.persona.rfc);
                cmd.Parameters.AddWithValue("@curp", usuario.persona.curp);
                cmd.Parameters.AddWithValue("@sexo", usuario.persona.sexo);
                cmd.Parameters.AddWithValue("@fechaReg", usuario.persona.fecha_registro);
                cmd.Parameters.AddWithValue("@numTelefono", usuario.persona.numero_telefono);
                cmd.Parameters.AddWithValue("@correo", usuario.persona.correo_electronico);
                cmd.Parameters.AddWithValue("@estadoCivil", usuario.persona.estado_civil);
                cmd.Parameters.AddWithValue("@nacionalidad", usuario.persona.nacionalidad);
                cmd.Parameters.AddWithValue("@municipio", usuario.persona.municipio);
                cmd.Parameters.AddWithValue("@fechaNac", usuario.persona.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@colonia", usuario.persona.colonia);
                #endregion
                //Datos del usuario
                cmd.Parameters.AddWithValue("@nombreUser", usuario.nombre_usuario);
                cmd.Parameters.AddWithValue("@contrasenia", usuario.contraseña);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fecha_registro);
                cmd.Parameters.AddWithValue("@rol", usuario.rol);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en el guardado de la información " + ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ModificarPerfil(Usuario usuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Call p_modificar_perfil(@cvePersona,@nombre, @apePaterno, @apeMaterno, @rfc, @curp, @sexo" +
                    ", @fechaReg, @numTelefono, @correo, @estadoCivil, @nacionalidad, @municipio, @fechaNac, @colonia, @cveUsuario, @nombreUser" +
                    ",@estatus ,@contrasenia, @fechaRegUser, @rol)";
                //Datos de la persona
                #region Datos de la persona
                cmd.Parameters.AddWithValue("@cvePersona", usuario.persona.cve_persona);
                cmd.Parameters.AddWithValue("@nombre", usuario.persona.nombre);
                cmd.Parameters.AddWithValue("@apePaterno", usuario.persona.apellido_paterno);
                cmd.Parameters.AddWithValue("@apeMaterno", usuario.persona.apellido_materno);
                cmd.Parameters.AddWithValue("@rfc", usuario.persona.rfc);
                cmd.Parameters.AddWithValue("@curp", usuario.persona.curp);
                cmd.Parameters.AddWithValue("@sexo", usuario.persona.sexo);
                cmd.Parameters.AddWithValue("@fechaReg", usuario.persona.fecha_registro);
                cmd.Parameters.AddWithValue("@numTelefono", usuario.persona.numero_telefono);
                cmd.Parameters.AddWithValue("@correo", usuario.persona.correo_electronico);
                cmd.Parameters.AddWithValue("@estadoCivil", usuario.persona.estado_civil);
                cmd.Parameters.AddWithValue("@nacionalidad", usuario.persona.nacionalidad);
                cmd.Parameters.AddWithValue("@municipio", usuario.persona.municipio);
                cmd.Parameters.AddWithValue("@fechaNac", usuario.persona.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@colonia", usuario.persona.colonia);
                #endregion
                //Datos del usuario
                cmd.Parameters.AddWithValue("@cveUsuario", usuario.cve_usuario);
                cmd.Parameters.AddWithValue("@nombreUser", usuario.nombre_usuario);
                cmd.Parameters.AddWithValue("@estatus", usuario.estatus);
                cmd.Parameters.AddWithValue("@contrasenia", usuario.contraseña);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fecha_registro);
                cmd.Parameters.AddWithValue("@rol", usuario.rol);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la modificacion de la información " + ex.Message);
                return false;
            }
            finally
            {

            }
        }

        public Usuario ConsultarPerfilUsuario(string user, string password)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From usuario where nombre_usuario = @user and contraseña = @pass";
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", password);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                        usuario = new Usuario();
                        usuario.cve_usuario = Convert.ToInt32(reader["cve_usuario"].ToString());
                        usuario.nombre_usuario = reader["nombre_usuario"].ToString();
                        usuario.contraseña = reader["contraseña"].ToString();
                        usuario.fecha_registro = Convert.ToDateTime(reader["fecha_registro"].ToString());
                        usuario.estatus = reader["estatus"].ToString();
                        usuario.rol = reader["rol"].ToString();
                        usuario.persona = ConsultarPerfilPersona(Convert.ToInt32(reader["cve_personas"].ToString()));
                }

                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Persona ConsultarPerfilPersona(int cvePersona)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From persona where cvePersona = @cvePersona";
                cmd.Parameters.AddWithValue("@cvePersona", cvePersona);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    persona = new Persona();
                        persona.cve_persona = Convert.ToInt16(reader["cve_persona"].ToString());
                        persona.nombre= reader["nombre"].ToString();
                        persona.apellido_paterno= reader["apellido_paterno"].ToString();
                        persona.apellido_materno= reader["apellido_materno"].ToString();
                        persona.rfc= reader["rfc"].ToString();
                        persona.curp= reader["curp"].ToString();
                        persona.sexo= reader["sexo"].ToString();
                        persona.fecha_nacimiento= Convert.ToDateTime( reader["fecha_nacimiento"].ToString());
                        persona.numero_telefono= reader["numero_telefono"].ToString();
                        persona.correo_electronico= reader["correo_electronico"].ToString();
                        persona.estado_civil=Convert.ToInt16(reader["estado_civil"].ToString());
                        persona.nacionalidad= reader["nacionalidad"].ToString();
                        persona.municipio= reader["municipio"].ToString();
                        persona.fecha_registro= Convert.ToDateTime(reader["fecha_registro"].ToString());
                    persona.colonia = reader["idColonia"].ToString();
                }
                return persona;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool EliminarPerfil(int cveUsuario, int cvePalabra)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Call p_modificar_perfil()";
                //Datos de la persona
                cmd.Parameters.AddWithValue("", cveUsuario);
                cmd.Parameters.AddWithValue("", cvePalabra);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la eliminación de la información " + ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}