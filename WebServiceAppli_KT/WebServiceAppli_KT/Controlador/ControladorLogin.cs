using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador
{
    public class ControladorLogin
    {
        LoginDAO loginDAO;
        public ControladorLogin()
        {
            loginDAO = new LoginDAO(); 

        }

        public bool ValidarUsuario(string usuario)
        {
            try
            {
                loginDAO.ValidarUsuario(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ValidarContrasenia(string contrasenia)
        {
            try
            {
                loginDAO.ValidarContrasenia(contrasenia);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       // public bool CrearCuenta(string usuario, string contrasenia)
        public bool CrearCuenta(Persona persona)
        {
            try
            {
               // if (loginDAO.CrearCuenta(usuario, contrasenia))
                if (loginDAO.CrearCuenta(persona))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}