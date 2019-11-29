using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class CarrerasDAO
    {
        ConexionSuredsuDAO conexion = new ConexionSuredsuDAO();
        MySqlConnection con;
        List<CarrerasES> lstCarreras;

        public List<CarrerasES> ObtenerCarreras()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from vistaCarreras";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                lstCarreras = new List<CarrerasES>();
                while (reader.Read())
                {
                   
                    lstCarreras.Add(new CarrerasES()
                    {
                            idCarreraES = Convert.ToInt32(reader["idCarreraEs"].ToString()),
                            NombreCarreraES = reader["NombreCarreraES"].ToString(),
                            Activa = Convert.ToInt16(reader["Activa"].ToString()),
                            ClaveCarrera = reader["ClaveCarrera"].ToString(),
                            CampoAmplio2016 = reader["CampoAmplio2016"].ToString(),
                            CampoAmplioAnterior = reader["CampoAmplioAnterior"].ToString(),
                            Nivel = reader["Nivel"].ToString(),
                            CampoEspecifico2016 = reader["CampoEspecífico2016"].ToString(),
                            CampoEspecificoAnterior = reader["CampoEspecificoAnterior"].ToString(),
                            IdPlantelesES = Convert.ToInt16(reader["idPlantelES"].ToString())
                    });
                }
               
                return lstCarreras;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la consulta: " + ex.Message);
                return null;
                throw;
            }
            finally
            {
                con.Close();
            }
        }

    }
}