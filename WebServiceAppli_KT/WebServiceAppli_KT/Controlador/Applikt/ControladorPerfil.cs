using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceAppli_KT.Datos;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT.Controlador
{
    public class ControladorPerfil
    {
        PerfilDAO perfilDAO;

        #region Constructor
        public ControladorPerfil()
        {
            perfilDAO = new PerfilDAO();
        } 
        #endregion

        #region Usuario
        public bool CrearPerfill(Usuario usuario)
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

        public bool ModificarPerfill(Usuario usuario)
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

        public bool EliminarPerfill(Usuario usuario)
        {
            try
            {
                perfilDAO.EliminarPerfil(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Usuario ConsultarPerfill(string user, string pass)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario = perfilDAO.ConsultarPerfilUsuario(user, pass);
                return usuario;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion

        #region Empleado
        public bool CrearPerfilEmpleado(Usuario usuario)
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

        public bool ModificarPerfilEmpleado(Usuario usuario)
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

        public bool EliminarPerfilEmpleado(Usuario usuario)
        {
            try
            {
                perfilDAO.EliminarPerfil(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Usuario ConsultarPerfilEmpleado(string user, string pass)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario = perfilDAO.ConsultarPerfilUsuario(user, pass);
                return usuario;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion

        #region EmpleadoPlantel
        public bool CrearPerfilEmpleadoPlantel(Usuario usuario)
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

        public bool ModificarPerfilEmpleadoPlantel(Usuario usuario)
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

        public bool EliminarPerfilEmpleadoPlantel(Usuario usuario)
        {
            try
            {
                perfilDAO.EliminarPerfil(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Usuario ConsultarPerfilEmpleadoPlantel(string user, string pass)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario = perfilDAO.ConsultarPerfilUsuario(user, pass);
                return usuario;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion

        #region PadreFamilia
        public bool CrearPerfilPadreFamilia(Usuario usuario)
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

        public bool ModificarPerfilPadreFamilia(Usuario usuario)
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

        public bool EliminarPerfilPadreFamilia(Usuario usuario)
        {
            try
            {
                perfilDAO.EliminarPerfil(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Usuario ConsultarPerfilPadreFamilia(string user, string pass)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario = perfilDAO.ConsultarPerfilUsuario(user, pass);
                return usuario;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        } 
        #endregion
    }
}