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
        Notificaciones entNotificacion;

        public Notificaciones ConsultarNotificaciones()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from bandeja_notificacion_usuario";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    entNotificacion = new Notificaciones();
                    entNotificacion.cve_notificaciones = int.Parse(reader["cve_notificaciones"].ToString());
                    entNotificacion.tipo_notificaciones = reader["tipo_notificacion"].ToString();
                    entNotificacion.texto = reader["texto"].ToString();
                    entNotificacion.responsable = reader["responsable"].ToString();
                    entNotificacion.cve_categoria = reader["categorizacion"].ToString();
                    entNotificacion.titulo = reader["titulo"].ToString();
                    entNotificacion.url = reader["url"].ToString();
                    entNotificacion.audiencia = reader["audiencia"].ToString();
               //     entNotificacion.fechaNotificacion = reader["fecha_notificacion"].ToString();
                 //   entNotificacion.horaNotificacion = reader["hora_notificacion"].ToString();
                }
                return entNotificacion;
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

        public void EliminarNotificacion()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}