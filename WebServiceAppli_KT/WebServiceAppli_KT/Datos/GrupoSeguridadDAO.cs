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
        ConexionDAO conexion = new ConexionDAO();
        MySqlConnection con;
        List<GrupoSeguridad> lstgruposeguridad;

        public List<GrupoSeguridad> ObtenerGrupos()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From grupo_seguridad";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lstgruposeguridad = new List<GrupoSeguridad>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        lstgruposeguridad[i].descripcion = reader[""].ToString();
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