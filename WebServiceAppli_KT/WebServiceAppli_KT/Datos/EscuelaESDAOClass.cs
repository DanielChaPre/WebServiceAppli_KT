using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class EscuelaESDAOClass
    {
        ConexionClass conexion = new ConexionClass();
        MySqlConnection con;
        List<PlantelesESClass> lstPlanteles;

        public List<PlantelesESClass> obtenerPlnateles()
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
                    lstPlanteles = new List<PlantelesESClass>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        lstPlanteles[i].idPlantelesES = Convert.ToInt16(reader["idPlantelesEs"].ToString());
                        lstPlanteles[i].clavePlantel = reader["ClavePlantel"].ToString();
                        lstPlanteles[i].nombrePlantelES= reader["NombrePlantel"].ToString();
                        lstPlanteles[i].subsistema= reader["Subsistema"].ToString();
                        lstPlanteles[i].sostenimiento= reader["Sostenimiento"].ToString();
                        lstPlanteles[i].municipio= reader["NombreMunicipio"].ToString();
                        lstPlanteles[i].activo= Convert.ToInt32( reader["Activo"].ToString());
                        lstPlanteles[i].claveInstitucion= reader["ClaveInstitucion"].ToString();
                        lstPlanteles[i].nombreInstitucionEs= reader["NombreInstitucionEs"].ToString();
                        lstPlanteles[i].OPD= reader["OPD"].ToString();
                        lstPlanteles[i].nivelAgrupado= reader["NivelAgrupado"].ToString();
                        lstPlanteles[i].detallePlantel.cveDetallePlantel=Convert.ToInt32( reader["cve_detalle_plantel"].ToString());
                        lstPlanteles[i].detallePlantel.urlVinculacion= reader["url_vinculacion"].ToString();
                        lstPlanteles[i].detallePlantel.imagenPlantel= reader["imiagen_plantel"].ToString();
                        lstPlanteles[i].detallePlantel.logoPlantel= reader["logo_plantel"].ToString();
                        lstPlanteles[i].detallePlantel.costos= reader["costos"].ToString();
                        lstPlanteles[i].detallePlantel.requisitos= reader["requisitos"].ToString();
                        lstPlanteles[i].detallePlantel.fechas= Convert.ToDateTime(reader["fechas"].ToString());
                        lstPlanteles[i].detallePlantel.reseña= reader["reseña"].ToString();
                        lstPlanteles[i].detallePlantel.ubicacion= reader["ubicacion"].ToString();
                        lstPlanteles[i].detallePlantel.latitud= reader["latitud"].ToString();
                        lstPlanteles[i].detallePlantel.longitud= reader["longitud"].ToString();
                        lstPlanteles[i].detallePlantel.nivelEstudio= reader["nivel_estudio"].ToString();
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