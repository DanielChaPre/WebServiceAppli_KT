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
        ConexionAppliktDAO conexion = new ConexionAppliktDAO();
        MySqlConnection con;
        Usuario usuario;
        Persona persona;

        #region Persona
        public bool GuardarPerfilPersona(Persona persona)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Call p_crear_perfil(@nombre, @apePaterno, @apeMaterno, @rfc, @curp, @sexo" +
                    ", @fechaNac, @numTelefono, @estadoCivil, @nacionalidad, @idAlumno ,@municipio, @idColonia " +
                    ", @contrasenia, @fechaRegUser, @aliasRedes)";
                //Datos de la persona
                #region Datos de la persona
                cmd.Parameters.AddWithValue("@nombre", persona.nombre);
                cmd.Parameters.AddWithValue("@apePaterno", persona.apellido_paterno);
                cmd.Parameters.AddWithValue("@apeMaterno", persona.apellido_materno);
                cmd.Parameters.AddWithValue("@rfc", persona.rfc);
                cmd.Parameters.AddWithValue("@curp", persona.curp);
                cmd.Parameters.AddWithValue("@sexo", persona.sexo);
                cmd.Parameters.AddWithValue("@fechaNac", persona.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@numTelefono", persona.numero_telefono);
                cmd.Parameters.AddWithValue("@estadoCivil", persona.estado_civil);
                cmd.Parameters.AddWithValue("@nacionalidad", persona.nacionalidad);
                cmd.Parameters.AddWithValue("@idAlumno", persona.idAlumno);
                cmd.Parameters.AddWithValue("@municipio", persona.municipio);
                cmd.Parameters.AddWithValue("@idColonia", persona.idColonia);
                #endregion
                //Datos del usuario
                #region Datos del usuario
                cmd.Parameters.AddWithValue("@contrasenia", persona.usuario.contrasena);
                cmd.Parameters.AddWithValue("@fechaRegUSer", persona.usuario.fecha_registro);
                cmd.Parameters.AddWithValue("@aliasRedes", persona.usuario.alias_red);
                #endregion
                // cmd.Parameters.AddWithValue("@rol", usuario.r);
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
        public bool ModificarPerfil(Persona persona)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Call p_crear_perfil(@cvePersona, @nombre, @apePaterno, @apeMaterno, @rfc, @curp, @sexo" +
                    ", @fechaNac, @numTelefono, @estadoCivil, @nacionalidad, @idAlumno ,@municipio, @idColonia " +
                    ", @cveUsuario, @contrasenia, @fechaRegUser, @estatus,@aliasRedes)";
                //Datos de la persona
                #region Datos de la persona
                cmd.Parameters.AddWithValue("@cvePersona", persona.cve_persona);
                cmd.Parameters.AddWithValue("@nombre", persona.nombre);
                cmd.Parameters.AddWithValue("@apePaterno", persona.apellido_paterno);
                cmd.Parameters.AddWithValue("@apeMaterno", persona.apellido_materno);
                cmd.Parameters.AddWithValue("@rfc", persona.rfc);
                cmd.Parameters.AddWithValue("@curp", persona.curp);
                cmd.Parameters.AddWithValue("@sexo", persona.sexo);
                cmd.Parameters.AddWithValue("@fechaNac", persona.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@numTelefono", persona.numero_telefono);
                cmd.Parameters.AddWithValue("@estadoCivil", persona.estado_civil);
                cmd.Parameters.AddWithValue("@nacionalidad", persona.nacionalidad);
                cmd.Parameters.AddWithValue("@idAlumno", persona.idAlumno);
                cmd.Parameters.AddWithValue("@municipio", persona.municipio);
                cmd.Parameters.AddWithValue("@idColonia", persona.idColonia);
                #endregion
                //Datos del usuario
                #region Datos del usuario
                cmd.Parameters.AddWithValue("@cveUsuario", persona.usuario.cve_usuario);
                cmd.Parameters.AddWithValue("@contrasenia", persona.usuario.contrasena);
                cmd.Parameters.AddWithValue("@fechaRegUSer", persona.usuario.fecha_registro);
                cmd.Parameters.AddWithValue("@estatus", persona.usuario.estatus);
                cmd.Parameters.AddWithValue("@aliasRedes", persona.usuario.alias_red);
                #endregion
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
                con.Close();
            }
        }
        public Persona ConsultarPerfilPersona(int cveUsuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from usuario u, persona p where u.cve_usuario = @cveUsuario";
                cmd.Parameters.AddWithValue("@cveUsuario", cveUsuario);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    persona = new Persona();
                    persona.usuario.cve_usuario = Convert.ToInt16(reader["cve_usuario"].ToString());
                    persona.usuario.contrasena = reader["contrasena"].ToString();
                    persona.usuario.fecha_registro = Convert.ToDateTime(reader["fecha_registro"].ToString());
                    persona.usuario.estatus = reader["estatus"].ToString();
                    persona.usuario.alias_red = reader["alias_red"].ToString();
                    persona.cve_persona = Convert.ToInt16(reader["cve_persona"].ToString());
                    persona.nombre = reader["nombre"].ToString();
                    persona.apellido_paterno = reader["apellido_paterno"].ToString();
                    persona.apellido_materno = reader["apellido_materno"].ToString();
                    persona.rfc = reader["rfc"].ToString();
                    persona.curp = reader["curp"].ToString();
                    persona.sexo = reader["sexo"].ToString();
                    persona.fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"].ToString());
                    persona.numero_telefono = reader["numero_telefono"].ToString();
                    persona.estado_civil = Convert.ToInt16(reader["estado_civil"].ToString());
                    persona.nacionalidad = reader["nacionalidad"].ToString();
                    persona.idAlumno = Convert.ToInt16(reader["idAlumno"].ToString());
                    persona.municipio = reader["municipio"].ToString();
                    persona.idColonia = Convert.ToInt32(reader["idColonia"].ToString());
                }
                return persona;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public bool EliminarPerfil(Persona persona)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update usuario set estatus = @estatus where cve_usuario = @cve_usuario";
                cmd.Parameters.AddWithValue("@estatus", "Inactivo");
                cmd.Parameters.AddWithValue("@cve_usuario", persona.usuario.cve_usuario);
                //Datos de la persona
                //cmd.Parameters.AddWithValue("", cveUsuario);
                //cmd.Parameters.AddWithValue("", cvePalabra);
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
        #endregion
        #region Empleado
        public bool GuardarPerfilEmpleado(Empleado empleado)
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
                cmd.Parameters.AddWithValue("@numTelefono", usuario.persona.numero_telefono);
                cmd.Parameters.AddWithValue("@estadoCivil", usuario.persona.estado_civil);
                cmd.Parameters.AddWithValue("@nacionalidad", usuario.persona.nacionalidad);
                cmd.Parameters.AddWithValue("@municipio", usuario.persona.municipio);
                cmd.Parameters.AddWithValue("@fechaNac", usuario.persona.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@colonia", usuario.persona.idColonia);
                #endregion
                //Datos del usuario
                cmd.Parameters.AddWithValue("@contrasenia", usuario.contrasena);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fecha_registro);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.estatus);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.alias_redes);
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

        public bool ModificarPerfilEmpleado(Empleado empleado)
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
                cmd.Parameters.AddWithValue("@numTelefono", usuario.persona.numero_telefono);
                cmd.Parameters.AddWithValue("@estadoCivil", usuario.persona.estado_civil);
                cmd.Parameters.AddWithValue("@nacionalidad", usuario.persona.nacionalidad);
                cmd.Parameters.AddWithValue("@municipio", usuario.persona.municipio);
                cmd.Parameters.AddWithValue("@fechaNac", usuario.persona.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@colonia", usuario.persona.idColonia);
                #endregion
                //Datos del usuario
                cmd.Parameters.AddWithValue("@contrasenia", usuario.contrasena);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fecha_registro);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.estatus);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.alias_redes);
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

        public Usuario ConsultarPerfilUsuarioEmpleado(string user, string password)
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
                    cmd.Parameters.AddWithValue("@contrasenia", usuario.contrasena);
                    cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fecha_registro);
                    cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.estatus);
                    cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.alias_redes);
                    usuario.persona = ConsultarPerfilPersonaEmpleado(Convert.ToInt32(reader["cve_personas"].ToString()));
                }

                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Persona ConsultarPerfilPersonaEmpleado(int cvePersona)
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
                    persona.nombre = reader["nombre"].ToString();
                    persona.apellido_paterno = reader["apellido_paterno"].ToString();
                    persona.apellido_materno = reader["apellido_materno"].ToString();
                    persona.rfc = reader["rfc"].ToString();
                    persona.curp = reader["curp"].ToString();
                    persona.sexo = reader["sexo"].ToString();
                    persona.fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"].ToString());
                    persona.numero_telefono = reader["numero_telefono"].ToString();
                    persona.estado_civil = Convert.ToInt16(reader["estado_civil"].ToString());
                    persona.nacionalidad = reader["nacionalidad"].ToString();
                    persona.municipio = reader["municipio"].ToString();
                    persona.idColonia = Convert.ToInt32(reader["idColonia"].ToString());
                }
                return persona;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool EliminarPerfilEmpleado(Empleado empleado)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "";
                //Datos de la persona
                //cmd.Parameters.AddWithValue("", cveUsuario);
                //cmd.Parameters.AddWithValue("", cvePalabra);
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
        #endregion
        #region EmpleadoPlantel
        public bool GuardarPerfilEmpleadoPlantel(Usuario usuario)
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
                cmd.Parameters.AddWithValue("@numTelefono", usuario.persona.numero_telefono);
                cmd.Parameters.AddWithValue("@estadoCivil", usuario.persona.estado_civil);
                cmd.Parameters.AddWithValue("@nacionalidad", usuario.persona.nacionalidad);
                cmd.Parameters.AddWithValue("@municipio", usuario.persona.municipio);
                cmd.Parameters.AddWithValue("@fechaNac", usuario.persona.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@colonia", usuario.persona.idColonia);
                #endregion
                //Datos del usuario
                cmd.Parameters.AddWithValue("@contrasenia", usuario.contrasena);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fecha_registro);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.estatus);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.alias_redes);
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

        public bool ModificarPerfilEmpleadoPlantel(Usuario usuario)
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
                cmd.Parameters.AddWithValue("@numTelefono", usuario.persona.numero_telefono);
                cmd.Parameters.AddWithValue("@estadoCivil", usuario.persona.estado_civil);
                cmd.Parameters.AddWithValue("@nacionalidad", usuario.persona.nacionalidad);
                cmd.Parameters.AddWithValue("@municipio", usuario.persona.municipio);
                cmd.Parameters.AddWithValue("@fechaNac", usuario.persona.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@colonia", usuario.persona.idColonia);
                #endregion
                //Datos del usuario
                cmd.Parameters.AddWithValue("@contrasenia", usuario.contrasena);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fecha_registro);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.estatus);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.alias_redes);
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

        public Usuario ConsultarPerfilUsuarioEmpleadoPlantel(string user, string password)
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
                    cmd.Parameters.AddWithValue("@contrasenia", usuario.contrasena);
                    cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fecha_registro);
                    cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.estatus);
                    cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.alias_redes);
                    usuario.persona = ConsultarPerfilPersonaEmpleadoPlantel(Convert.ToInt32(reader["cve_personas"].ToString()));
                }

                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Persona ConsultarPerfilPersonaEmpleadoPlantel(int cvePersona)
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
                    persona.nombre = reader["nombre"].ToString();
                    persona.apellido_paterno = reader["apellido_paterno"].ToString();
                    persona.apellido_materno = reader["apellido_materno"].ToString();
                    persona.rfc = reader["rfc"].ToString();
                    persona.curp = reader["curp"].ToString();
                    persona.sexo = reader["sexo"].ToString();
                    persona.fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"].ToString());
                    persona.numero_telefono = reader["numero_telefono"].ToString();
                    persona.estado_civil = Convert.ToInt16(reader["estado_civil"].ToString());
                    persona.nacionalidad = reader["nacionalidad"].ToString();
                    persona.municipio = reader["municipio"].ToString();
                    persona.idColonia = Convert.ToInt32(reader["idColonia"].ToString());
                }
                return persona;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool EliminarPerfilEmpleadoPlantel(Usuario usuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "";
                //Datos de la persona
                //cmd.Parameters.AddWithValue("", cveUsuario);
                //cmd.Parameters.AddWithValue("", cvePalabra);
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
        #endregion
        #region PadreFamilia
        public bool GuardarPerfilPersonaPadreFamilia(Usuario usuario)
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
                cmd.Parameters.AddWithValue("@numTelefono", usuario.persona.numero_telefono);
                cmd.Parameters.AddWithValue("@estadoCivil", usuario.persona.estado_civil);
                cmd.Parameters.AddWithValue("@nacionalidad", usuario.persona.nacionalidad);
                cmd.Parameters.AddWithValue("@municipio", usuario.persona.municipio);
                cmd.Parameters.AddWithValue("@fechaNac", usuario.persona.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@colonia", usuario.persona.idColonia);
                #endregion
                //Datos del usuario
                cmd.Parameters.AddWithValue("@contrasenia", usuario.contrasena);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fecha_registro);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.estatus);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.alias_redes);
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

        public bool ModificarPerfilPadreFamilia(Usuario usuario)
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
                cmd.Parameters.AddWithValue("@numTelefono", usuario.persona.numero_telefono);
                cmd.Parameters.AddWithValue("@estadoCivil", usuario.persona.estado_civil);
                cmd.Parameters.AddWithValue("@nacionalidad", usuario.persona.nacionalidad);
                cmd.Parameters.AddWithValue("@municipio", usuario.persona.municipio);
                cmd.Parameters.AddWithValue("@fechaNac", usuario.persona.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@colonia", usuario.persona.idColonia);
                #endregion
                //Datos del usuario
                cmd.Parameters.AddWithValue("@cveUsuario", usuario.cve_usuario);
                cmd.Parameters.AddWithValue("@contrasenia", usuario.contrasena);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fecha_registro);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.estatus);
                cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.alias_redes);
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

        public Usuario ConsultarPerfilUsuarioPadreFamilia(string user, string password)
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
                    cmd.Parameters.AddWithValue("@contrasenia", usuario.contrasena);
                    cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.fecha_registro);
                    cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.estatus);
                    cmd.Parameters.AddWithValue("@fechaRegUSer", usuario.alias_redes);
                    usuario.persona = ConsultarPerfilPersonaPadreFamilia(Convert.ToInt32(reader["cve_personas"].ToString()));
                }

                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Persona ConsultarPerfilPersonaPadreFamilia(int cvePersona)
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
                    persona.nombre = reader["nombre"].ToString();
                    persona.apellido_paterno = reader["apellido_paterno"].ToString();
                    persona.apellido_materno = reader["apellido_materno"].ToString();
                    persona.rfc = reader["rfc"].ToString();
                    persona.curp = reader["curp"].ToString();
                    persona.sexo = reader["sexo"].ToString();
                    persona.fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"].ToString());
                    persona.numero_telefono = reader["numero_telefono"].ToString();
                    persona.estado_civil = Convert.ToInt16(reader["estado_civil"].ToString());
                    persona.nacionalidad = reader["nacionalidad"].ToString();
                    persona.municipio = reader["municipio"].ToString();
                    persona.idColonia = Convert.ToInt32(reader["idColonia"].ToString());
                }
                return persona;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool EliminarPerfilPadreFamilia(Usuario usuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "";
                //Datos de la persona
                //cmd.Parameters.AddWithValue("", cveUsuario);
                //cmd.Parameters.AddWithValue("", cvePalabra);
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
        #endregion
    }
}