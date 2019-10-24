using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador
{
    public class PerfilController
    {
        PerfilDAO perfilDAO;
        public PerfilController()
        {
            perfilDAO = new PerfilDAO();
        }

        public bool CrearPerfil(UsuarioClass usuario)
        {
            try
            {
                perfilDAO.GuardarPerfilPersona(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool ModificarPerfil(UsuarioClass usuario)
        {
            try
            {
                perfilDAO.ModificarPerfil(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public  bool EliminarPerfil(int cveUsuario, int cvePersona)
        {
            try
            {
                perfilDAO.EliminarPerfil(cveUsuario, cvePersona);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public UsuarioClass ConsultarPerfil(string user, string pass)
        {
            try
            {
                UsuarioClass usuario = new UsuarioClass();
                usuario = perfilDAO.ConsultarPerfilUsuario(user, pass);
                return usuario;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}