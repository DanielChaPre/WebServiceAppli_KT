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
        Persona persona;
        Empleado ent_empleado;
        EmpleadoPlantel ent_empleado_plantel;
        PadreFamilia ent_padre_familia;

        #region Persona
        public List<int> GuardarPerfilPersona(Persona persona)
        {
            try
            {
               
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = new MySqlCommand("p_crear_perfil",con);
                  cmd.CommandType = System.Data.CommandType.StoredProcedure;
                  cmd.Parameters.Add(new MySqlParameter("p_nombre", persona.nombre));
                  cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", persona.apellido_paterno));
                  cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", persona.apellido_materno));
                  cmd.Parameters.Add(new MySqlParameter("p_rfc", persona.rfc));
                  cmd.Parameters.Add(new MySqlParameter("p_curp", persona.curp));
                  cmd.Parameters.Add(new MySqlParameter("p_sexo", persona.sexo));
                  cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", persona.fecha_nacimiento));
                  cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", persona.numero_telefono));
                  cmd.Parameters.Add(new MySqlParameter("p_estado_civil", persona.estado_civil));
                  cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", persona.nacionalidad));
                  cmd.Parameters.Add(new MySqlParameter("p_municipio", persona.municipio));
                  cmd.Parameters.Add(new MySqlParameter("p_idColonia", persona.idColonia));
                  cmd.Parameters.Add(new MySqlParameter("p_contraseña", persona.usuario.contrasena));
                  cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", persona.usuario.fecha_registro));
                  cmd.Parameters.Add(new MySqlParameter("p_alias_redes", persona.usuario.alias_red));
                  cmd.Parameters.Add(new MySqlParameter("p_idAlumno", persona.usuario.idAlumno));
                 MySqlParameter cve_usuario = new MySqlParameter("p_cve_usuario", MySqlDbType.Int16);
                 MySqlParameter cve_persona = new MySqlParameter("p_cve_persona", MySqlDbType.Int16);
                 cve_usuario.Direction = System.Data.ParameterDirection.Output;
                 cve_persona.Direction = System.Data.ParameterDirection.Output;
                 cmd.Parameters.Add(cve_usuario);
                  cmd.Parameters.Add(cve_persona);
                  con.Open();
                  cmd.ExecuteNonQuery();
                  int cve_Usuario = Int16.Parse(cmd.Parameters["p_cve_usuario"].Value.ToString());
                  int cve_Persona = Int16.Parse(cmd.Parameters["p_cve_persona"].Value.ToString());
                List<int> claves = new List<int>();
                claves.Add(cve_Usuario);
                  claves.Add(cve_Persona);
                  return claves;
            }
            catch (Exception ex)
            {
                try
                {
                    Console.WriteLine("Error en el guardado de la información " + ex.Message);
                    var conn = conexion.Builder;
                    con = new MySqlConnection(conn.ToString());
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "rollback";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return null;
                }
                catch (Exception exs)
                {
                    Console.WriteLine("Error en el guardado de la información " + exs.Message);
                    throw;
                }
               
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
                MySqlCommand cmd = new MySqlCommand("p_modificar_perfil", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_cve_persona", persona.cve_persona));
                cmd.Parameters.Add(new MySqlParameter("p_nombre", persona.nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", persona.apellido_paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", persona.apellido_materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", persona.rfc));
                cmd.Parameters.Add(new MySqlParameter("p_curp", persona.curp));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", persona.sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", persona.fecha_nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", persona.numero_telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", persona.estado_civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", persona.nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", persona.municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", persona.idColonia));
                cmd.Parameters.Add(new MySqlParameter("p_cve_usuario", persona.usuario.cve_usuario));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", persona.usuario.contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", persona.usuario.fecha_registro));
                cmd.Parameters.Add(new MySqlParameter("p_estatus", persona.usuario.estatus));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", persona.usuario.alias_red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", persona.usuario.idAlumno));
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
                cmd.CommandText = "Select * from usuario u, persona p where p.cve_usuario = @cveUsuarioP and u.cve_usuario = @cveUsuarioU";
                cmd.Parameters.AddWithValue("@cveUsuarioP", cveUsuario);
                cmd.Parameters.AddWithValue("@cveUsuarioU", cveUsuario);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
             //   object o = reader.GetValue(1);
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
                    persona.usuario = new Usuario();
                    persona.usuario.cve_usuario = Convert.ToInt16(reader["cve_usuario"].ToString());
                    persona.usuario.contrasena = reader["contrasena"].ToString();
                    persona.usuario.fecha_registro = Convert.ToDateTime(reader["fecha_registro"].ToString());
                    persona.usuario.estatus = reader["estatus"].ToString();
                    persona.usuario.alias_red = reader["alias_red"].ToString();
                    persona.usuario.idAlumno = Convert.ToInt16(reader["idAlumno"].ToString());
                }
                    return persona;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
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
        public List<int> GuardarPerfilEmpleado(Empleado empleado)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = new MySqlCommand("p_crear_perfilEmpleado", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_nombre", empleado.persona.nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", empleado.persona.apellido_paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", empleado.persona.apellido_materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", empleado.persona.rfc));
                cmd.Parameters.Add(new MySqlParameter("p_curp", empleado.persona.curp));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", empleado.persona.sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", empleado.persona.fecha_nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", empleado.persona.numero_telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", empleado.persona.estado_civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", empleado.persona.nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", empleado.persona.municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", empleado.persona.idColonia));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", empleado.persona.usuario.contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", empleado.persona.usuario.fecha_registro));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", empleado.persona.usuario.alias_red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", empleado.persona.usuario.idAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_numero_empleado", empleado.numero_empleado));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro", empleado.fecha_registro));
                MySqlParameter cve_usuario = new MySqlParameter("p_cve_usuario", MySqlDbType.Int16);
                MySqlParameter cve_persona = new MySqlParameter("p_cve_persona", MySqlDbType.Int16);
                cve_usuario.Direction = System.Data.ParameterDirection.Output;
                cve_persona.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(cve_usuario);
                cmd.Parameters.Add(cve_persona);
                con.Open();
                cmd.ExecuteNonQuery();
                int cve_Usuario = Int16.Parse(cmd.Parameters["p_cve_usuario"].Value.ToString());
                int cve_Persona = Int16.Parse(cmd.Parameters["p_cve_persona"].Value.ToString());
                List<int> claves = new List<int>();
                claves.Add(cve_Usuario);
                claves.Add(cve_Persona);
                return claves;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el guardado de la información " + ex.Message);
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "rollback";
                con.Open();
                cmd.ExecuteNonQuery();
                return null;
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
                MySqlCommand cmd = new MySqlCommand("p_modificar_perfilEmpleado", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_cve_persona", empleado.persona.cve_persona));
                cmd.Parameters.Add(new MySqlParameter("p_nombre", empleado.persona.nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", empleado.persona.apellido_paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", empleado.persona.apellido_materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", empleado.persona.rfc));
                cmd.Parameters.Add(new MySqlParameter("p_curp", empleado.persona.curp));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", empleado.persona.sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", empleado.persona.fecha_nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", empleado.persona.numero_telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", empleado.persona.estado_civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", empleado.persona.nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", empleado.persona.municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", empleado.persona.idColonia));
                cmd.Parameters.Add(new MySqlParameter("p_cve_usuario", empleado.persona.usuario.cve_usuario));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", empleado.persona.usuario.contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", empleado.persona.usuario.fecha_registro));
                cmd.Parameters.Add(new MySqlParameter("p_estatus", empleado.persona.usuario.estatus));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", empleado.persona.usuario.alias_red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", empleado.persona.usuario.idAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_cve_empleado", empleado.cve_empleado));
                cmd.Parameters.Add(new MySqlParameter("p_numero_empleado", empleado.numero_empleado));
                cmd.Parameters.Add(new MySqlParameter("p_estatusE", empleado.estatus));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro", empleado.fecha_registro));
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

        public Empleado ConsultarPerfilEmpleado(int cveUsuario, int cvePersona)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from usuario u, persona p, empleado e where p.cve_usuario = @cve_usuarioP and u.cve_usuario = @cve_usuarioU" +
                    " and e.cve_persona = @cve_persona";
                cmd.Parameters.AddWithValue("@cve_usuarioP", cveUsuario);
                cmd.Parameters.AddWithValue("@cve_usuarioU", cveUsuario);
                cmd.Parameters.AddWithValue("@cve_persona", cvePersona);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ent_empleado = new Empleado();
                    ent_empleado.persona = new Persona();
                    ent_empleado.persona.usuario = new Usuario();
                    ent_empleado.persona.usuario.cve_usuario = Convert.ToInt16(reader["cve_usuario"].ToString());
                    ent_empleado.persona.usuario.contrasena = reader["contrasena"].ToString();
                    ent_empleado.persona.usuario.fecha_registro = Convert.ToDateTime(reader["fecha_registro"].ToString());
                    ent_empleado.persona.usuario.estatus = reader["estatus"].ToString();
                    ent_empleado.persona.usuario.alias_red = reader["alias_red"].ToString();
                    ent_empleado.persona.usuario.idAlumno = Convert.ToInt16(reader["idAlumno"].ToString());
                    ent_empleado.persona.cve_persona = Convert.ToInt16(reader["cve_persona"].ToString());
                    ent_empleado.persona.nombre = reader["nombre"].ToString();
                    ent_empleado.persona.apellido_paterno = reader["apellido_paterno"].ToString();
                    ent_empleado.persona.apellido_materno = reader["apellido_materno"].ToString();
                    ent_empleado.persona.rfc = reader["rfc"].ToString();
                    ent_empleado.persona.curp = reader["curp"].ToString();
                    ent_empleado.persona.sexo = reader["sexo"].ToString();
                    ent_empleado.persona.fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"].ToString());
                    ent_empleado.persona.numero_telefono = reader["numero_telefono"].ToString();
                    ent_empleado.persona.estado_civil = Convert.ToInt16(reader["estado_civil"].ToString());
                    ent_empleado.persona.nacionalidad = reader["nacionalidad"].ToString();
                    ent_empleado.persona.municipio = reader["municipio"].ToString();
                    ent_empleado.persona.idColonia = Convert.ToInt32(reader["idColonia"].ToString());
                    ent_empleado.cve_empleado = Convert.ToInt32(reader["cve_empleado"].ToString());
                    ent_empleado.numero_empleado = reader["numero_empleado"].ToString();
                    ent_empleado.estatus = reader["estatus"].ToString();
                    ent_empleado.fecha_registro = Convert.ToDateTime(reader["fecha_registro"].ToString());
                }
                return ent_empleado;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
                throw;
            }
            finally
            {
                con.Close();
            }
        }
       
        public bool EliminarPerfilEmpleado(Empleado empleado)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update usuario set estatus = @estatus where cve_usuario = @cve_usuario";
                cmd.Parameters.AddWithValue("@estatus", "Inactivo");
                cmd.Parameters.AddWithValue("@cve_usuario", empleado.persona.usuario.cve_usuario);
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
        public List<int> GuardarPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = new MySqlCommand("p_crear_perfilEmpleadoPlantel", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_nombre", empleadoPlantel.persona.nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", empleadoPlantel.persona.apellido_paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", empleadoPlantel.persona.apellido_materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", empleadoPlantel.persona.rfc));
                cmd.Parameters.Add(new MySqlParameter("p_curp", empleadoPlantel.persona.curp));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", empleadoPlantel.persona.sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", empleadoPlantel.persona.fecha_nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", empleadoPlantel.persona.numero_telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", empleadoPlantel.persona.estado_civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", empleadoPlantel.persona.nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", empleadoPlantel.persona.municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", empleadoPlantel.persona.idColonia));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", empleadoPlantel.persona.usuario.contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", empleadoPlantel.persona.usuario.fecha_registro));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", empleadoPlantel.persona.usuario.alias_red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", empleadoPlantel.persona.usuario.idAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_idPlantelesES", empleadoPlantel.idPlantelesES));
                cmd.Parameters.Add(new MySqlParameter("p_tipo", empleadoPlantel.tipo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro", empleadoPlantel.fecha_registro));
                MySqlParameter cve_usuario = new MySqlParameter("p_cve_usuario", MySqlDbType.Int16);
                MySqlParameter cve_persona = new MySqlParameter("p_cve_persona", MySqlDbType.Int16);
                cve_usuario.Direction = System.Data.ParameterDirection.Output;
                cve_persona.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(cve_usuario);
                cmd.Parameters.Add(cve_persona);
                con.Open();
                cmd.ExecuteNonQuery();
                int cve_Usuario = Int16.Parse(cmd.Parameters["p_cve_usuario"].Value.ToString());
                int cve_Persona = Int16.Parse(cmd.Parameters["p_cve_persona"].Value.ToString());
                List<int> claves = new List<int>();
                claves.Add(cve_Usuario);
                claves.Add(cve_Persona);
                return claves;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error en el guardado de la información " + ex.Message);
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "rollback";
                con.Open();
                cmd.ExecuteNonQuery();
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ModificarPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = new MySqlCommand("p_modificar_perfilEmpleadoPlantel", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_cve_persona", empleadoPlantel.persona.cve_persona));
                cmd.Parameters.Add(new MySqlParameter("p_nombre", empleadoPlantel.persona.nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", empleadoPlantel.persona.apellido_paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", empleadoPlantel.persona.apellido_materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", empleadoPlantel.persona.rfc));
                cmd.Parameters.Add(new MySqlParameter("p_curp", empleadoPlantel.persona.curp));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", empleadoPlantel.persona.sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", empleadoPlantel.persona.fecha_nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", empleadoPlantel.persona.numero_telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", empleadoPlantel.persona.estado_civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", empleadoPlantel.persona.nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", empleadoPlantel.persona.municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", empleadoPlantel.persona.idColonia));
                cmd.Parameters.Add(new MySqlParameter("p_cve_usuario", empleadoPlantel.persona.usuario.cve_usuario));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", empleadoPlantel.persona.usuario.contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", empleadoPlantel.persona.usuario.fecha_registro));
                cmd.Parameters.Add(new MySqlParameter("p_estatus", empleadoPlantel.persona.usuario.estatus));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", empleadoPlantel.persona.usuario.alias_red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", empleadoPlantel.persona.usuario.idAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_cve_empleado_plantel", empleadoPlantel.cve_empleado_plantel));
                cmd.Parameters.Add(new MySqlParameter("p_idPlantelES", empleadoPlantel.idPlantelesES));
                cmd.Parameters.Add(new MySqlParameter("p_tipo", empleadoPlantel.tipo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro", empleadoPlantel.fecha_registro));
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la modificacion de la información " + ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public EmpleadoPlantel ConsultarPerfilEmpleadoPlantel(int cveUsuario, int cvePersona)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from usuario u, persona p, empleado_plantel ep where p.cve_usuario = @cve_usuarioP and u.cve_usuario = @cve_usuarioU and ep.cve_persona = @cve_persona";
                cmd.Parameters.AddWithValue("@cve_usuarioP", cveUsuario);
                cmd.Parameters.AddWithValue("@cve_usuarioU", cveUsuario);
                cmd.Parameters.AddWithValue("@cve_persona", cvePersona);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ent_empleado_plantel = new EmpleadoPlantel();
                    ent_empleado_plantel.persona = new Persona();
                    ent_empleado_plantel.persona.usuario = new Usuario();
                    ent_empleado_plantel.persona.usuario.cve_usuario = Convert.ToInt16(reader["cve_usuario"].ToString());
                    ent_empleado_plantel.persona.usuario.contrasena = reader["contrasena"].ToString();
                    ent_empleado_plantel.persona.usuario.fecha_registro = Convert.ToDateTime(reader["fecha_registro"].ToString());
                    ent_empleado_plantel.persona.usuario.estatus = reader["estatus"].ToString();
                    ent_empleado_plantel.persona.usuario.alias_red = reader["alias_red"].ToString();
                    ent_empleado_plantel.persona.usuario.idAlumno = Convert.ToInt16(reader["idAlumno"].ToString());
                    ent_empleado_plantel.persona.cve_persona = Convert.ToInt16(reader["cve_persona"].ToString());
                    ent_empleado_plantel.persona.nombre = reader["nombre"].ToString();
                    ent_empleado_plantel.persona.apellido_paterno = reader["apellido_paterno"].ToString();
                    ent_empleado_plantel.persona.apellido_materno = reader["apellido_materno"].ToString();
                    ent_empleado_plantel.persona.rfc = reader["rfc"].ToString();
                    ent_empleado_plantel.persona.curp = reader["curp"].ToString();

                    ent_empleado_plantel.persona.sexo = reader["sexo"].ToString();
                    ent_empleado_plantel.persona.fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"].ToString());
                    ent_empleado_plantel.persona.numero_telefono = reader["numero_telefono"].ToString();
                    ent_empleado_plantel.persona.estado_civil = Convert.ToInt16(reader["estado_civil"].ToString());
                    ent_empleado_plantel.persona.nacionalidad = reader["nacionalidad"].ToString();
                    ent_empleado_plantel.persona.municipio = reader["municipio"].ToString();
                    ent_empleado_plantel.persona.idColonia = Convert.ToInt32(reader["idColonia"].ToString());
                    ent_empleado_plantel.cve_empleado_plantel = Convert.ToInt32(reader["cve_empleado_plantel"].ToString());
                    ent_empleado_plantel.idPlantelesES = Convert.ToInt16(reader["idPlantelesES"].ToString());
                    ent_empleado_plantel.tipo = Convert.ToInt16(reader["tipo"].ToString());
                    ent_empleado_plantel.fecha_registro = Convert.ToDateTime(reader["fecha_registro"].ToString());
                }
                return ent_empleado_plantel;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public bool EliminarPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update usuario set estatus = @estatus where cve_usuario = @cve_usuario";
                cmd.Parameters.AddWithValue("@estatus", "Inactivo");
                cmd.Parameters.AddWithValue("@cve_usuario", empleadoPlantel.persona.usuario.cve_usuario);
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
        public List<int> GuardarPerfilPersonaPadreFamilia(PadreFamilia padreFamilia)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = new MySqlCommand("p_crear_perfilPadreFamilia", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_nombre", padreFamilia.persona.nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", padreFamilia.persona.apellido_paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", padreFamilia.persona.apellido_materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", padreFamilia.persona.rfc));
                cmd.Parameters.Add(new MySqlParameter("p_curp", padreFamilia.persona.curp));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", padreFamilia.persona.sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", padreFamilia.persona.fecha_nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", padreFamilia.persona.numero_telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", padreFamilia.persona.estado_civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", padreFamilia.persona.nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", padreFamilia.persona.municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", padreFamilia.persona.idColonia));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", padreFamilia.persona.usuario.contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", padreFamilia.persona.usuario.fecha_registro));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", padreFamilia.persona.usuario.alias_red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", padreFamilia.persona.usuario.idAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumnoP", padreFamilia.idAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro", padreFamilia.fecha_registro));
                MySqlParameter cve_usuario = new MySqlParameter("p_cve_usuario", MySqlDbType.Int16);
                MySqlParameter cve_persona = new MySqlParameter("p_cve_persona", MySqlDbType.Int16);
                cve_usuario.Direction = System.Data.ParameterDirection.Output;
                cve_persona.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(cve_usuario);
                cmd.Parameters.Add(cve_persona);
                con.Open();
                cmd.ExecuteNonQuery();
                int cve_Usuario = Int16.Parse(cmd.Parameters["p_cve_usuario"].Value.ToString());
                int cve_Persona = Int16.Parse(cmd.Parameters["p_cve_persona"].Value.ToString());
                List<int> claves = new List<int>();
                claves.Add(cve_Usuario);
                claves.Add(cve_Persona);
                return claves;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el guardado de la información " + ex.Message);
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "rollback";
                con.Open();
                cmd.ExecuteNonQuery();
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ModificarPerfilPadreFamilia(PadreFamilia padreFamilia)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = new MySqlCommand("p_modificar_perfilEmpleado", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_cve_persona", padreFamilia.persona.cve_persona));
                cmd.Parameters.Add(new MySqlParameter("p_nombre", padreFamilia.persona.nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", padreFamilia.persona.apellido_paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", padreFamilia.persona.apellido_materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", padreFamilia.persona.rfc));
                cmd.Parameters.Add(new MySqlParameter("p_curp", padreFamilia.persona.curp));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", padreFamilia.persona.sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", padreFamilia.persona.fecha_nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", padreFamilia.persona.numero_telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", padreFamilia.persona.estado_civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", padreFamilia.persona.nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", padreFamilia.persona.municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", padreFamilia.persona.idColonia));
                cmd.Parameters.Add(new MySqlParameter("p_cve_usuario", padreFamilia.persona.usuario.cve_usuario));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", padreFamilia.persona.usuario.contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", padreFamilia.persona.usuario.fecha_registro));
                cmd.Parameters.Add(new MySqlParameter("p_estatus", padreFamilia.persona.usuario.estatus));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", padreFamilia.persona.usuario.alias_red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", padreFamilia.persona.usuario.idAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_cve_padre_familia", padreFamilia.cve_padre_familia));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumnoP", padreFamilia.idAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro", padreFamilia.fecha_registro));
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

        public PadreFamilia ConsultarPerfilPadreFamilia(int cveUsuario, int cvePersona)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from usuario u, persona p, padre_familia pf where p.cve_usuario = @cve_usuarioP and u.cve_usuario = @cve_usuarioU " +
                "and pf.cve_persona = @cve_persona";
                cmd.Parameters.AddWithValue("@cve_usuarioP", cveUsuario);
                cmd.Parameters.AddWithValue("@cve_usuarioU", cveUsuario);
                cmd.Parameters.AddWithValue("@cve_persona", cvePersona);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ent_padre_familia = new PadreFamilia();
                    ent_padre_familia.persona = new Persona();
                    ent_padre_familia.persona.usuario = new Usuario();
                    ent_padre_familia.persona.usuario.cve_usuario = Convert.ToInt16(reader["cve_usuario"].ToString());
                    ent_padre_familia.persona.usuario.contrasena = reader["contrasena"].ToString();
                    ent_padre_familia.persona.usuario.fecha_registro = Convert.ToDateTime(reader["fecha_registro"].ToString());
                    ent_padre_familia.persona.usuario.estatus = reader["estatus"].ToString();
                    ent_padre_familia.persona.usuario.alias_red = reader["alias_red"].ToString();
                    ent_padre_familia.persona.usuario.idAlumno = Convert.ToInt16(reader["idAlumno"].ToString());
                    ent_padre_familia.persona.cve_persona = Convert.ToInt16(reader["cve_persona"].ToString());
                    ent_padre_familia.persona.nombre = reader["nombre"].ToString();
                    ent_padre_familia.persona.apellido_paterno = reader["apellido_paterno"].ToString();
                    ent_padre_familia.persona.apellido_materno = reader["apellido_materno"].ToString();
                    ent_padre_familia.persona.rfc = reader["rfc"].ToString();
                    ent_padre_familia.persona.curp = reader["curp"].ToString();
                    ent_padre_familia.persona.sexo = reader["sexo"].ToString();
                    ent_padre_familia.persona.fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"].ToString());
                    ent_padre_familia.persona.numero_telefono = reader["numero_telefono"].ToString();
                    ent_padre_familia.persona.estado_civil = Convert.ToInt16(reader["estado_civil"].ToString());
                    ent_padre_familia.persona.nacionalidad = reader["nacionalidad"].ToString();
                    ent_padre_familia.persona.municipio = reader["municipio"].ToString();
                    ent_padre_familia.persona.idColonia = Convert.ToInt32(reader["idColonia"].ToString());
                    ent_padre_familia.cve_padre_familia = Convert.ToInt32(reader["cve_padre_familia"].ToString());
                    ent_padre_familia.idAlumno = Convert.ToInt16(reader["idAlumno"].ToString());
                    ent_padre_familia.fecha_registro = Convert.ToDateTime(reader["fecha_registro"].ToString());
                }
                return ent_padre_familia;
            }
            catch (MySqlException ex)
            {
                return null;
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public bool EliminarPerfilPadreFamilia(PadreFamilia padre)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update usuario set estatus = @estatus where cve_usuario = @cve_usuario";
                cmd.Parameters.AddWithValue("@estatus", "Inactivo");
                cmd.Parameters.AddWithValue("@cve_usuario", padre.persona.usuario.cve_usuario);
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