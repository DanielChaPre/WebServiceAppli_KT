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

        public string ValidarUsuario(string usuario)
        {
            try
            {
                return loginDAO.ValidarUsuario(usuario);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string ValidarUsuarioAlumno(string idAlumno)
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

        public List<string> ValidarUsuarioFacebook(string aliasred)
        {
            loginDAO = new LoginDAO();
            return loginDAO.ValidarUsuarioFacebook(aliasred);
        }

        public List<string> ValidarUsuarioGoogle(string aliasred)
        {
            loginDAO = new LoginDAO();
            return loginDAO.ValidarUsuarioGoogle(aliasred);
        }

        public List<string> RelacionarFacebookUsuario(string aliasred, string usuario, string contrasena)
        {
            loginDAO = new LoginDAO();
            return loginDAO.RelacionarFacebookUsuario(aliasred, usuario, contrasena);
        }

        public List<string> RelacionarGoogleUsuario(string aliasred, string usuario, string contrasena)
        {
            loginDAO = new LoginDAO();
            return loginDAO.RelacionarGoogleUsuario(aliasred, usuario, contrasena);
        }

        public List<string> RelacionarFacebookAlumno(string aliasred, string curp, string contrasena)
        {
            loginDAO = new LoginDAO();
            return loginDAO.RelacionarFacebookAlumno(aliasred, curp, contrasena);
        }

        public List<string> RelacionarGoogleAlumno(string aliasred, string curp, string contrasena)
        {
            loginDAO = new LoginDAO();
            return loginDAO.RelacionarGoogleAlumno(aliasred, curp, contrasena);
        }
    }
}