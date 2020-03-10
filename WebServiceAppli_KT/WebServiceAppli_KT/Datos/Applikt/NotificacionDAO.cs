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

        //public List<Notificaciones> ConsultarNotificaciones(string cveUsuario)
        //{
        //    try
        //    {
        //        var listnoti = new List<Notificaciones>();
        //        var listnotieli = new List<int>();
        //        listnoti = ConsultarNotificacionesUsuario(cveUsuario);
        //        listnotieli = ConsultarNotificacionesEliminadas(cveUsuario);
        //        for (int i = 0; i < listnoti.Count; i++)
        //        {
        //            for (int j = 0; j < listnotieli.Count; j++)
        //            {
        //                if (listnotieli[j] != listnoti[i].cve_notificacion)
        //                {
        //                    lstnotificaciones.Add(listnoti[j]);
        //                }
        //            }
        //        }
        //        return lstnotificaciones;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error en la consulta de notificaciones: "+ex.Message);
        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        public List<Notificaciones> ConsultarNotificaciones(string cveUsuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select n.* from notificacion as n " +
                    "inner join notificacion_grupo_seguridad as ngs on ngs.cve_notificacion = n.cve_notificacion " +
                    "inner join grupo_seguridad as gs on gs.cve_grupo_seguridad = ngs.cve_grupo_seguridad " +
                    "where gs.cve_grupo_seguridad in  " +
                    "(Select cve_grupo_seguridad from grupo_seguridad_usuario where cve_usuario = @cveUsuario) and " +
                    "n.cve_notificacion not in (Select cve_notificacion from detalle_notificacion_eliminada dne where dne.cve_usuario = @cveUsuario)";
                cmd.Parameters.AddWithValue("@cveUsuario", cveUsuario);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                lstnotificaciones = new List<Notificaciones>();
                while (reader.Read())
                {
                    var notificacion = new Notificaciones()
                    {
                        cve_notificacion = int.Parse(reader["cve_notificacion"].ToString()),
                        cve_tipo_notificacion = Convert.ToInt32(reader["cve_tipo_notificacion"].ToString()),
                        texto = reader["texto"].ToString(),
                        responsable = reader["responsable"].ToString(),
                        cve_categoria = reader["cve_categoria"].ToString(),
                        titulo = reader["titulo"].ToString(),
                        url = reader["url"].ToString(),
                        fecha_notificacion = reader["fecha_notificacion"].ToString(),
                        hora_notificacion = reader["hora_notificacion"].ToString()
                    };
                    lstnotificaciones.Add(ConsultarNotificacionesLeidas(notificacion));
                }
                return lstnotificaciones;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta de notificaciones: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<int> ConsultarNotificacionesEliminadas(string cveUsuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select cve_notificacion from detalle_notificacion_eliminada where cve_usuario = @cveUsuario";
                cmd.Parameters.AddWithValue("@cveUsuario", cveUsuario);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                var lstnotificacioneseliminadas = new List<int>();
                while (reader.Read())
                {

                    lstnotificacioneseliminadas.Add(Convert.ToInt32(reader["cve_notificacion"].ToString()));
                }
                return lstnotificacioneseliminadas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Notificaciones ConsultarNotificacionesLeidas(Notificaciones notificacion)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM bd_applikt.detalle_notificacion_leida where cve_notificacion = @cve_notificacion";
                cmd.Parameters.AddWithValue("@cve_notificacion", notificacion.cve_notificacion);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                var lstnotificacioneseliminadas = new List<int>();
                if (reader.Read())
                {
                    notificacion.estatus = "Leida";
                }
                else
                {
                    notificacion.estatus = "No Leida";
                }
                return notificacion;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool EliminarNotificacion(string cveUsuario, string cveNotificacion)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Insert into detalle_notificacion_eliminada (cve_usuario, cve_notificacion) values (@cveUsuario , @cveNotificacion)";
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

        public bool CambiarEstatusNotificacion(string cveUsuario, string cveNotificacion)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Insert into detalle_notificacion_ (cve_usuario, cve_notificacion) values (@cveUsuario , @cveNotificacion)";
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