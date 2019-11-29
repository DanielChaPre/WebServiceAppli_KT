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

        public List<Colonias> ConsultarColonia()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from colonias";
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
            catch (Exception)
            {
                return null;
            }
        }

    }
}