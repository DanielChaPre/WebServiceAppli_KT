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

        public bool iniciarSesion(UsuarioClass entUsuario)
        {
            try
            {
                loginDAO.iniciarSesion(entUsuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CrearCuenta(UsuarioClass usuario)
        {
            try
            {
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