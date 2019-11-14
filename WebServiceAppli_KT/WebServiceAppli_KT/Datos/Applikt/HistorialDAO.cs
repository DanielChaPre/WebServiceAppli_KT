using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class HistorialDAO
    {
        ConexionAppliktDAO conexion = new ConexionAppliktDAO();
        MySqlConnection con;
        Historial ent_historial;

        public void ConsultarHistorial()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}