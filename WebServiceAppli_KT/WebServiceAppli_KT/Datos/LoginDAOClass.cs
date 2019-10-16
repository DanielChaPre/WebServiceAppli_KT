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
        
        public bool iniciarSesion(UsuarioClass entUsuario)
        {
            try
            {
                var conn = conexion.Builder;
                MySqlConnection con = new MySqlConnection(conn.ToString());
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
        }
    }
}