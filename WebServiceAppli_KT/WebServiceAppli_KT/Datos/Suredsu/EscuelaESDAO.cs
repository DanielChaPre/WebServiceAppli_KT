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
        ConexionAppliktDAO conexionApplikt = new ConexionAppliktDAO();
        MySqlConnection con;
        List<DetallePlantel> lstDetallePlantel;
        PlantelesES planteles;
        PlantelesEMS plantelems;
        DetallePlantel detallePlantel;

        public List<DetallePlantel> ObtenerPlnateles()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "Select * from bd_applikt.detalle_plantel" +
                    " inner join suredsu.planteleses " +
                    " on suredsu.planteleses.idPlantelES = bd_applikt.detalle_plantel.idPlantelesES";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                lstDetallePlantel = new List<DetallePlantel>();
                while (reader.Read())
                {

                    lstDetallePlantel.Add(new DetallePlantel()
                    {
                        cve_detalle_plantel = Convert.ToInt32(reader["cve_detalle_plantel"].ToString()),
                        url_vinculacion = reader["url_vinculacion"].ToString(),
                        logo_plantel = reader["logo_plantel"].ToString(),
                        costos = reader["costos"].ToString(),
                        requisitos = reader["requisitos"].ToString(),
                        fechas = reader["fechas"].ToString(),
                        reseña = reader["reseña"].ToString(),
                        latitud = reader["latitud"].ToString(),
                        longitud = reader["longitud"].ToString(),
                        ubicacion = reader["ubicacion"].ToString(),
                        nivel_estudio = reader["nivel_estudio"].ToString(),
                        cve_nivel_agrupado = Convert.ToInt32(reader["cve_nivel_agrupado"].ToString()),
                        cve_nivel_estudio = Convert.ToInt32(reader["cve_nivel_estudio"].ToString()),
                        PlantelesES = new PlantelesES()
                        {
                            idPlantelES = Convert.ToInt32(reader["idPlantelES"].ToString()),
                            ClavePlantel = reader["ClavePlantel"].ToString(),
                            NombrePlantelES = reader["NombrePlantelES"].ToString(),
                            Subsistema = reader["Subsistema"].ToString(),
                            Sostenimiento = reader["Sostenimiento"].ToString(),
                            Municipio = Convert.ToInt32(reader["idMunicipio"].ToString()),
                            Activo = reader["Activo"].ToString(),
                            ClaveInstitucion = reader["ClaveInstitucion"].ToString(),
                            NombreInstitucionES = reader["NombreInstitucionES"].ToString(),
                            OPD = reader["OPD"].ToString(),
                            NivelAgrupado = reader["NivelAgrupado"].ToString(),
                        }
                    });
                }

                return lstDetallePlantel;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public PlantelesES BuscarPlantelMunicipio(int idMunicipio)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "select * from planteleses where idMunicipio = @idMunicipio";
                cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    planteles = new PlantelesES()
                    {
                        idPlantelES = Convert.ToInt16(reader["idPlantelEs"].ToString()),
                        ClavePlantel = reader["ClavePlantel"].ToString(),
                        NombrePlantelES = reader["NombrePlantelES"].ToString(),
                        Subsistema = reader["Subsistema"].ToString(),
                        Sostenimiento = reader["Sostenimiento"].ToString(),
                        Municipio = Convert.ToInt32(reader["idMunicipio"].ToString()),
                        Activo = reader["Activo"].ToString(),
                        ClaveInstitucion = reader["ClaveInstitucion"].ToString(),
                        NombreInstitucionES = reader["NombreInstitucionEs"].ToString(),
                        OPD = reader["OPD"].ToString(),
                        NivelAgrupado = reader["NivelAgrupado"].ToString()
                    };
                }
                return planteles;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public PlantelesES BuscarPlantelId(int idPlanteles)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "select * from planteleses where idPlantelES = @idPlanteles";
                cmd.Parameters.AddWithValue("@idPlanteles", idPlanteles);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    planteles = new PlantelesES()
                    {
                        idPlantelES = Convert.ToInt16(reader["idPlantelEs"].ToString()),
                        ClavePlantel = reader["ClavePlantel"].ToString(),
                        NombrePlantelES = reader["NombrePlantelES"].ToString(),
                        Subsistema = reader["Subsistema"].ToString(),
                        Sostenimiento = reader["Sostenimiento"].ToString(),
                        Municipio = Convert.ToInt32(reader["idMunicipio"].ToString()),
                        Activo = reader["Activo"].ToString(),
                        ClaveInstitucion = reader["ClaveInstitucion"].ToString(),
                        NombreInstitucionES = reader["NombreInstitucionEs"].ToString(),
                        OPD = reader["OPD"].ToString(),
                        NivelAgrupado = reader["NivelAgrupado"].ToString()
                    };
                }
                return planteles;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public PlantelesES BuscarPlantel(string plantel)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "select * from planteleses where NombrePlantelES = @plantel";
                cmd.Parameters.AddWithValue("@plantel", plantel);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    planteles = new PlantelesES()
                    {
                        idPlantelES = Convert.ToInt16(reader["idPlantelEs"].ToString()),
                        ClavePlantel = reader["ClavePlantel"].ToString(),
                        NombrePlantelES = reader["NombrePlantelES"].ToString(),
                        Subsistema = reader["Subsistema"].ToString(),
                        Sostenimiento = reader["Sostenimiento"].ToString(),
                        Municipio = Convert.ToInt32(reader["idMunicipio"].ToString()),
                        Activo = reader["Activo"].ToString(),
                        ClaveInstitucion = reader["ClaveInstitucion"].ToString(),
                        NombreInstitucionES = reader["NombreInstitucionEs"].ToString(),
                        OPD = reader["OPD"].ToString(),
                        NivelAgrupado = reader["NivelAgrupado"].ToString()
                    };
                }
                return planteles;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public PlantelesEMS BuscarPlantelIDPlantelEMS(int idplantel)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "Select  * from plantelesems where idPlantelEMS = @idPlantel";
                cmd.Parameters.AddWithValue("@idPlantel", idplantel);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    plantelems = new PlantelesEMS();
                    plantelems.idPlantelesEMS = Convert.ToInt32(reader["idPlantelEMS"].ToString());
                    plantelems.ClavePlantel = reader["ClavePlantel"].ToString();
                    plantelems.NombrePlantelEMS = reader["NombrePlantelEMS"].ToString();
                    plantelems.Subsistema = reader["Subsistema"].ToString();
                    plantelems.Sostenimiento = reader["Sostenimiento"].ToString();
                    plantelems.Control = reader["Control"].ToString();
                    plantelems.subcontrol = reader["subcontrol"].ToString();
                    plantelems.idMunicipio = Convert.ToInt32(reader["idMunicipio"].ToString());
                    plantelems.Activo = Convert.ToBoolean(reader["Activo"].ToString());
                    plantelems.subsistemaSices = reader["subsistemaSices"].ToString();
                    plantelems.Turno = reader["Turno"].ToString();
                }
                return plantelems;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public DetallePlantel BuscarDetallePlantel(string idPlantel)
        {
            try
            {
                var conn = conexionApplikt.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulta en vista
                cmd.CommandText = "Select * from detalle_plantel where idPlantelesES = @idPlantel";
                cmd.Parameters.AddWithValue("@idPlantel", idPlantel);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    detallePlantel = new DetallePlantel()
                    {
                        costos = reader["costos"].ToString(),
                        cve_detalle_plantel = Convert.ToInt32(reader["cve_detalle_plantel"].ToString()),
                        fechas = reader["fechas"].ToString(),
                        //idPlantelesES = Convert.ToInt32(reader["idPlantelesES"].ToString()),
                        logo_plantel = reader["logo_plantel"].ToString(),
                        nivel_estudio = reader["nivel_estudio"].ToString(),
                        requisitos = reader["requisitos"].ToString(),
                        reseña = reader["reseña"].ToString(),
                        ubicacion = reader["ubicacion"].ToString(),
                        url_vinculacion = reader["url_vinculacion"].ToString(),
                        latitud = reader["latitud"].ToString(),
                        longitud = reader["longitud"].ToString()
                    };
                }
                return detallePlantel;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la consulta escuela: " + ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}