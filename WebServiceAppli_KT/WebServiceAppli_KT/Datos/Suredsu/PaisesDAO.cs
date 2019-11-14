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
                if (reader.Read())
                {
                    lst_paises = new List<Paises>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        lst_paises[i].IdPais = Convert.ToInt32(reader["IdPais"].ToString());
                        lst_paises[i].NombrePais = reader["NombrePais"].ToString();
                    }
                }
                return lst_paises;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

    }
}