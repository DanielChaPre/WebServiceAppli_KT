using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos.Applikt
{
    public class HistorialBusquedaCarreraDAO
    {
        ConexionAppliktDAO conexion = new ConexionAppliktDAO();
        MySqlConnection con;

        public bool AgregarHistorialCarrera(string cve_usuario, string idCarreraEs)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO historial_busqueda_carrera(cve_usuario, idCarreraES) Values (@cveUsuario,@idCarrera)";
                cmd.Parameters.AddWithValue("@cveUsuario", cve_usuario);
                cmd.Parameters.AddWithValue("@idCarrera", idCarreraEs);
                con.Open();
                cmd.ExecuteReader();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AgregarHistorialVisita(string cve_usuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO historial_visitas_atlas(cve_usuario) Values (@cveUsuario)";
                cmd.Parameters.AddWithValue("@cveUsuario", cve_usuario);
                con.Open();
                cmd.ExecuteReader();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}