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
        public List<int> CrearPerfill(Persona persona)
        {
            try
            {

                return perfilDAO.GuardarPerfilPersona(persona);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool ModificarPerfill(Persona persona)
        {
            try
            {
                perfilDAO.ModificarPerfil(persona);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool EliminarPerfill(Persona persona)
        {
            try
            {
                perfilDAO.EliminarPerfil(persona);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Persona ConsultarPerfill(int cve_usuario)
        {
            try
            {
                Persona usuario = new Persona();
                usuario = perfilDAO.ConsultarPerfilPersona(cve_usuario);
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
        public List<int> CrearPerfilEmpleado(Empleado empleado)
        {
            try
            {
                return perfilDAO.GuardarPerfilEmpleado(empleado);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool ModificarPerfilEmpleado(Empleado empleado)
        {
            try
            {
                perfilDAO.ModificarPerfilEmpleado(empleado);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool EliminarPerfilEmpleado(Empleado empleado)
        {
            try
            {
                perfilDAO.EliminarPerfilEmpleado(empleado);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Empleado ConsultarPerfilEmpleado(int cve_usuario, int cve_persona)
        {
            try
            {
                Empleado empleado = new Empleado();
                empleado = perfilDAO.ConsultarPerfilEmpleado(cve_usuario, cve_persona);
                return empleado;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion

        #region EmpleadoPlantel
        public List<int> CrearPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel)
        {
            try
            {
                return perfilDAO.GuardarPerfilEmpleadoPlantel(empleadoPlantel);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool ModificarPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel)
        {
            try
            {
                perfilDAO.ModificarPerfilEmpleadoPlantel(empleadoPlantel);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool EliminarPerfilEmpleadoPlantel(EmpleadoPlantel empleadoPlantel)
        {
            try
            {
                perfilDAO.EliminarPerfilEmpleadoPlantel(empleadoPlantel);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public EmpleadoPlantel ConsultarPerfilEmpleadoPlantel(int cve_usuario, int cve_persona)
        {
            try
            {
                EmpleadoPlantel empleadoPlantel = new EmpleadoPlantel();
                empleadoPlantel = perfilDAO.ConsultarPerfilEmpleadoPlantel(cve_usuario, cve_persona);
                return empleadoPlantel;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        #endregion

        #region PadreFamilia
        public List<int> CrearPerfilPadreFamilia(PadreFamilia padreFamilia)
        {
            try
            {
                return perfilDAO.GuardarPerfilPersonaPadreFamilia(padreFamilia);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool ModificarPerfilPadreFamilia(PadreFamilia padreFamilia)
        {
            try
            {
                perfilDAO.ModificarPerfilPadreFamilia(padreFamilia);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool EliminarPerfilPadreFamilia(PadreFamilia padreFamilia)
        {
            try
            {
                perfilDAO.EliminarPerfilPadreFamilia(padreFamilia);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public PadreFamilia ConsultarPerfilPadreFamilia(int cve_usuario, int cve_persona)
        {
            try
            {
                PadreFamilia  padreFamilia = new PadreFamilia();
                padreFamilia = perfilDAO.ConsultarPerfilPadreFamilia(cve_usuario, cve_persona);
                return padreFamilia;
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