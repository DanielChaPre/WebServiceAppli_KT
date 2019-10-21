using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class LoginDAOClass
    {
        ConexionClass conexion = new ConexionClass();
        MySqlConnection con;


        public bool iniciarSesion(UsuarioClass entUsuario)
        {
            try
            { 
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
               
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From usuario where nombre_usuario = @user and contraseña = @pass";
                cmd.Parameters.AddWithValue("@user",entUsuario.nombreUsuario );
                cmd.Parameters.AddWithValue("@pass",entUsuario.contrasenia);
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

        public bool CrearCuenta(UsuarioClass usuario)
        {
            try
            {
                
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "Insert	into usuario(cve_usuario,nombre_usuario,contraseña,fecha_registro,estatus,rol,cve_persona) " +
                    "values(5 , @user, @password, '', '', '', 0); ";
                cmd.Parameters.AddWithValue("@user", usuario.nombreUsuario);
                cmd.Parameters.AddWithValue("@password", usuario.contrasenia);
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