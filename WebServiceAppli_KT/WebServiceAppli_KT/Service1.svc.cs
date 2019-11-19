using System;
using System.Collections.Generic;
using WebServiceAppli_KT.Controlador;
using WebServiceAppli_KT.Controlador.Suredsu;
using WebServiceAppli_KT.Modelo;

namespace WebServiceAppli_KT
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        #region controladores
        ControladorLogin loginController;
        ControladorNotificacion notificacionController;
        ControladorEscuelasES escuelaESController;
        ControladorCarreasES carrerasController;
        ControladorPerfil perfilController;
        ControladorGrupoSeguridad grupoSeguridadController;
        ControladorDireccion controladorDireccion;
        #endregion

        #region variables(Objetos)
        Notificaciones entNotificacion;
        Persona entPersona = new Persona();
        Usuario entUsuario = new Usuario();
        List<PlantelesES> lstPlanteles;
        List<CarrerasES> lstCarreras;
        List<Colonias> lst_colonias;
        List<Municipios> lst_municipios;
        List<Estados> lst_estados;
        List<Paises> lst_paises;
        #endregion


        public Notificaciones ConsultarNotificaciones()
        {
            try
            {
                notificacionController = new ControladorNotificacion();
                entNotificacion = new Notificaciones();
                entNotificacion = notificacionController.Consultar();
                return entNotificacion;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Usuario ConsultarPerfilS(string user, string pass)
        {
            try
            {
                perfilController = new ControladorPerfil();
                entUsuario = perfilController.ConsultarPerfill(user,pass);
                return entUsuario;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            
        }

        //public bool CrearCuenta(string usuario, string contrasenia)
        public bool CrearCuenta(Persona persona)
        {
            try
            {
                loginController = new ControladorLogin();
                //if (loginController.CrearCuenta(usuario, contrasenia))
                if (loginController.CrearCuenta(persona))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CrearPerfil(Persona persona)
        {
            try
            {
                perfilController = new ControladorPerfil();
                perfilController.CrearPerfill(persona);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool EliminarPerfil(Persona persona)
        {
            try
            {
                perfilController = new ControladorPerfil();
                perfilController.EliminarPerfill(persona);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

       

        public bool ModificarPerfil(Persona persona)
        {
            try
            {
                perfilController = new ControladorPerfil();
                perfilController.ModificarPerfill(persona);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<CarrerasES> ObtenerCarreras()
        {
            try
            {
                carrerasController = new ControladorCarreasES();
                lstCarreras = new List<CarrerasES>();
                lstCarreras = carrerasController.ObtenerCarreras();
                return lstCarreras;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Colonias> ObtenerColonias()
        {
            try
            {
                controladorDireccion = new ControladorDireccion();
                lst_colonias = new List<Colonias>();
                lst_colonias = controladorDireccion.ConsultarColonia();
                return lst_colonias;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<Estados> ObtenerEstados()
        {
            try
            {
                controladorDireccion = new ControladorDireccion();
                lst_estados = new List<Estados>();
                lst_estados = controladorDireccion.ConsultarEstados();
                return lst_estados;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<string> ObtenerGrupos()
        {
            try
            {
                grupoSeguridadController = new ControladorGrupoSeguridad();
                List<string> lstGrupos = new List<string>();
                lstGrupos = grupoSeguridadController.ConsultarGrupos();
                return lstGrupos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Municipios> ObtenerMunicipios()
        {
            try
            {
                controladorDireccion = new ControladorDireccion();
                lst_municipios = new List<Municipios>();
                lst_municipios = controladorDireccion.ConsultarMunicipios();
                return lst_municipios;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Paises> ObtenerPaises()
        {
            try
            {
                controladorDireccion = new ControladorDireccion();
                lst_paises = new List<Paises>();
                lst_paises = controladorDireccion.ConsultarPaises();
                return lst_paises;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<PlantelesES> ObtenerPlanteles()
        {
            try
            {
                escuelaESController = new ControladorEscuelasES();
                lstPlanteles = new List<PlantelesES>();
                lstPlanteles = escuelaESController.ObtenerPlanteles();
                return lstPlanteles;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ValidarContrasenia(string contrasenia)
        {
            try
            {
                loginController = new ControladorLogin();
                if (loginController.ValidarContrasenia(contrasenia))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool ValidarUsuario(string usuario)
        {
            try
            {
                loginController = new ControladorLogin();
                if (loginController.ValidarUsuario(usuario))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
