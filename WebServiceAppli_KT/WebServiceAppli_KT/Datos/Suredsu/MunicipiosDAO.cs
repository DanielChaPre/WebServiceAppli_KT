using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class MunicipiosDAO
    {
        ConexionSuredsuDAO conexion = new ConexionSuredsuDAO();
        MySqlConnection con;
        List<Municipios> lst_municipios;

        public List<Municipios> ObtenerMunicipios()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from municipios";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lst_municipios = new List<Municipios>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        lst_municipios[i].idMunicipio  = Convert.ToInt32(reader["idMunicipio"].ToString());
                        lst_municipios[i].NombreMunicipio = reader["NombreMunicipio"].ToString();
                        lst_municipios[i].idEstado = Convert.ToInt32(reader["idEstado"].ToString());
                    }
                }
                return lst_municipios;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}