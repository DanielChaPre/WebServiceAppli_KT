using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceAppli_KT.Datos.Applikt
{
    public class ConfiguracionPlantillasDAO
    {
        ConexionAppliktDAO conexion = new ConexionAppliktDAO();
        MySqlConnection con;

        public List<string> ConfigurarPlantillaUsuarios(string cveUsuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT  distinct grupo_seguridad_plantilla.cve_grupo_seguridad_plantilla," +
                    "  grupo_seguridad_plantilla.cve_plantilla_superior, grupo_seguridad_plantilla.estatus, grupo_seguridad_plantilla.icono," +
                    "  grupo_seguridad_plantilla.plantilla, grupo_seguridad_plantilla.ruta, usuario.cve_usuario," +
                    " IFNULL(usuario.nombre_usuario, '¬') as nombre_usuario, puesto.nombre as nombre_puesto, IF(usuario.contrasena = '-', '¬', '1') as contrasena" +
                    " FROM usuario  INNER JOIN puesto ON puesto.cve_puesto = usuario.tipo_usuario" +
                    " INNER JOIN grupo_seguridad_usuario ON usuario.cve_usuario = grupo_seguridad_usuario.cve_usuario" +
                    " INNER JOIN grupo_seguridad ON grupo_seguridad_usuario.cve_grupo_seguridad = grupo_seguridad.cve_grupo_seguridad" +
                    " INNER JOIN detalle_grupo_seguridad_plantilla ON grupo_seguridad.cve_grupo_seguridad = detalle_grupo_seguridad_plantilla.cve_grupo_seguridad" +
                    " INNER JOIN grupo_seguridad_plantilla ON detalle_grupo_seguridad_plantilla.cve_grupo_seguridad_plantilla = grupo_seguridad_plantilla.cve_grupo_seguridad_plantilla" +
                    " WHERE usuario.cve_usuario = @cveUsuario AND  grupo_seguridad_plantilla.estatus = 'Activo'";
                cmd.Parameters.AddWithValue("@cveUsuario", cveUsuario);
                con.Open();
                var lstPlantillas = new List<string>();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        lstPlantillas.Add(reader["plantilla"].ToString());
                    }
                }
                return lstPlantillas;
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

        public List<string> ConfigurarPlantillaUsuariosAlumno(string idAlumno)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT  distinct grupo_seguridad_plantilla.cve_grupo_seguridad_plantilla," +
                    "  grupo_seguridad_plantilla.cve_plantilla_superior, grupo_seguridad_plantilla.estatus, grupo_seguridad_plantilla.icono," +
                    "  grupo_seguridad_plantilla.plantilla, grupo_seguridad_plantilla.ruta, usuario.cve_usuario," +
                    " IFNULL(usuario.nombre_usuario, '¬') as nombre_usuario, puesto.nombre as nombre_puesto, IF(usuario.contrasena = '-', '¬', '1') as contrasena" +
                    " FROM usuario  INNER JOIN puesto ON puesto.cve_puesto = usuario.tipo_usuario" +
                    " INNER JOIN grupo_seguridad_usuario ON usuario.cve_usuario = grupo_seguridad_usuario.cve_usuario" +
                    " INNER JOIN grupo_seguridad ON grupo_seguridad_usuario.cve_grupo_seguridad = grupo_seguridad.cve_grupo_seguridad" +
                    " INNER JOIN detalle_grupo_seguridad_plantilla ON grupo_seguridad.cve_grupo_seguridad = detalle_grupo_seguridad_plantilla.cve_grupo_seguridad" +
                    " INNER JOIN grupo_seguridad_plantilla ON detalle_grupo_seguridad_plantilla.cve_grupo_seguridad_plantilla = grupo_seguridad_plantilla.cve_grupo_seguridad_plantilla" +
                    " WHERE usuario.idAlumno = @idAlumno AND  grupo_seguridad_plantilla.estatus = 'Activo'";
                cmd.Parameters.AddWithValue("@idAlumno", idAlumno);
                con.Open();
                var lstPlantillas = new List<string>();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        lstPlantillas.Add(reader["plantilla"].ToString());
                    }
                }
                return lstPlantillas;
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
    }
}