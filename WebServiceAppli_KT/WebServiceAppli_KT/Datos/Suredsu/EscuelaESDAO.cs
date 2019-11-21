using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class EscuelaESDAO
    {
        ConexionSuredsuDAO conexion = new ConexionSuredsuDAO();
        MySqlConnection con;
        List<PlantelesES> lstPlanteles;

        public List<PlantelesES> ObtenerPlnateles()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "select * from vistaPlanteles";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lstPlanteles = new List<PlantelesES>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        lstPlanteles[i].idPlantelES = Convert.ToInt16(reader["idPlantelEs"].ToString());
                        lstPlanteles[i].ClavePlantel = reader["ClavePlantel"].ToString();
                        lstPlanteles[i].NombrePlantelES= reader["NombrePlantelES"].ToString();
                        lstPlanteles[i].Subsistema= reader["Subsistema"].ToString();
                        lstPlanteles[i].Sostenimiento= reader["Sostenimiento"].ToString();
                        lstPlanteles[i].Municipio= reader["NombreMunicipio"].ToString();
                        lstPlanteles[i].Activo= Convert.ToInt32( reader["Activo"].ToString());
                        lstPlanteles[i].ClaveInstitucion= reader["ClaveInstitucion"].ToString();
                        lstPlanteles[i].NombreInstitucionES= reader["NombreInstitucionEs"].ToString();
                        lstPlanteles[i].OPD= reader["OPD"].ToString();
                        lstPlanteles[i].NivelAgrupado= reader["NivelAgrupado"].ToString();
                    }
                }

                return lstPlanteles;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la consulta escuela: "+ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

    }
}