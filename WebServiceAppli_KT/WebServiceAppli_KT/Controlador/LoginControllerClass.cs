using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador
{
    public class LoginControllerClass
    {
        LoginDAOClass loginDAO;
        public LoginControllerClass()
        {
            loginDAO = new LoginDAOClass(); 

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
        public bool CrearCuenta(UsuarioClass usuario)
        {
            try
            {
               // if (loginDAO.CrearCuenta(usuario, contrasenia))
                if (loginDAO.CrearCuenta(usuario))
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