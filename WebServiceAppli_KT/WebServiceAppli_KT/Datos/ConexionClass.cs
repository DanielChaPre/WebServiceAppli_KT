using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebServiceAppli_KT.Datos
{
    public class ConexionClass
    {
        private MySqlConnectionStringBuilder builder;

        public MySqlConnectionStringBuilder Builder
        {
            get { return builder; }
            set { builder = value; }
        }

        public ConexionClass()
        {
            conexioBD();
        }
        public void conexioBD()
        {
            try
            {
                this.builder = new MySqlConnectionStringBuilder();
                builder.Server = "localhost";
                builder.UserID = "root";
                builder.Password = "";
                builder.Database = "appli-kt";
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la conexion a la base de datos: " + ex.Message);
            }
            
        }
        
    }
}