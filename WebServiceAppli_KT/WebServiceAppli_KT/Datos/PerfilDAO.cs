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
        ConexionClass conexion = new ConexionClass();
        MySqlConnection con;
        UsuarioClass usuario;
        PersonaClass persona;

        public bool GuardarPerfilPersona(UsuarioClass usuario)
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
                cmd.Parameters.AddWithValue("@apePaterno", usuario.persona.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apeMaterno", usuario.persona.apellidoMaterno);
                cmd.Parameters.AddWithValue("@rfc", usuario.persona.rfc);
                cmd.Parameters.AddWithValue("@curp", usuario.persona.curp);
                cmd.Parameters.AddWithValue("@sexo", usuario.persona.sexo);
                cmd.Parameters.AddWithValue("@fechaReg", usuario.persona.fechaRegistro);
                cmd.Parameters.AddWithValue("@numTelefono", usuario.persona.numeroTelefono);
                cmd.Parameters.AddWithValue("@correo", usuario.persona.correoElectronico);
                cmd.Parameters.AddWithValue("@estadoCivil", usuario.persona.estadoCivil);
                cmd.Parameters.AddWithValue("@nacionalidad", usuario.persona.nacionalidad);
                cmd.Parameters.AddWithValue("@municipio", usuario.persona.municipio);
                cmd.Parameters.AddWithValue("@fechaNac", usuario.persona.fechaNacimiento);
                cmd.Parameters.AddWithValue("@colonia", usuario.persona.colonia);
                #endregion
                //Datos del usuario
                cmd.Parameters.AddWithValue("@nombreUser", usuario.nombreUsuario);
                cmd.Parameters.AddWithValue("@contrasenia", usuario.contrasenia);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fechaRegistro);
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

        public bool ModificarPerfil(UsuarioClass usuario)
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
                cmd.Parameters.AddWithValue("@cvePersona", usuario.persona.cvePersona);
                cmd.Parameters.AddWithValue("@nombre", usuario.persona.nombre);
                cmd.Parameters.AddWithValue("@apePaterno", usuario.persona.apellidoPaterno);
                cmd.Parameters.AddWithValue("@apeMaterno", usuario.persona.apellidoMaterno);
                cmd.Parameters.AddWithValue("@rfc", usuario.persona.rfc);
                cmd.Parameters.AddWithValue("@curp", usuario.persona.curp);
                cmd.Parameters.AddWithValue("@sexo", usuario.persona.sexo);
                cmd.Parameters.AddWithValue("@fechaReg", usuario.persona.fechaRegistro);
                cmd.Parameters.AddWithValue("@numTelefono", usuario.persona.numeroTelefono);
                cmd.Parameters.AddWithValue("@correo", usuario.persona.correoElectronico);
                cmd.Parameters.AddWithValue("@estadoCivil", usuario.persona.estadoCivil);
                cmd.Parameters.AddWithValue("@nacionalidad", usuario.persona.nacionalidad);
                cmd.Parameters.AddWithValue("@municipio", usuario.persona.municipio);
                cmd.Parameters.AddWithValue("@fechaNac", usuario.persona.fechaNacimiento);
                cmd.Parameters.AddWithValue("@colonia", usuario.persona.colonia);
                #endregion
                //Datos del usuario
                cmd.Parameters.AddWithValue("@cveUsuario", usuario.cveUsuario);
                cmd.Parameters.AddWithValue("@nombreUser", usuario.nombreUsuario);
                cmd.Parameters.AddWithValue("@estatus", usuario.estatus);
                cmd.Parameters.AddWithValue("@contrasenia", usuario.contrasenia);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fechaRegistro);
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

        public UsuarioClass ConsultarPerfilUsuario(string user, string password)
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
                    usuario = new UsuarioClass();
                        usuario.cveUsuario = Convert.ToInt32(reader["cve_usuario"].ToString());
                        usuario.nombreUsuario = reader["nombre_usuario"].ToString();
                        usuario.contrasenia = reader["contraseña"].ToString();
                        usuario.fechaRegistro = Convert.ToDateTime(reader["fecha_registro"].ToString());
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

        public PersonaClass ConsultarPerfilPersona(int cvePersona)
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
                    persona = new PersonaClass();
                        persona.cvePersona = Convert.ToInt16(reader["cve_persona"].ToString());
                        persona.nombre= reader["nombre"].ToString();
                        persona.apellidoPaterno= reader["apellido_paterno"].ToString();
                        persona.apellidoMaterno= reader["apellido_materno"].ToString();
                        persona.rfc= reader["rfc"].ToString();
                        persona.curp= reader["curp"].ToString();
                        persona.sexo= reader["sexo"].ToString();
                        persona.fechaNacimiento= Convert.ToDateTime( reader["fecha_nacimiento"].ToString());
                        persona.numeroTelefono= reader["numero_telefono"].ToString();
                        persona.correoElectronico= reader["correo_electronico"].ToString();
                        persona.estadoCivil=Convert.ToInt16(reader["estado_civil"].ToString());
                        persona.nacionalidad= reader["nacionalidad"].ToString();
                        persona.municipio= reader["municipio"].ToString();
                        persona.fechaRegistro= Convert.ToDateTime(reader["fecha_registro"].ToString());
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