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
                if (reader.Read())
                {
                    lst_colonias = new List<Colonias>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        lst_colonias[i].idColonia = Convert.ToInt32(reader["idColonia"].ToString());
                        lst_colonias[i].NombreColonia = reader["NombreColonia"].ToString();
                        lst_colonias[i].CP = reader["CP"].ToString();
                        lst_colonias[i].idMunicipio = Convert.ToInt32(reader["idColonia"].ToString());
                    }
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