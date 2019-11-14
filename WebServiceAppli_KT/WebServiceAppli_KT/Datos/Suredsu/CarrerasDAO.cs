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
                if (reader.Read())
                {
                    lstCarreras = new List<CarrerasES>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        lstCarreras[i].idCarreraES = Convert.ToInt32(reader["idCarreraEs"].ToString());
                        lstCarreras[i].NombreCarreraES = reader["NombreCarreraES"].ToString();
                        lstCarreras[i].Activa = Convert.ToInt16(reader["Activa"].ToString());
                        lstCarreras[i].ClaveCarrera = reader["ClaveCarrera"].ToString();
                        lstCarreras[i].CampoAmplio2016 = reader["CampoAmplio2016"].ToString();
                        lstCarreras[i].CampoAmplioAnterior = reader["CampoAmplioAnterior"].ToString();
                        lstCarreras[i].Nivel = reader["Nivel"].ToString();
                        lstCarreras[i].CampoEspecifico2016 = reader["CampoEspecífico2016"].ToString();
                        lstCarreras[i].CampoEspecificoAnterior = reader["CampoEspecificoAnterior"].ToString();
                        lstCarreras[i].PlantelES.idPlantelesES = Convert.ToInt16(reader["idPlantelesES"].ToString());
                    }
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