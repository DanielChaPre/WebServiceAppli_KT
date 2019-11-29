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
                lstPlanteles = new List<PlantelesES>();
                while (reader.Read())
                {
                  
                    lstPlanteles.Add(new PlantelesES()
                    {
                        idPlantelES = Convert.ToInt16(reader["idPlantelEs"].ToString()),
                        ClavePlantel = reader["ClavePlantel"].ToString(),
                        NombrePlantelES = reader["NombrePlantelES"].ToString(),
                        Subsistema = reader["Subsistema"].ToString(),
                        Sostenimiento = reader["Sostenimiento"].ToString(),
                        Municipio = reader["NombreMunicipio"].ToString(),
                        Activo = Convert.ToInt32(reader["Activo"].ToString()),
                        ClaveInstitucion = reader["ClaveInstitucion"].ToString(),
                        NombreInstitucionES = reader["NombreInstitucionEs"].ToString(),
                        OPD = reader["OPD"].ToString(),
                        NivelAgrupado = reader["NivelAgrupado"].ToString()
                     });
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