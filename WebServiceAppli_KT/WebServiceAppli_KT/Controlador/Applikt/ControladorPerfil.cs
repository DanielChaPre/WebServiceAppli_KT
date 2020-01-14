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
                return perfilDAO.ModificarPerfil(persona);
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
                
                return perfilDAO.EliminarPerfil(persona);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Persona ConsultarPerfill(string usuario, string contrasenia)
        {
            try
            {
                Persona persona = new Persona();
                persona = perfilDAO.ConsultarPerfilPersona(usuario, contrasenia);
                return persona;
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

                return perfilDAO.ModificarPerfilEmpleado(empleado);
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

                return perfilDAO.EliminarPerfilEmpleado(empleado);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Empleado ConsultarPerfilEmpleado(string usuario, string contrasenia)
        {
            try
            {
                Empleado empleado = new Empleado();
                empleado = perfilDAO.ConsultarPerfilEmpleado(usuario, contrasenia);
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
                return perfilDAO.ModificarPerfilEmpleadoPlantel(empleadoPlantel);
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
                return perfilDAO.EliminarPerfilEmpleadoPlantel(empleadoPlantel);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public EmpleadoPlantel ConsultarPerfilEmpleadoPlantel(string usuario, string contrasenia)
        {
            try
            {
                EmpleadoPlantel empleadoPlantel = new EmpleadoPlantel();
                empleadoPlantel = perfilDAO.ConsultarPerfilEmpleadoPlantel(usuario, contrasenia);
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
                return perfilDAO.ModificarPerfilPadreFamilia(padreFamilia);
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
                return perfilDAO.EliminarPerfilPadreFamilia(padreFamilia);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public PadreFamilia ConsultarPerfilPadreFamilia(string usuario, string contrasenia)
        {
            try
            {
                PadreFamilia  padreFamilia = new PadreFamilia();
                padreFamilia = perfilDAO.ConsultarPerfilPadreFamilia(usuario, contrasenia);
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