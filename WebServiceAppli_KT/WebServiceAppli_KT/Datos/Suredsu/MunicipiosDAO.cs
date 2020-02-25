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
        Municipios municipios;


        public List<Municipios> ObtenerTodosMunicipios()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
               // cmd.CommandText = "Select * from municipios where idEstado = 11";
                cmd.CommandText = "Select * from municipios";
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

        public List<Municipios> ObtenerMunicipios(string estado)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from municipios where idEstado = (Select idEstado from estados where NombreEstado = @estado)";
                cmd.Parameters.AddWithValue("@estado", estado);
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

        public int BuscarMunicipio(string municipio)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select idMunicipio from municipios where NombreMunicipio = @municipio";
                cmd.Parameters.AddWithValue("@municipio", municipio);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                int idMunicipio=0;
                while (reader.Read())
                {
                    idMunicipio = Convert.ToInt32(reader["idMunicipio"].ToString());
                }

                return idMunicipio;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}