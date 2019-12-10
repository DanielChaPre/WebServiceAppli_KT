﻿using MySql.Data.MySqlClient;
using System;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Datos
{
    public class LoginDAO
    {
        ConexionAppliktDAO conexion = new ConexionAppliktDAO();
        MySqlConnection con;


        public bool ValidarUsuario(string usuario)
        {
            try
            {
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From usuario where usuario = @user";
                cmd.Parameters.AddWithValue("@user", usuario);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return true;
                else
                    return false;
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
                cmd.CommandText = "Select * From usuario where contrasena = @pass";
                cmd.Parameters.AddWithValue("@pass", contrasenia);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return true;
                else
                    return false;
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
        public bool CrearCuenta(Persona persona)
        {
            try
            {
                
                var conn = conexion.Builder;
                con = new MySqlConnection(conn.ToString());
                MySqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "Insert into usuario(cve_usuario,nombre_usuario,contraseña,fecha_registro,estatus,rol,cve_personas) " +
                    "values(@cve_usuario , @user, @password, '', '', '', 0); ";
                cmd.Parameters.AddWithValue("@cve_usuario", persona.usuario.cve_usuario);
                cmd.Parameters.AddWithValue("@user", persona.usuario.alias_red);
                cmd.Parameters.AddWithValue("@password", persona.usuario.contrasena);
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