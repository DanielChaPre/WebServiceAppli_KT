using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class LoginDAO
    {
        ConexionDAO conexion = new ConexionDAO();
        MySqlConnection con;


        public bool ValidarUsuario(string usuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From usuario where nombre_usuario = @user";
                cmd.Parameters.AddWithValue("@user", usuario);
                con.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en el logeo, " + ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ValidarContrasenia(string contrasenia)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From usuario where contraseña = @pass";
                cmd.Parameters.AddWithValue("@pass", contrasenia);
                con.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en el logeo, " + ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

       // public bool CrearCuenta(string usuario, string contrasenia)
        public bool CrearCuenta(Usuario usuario)
        {
            try
            {
                
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "Insert into usuario(cve_usuario,nombre_usuario,contraseña,fecha_registro,estatus,rol,cve_personas) " +
                    "values(@cve_usuario , @user, @password, '', '', '', 0); ";
                cmd.Parameters.AddWithValue("@cve_usuario", usuario.cve_usuario);
                cmd.Parameters.AddWithValue("@user", usuario.nombre_usuario);
                cmd.Parameters.AddWithValue("@password", usuario.contraseña);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la creación de la base de datos, " + ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}