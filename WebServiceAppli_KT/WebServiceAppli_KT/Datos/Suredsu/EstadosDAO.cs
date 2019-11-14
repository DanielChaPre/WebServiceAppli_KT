using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class EstadosDAO
    {
        ConexionSuredsuDAO conexion = new ConexionSuredsuDAO();
        MySqlConnection con;
        List<Estados> lst_estados;

        public List<Estados> ConsultarEstados()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from estados";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lst_estados = new List<Estados>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        lst_estados[i].IdEstado = Convert.ToInt32(reader["IdEstado"].ToString());
                        lst_estados[i].NombreEstado = reader["NombreEstado"].ToString();
                        lst_estados[i].idPais = Convert.ToInt32(reader["idPais"].ToString());
                    }
                }
                return lst_estados;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}