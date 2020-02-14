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
                return loginDAO.ValidarUsuario(usuario);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ValidarUsuarioAlumno(string idAlumno)
        {
            return loginDAO.ValidarUsuarioAlumno(idAlumno);
        }

        public List<string> ValidarContrasenia(string contrasenia, string usuario, string idAlumno)
        {
            try
            {
                return loginDAO.ValidarContrasenia(contrasenia, usuario, idAlumno);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<string> ValidarContrasenaAlumno(string contrasenia, string usuario, string idAlumno)
        {
            try
            {
                return loginDAO.ValidarContrasenaAlumno(contrasenia, usuario, idAlumno);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CrearCuenta(string usuario, string contrasena, string idAlumno, string tipoUsuario)
        {
            try
            {
                if (loginDAO.CrearCuenta(usuario, contrasena, idAlumno, tipoUsuario))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RecuperarContrasena(string usuario, string nuevaContrasena)
        {
            return loginDAO.RecuperarContraseña(usuario, nuevaContrasena);
        }

        public bool VerificarRegistroAlumno(string contrasen, string idAlumno)
        {
            loginDAO = new LoginDAO();
            return loginDAO.VerificarRegistroAlumno(contrasen, idAlumno);
        }

        public Usuario ConsultarUsuarioAlumno(string idAlumno)
        {
            loginDAO = new LoginDAO();
            return loginDAO.ConsultarUsuarioAlumno(idAlumno);
        }
    }
}