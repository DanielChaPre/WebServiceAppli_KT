﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace WebServiceAppli_KT.Datos
{
    public class ConexionSuredsuDAO
    {
        private MySqlConnectionStringBuilder builder;

        public MySqlConnectionStringBuilder Builder
        {
            get { return builder; }
            set { builder = value; }
        }

        public ConexionSuredsuDAO()
        {
            ConexioBDSuredsu();
        }

        public void ConexioBDSuredsu()
        {
            try
            {
                this.builder = new MySqlConnectionStringBuilder();
                //this.builder.Server = "10.16.42.59";
                this.builder.Server = "s-applikt.utleon.edu.mx";
                ///this.builder.UserID = "root";
                this.builder.UserID = "dev";
                this.builder.Password = "applikt19";
                ///this.builder.Database = "appli-kt";
                this.builder.Database = "suredsu";
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en la conexion a la base de datos: " + ex.Message);
            }
        }

    }
}