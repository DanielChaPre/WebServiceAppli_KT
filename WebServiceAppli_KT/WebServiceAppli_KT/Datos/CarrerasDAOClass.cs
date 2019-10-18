using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class CarrerasDAOClass
    {
        ConexionClass conexion = new ConexionClass();
        MySqlConnection con;
        List<CarrerasESClass> lstCarreras;

        public List<CarrerasESClass> obtenerCarreras()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                //Queda pendiente la consulata para la realizacuion de la vista en mysql
                cmd.CommandText = "select * from vistaCarreras";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lstCarreras = new List<CarrerasESClass>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        lstCarreras[i].idCarreraES = Convert.ToInt32(reader["idCarreraEs"].ToString());
                        lstCarreras[i].nombreCarreraES = reader["NombreCarreraES"].ToString();
                        lstCarreras[i].activa= Convert.ToInt16(reader["Activa"].ToString());
                        lstCarreras[i].claveCarrera= reader["ClaveCarrera"].ToString();
                        lstCarreras[i].campoAmplio2016= reader["CampoAmplio2016"].ToString();
                        lstCarreras[i].campoAmplioAnterior= reader["CampoAmplioAnterior"].ToString();
                        lstCarreras[i].nivel= reader["Nivel"].ToString();
                        lstCarreras[i].campoEspecifico2016= reader["CampoEspecífico2016"].ToString();
                        lstCarreras[i].campoEspecificoAnterior= reader["CampoEspecificoAnterior"].ToString();
                        lstCarreras[i].plantelES.idPlantelesES= Convert.ToInt16(reader["idPlantelesES"].ToString());
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