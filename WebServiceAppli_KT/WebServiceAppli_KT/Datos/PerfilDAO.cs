using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceAppli_KT.Datos
{
    public class PerfilDAO
    {
        ConexionClass conexion = new ConexionClass();
        MySqlConnection con;

        public void GuardarPerfilPersona()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
            }
            catch (MySqlException)
            {


            }
            finally
            {

            }
        }

        public void GuardarPerfilAlumno()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
            }
            catch (MySqlException)
            {

            }
            finally
            {

            }
        }

        public void ModificarPerfil()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
            }
            catch (MySqlException)
            {


            }
            finally
            {

            }
        }

        public void ConsultarPerfil()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
            }
            catch (MySqlException)
            {


            }
            finally
            {

            }
        }

        public void EliminarPerfil()
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();
            }
            catch (MySqlException)
            {


            }
            finally
            {

            }
        }
    }
}