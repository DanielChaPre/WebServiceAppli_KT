using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class HistorialDAO
    {
        ConexionAppliktDAO conexion = new ConexionAppliktDAO();
        MySqlConnection con;
        Historial ent_historial;
        List<Historial> lstHistorial;

        public List<Historial> ConsultarHistorial(string cveUsuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "  Select * from historial where cve_usuario = @cveUsuario";
                cmd.Parameters.AddWithValue("@cveUsuario", cveUsuario);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                lstHistorial = new List<Historial>();
                while (reader.Read())
                {

                    lstHistorial.Add(new Historial()
                    {
                        cve_categoria = Convert.ToInt32(reader["cve_categoria"].ToString()),
                        cve_historial = Convert.ToInt32(reader["cve_historial"].ToString()),
                        cve_usuario = Convert.ToInt32(reader["cve_usuario"].ToString()),
                        descripcion = reader["descripcion"].ToString(),
                        url = reader["url"].ToString()
                    });
                }
                return lstHistorial;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}