using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class PaisesDAO
    {
        ConexionSuredsuDAO conexion = new ConexionSuredsuDAO();
        MySqlConnection con;
        List<Paises> lst_paises;
        public List<Paises> ObtenerPaises()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from paises";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                lst_paises = new List<Paises>();
                while (reader.Read())
                {
                    lst_paises.Add(new Paises()
                    {
                        IdPais = Convert.ToInt32(reader["IdPais"].ToString()),
                        NombrePais = reader["NombrePais"].ToString()
                });
                }
                return lst_paises;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:"+ ex.Message);
                return null;
                throw;
            }
        }
    }
}