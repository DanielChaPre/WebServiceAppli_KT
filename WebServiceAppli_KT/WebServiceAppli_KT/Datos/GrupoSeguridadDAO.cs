using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class GrupoSeguridadDAO
    {
        ConexionAppliktDAO conexion = new ConexionAppliktDAO();
        MySqlConnection con;
        List<string> lstgruposeguridad;


        public List<string> ObtenerGrupos()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select nombre From grupo_seguridad";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lstgruposeguridad = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        lstgruposeguridad[i] = reader["nombre"].ToString();
                    }
                }

                return lstgruposeguridad;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}