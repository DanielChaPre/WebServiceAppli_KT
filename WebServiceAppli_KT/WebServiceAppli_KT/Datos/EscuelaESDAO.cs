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
        ConexionAppliktDAO conexion = new ConexionAppliktDAO();
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
                        lstPlanteles[i].idPlantelesES = Convert.ToInt16(reader["idPlantelesEs"].ToString());
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
                        lstPlanteles[i].detalle_plantel.cve_detalle_plantel=Convert.ToInt32( reader["cve_detalle_plantel"].ToString());
                        lstPlanteles[i].detalle_plantel.url_vinculacion= reader["url_vinculacion"].ToString();
                        lstPlanteles[i].detalle_plantel.imiagen_plantel= reader["imiagen_plantel"].ToString();
                        lstPlanteles[i].detalle_plantel.logo_plantel= reader["logo_plantel"].ToString();
                        lstPlanteles[i].detalle_plantel.costos= reader["costos"].ToString();
                        lstPlanteles[i].detalle_plantel.requisitos= reader["requisitos"].ToString();
                        lstPlanteles[i].detalle_plantel.fechas= Convert.ToDateTime(reader["fechas"].ToString());
                        lstPlanteles[i].detalle_plantel.reseña= reader["reseña"].ToString();
                        lstPlanteles[i].detalle_plantel.ubicacion= reader["ubicacion"].ToString();
                        lstPlanteles[i].detalle_plantel.latitud= reader["latitud"].ToString();
                        lstPlanteles[i].detalle_plantel.longitud= reader["longitud"].ToString();
                        lstPlanteles[i].detalle_plantel.nivel_estudio= reader["nivel_estudio"].ToString();
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