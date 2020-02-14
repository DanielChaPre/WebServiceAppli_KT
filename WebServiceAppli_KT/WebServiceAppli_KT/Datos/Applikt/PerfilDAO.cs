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
        int cveUsuario, cvePersona;

        #region Persona
        public List<int> GuardarPerfilPersona(Persona persona)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = new MySqlCommand("p_crear_perfil",con);
                  cmd.CommandType = System.Data.CommandType.StoredProcedure;
                  cmd.Parameters.Add(new MySqlParameter("p_nombre", persona.Nombre));
                  cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", persona.Apellido_Paterno));
                  cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", persona.Apellido_Materno));
                  cmd.Parameters.Add(new MySqlParameter("p_rfc", persona.RFC));
                  cmd.Parameters.Add(new MySqlParameter("p_curp", persona.CURP));
                  cmd.Parameters.Add(new MySqlParameter("p_sexo", persona.Sexo));
                  cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", persona.Fecha_Nacimiento));
                  cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", persona.Numero_Telefono));
                  cmd.Parameters.Add(new MySqlParameter("p_estado_civil", persona.Estado_Civil));
                  cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", persona.Nacionalidad));
                  cmd.Parameters.Add(new MySqlParameter("p_municipio", persona.Municipio));
                  cmd.Parameters.Add(new MySqlParameter("p_idColonia", persona.IdColonia));
                  cmd.Parameters.Add(new MySqlParameter("p_nombre_usuario", persona.Usuario.Nombre_Usuario));
                  cmd.Parameters.Add(new MySqlParameter("p_contraseña", persona.Usuario.Contrasena));
                  cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", persona.Usuario.Fecha_Registro));
                  cmd.Parameters.Add(new MySqlParameter("p_alias_redes", persona.Usuario.Alias_Red));
                  cmd.Parameters.Add(new MySqlParameter("p_idAlumno", persona.Usuario.IdAlumno));
               // cmd.Parameters.Add(new MySqlParameter(""))
                 MySqlParameter cve_usuario = new MySqlParameter("p_cve_usuario", MySqlDbType.Int16);
                 MySqlParameter cve_persona = new MySqlParameter("p_cve_persona", MySqlDbType.Int16);
                 cve_usuario.Direction = System.Data.ParameterDirection.Output;
                 cve_persona.Direction = System.Data.ParameterDirection.Output;
                 cmd.Parameters.Add(cve_usuario);
                  cmd.Parameters.Add(cve_persona);
                  con.Open();
                  cmd.ExecuteNonQuery();
                  int cve_Usuario = Int32.Parse(cmd.Parameters["p_cve_usuario"].Value.ToString());
                  int cve_Persona = Int32.Parse(cmd.Parameters["p_cve_persona"].Value.ToString());
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
                ConsultarClaves(persona.Usuario.Nombre_Usuario, persona.Usuario.Contrasena);
                MySqlCommand cmd = new MySqlCommand("p_modificar_perfil", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_cve_persona", cvePersona));
                cmd.Parameters.Add(new MySqlParameter("p_nombre", persona.Nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", persona.Apellido_Paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", persona.Apellido_Materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", persona.RFC));
                cmd.Parameters.Add(new MySqlParameter("p_curp", persona.CURP));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", persona.Sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", persona.Fecha_Nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", persona.Numero_Telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", persona.Estado_Civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", persona.Nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", persona.Municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", persona.IdColonia));
                cmd.Parameters.Add(new MySqlParameter("p_cve_usuario", cveUsuario));
                cmd.Parameters.Add(new MySqlParameter("p_nombre_usuario", persona.Usuario.Nombre_Usuario));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", persona.Usuario.Contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", persona.Usuario.Fecha_Registro));
                cmd.Parameters.Add(new MySqlParameter("p_estatus", persona.Usuario.Estatus));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", persona.Usuario.Alias_Red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", persona.Usuario.IdAlumno));
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

        public void ConsultarClaves(string user, string contrasena)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "    Select usuario.cve_usuario, persona.cve_persona from usuario , persona where (usuario.contrasena =@contrasena  and " +
                    "nombre_usuario = @user ) and persona.cve_usuario = (Select cve_usuario from usuario where(usuario.contrasena = @contrasena and" +
                    " nombre_usuario = @user)) ";
                //  var clave = ByUsuarioCve(usuario, contrasenia);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@contrasena", contrasena);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                //   object o = reader.GetValue(1);
                if (reader.Read())
                {
                    cvePersona = Convert.ToInt32(reader["cve_persona"].ToString());
                    cveUsuario = Convert.ToInt32(reader["cve_usuario"].ToString());
                    return;
                }
                return;
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
        public Persona ConsultarPerfilPersona(string usuario, string contrasenia)
        {
            try
            {
                var cveUsuario = ByUsuarioCve(usuario, contrasenia);
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
                    persona.Cve_Persona = Convert.ToInt16(reader["cve_persona"].ToString());
                    persona.Nombre = reader["nombre"].ToString();
                    persona.Apellido_Paterno = reader["apellido_paterno"].ToString();
                    persona.Apellido_Materno = reader["apellido_materno"].ToString();
                    persona.RFC = reader["rfc"].ToString();
                    persona.CURP = reader["curp"].ToString();
                    persona.Sexo = reader["sexo"].ToString();
                    persona.Fecha_Nacimiento = reader["fecha_nacimiento"].ToString();
                    persona.Numero_Telefono = reader["numero_telefono"].ToString();
                    persona.Estado_Civil = Convert.ToInt16(reader["estado_civil"].ToString());
                    persona.Nacionalidad = reader["nacionalidad"].ToString();
                    persona.Municipio = reader["municipio"].ToString();
                    persona.IdColonia = Convert.ToInt32(reader["idColonia"].ToString());
                    persona.Usuario = new Usuario();
                    persona.Usuario.Cve_Usuario = Convert.ToInt16(reader["cve_usuario"].ToString());
                    persona.Usuario.Nombre_Usuario = reader["nombre_usuario"].ToString();
                    persona.Usuario.Contrasena = reader["contrasena"].ToString();
                    persona.Usuario.Fecha_Registro = reader["fecha_registro"].ToString();
                    persona.Usuario.Estatus = reader["estatus"].ToString();
                    persona.Usuario.Alias_Red = reader["alias_red"].ToString();
                    persona.Usuario.Tipo_Usuario = Convert.ToInt32(reader["tipo_usuario"].ToString());
                    persona.Usuario.Ruta_Imagen = reader["ruta_imagen"].ToString();
                    var idAlumno = reader["idAlumno"].ToString();
                    persona.Usuario.IdAlumno = Convert.ToInt32(idAlumno);
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
                ConsultarClaves(persona.Usuario.Nombre_Usuario, persona.Usuario.Contrasena);
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update usuario set estatus = @estatus where cve_usuario = @cve_usuario";
                cmd.Parameters.AddWithValue("@estatus", "Inactivo");
                cmd.Parameters.AddWithValue("@cve_usuario", cveUsuario);
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
                cmd.Parameters.Add(new MySqlParameter("p_nombre", empleado.Persona.Nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", empleado.Persona.Apellido_Paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", empleado.Persona.Apellido_Materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", empleado.Persona.RFC));
                cmd.Parameters.Add(new MySqlParameter("p_curp", empleado.Persona.CURP));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", empleado.Persona.Sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", empleado.Persona.Fecha_Nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", empleado.Persona.Numero_Telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", empleado.Persona.Estado_Civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", empleado.Persona.Nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", empleado.Persona.Municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", empleado.Persona.IdColonia));
                cmd.Parameters.Add(new MySqlParameter("p_nombre_usuario", empleado.Persona.Usuario.Nombre_Usuario));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", empleado.Persona.Usuario.Contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", empleado.Persona.Usuario.Fecha_Registro));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", empleado.Persona.Usuario.Alias_Red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", empleado.Persona.Usuario.IdAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_numero_empleado", empleado.Numero_Empleado));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro", empleado.Fecha_Registro));
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
                cmd.Parameters.Add(new MySqlParameter("p_cve_persona", empleado.Persona.Cve_Persona));
                cmd.Parameters.Add(new MySqlParameter("p_nombre", empleado.Persona.Nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", empleado.Persona.Apellido_Paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", empleado.Persona.Apellido_Materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", empleado.Persona.RFC));
                cmd.Parameters.Add(new MySqlParameter("p_curp", empleado.Persona.CURP));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", empleado.Persona.Sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", empleado.Persona.Fecha_Nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", empleado.Persona.Numero_Telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", empleado.Persona.Estado_Civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", empleado.Persona.Nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", empleado.Persona.Municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", empleado.Persona.IdColonia));
                cmd.Parameters.Add(new MySqlParameter("p_cve_usuario", empleado.Persona.Usuario.Cve_Usuario));
                cmd.Parameters.Add(new MySqlParameter("p_nombre_usuario", empleado.Persona.Usuario.Nombre_Usuario));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", empleado.Persona.Usuario.Contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", empleado.Persona.Usuario.Fecha_Registro));
                cmd.Parameters.Add(new MySqlParameter("p_estatus", empleado.Persona.Usuario.Estatus));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", empleado.Persona.Usuario.Alias_Red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", empleado.Persona.Usuario.IdAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_cve_empleado", empleado.Cve_Empleado));
                cmd.Parameters.Add(new MySqlParameter("p_numero_empleado", empleado.Numero_Empleado));
                cmd.Parameters.Add(new MySqlParameter("p_estatusE", empleado.Estatus));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro", empleado.Fecha_Registro));
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

        public Empleado ConsultarPerfilEmpleado(string usuario, string contrasenia)
        {
            try
            {
                var conn = conexion.Builder;
                var cveUsuario = ByUsuarioCve(usuario, contrasenia);
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from usuario u, persona p, empleado e where p.cve_usuario = @cveUsuarioP and u.cve_usuario = @cveUsuarioU and " +
                    "e.cve_persona = (Select cve_persona from persona where cve_usuario = @cveUsuario)";
                cmd.Parameters.AddWithValue("@cveUsuarioP", cveUsuario);
                cmd.Parameters.AddWithValue("@cveUsuarioU", cveUsuario);
                cmd.Parameters.AddWithValue("@cveUsuario", cveUsuario);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ent_empleado = new Empleado();
                    ent_empleado.Persona = new Persona();
                    ent_empleado.Persona.Usuario = new Usuario();
                    ent_empleado.Persona.Usuario.Cve_Usuario = Convert.ToInt16(reader["cve_usuario"].ToString());
                    ent_empleado.Persona.Usuario.Nombre_Usuario = reader["nombre_usuario"].ToString();
                    ent_empleado.Persona.Usuario.Contrasena = reader["contrasena"].ToString();
                    ent_empleado.Persona.Usuario.Fecha_Registro = reader["fecha_registro"].ToString();
                    ent_empleado.Persona.Usuario.Estatus = reader["estatus"].ToString();
                    ent_empleado.Persona.Usuario.Alias_Red = reader["alias_red"].ToString();
                    ent_empleado.Persona.Usuario.IdAlumno = Convert.ToInt16(reader["idAlumno"].ToString());
                    ent_empleado.Persona.Cve_Persona = Convert.ToInt16(reader["cve_persona"].ToString());
                    ent_empleado.Persona.Nombre = reader["nombre"].ToString();
                    ent_empleado.Persona.Apellido_Paterno = reader["apellido_paterno"].ToString();
                    ent_empleado.Persona.Apellido_Materno = reader["apellido_materno"].ToString();
                    ent_empleado.Persona.RFC = reader["rfc"].ToString();
                    ent_empleado.Persona.CURP = reader["curp"].ToString();
                    ent_empleado.Persona.Sexo = reader["sexo"].ToString();
                    ent_empleado.Persona.Fecha_Nacimiento = reader["fecha_nacimiento"].ToString();
                    ent_empleado.Persona.Numero_Telefono = reader["numero_telefono"].ToString();
                    ent_empleado.Persona.Estado_Civil = Convert.ToInt16(reader["estado_civil"].ToString());
                    ent_empleado.Persona.Nacionalidad = reader["nacionalidad"].ToString();
                    ent_empleado.Persona.Municipio = reader["municipio"].ToString();
                    ent_empleado.Persona.IdColonia = Convert.ToInt32(reader["idColonia"].ToString());
                    ent_empleado.Cve_Empleado = Convert.ToInt32(reader["cve_empleado"].ToString());
                    ent_empleado.Numero_Empleado = reader["numero_empleado"].ToString();
                    ent_empleado.Estatus = reader["estatus"].ToString();
                    ent_empleado.Fecha_Registro = reader["fecha_registro"].ToString();
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
                cmd.Parameters.AddWithValue("@cve_usuario", empleado.Persona.Usuario.Cve_Usuario);
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
                cmd.Parameters.Add(new MySqlParameter("p_nombre", empleadoPlantel.Persona.Nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", empleadoPlantel.Persona.Apellido_Paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", empleadoPlantel.Persona.Apellido_Materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", empleadoPlantel.Persona.RFC));
                cmd.Parameters.Add(new MySqlParameter("p_curp", empleadoPlantel.Persona.CURP));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", empleadoPlantel.Persona.Sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", empleadoPlantel.Persona.Fecha_Nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", empleadoPlantel.Persona.Numero_Telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", empleadoPlantel.Persona.Estado_Civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", empleadoPlantel.Persona.Nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", empleadoPlantel.Persona.Municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", empleadoPlantel.Persona.IdColonia));
                cmd.Parameters.Add(new MySqlParameter("p_nombre_usuario", empleadoPlantel.Persona.Usuario.Nombre_Usuario));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", empleadoPlantel.Persona.Usuario.Contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", empleadoPlantel.Persona.Usuario.Fecha_Registro));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", empleadoPlantel.Persona.Usuario.Alias_Red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", empleadoPlantel.Persona.Usuario.IdAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_idPlantelesES", empleadoPlantel.IdPlantelesES));
                cmd.Parameters.Add(new MySqlParameter("p_tipo", empleadoPlantel.Tipo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro", empleadoPlantel.Fecha_Registro));
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
                cmd.Parameters.Add(new MySqlParameter("p_cve_persona", empleadoPlantel.Persona.Cve_Persona));
                cmd.Parameters.Add(new MySqlParameter("p_nombre", empleadoPlantel.Persona.Nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", empleadoPlantel.Persona.Apellido_Paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", empleadoPlantel.Persona.Apellido_Materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", empleadoPlantel.Persona.RFC));
                cmd.Parameters.Add(new MySqlParameter("p_curp", empleadoPlantel.Persona.CURP));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", empleadoPlantel.Persona.Sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", empleadoPlantel.Persona.Fecha_Nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", empleadoPlantel.Persona.Numero_Telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", empleadoPlantel.Persona.Estado_Civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", empleadoPlantel.Persona.Nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", empleadoPlantel.Persona.Municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", empleadoPlantel.Persona.IdColonia));
                cmd.Parameters.Add(new MySqlParameter("p_cve_usuario", empleadoPlantel.Persona.Usuario.Cve_Usuario));
                cmd.Parameters.Add(new MySqlParameter("p_nombre_usuario", empleadoPlantel.Persona.Usuario.Nombre_Usuario));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", empleadoPlantel.Persona.Usuario.Contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", empleadoPlantel.Persona.Usuario.Fecha_Registro));
                cmd.Parameters.Add(new MySqlParameter("p_estatus", empleadoPlantel.Persona.Usuario.Estatus));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", empleadoPlantel.Persona.Usuario.Alias_Red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", empleadoPlantel.Persona.Usuario.IdAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_cve_empleado_plantel", empleadoPlantel.Cve_Empleado_Plantel));
                cmd.Parameters.Add(new MySqlParameter("p_idPlantelES", empleadoPlantel.IdPlantelesES));
                cmd.Parameters.Add(new MySqlParameter("p_tipo", empleadoPlantel.Tipo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro", empleadoPlantel.Fecha_Registro));
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

        public EmpleadoPlantel ConsultarPerfilEmpleadoPlantel(string usuario, string contrasenia)
        {
            try
            {
                var cveUsuario = ByUsuarioCve(usuario, contrasenia);
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from usuario u, persona p, empleado_plantel e where p.cve_usuario = @cveUsuarioP and u.cve_usuario = @cveUsuarioU and " +
                                   "e.cve_persona = (Select cve_persona from persona where cve_usuario = @cveUsuario)";
                cmd.Parameters.AddWithValue("@cveUsuarioP", cveUsuario);
                cmd.Parameters.AddWithValue("@cveUsuarioU", cveUsuario);
                cmd.Parameters.AddWithValue("@cveUsuario", cveUsuario);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ent_empleado_plantel = new EmpleadoPlantel();
                    ent_empleado_plantel.Persona = new Persona();
                    ent_empleado_plantel.Persona.Usuario = new Usuario();
                    ent_empleado_plantel.Persona.Usuario.Cve_Usuario = Convert.ToInt16(reader["cve_usuario"].ToString());
                    ent_empleado_plantel.Persona.Usuario.Nombre_Usuario = reader["nombre_usuario"].ToString();
                    ent_empleado_plantel.Persona.Usuario.Contrasena = reader["contrasena"].ToString();
                    ent_empleado_plantel.Persona.Usuario.Fecha_Registro = reader["fecha_registro"].ToString();
                    ent_empleado_plantel.Persona.Usuario.Estatus = reader["estatus"].ToString();
                    ent_empleado_plantel.Persona.Usuario.Alias_Red = reader["alias_red"].ToString();
                    ent_empleado_plantel.Persona.Usuario.IdAlumno = Convert.ToInt16(reader["idAlumno"].ToString());
                    ent_empleado_plantel.Persona.Cve_Persona = Convert.ToInt16(reader["cve_persona"].ToString());
                    ent_empleado_plantel.Persona.Nombre = reader["nombre"].ToString();
                    ent_empleado_plantel.Persona.Apellido_Paterno = reader["apellido_paterno"].ToString();
                    ent_empleado_plantel.Persona.Apellido_Materno = reader["apellido_materno"].ToString();
                    ent_empleado_plantel.Persona.RFC = reader["rfc"].ToString();
                    ent_empleado_plantel.Persona.CURP = reader["curp"].ToString();
                    ent_empleado_plantel.Persona.Sexo = reader["sexo"].ToString();
                    ent_empleado_plantel.Persona.Fecha_Nacimiento = reader["fecha_nacimiento"].ToString();
                    ent_empleado_plantel.Persona.Numero_Telefono = reader["numero_telefono"].ToString();
                    ent_empleado_plantel.Persona.Estado_Civil = Convert.ToInt16(reader["estado_civil"].ToString());
                    ent_empleado_plantel.Persona.Nacionalidad = reader["nacionalidad"].ToString();
                    ent_empleado_plantel.Persona.Municipio = reader["municipio"].ToString();
                    ent_empleado_plantel.Persona.IdColonia = Convert.ToInt32(reader["idColonia"].ToString());
                    ent_empleado_plantel.Cve_Empleado_Plantel = Convert.ToInt32(reader["cve_empleado_plantel"].ToString());
                    ent_empleado_plantel.IdPlantelesES = Convert.ToInt16(reader["idPlantelesES"].ToString());
                    ent_empleado_plantel.Tipo = Convert.ToInt16(reader["tipo"].ToString());
                    ent_empleado_plantel.Fecha_Registro = reader["fecha_registro"].ToString();
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
                cmd.Parameters.AddWithValue("@cve_usuario", empleadoPlantel.Persona.Usuario.Cve_Usuario);
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
                cmd.Parameters.Add(new MySqlParameter("p_nombre", padreFamilia.Persona.Nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", padreFamilia.Persona.Apellido_Paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", padreFamilia.Persona.Apellido_Materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", padreFamilia.Persona.RFC));
                cmd.Parameters.Add(new MySqlParameter("p_curp", padreFamilia.Persona.CURP));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", padreFamilia.Persona.Sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", padreFamilia.Persona.Fecha_Nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", padreFamilia.Persona.Numero_Telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", padreFamilia.Persona.Estado_Civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", padreFamilia.Persona.Nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", padreFamilia.Persona.Municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", padreFamilia.Persona.IdColonia));
                cmd.Parameters.Add(new MySqlParameter("p_nombre_usuario", padreFamilia.Persona.Usuario.Nombre_Usuario));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", padreFamilia.Persona.Usuario.Contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", padreFamilia.Persona.Usuario.Fecha_Registro));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", padreFamilia.Persona.Usuario.Alias_Red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", padreFamilia.Persona.Usuario.IdAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumnoP", padreFamilia.IdAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro", padreFamilia.Fecha_Registro));
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
                cmd.Parameters.Add(new MySqlParameter("p_cve_persona", padreFamilia.Persona.Cve_Persona));
                cmd.Parameters.Add(new MySqlParameter("p_nombre", padreFamilia.Persona.Nombre));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_paterno", padreFamilia.Persona.Apellido_Paterno));
                cmd.Parameters.Add(new MySqlParameter("p_apellido_materno", padreFamilia.Persona.Apellido_Materno));
                cmd.Parameters.Add(new MySqlParameter("p_rfc", padreFamilia.Persona.RFC));
                cmd.Parameters.Add(new MySqlParameter("p_curp", padreFamilia.Persona.CURP));
                cmd.Parameters.Add(new MySqlParameter("p_sexo", padreFamilia.Persona.Sexo));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_nacimiento", padreFamilia.Persona.Fecha_Nacimiento));
                cmd.Parameters.Add(new MySqlParameter("p_numero_telefono", padreFamilia.Persona.Numero_Telefono));
                cmd.Parameters.Add(new MySqlParameter("p_estado_civil", padreFamilia.Persona.Estado_Civil));
                cmd.Parameters.Add(new MySqlParameter("p_nacionalidad", padreFamilia.Persona.Nacionalidad));
                cmd.Parameters.Add(new MySqlParameter("p_municipio", padreFamilia.Persona.Municipio));
                cmd.Parameters.Add(new MySqlParameter("p_idColonia", padreFamilia.Persona.IdColonia));
                cmd.Parameters.Add(new MySqlParameter("p_cve_usuario", padreFamilia.Persona.Usuario.Cve_Usuario));
                cmd.Parameters.Add(new MySqlParameter("p_nombre_usuario", padreFamilia.Persona.Usuario.Nombre_Usuario));
                cmd.Parameters.Add(new MySqlParameter("p_contraseña", padreFamilia.Persona.Usuario.Contrasena));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro_u", padreFamilia.Persona.Usuario.Fecha_Registro));
                cmd.Parameters.Add(new MySqlParameter("p_estatus", padreFamilia.Persona.Usuario.Estatus));
                cmd.Parameters.Add(new MySqlParameter("p_alias_redes", padreFamilia.Persona.Usuario.Alias_Red));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumno", padreFamilia.Persona.Usuario.IdAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_cve_padre_familia", padreFamilia.Cve_Padre_Familia));
                cmd.Parameters.Add(new MySqlParameter("p_idAlumnoP", padreFamilia.IdAlumno));
                cmd.Parameters.Add(new MySqlParameter("p_fecha_registro", padreFamilia.Fecha_Registro));
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

        public PadreFamilia ConsultarPerfilPadreFamilia(string usuario, string contrasenia)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from usuario u, persona p, padre_familia pf where p.cve_usuario = @cveUsuarioP and u.cve_usuario = @cveUsuarioU and " +
                      "pf.cve_persona = (Select cve_persona from persona where cve_usuario = @cveUsuario)";
                cmd.Parameters.AddWithValue("@cveUsuarioP", ByUsuarioCve(usuario, contrasenia));
                cmd.Parameters.AddWithValue("@cveUsuarioU", ByUsuarioCve(usuario, contrasenia));
                cmd.Parameters.AddWithValue("@cveUsuario", ByUsuarioCve(usuario, contrasenia));
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ent_padre_familia = new PadreFamilia();
                    ent_padre_familia.Persona = new Persona();
                    ent_padre_familia.Persona.Usuario = new Usuario();
                    ent_padre_familia.Persona.Usuario.Cve_Usuario = Convert.ToInt16(reader["cve_usuario"].ToString());
                    ent_padre_familia.Persona.Usuario.Nombre_Usuario = reader["nombre_usuario"].ToString();
                    ent_padre_familia.Persona.Usuario.Contrasena = reader["contrasena"].ToString();
                    ent_padre_familia.Persona.Usuario.Fecha_Registro = reader["fecha_registro"].ToString();
                    ent_padre_familia.Persona.Usuario.Estatus = reader["estatus"].ToString();
                    ent_padre_familia.Persona.Usuario.Alias_Red = reader["alias_red"].ToString();
                    ent_padre_familia.Persona.Usuario.IdAlumno = Convert.ToInt16(reader["idAlumno"].ToString());
                    ent_padre_familia.Persona.Cve_Persona = Convert.ToInt16(reader["cve_persona"].ToString());
                    ent_padre_familia.Persona.Nombre = reader["nombre"].ToString();
                    ent_padre_familia.Persona.Apellido_Paterno = reader["apellido_paterno"].ToString();
                    ent_padre_familia.Persona.Apellido_Materno = reader["apellido_materno"].ToString();
                    ent_padre_familia.Persona.RFC = reader["rfc"].ToString();
                    ent_padre_familia.Persona.CURP = reader["curp"].ToString();
                    ent_padre_familia.Persona.Sexo = reader["sexo"].ToString();
                    ent_padre_familia.Persona.Fecha_Nacimiento = reader["fecha_nacimiento"].ToString();
                    ent_padre_familia.Persona.Numero_Telefono = reader["numero_telefono"].ToString();
                    ent_padre_familia.Persona.Estado_Civil = Convert.ToInt16(reader["estado_civil"].ToString());
                    ent_padre_familia.Persona.Nacionalidad = reader["nacionalidad"].ToString();
                    ent_padre_familia.Persona.Municipio = reader["municipio"].ToString();
                    ent_padre_familia.Persona.IdColonia = Convert.ToInt32(reader["idColonia"].ToString());
                    ent_padre_familia.Cve_Padre_Familia = Convert.ToInt32(reader["cve_padre_familia"].ToString());
                    ent_padre_familia.IdAlumno = Convert.ToInt16(reader["idAlumno"].ToString());
                    ent_padre_familia.Fecha_Registro = reader["fecha_registro"].ToString();
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
                cmd.Parameters.AddWithValue("@cve_usuario", padre.Persona.Usuario.Cve_Usuario);
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

        public int ByUsuarioCve(string usuario, string contrasena)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from usuario where nombre_usuario = @usuario" +
                    "  and contrasena = @contrasenia";
                //cmd.Parameters.AddWithValue("@usuario", "fer.hdez.sierra9647@gmail.com");
                //cmd.Parameters.AddWithValue("@contrasenia", "Q1*queen");
                cmd.Parameters.AddWithValue("@usuario", usuario.ToString());
                cmd.Parameters.AddWithValue("@contrasenia", contrasena.ToString());
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var cve = Convert.ToInt32(reader["cve_usuario"].ToString());
                    return Convert.ToInt32(reader["cve_usuario"].ToString());
                }
                //if (reader.Read())
                //{
                  
                //}
                return 0;
            }
            catch (MySqlException ex)
            {
                return 0;
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}