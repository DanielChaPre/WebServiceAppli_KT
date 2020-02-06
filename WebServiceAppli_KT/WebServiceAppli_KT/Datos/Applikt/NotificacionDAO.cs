using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class NotificacionDAO
    {
        ConexionAppliktDAO conexion = new ConexionAppliktDAO();
        MySqlConnection con;
        List<Notificaciones> lstnotificaciones;

        public List<Notificaciones> ConsultarNotificaciones(string cveUsuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "  Select * from notificacion where cve_notificacion in " +
                    "(Select cve_notificacion from bandeja_notifiacion_usuario where cve_usuario = @cveUsuario); ";
                cmd.Parameters.AddWithValue("@cveUsuario", cveUsuario);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                lstnotificaciones = new List<Notificaciones>();
                while (reader.Read())
                {

                    lstnotificaciones.Add(new Notificaciones()
                    {
                        cve_notificacion = int.Parse(reader["cve_notificacion"].ToString()),
                        cve_tipo_notificacion = Convert.ToInt32(reader["cve_tipo_notificacion"].ToString()),
                        texto = reader["texto"].ToString(),
                        responsable = reader["responsable"].ToString(),
                        cve_categoria = reader["cve_categoria"].ToString(),
                        titulo = reader["titulo"].ToString(),
                        url = reader["url"].ToString(),
                        fecha_notificacion = reader["fecha_notificacion"].ToString(),
                        hora_notificacion = reader["hora_notificacion"].ToString(),
                        
                     });
                }
                return lstnotificaciones;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la consulta de notificaciones: "+ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool EliminarNotificacion(string cveUsuario, string cveNotificacion)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Delete from bandeja_notifiacion_usuario where cve_usuario = @cveUsuario and" +
                    " cve_notificacion = @cveNotificacion";
                cmd.Parameters.AddWithValue("@cveUsuario", cveUsuario);
                cmd.Parameters.AddWithValue("@cveNotificacion", cveNotificacion);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}