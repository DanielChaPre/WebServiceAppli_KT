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
                lst_municipios = new List<Municipios>();
                while (reader.Read())
                {
                    
                    lst_municipios.Add(new Municipios()
                    {
                        idMunicipio = Convert.ToInt32(reader["idMunicipio"].ToString()),
                        NombreMunicipio = reader["NombreMunicipio"].ToString(),
                        idEstado = Convert.ToInt32(reader["idEstado"].ToString()),
                    });
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