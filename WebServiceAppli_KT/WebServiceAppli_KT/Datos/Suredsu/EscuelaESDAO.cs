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
        PlantelesES planteles;
        PlantelesEMS plantelems;

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
                        Municipio = reader["NombreMunicipio"].ToString(),
                        Activo = Convert.ToInt32(reader["Activo"].ToString()),
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
                        Municipio = reader["NombreMunicipio"].ToString(),
                        Activo = Convert.ToInt32(reader["Activo"].ToString()),
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
                        Municipio = reader["NombreMunicipio"].ToString(),
                        Activo = Convert.ToInt32(reader["Activo"].ToString()),
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

    }
}