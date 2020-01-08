using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class ColoniasDAO
    {
        ConexionSuredsuDAO conexion = new ConexionSuredsuDAO();
        MySqlConnection con;
        List<Colonias> lst_colonias;

        public List<Colonias> ConsultarColonia(string cp)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from colonias where CP = @cp";
                cmd.Parameters.AddWithValue("@cp", cp);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                lst_colonias = new List<Colonias>();
                while (reader.Read())
                {
                  
                    lst_colonias.Add(new Colonias()
                    {
                        idColonia = Convert.ToInt32(reader["idColonia"].ToString()),
                        NombreColonia = reader["NombreColonia"].ToString(),
                        CP = reader["CP"].ToString(),
                        idMunicipio = Convert.ToInt32(reader["idColonia"].ToString())
                     });
                }
                return lst_colonias;
            }
            catch (MySqlException ex)
            {
                return null;
            }
        }

        public int BuscarColonia(string colonia)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select idColonia from colonias NombreColonia = @colonia";
                cmd.Parameters.AddWithValue("@colonia", colonia);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                int idColonia = 0;
                while (reader.Read())
                {
                    idColonia = Convert.ToInt32(reader["idColonia"].ToString());
                }
                return idColonia;
            }
            catch (MySqlException ex)
            {
                return 0;
            }
        }
    }
}